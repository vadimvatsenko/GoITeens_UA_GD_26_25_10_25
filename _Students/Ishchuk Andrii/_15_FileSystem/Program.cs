using System.Text.Json;

namespace Lesson_15_FileSystem_2
{
    public class Program
    {
        private static readonly string DirPath = "save data";
        private static readonly string FilePath = Path.Combine(DirPath, "save.json");

        private static readonly Dictionary<int, string> MainMenu = new Dictionary<int, string>()
        {
            [0] = "Exit",
            [1] = "Register",
            [2] = "Login"
        };

        private static readonly Dictionary<int, string> GameMenu = new Dictionary<int, string>()
        {
            [0] = "Exit",
            [1] = "Take Damage (-10HP)",
            [2] = "Take Heal (+10HP)",
            [3] = "Next Level (+1 level)",
            [4] = "Add Range",
            [5] = "Add Weapon",
            [6] = "Gain Experience (+20XP)",
            [7] = "Use Mana (-10MP)"
        };

        public static async Task Main(string[] args)
        {
            Directory.CreateDirectory(DirPath);

            if (!File.Exists(FilePath))
            {
                await File.WriteAllTextAsync(FilePath, "[]");
            }

            while (true)
            {
                Console.Clear();
                foreach (var m in MainMenu)
                {
                    Console.WriteLine($"{m.Key}: {m.Value}");
                }

                Console.WriteLine("Enter your choice: ");
                string? choice = Console.ReadLine()?.Trim();

                User? user = null;

                switch (choice)
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
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (user != null)
                {
                    await PlayerMenuAsync(user);
                }
            }
        }

        private static async Task<List<User>> LoadUsersAsync()
        {
            if (!File.Exists(FilePath)) return new List<User>();
            string json = await File.ReadAllTextAsync(FilePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<User>();

            try
            {
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }

        private static async Task SaveUsersAsync(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePath, json);
        }

        private static async Task UpdateUsersAsync(User user)
        {
            List<User> allUsers = await LoadUsersAsync();
            int index = allUsers.FindIndex(u => u.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                allUsers[index] = user;
                await SaveUsersAsync(allUsers);
            }
        }

        private static async Task<User?> RegisterUserAsync()
        {
            List<User> allUsers = await LoadUsersAsync();
            Console.Clear();
            Console.WriteLine($"====Register User====");

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Enter valid Name and Password");
                Console.ReadKey();
                return null;
            }

            User user = new User
            {
                Name = name,
                Password = password,
                PlayerData = new PlayerData { Health = 100, Level = 1, Range = 0, Mana = 50, Experience = 0 }
            };

            allUsers.Add(user);
            await SaveUsersAsync(allUsers);

            Console.WriteLine($"User {user.Name} created.");
            return user;
        }

        private static async Task<User?> LoginUserAsync()
        {
            List<User> allUsers = await LoadUsersAsync();
            Console.Clear();
            Console.WriteLine("====Login====");

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter your Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            User? user = allUsers.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (user == null || user.Password != password)
            {
                Console.WriteLine("Wrong password or name");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine($"User {user.Name} successfully logged in.");
            Console.ReadKey();
            return user;
        }

        private static async Task PlayerMenuAsync(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Hello user {user.Name}");
                Console.WriteLine(
                    $"HP {user.PlayerData.Health} | Level {user.PlayerData.Level} | Range {user.PlayerData.Range} | " +
                    $"XP {user.PlayerData.Experience} | Mana {user.PlayerData.Mana} | Weapons {string.Join(",", user.PlayerData.Weapons)}");
                Console.WriteLine();

                foreach (var m in GameMenu)
                {
                    Console.WriteLine($"{m.Key}: {m.Value}");
                }

                Console.Write("Enter option: ");
                string? option = Console.ReadLine()?.Trim();

                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        user.PlayerData.Health -= 10;
                        break;
                    case "2":
                        user.PlayerData.Health += 10;
                        break;
                    case "3":
                        user.PlayerData.Level++;
                        break;
                    case "4":
                        user.PlayerData.Range += 20;
                        break;
                    case "5":
                        Console.Write("Enter name of weapon: ");
                        string? weap = Console.ReadLine()?.Trim() ?? "";
                        user.PlayerData.AddWeapon(weap);
                        break;
                    case "6":
                        user.PlayerData.Experience += 20;
                        break;
                    case "7":
                        user.PlayerData.Mana -= 10;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        continue;
                }

                await UpdateUsersAsync(user);
            }
        }
    }

    public class PlayerData
    {
        public List<string> Weapons { get; set; } = new List<string>();
        public int Health { get; set; }
        public int Level { get; set; }
        public int Range { get; set; }
        public int Experience { get; set; } = 0;
        public int Mana { get; set; } = 50;

        public void AddWeapon(string weap) => Weapons.Add(weap);
    }

    public class User
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public PlayerData PlayerData { get; set; } = new PlayerData();
    }
}
