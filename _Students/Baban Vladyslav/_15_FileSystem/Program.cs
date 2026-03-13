using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;

namespace ConsoleApp10;

public class Program
{
    private static readonly string DirPath = "save data";
    private static readonly string FilePath = Path.Combine(DirPath, "save.json");
    private static readonly List<string> Weapons = new() { "Sword", "Bow", "Axe", "Magic Staff", "Dagger" };

    public static async Task Main(string[] args)
    {
        // Фікс кодування для українських літер
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Directory.CreateDirectory(DirPath);
        if (!File.Exists(FilePath)) await File.WriteAllTextAsync(FilePath, "[]");

        while (true)
        {
            Console.Clear();
            DrawLogo();
            PrintColored("==== MAIN MENU ====\n", ConsoleColor.Cyan);
            Console.WriteLine("[1] Register\n[2] Login\n[0] Exit");

            int choice = GetSafeInt("Enter your choice: ");

            User? user = null;
            switch (choice)
            {
                case 0: return;
                case 1: user = await RegisterUserAsync(); break;
                case 2: user = await LoginUserAsync(); break;
                default: 
                    PrintColored("Invalid choice!", ConsoleColor.Red); 
                    Console.ReadKey(); 
                    break;
            }

            if (user != null) await PlayerMenuAsync(user);
        }
    }

    // ================= UTILS & VISUALS =================

    private static void DrawLogo()
    {
        PrintColored(@"
***************************************
* The CLASS              *
* Ultimate RPG Experience      *
***************************************", ConsoleColor.Magenta);
        Console.WriteLine("\n");
    }

    private static int GetSafeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result)) return result;
            PrintColored("Error: Enter a number!\n", ConsoleColor.Red);
        }
    }

    private static void PrintColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    private static (string Name, ConsoleColor Color) GetTitle(int level)
    {
        if (level >= 5000) return ("Подорожуючий бог", ConsoleColor.Cyan);
        if (level >= 500) return ("Гроза всіх селищ", ConsoleColor.DarkYellow);
        if (level >= 100) return ("Тебе бояться комарі", ConsoleColor.Yellow);
        if (level >= 10) return ("В тебе не плюнуть", ConsoleColor.Green);
        return ("Ніхто", ConsoleColor.Gray);
    }

    private static void DrawHeader(User user)
    {
        var title = GetTitle(user.PlayerData.Level);
        Console.WriteLine(new string('=', 65));
        
        Console.Write($" Player: {user.Name} | Title: ");
        PrintColored($"[{title.Name}]", title.Color);
        
        Console.Write("\n HP: ");
        if (user.PlayerData.Health < 30) Console.ForegroundColor = ConsoleColor.Red;
        else if (user.PlayerData.Health > 70) Console.ForegroundColor = ConsoleColor.Green;
        else Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(user.PlayerData.Health);
        Console.ResetColor();

        Console.Write($" | LVL: {user.PlayerData.Level}");
        Console.Write($" | Weapon: ");
        PrintColored(user.PlayerData.Weapon, ConsoleColor.Cyan);
        Console.WriteLine();
        Console.WriteLine(new string('=', 65));
    }

    // ================= REGISTER & LOGIN =================

    private static async Task<User?> RegisterUserAsync()
    {
        if (!AntiBotCheck()) 
        { 
            PrintColored("\nBot detected! Access denied.", ConsoleColor.Red); 
            Console.ReadKey(); 
            return null; 
        }

        Console.Clear();
        PrintColored("==== REGISTER ====\n", ConsoleColor.Cyan);
        Console.Write("Enter Name: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        List<User> allUsers = await LoadUsersAsync();
        if (allUsers.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            PrintColored("User already exists!", ConsoleColor.Red);
            Console.ReadKey();
            return null;
        }

        Console.Write("Enter Password: ");
        string password = Console.ReadLine()?.Trim() ?? "";

        if (password.Length < 6 || !Regex.IsMatch(password, @"[A-Z]") || !Regex.IsMatch(password, @"\d"))
        {
            PrintColored("Weak password! (6+ chars, 1 Upper, 1 Digit)\n", ConsoleColor.Red);
            Console.ReadKey();
            return null;
        }

        User user = new() { Name = name, Password = password };
        ChooseClass(user);

        allUsers.Add(user);
        await SaveUsersAsync(allUsers);
        return user;
    }

    private static async Task<User?> LoginUserAsync()
    {
        List<User> allUsers = await LoadUsersAsync();
        Console.Clear();
        Console.Write("Enter Name: ");
        string name = Console.ReadLine()?.Trim() ?? "";
        User? user = allUsers.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (user == null) { PrintColored("User not found!\n", ConsoleColor.Red); Console.ReadKey(); return null; }

        Console.Write("Enter Password: ");
        if (Console.ReadLine() == user.Password)
        {
            user.PlayerData.LastLogin = DateTime.Now.ToString("g");
            await UpdateUsersAsync(user);
            return user;
        }
        
        PrintColored("Wrong password!\n", ConsoleColor.Red); Console.ReadKey();
        return null;
    }

    // ================= PLAYER MENU =================

    private static async Task PlayerMenuAsync(User user)
    {
        while (true)
        {
            Console.Clear();
            DrawHeader(user);
            Console.WriteLine("[1] Take Damage | [2] Take Heal | [3] Next Level");
            Console.WriteLine("[4] Choose Weapon | [5] Show Full Stats");
            Console.WriteLine("[6] Bonus Menu | [7] Change Password | [0] Logout");

            int choice = GetSafeInt("\nEnter option: ");
            switch (choice)
            {
                case 0: return;
                case 1: user.PlayerData.Health = Math.Max(0, user.PlayerData.Health - 10); break;
                case 2: user.PlayerData.Health += 10; break;
                case 3: LevelUp(user, 1); break;
                case 4: ChooseWeapon(user); break;
                case 5: ShowStats(user); break;
                case 6: BonusMenu(user); break;
                case 7: await ChangePasswordSafe(user); break;
                default: PrintColored("Invalid option!\n", ConsoleColor.Red); Console.ReadKey(); break;
            }

            await UpdateUsersAsync(user);
        }
    }

    private static void LevelUp(User user, int amount)
    {
        Random rnd = new();
        if (rnd.Next(1, 101) <= 3) 
        {
            user.PlayerData.Level = 1;
            user.PlayerData.Health = 100;
            Console.Clear();
            PrintColored("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n", ConsoleColor.Red);
            PrintColored("ОЙ! Ти спіткнувся об камінь і забув усе на світі!\n", ConsoleColor.Red);
            PrintColored("Твій рівень скинуто до 1!\n", ConsoleColor.Red);
            PrintColored("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", ConsoleColor.Red);
            Console.ReadKey();
            return;
        }

        string oldTitle = GetTitle(user.PlayerData.Level).Name;
        user.PlayerData.Level += amount;

        int hpBonus = user.PlayerData.PlayerClass switch { "Warrior" => 20, "Mage" => 5, _ => 10 };
        user.PlayerData.Health += hpBonus * amount;

        PrintColored($"\n+++ LEVEL UP! (+{amount}) +++\n", ConsoleColor.Yellow);
        
        if (oldTitle != GetTitle(user.PlayerData.Level).Name)
        {
            PrintColored($"ВІТАЄМО! Твій новий титул: {GetTitle(user.PlayerData.Level).Name}!\n", ConsoleColor.Magenta);
        }
        Console.ReadKey();
    }

    private static async Task ChangePasswordSafe(User user)
    {
        Console.Clear();
        PrintColored("==== CHANGE PASSWORD ====\n", ConsoleColor.Cyan);
        Console.Write("Confirm your Name: ");
        if (Console.ReadLine() != user.Name) { PrintColored("Wrong name!", ConsoleColor.Red); Console.ReadKey(); return; }

        Console.Write("Enter OLD Password: ");
        if (Console.ReadLine() != user.Password) { PrintColored("Incorrect old password!", ConsoleColor.Red); Console.ReadKey(); return; }

        Console.Write("Enter NEW Password: ");
        string newPass = Console.ReadLine() ?? "";
        if (newPass.Length >= 6 && Regex.IsMatch(newPass, @"[A-Z]") && Regex.IsMatch(newPass, @"\d"))
        {
            user.Password = newPass;
            PrintColored("Password updated successfully!", ConsoleColor.Green);
        }
        else PrintColored("New password is too weak! (Need 6+ chars, 1 Upper, 1 Digit)", ConsoleColor.Red);
        
        Console.ReadKey();
    }

    private static void BonusMenu(User user)
    {
        Console.Clear();
        PrintColored("==== BONUS MENU ====\n", ConsoleColor.Yellow);
        Console.WriteLine("[1] Quick Heal (+50 HP)\n[2] Secret Riddle (Promo)");
        int choice = GetSafeInt("Choice: ");

        if (choice == 1) { user.PlayerData.Health += 50; PrintColored("Healed!", ConsoleColor.Green); }
        else if (choice == 2)
        {
            PrintColored("\nRIDDLE: ", ConsoleColor.Blue);
            PrintColored("Скільки місяців у році мають 28 днів?\n", ConsoleColor.Blue);
            Console.Write("Your answer: ");
            string code = Console.ReadLine()?.ToLower() ?? "";

            if (code == "усі" || code == "vsi" || code == "all" || code == "всі") LevelUp(user, 10);
            else PrintColored("Wrong! No bonus.\n", ConsoleColor.Red);
        }
        Console.ReadKey();
    }

    private static void ChooseWeapon(User user)
    {
        Console.Clear();
        PrintColored("==== ARMORY ====\n", ConsoleColor.Cyan);
        for (int i = 0; i < Weapons.Count; i++) Console.WriteLine($"[{i + 1}] {Weapons[i]}");
        int w = GetSafeInt("\nSelect weapon: ");
        if (w > 0 && w <= Weapons.Count) user.PlayerData.Weapon = Weapons[w - 1];
    }

    private static void ShowStats(User user)
    {
        Console.Clear();
        DrawHeader(user);
        Console.WriteLine($"Class: {user.PlayerData.PlayerClass}");
        Console.WriteLine($"Range: {user.PlayerData.Range}");
        Console.WriteLine($"Last Login: {user.PlayerData.LastLogin}");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private static void ChooseClass(User user)
    {
        Console.WriteLine("\n[1] Warrior [2] Mage [3] Rogue");
        int c = GetSafeInt("Choose Class: ");
        user.PlayerData.PlayerClass = c switch { 1 => "Warrior", 2 => "Mage", 3 => "Rogue", _ => "Beginner" };
    }

    private static bool AntiBotCheck()
    {
        Console.Clear();
        PrintColored("==== ANTI-BOT CHECK ====\n", ConsoleColor.Yellow);
        
        Console.Write("2 + 2 = ");
        if (Console.ReadLine() != "5") return false;

        Console.Write("Type exactly 'human': ");
        if (Console.ReadLine()?.ToLower() != "human") return false;

        Console.Write("How many legs does a spider... have? ");
        if (Console.ReadLine() != "2") return false;

        return true;
    }

    // ================= FILE SYSTEM =================

    private static async Task<List<User>> LoadUsersAsync()
    {
        try { return JsonSerializer.Deserialize<List<User>>(await File.ReadAllTextAsync(FilePath)) ?? new(); }
        catch { return new(); }
    }

    private static async Task SaveUsersAsync(List<User> users) 
        => await File.WriteAllTextAsync(FilePath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

    private static async Task UpdateUsersAsync(User user)
    {
        var users = await LoadUsersAsync();
        int i = users.FindIndex(u => u.Name == user.Name);
        if (i != -1) { users[i] = user; await SaveUsersAsync(users); }
    }
}

public class PlayerData
{
    public string PlayerClass { get; set; } = "Beginner";
    public int Health { get; set; } = 100;
    public int Level { get; set; } = 1;
    public int Range { get; set; } = 0;
    public string Weapon { get; set; } = "None";
    public string LastLogin { get; set; } = "First time";
}

public class User
{
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
    public PlayerData PlayerData { get; set; } = new();
}