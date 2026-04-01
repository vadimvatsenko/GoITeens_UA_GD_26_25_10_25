// ДЗ: додати ще поля для збереження і перевірити на практиці (дедлайн до 08.03.2026)
// Наступна тема: дебагінг та аналіз коду.

// Підключаємо бібліотеку для роботи з JSON (серіалізація/десеріалізація)
using System.Text.Json;

// Оголошуємо простір імен (щоб класи групувалися в одній “папці” проєкту)
namespace Lesson_15_FileSystem_2;

// Оголошуємо клас Program — це головний клас консольного застосунку
public class Program
{
    // Шлях до папки, де будемо зберігати дані (файли збережень)
    private static readonly string DirPath = "save data";

    // Повний шлях до файлу save.json всередині папки DirPath
    // Path.Combine правильно “склеює” частини шляху під Windows/macOS/Linux /save data/save.json
    private static readonly string FilePath = Path.Combine(DirPath, "save.json");

    // Словник головного меню: ключ (int) -> текст пункту меню (string)
    private static readonly Dictionary<int, string> MainMenu = new Dictionary<int, string>()
    {
        [0] = "Exit",      // 0 — вихід
        [1] = "Register",  // 1 — реєстрація
        [2] = "Login"      // 2 — логін
    };

    // Словник ігрового меню: дії з гравцем
    private static readonly Dictionary<int, string> GameMenu = new Dictionary<int, string>()
    {
        [0] = "Exit",               // 0 — вихід з меню гравця
        [1] = "Take Damage (-10HP)",// 1 — відняти здоров’я
        [2] = "Take Heal (+10HP)",  // 2 — додати здоров’я
        [3] = "Next Level (+1 level)", // 3 — підвищити рівень
        [4] = "Add Range",          // 4 — додати дальність/радіус
        [5] = "Add Weapon",         // 5 — додати зброю в список
        [6] = "Add Stamina"
    };

    // Головний метод програми. async означає, що всередині можна використовувати await
    // Task — це “обіцянка” завершення роботи методу в майбутньому
    public static async Task Main(string[] args)
    {
        // Створюємо папку DirPath, якщо її ще немає
        Directory.CreateDirectory(DirPath);

        // Якщо файлу збереження ще немає — створимо його
        if (!File.Exists(FilePath))
        {
            // Записуємо "[]" — порожній JSON-масив (тобто порожній список користувачів)
            await File.WriteAllTextAsync(FilePath, "[]");
        }

        // Нескінченний цикл головного меню (працює, поки не вийдемо з програми)
        while (true)
        {
            // Очищаємо консоль для “чистого” меню
            Console.Clear();

            // Виводимо всі пункти головного меню
            foreach (var m in MainMenu)
            {
                // m.Key — число (0/1/2), m.Value — текст пункту
                Console.WriteLine($"{m.Key}: {m.Value}");
            }

            // Просимо користувача ввести вибір
            Console.WriteLine("Enter your choice: ");

            // Зчитуємо введення. ReadLine може повернути null, тому тип string?
            // Trim прибирає пробіли з початку/кінця
            string? choice = Console.ReadLine().Trim();

            // Змінна для поточного користувача (може бути null, якщо не залогінилися)
            User? user = null;

            // Обробляємо вибір меню
            switch (choice)
            {
                case "0":
                    // Вихід з програми (завершує Main)
                    return;

                case "1":
                    // Реєструємо нового користувача і отримуємо об'єкт User (або null якщо помилка)
                    user = await RegisterUserAsync();
                    break;

                case "2":
                    // Логінимося і отримуємо User (або null якщо невірні дані)
                    user = await LoginUserAsync();
                    break;

                default:
                    // Якщо введено щось інше — повідомляємо
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            // Якщо користувач успішно отриманий (зареєстрований або залогінений)
            if (user != null)
            {
                // Переходимо в меню гравця
                await PlayerMenuAsync(user);
            }
        }
    }

    // Метод для завантаження списку користувачів з JSON-файлу
    private static async Task<List<User>> LoadUsersAsync()
    {
        // Якщо файлу немає — повертаємо порожній список, щоб програма не падала
        if (!File.Exists(FilePath)) return new List<User>();

        // Читаємо весь текст JSON з файлу
        string json = await File.ReadAllTextAsync(FilePath);

        // Якщо текст порожній/з пробілами — теж повертаємо порожній список
        if (string.IsNullOrWhiteSpace(json)) return new List<User>();

        try
        {
            // Десеріалізуємо JSON у List<User>
            // Якщо Deserialize повернув null — повертаємо порожній список
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch (Exception e)
        {
            // Якщо JSON зламався або формат неправильний — не падаємо, просто повертаємо порожній список
            // Console.WriteLine(e.Message); // можна включити для дебагу
            return new List<User>();
        }
    }

    // Метод для збереження всіх користувачів у JSON-файл
    private static async Task SaveUsersAsync(List<User> users)
    {
        // Перетворюємо список users у JSON-рядок
        // WriteIndented = true робить JSON “красивим” з відступами
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

        // Записуємо JSON у файл (перезаписуємо повністю)
        await File.WriteAllTextAsync(FilePath, json);
    }

    // Метод для оновлення конкретного користувача у файлі (наприклад, після зміни HP/Level/Weapons)
    private static async Task UpdateUsersAsync(User users)
    {
        // Завантажуємо всіх користувачів з файлу
        List<User> allUser = await LoadUsersAsync();

        // Шукаємо індекс користувача в списку за ім'ям (без врахування регістру)
        int index = allUser.FindIndex(u => u.Name.Equals(users.Name, StringComparison.OrdinalIgnoreCase));

        // Якщо користувач знайдений
        if (index != -1)
        {
            // Замінюємо старий запис користувача на оновлений
            allUser[index] = users;

            // Зберігаємо список назад у файл
            await SaveUsersAsync(allUser);
        }
    }

    // Реєстрація нового користувача
    private static async Task<User?> RegisterUserAsync()
    {
        // Завантажуємо всіх користувачів, щоб додати нового
        List<User> allUser = await LoadUsersAsync();

        // Очищаємо екран
        Console.Clear();

        // Заголовок
        Console.WriteLine($"====Register User====");

        // Запитуємо ім'я
        Console.Write("Enter your Name: ");
        string name = Console.ReadLine().Trim();

        // Запитуємо пароль
        Console.Write("Enter your Password: ");
        string password = Console.ReadLine().Trim();

        // Перевірка: якщо ім'я або пароль порожні — реєстрацію не робимо
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Enter valid Name and Password");
            Console.ReadKey(); // чекаємо натискання клавіші, щоб учень встиг прочитати
            return null;        // повертаємо null — означає “неуспішно”
        }

        // Створюємо нового користувача
        User user = new User
        {
            Name = name,               // записуємо ім'я
            Password = password,       // записуємо пароль
            PlayerData = new PlayerData { Health = 100, Level = 1, Range = 0 } // стартові дані гравця
        };

        // Додаємо користувача у список
        allUser.Add(user);

        // Зберігаємо список у файл
        await SaveUsersAsync(allUser);

        // Повідомлення про успіх
        Console.WriteLine($"User {user.Name} created.");

        // Повертаємо створеного користувача
        return user;
    }

    // Логін користувача
    private static async Task<User?> LoginUserAsync()
    {
        // Завантажуємо всіх користувачів
        List<User> allUser = await LoadUsersAsync();

        // Очищаємо екран
        Console.Clear();

        // Заголовок
        Console.WriteLine("====Login====");

        // Вводимо ім'я
        Console.Write("Enter your Name: ");
        string name = Console.ReadLine().Trim();

        // Вводимо пароль
        Console.Write("Enter your Password: ");
        string password = Console.ReadLine().Trim();

        // Шукаємо користувача по імені (перший, який підходить)
        User user = allUser.FirstOrDefault(u => u.Name.Equals(name));

        // Якщо користувача не знайдено або пароль не співпав — логін невдалий
        if (user == null || user.Password != password)
        {
            Console.WriteLine("Wrong password or name");
            Console.ReadKey();
            return null;
        }

        // Якщо все добре — повідомляємо про успіх
        Console.WriteLine($"User {user.Name} successfully logged in.");
        Console.ReadKey();

        // Повертаємо знайденого користувача
        return user;
    }

    // Меню гравця (зміна HP/Level/Range/Weapons)
    private static async Task PlayerMenuAsync(User user)
    {
        // Нескінченний цикл, поки не натиснуть Exit
        while (true)
        {
            // Очищення екрану
            Console.Clear();

            // Вітання
            Console.WriteLine($"Hello user {user.Name}");

            // Показуємо поточні дані гравця
            Console.Write($"HP {user.PlayerData.Health} " +
                              $"| Level {user.PlayerData.Level} " +
                              $"| Range {user.PlayerData.Range} " +
                              $"|Stamina {user.PlayerData.Stamina} ");
            Console.Write("| All Weapons: ");
            user.PlayerData.Weapons.ForEach(w => Console.Write($"{w}, "));
            
            Console.WriteLine();

            // Виводимо всі пункти ігрового меню
            foreach (var m in GameMenu)
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }

            // Запитуємо опцію
            Console.Write("Enter option: ");
            string? option = Console.ReadLine().Trim();

            // Обробляємо дію
            switch (option)
            {
                case "0":
                    // Вихід з меню гравця і повернення у головне меню
                    return;

                case "1":
                    // Отримати урон: мінус 10 HP
                    user.PlayerData.Health -= 10;
                    break;

                case "2":
                    // Лікування: плюс 10 HP
                    user.PlayerData.Health += 10;
                    break;

                case "3":
                    // Підняти рівень на 1
                    user.PlayerData.Level++;
                    break;

                case "4":
                    // Додати дальність (range) на 20
                    user.PlayerData.Range += 20;
                    break;

                case "5":
                    // Додати зброю у список
                    Console.Write("Enter name of weapon :");
                    string? name = Console.ReadLine().Trim(); // читаємо назву зброї
                    user.PlayerData.AddWeapon(name);          // додаємо в список
                    break;
                
                case "6":
                    // Додати стаміну
                    user.PlayerData.Stamina += 30;
                    break;
                default:
                    // Якщо команда неправильна — повідомляємо і повертаємось на початок циклу
                    Console.WriteLine("Invalid option.");
                    continue;
            }

            // Після будь-якої зміни — зберігаємо оновлені дані користувача у файл
            await UpdateUsersAsync(user);
        }
    }
}

// Клас даних гравця (те, що “прив’язано” до користувача)
public class PlayerData
{
    // Список зброї. public властивість, щоб JSON міг зберігати/читати
    public List<string> Weapons { get; set; } = new List<string>();

    // Поточне здоров'я
    public int Health { get; set; }

    // Поточний рівень
    public int Level { get; set; }

    // Дальність/радіус
    public int Range { get; set; }
    
    public int Stamina { get; set; }

    // Метод для додавання зброї до списку
    public void AddWeapon(string weap)
    {
        // Додаємо назву зброї у список
        Weapons.Add(weap);
    }
}

// Клас користувача (логін/пароль + дані гравця)
public class User
{
    // Ім'я користувача
    public string Name { get; set; } = "";

    // Пароль користувача
    public string Password { get; set; } = "";

    // Дані гравця (HP/Level/Range/Weapons)
    public PlayerData PlayerData { get; set; } = new PlayerData();
}