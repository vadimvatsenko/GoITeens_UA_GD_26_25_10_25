using System.Text.Json;

class Program
{
    static readonly string DirPath  = "data";
    static readonly string FilePath = Path.Combine(DirPath, "users.json");

    static async Task Main()
    {
        Directory.CreateDirectory(DirPath); // створюємо директорію

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Register");
            Console.WriteLine("2) Login");
            Console.Write("Choose: ");

            string? choice = Console.ReadLine();
            UserRecord? user = null;
            
            switch (choice)
            {
                case "0":
                    return;
                case "1":
                    // тут буде виклик реестрації
                    user = await RegisterAsync();
                    break;
                case "2":
                    // тут буде виклик логінізації
                    user = await LoginAsync();
                    break;
            }
            
            if (user != null)
                // виклик ігрового меню
                await PlayerMenuAsync(user);
        }
    }

    // ======== MENUS ========

    static async Task PlayerMenuAsync(UserRecord user)
    {
        Dictionary<int, string> _menu = new Dictionary<int, string>()
        {
            [0] = "Logout",
            [1] = "Take damage (-10 HP)",
            [2] = "Take heal (+10 HP)",
            [3] = "Next Level",
        };
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Logged in as: {user.Username}");
            Console.WriteLine($"HP: {user.Player.Health} | Level: {user.Player.Level}");
            Console.WriteLine();

            foreach (var m in _menu)
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }
            
            Console.Write("Choose: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                case "1":
                    user.Player.Health = Math.Max(0, user.Player.Health - 10);
                    break;
                case "2":
                    user.Player.Health = Math.Min(100, user.Player.Health + 10);
                    break;
                case "3":
                    user.Player.Level += 1;
                    break;
            }
            
            await UpdateUserAsync(user); // зберігаємо зміни кожен раз 
        }
    }

    // ======== AUTH ========

    // метод реестрації юзера
    static async Task<UserRecord?> RegisterAsync()
    {
        var users = await LoadUsersAsync();

        Console.Clear();
        Console.WriteLine("=== Register ===");
        Console.Write("Username: ");
        string username = (Console.ReadLine() ?? "").Trim();

        Console.Write("Password: ");
        string password = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Username/password can't be empty.");
            Console.ReadKey();
            return null;
        }

        if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("This username is already taken.");
            Console.ReadKey();
            return null;
        }

        var newUser = new UserRecord
        {
            Username = username,
            Password = password,
            Player = new PlayerData { Health = 100, Level = 1 }
        };

        users.Add(newUser);
        await SaveUsersAsync(users);

        Console.WriteLine("Registered successfully!");
        Console.ReadKey();
        return newUser;
    }

    static async Task<UserRecord?> LoginAsync()
    {
        var users = await LoadUsersAsync();

        Console.Clear();
        Console.WriteLine("=== Login ===");
        Console.Write("Username: ");
        string username = (Console.ReadLine() ?? "").Trim();

        Console.Write("Password: ");
        string password = (Console.ReadLine() ?? "").Trim();

        var user = users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

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

    // ======== STORAGE ========

    
    // отримати список гравців з json файлу // ++
    static async Task<List<UserRecord>> LoadUsersAsync()
    {
        try
        {
            if (!File.Exists(FilePath))
                return new List<UserRecord>();

            string json = await File.ReadAllTextAsync(FilePath);
        
            if (string.IsNullOrWhiteSpace(json))
                return new List<UserRecord>();

            return JsonSerializer.Deserialize<List<UserRecord>>(json) ?? new List<UserRecord>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    // оновити гравця
    static async Task UpdateUserAsync(UserRecord updatedUser)
    {
        var users = await LoadUsersAsync();
        int index = users.FindIndex(u =>
            u.Username.Equals(updatedUser.Username, StringComparison.OrdinalIgnoreCase));

        if (index >= 0)
        {
            users[index] = updatedUser;
            await SaveUsersAsync(users);
        }
    }
    
    // зберігти гравця new JsonSerializerOptions { WriteIndented = true } — настройка “красивого JSON”:
    static async Task SaveUsersAsync(List<UserRecord> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(FilePath, json);
    }
}

// ======== MODELS ========

public class PlayerData
{
    public int Health { get; set; }
    public int Level { get; set; }
}

public class UserRecord
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = ""; // для учебного примера ок
    public PlayerData Player { get; set; } = new PlayerData();
}