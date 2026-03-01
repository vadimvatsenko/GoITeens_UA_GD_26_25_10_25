// модель героя PlayerData

// модель гравця User

// завантаження з файлу юзерів 
// private static async Task<List<User>> LoadUserAsync()

// збереження юзерів
// private static async Task SaveUserAsync(User user)

// оновити юзера
// private static async Task UpdateUserAsync(User user)

// логінізація юзера
// private static async Task<UserRecord?> RegisterUserAsync()

// меню гри
// private static async Task PlayerMenuAsync(User user)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson_15_FileSystem_2;

public class Program
{
    private static readonly string DirPath = "save data";
    private static readonly string FilePath = Path.Combine(DirPath, "save.json");

    private static readonly Dictionary<int, string> MainMenu = new()
    {
        [0] = "Exit",
        [1] = "Register",
        [2] = "Login",
    };

    private static readonly Dictionary<int, string> GameMenu = new()
    {
        [0] = "Exit",
        [1] = "Take damage (-10HP)",
        [2] = "Take Heal (+10HP)",
        [3] = "Level Up (+1 level)",
    };

    public static async Task Main(string[] args)
    {
        // 1) Підготовка папки + файлу
        Directory.CreateDirectory(DirPath);

        // ВАЖЛИВО: не перезатираємо файл кожен запуск!
        if (!File.Exists(FilePath))
            await File.WriteAllTextAsync(FilePath, "[]");

        while (true)
        {
            Console.Clear();

            foreach (var m in MainMenu)
                Console.WriteLine($"{m.Key}: {m.Value}");

            Console.Write("Choose an option: ");
            string option = (Console.ReadLine() ?? "").Trim();

            User? user = null;

            switch (option)
            {
                case "0":
                    return;

                case "1":
                    user = await RegisterUserAsync();
                    break;

                case "2":
                    user = await LoginUserAsync();
                    break;

                default:
                    Console.WriteLine("Unknown option.");
                    Console.ReadKey();
                    break;
            }

            if (user != null)
                await PlayerMenuAsync(user);
        }
    }

    // ===================== FILE HELPERS =====================

    private static async Task<List<User>> LoadUsersAsync()
    {
        if (!File.Exists(FilePath))
            return new List<User>();

        string json = await File.ReadAllTextAsync(FilePath);

        if (string.IsNullOrWhiteSpace(json))
            return new List<User>();

        try
        {
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch (JsonException)
        {
            // якщо файл зламався/неправильний формат — не падаємо
            return new List<User>();
        }
    }

    private static async Task SaveUsersAsync(List<User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(FilePath, json);
    }

    private static async Task UpdateUserAsync(User user)
    {
        List<User> users = await LoadUsersAsync();

        int index = users.FindIndex(u =>
            u.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
        {
            users[index] = user;
            await SaveUsersAsync(users);
        }
    }

    // ===================== AUTH =====================

    private static async Task<User?> RegisterUserAsync()
    {
        List<User> users = await LoadUsersAsync();

        Console.Clear();
        Console.WriteLine("=== Register New User ===");

        Console.Write("Enter your name: ");
        string name = (Console.ReadLine() ?? "").Trim();

        Console.Write("Enter your password: ");
        string password = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Invalid name or password.");
            Console.ReadKey();
            return null;
        }

        bool exists = users.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            Console.WriteLine("This name already exists.");
            Console.ReadKey();
            return null;
        }

        var user = new User
        {
            Name = name,
            Password = password,
            PlayerData = new PlayerData { Health = 100, Level = 1 }
        };

        users.Add(user);
        await SaveUsersAsync(users);

        Console.WriteLine($"User '{user.Name}' created!");
        Console.ReadKey();
        return user;
    }

    private static async Task<User?> LoginUserAsync()
    {
        List<User> users = await LoadUsersAsync();

        Console.Clear();
        Console.WriteLine("=== Login ===");

        Console.Write("Enter your name: ");
        string name = (Console.ReadLine() ?? "").Trim();

        Console.Write("Enter your password: ");
        string password = (Console.ReadLine() ?? "").Trim();

        var user = users.FirstOrDefault(u =>
            u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (user == null || user.Password != password)
        {
            Console.WriteLine("Wrong username or password.");
            Console.ReadKey();
            return null;
        }

        Console.WriteLine("Login success!");
        Console.ReadKey();
        return user;
    }

    // ===================== GAME MENU =====================

    private static async Task PlayerMenuAsync(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Logged in as: {user.Name}");
            Console.WriteLine($"HP: {user.PlayerData.Health} | Level: {user.PlayerData.Level}");
            Console.WriteLine();

            foreach (var m in GameMenu)
                Console.WriteLine($"{m.Key}: {m.Value}");

            Console.Write("Enter menu option: ");
            string option = (Console.ReadLine() ?? "").Trim();

            switch (option)
            {
                case "0":
                    return;

                case "1":
                    user.PlayerData.Health = Math.Max(0, user.PlayerData.Health - 10);
                    break;

                case "2":
                    user.PlayerData.Health = Math.Min(100, user.PlayerData.Health + 10);
                    break;

                case "3":
                    user.PlayerData.Level += 1;
                    break;

                default:
                    Console.WriteLine("Unknown option.");
                    Console.ReadKey();
                    continue;
            }

            // Після будь-якої дії — зберігаємо оновлення
            await UpdateUserAsync(user);
        }
    }
}

// ===================== MODELS =====================


public class PlayerData
{
    public int Health { get; set; }
    public int Level { get; set; }
}

public class User
{
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
    public PlayerData PlayerData { get; set; } = new PlayerData();
}