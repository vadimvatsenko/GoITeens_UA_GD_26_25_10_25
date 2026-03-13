using System;

class Program
{
    static void Main()
    {
        GreetHero("Артем");

        Console.WriteLine(HealthLoss(15));

        Console.WriteLine(StrongerEnemy(10, 20));

        Console.WriteLine(AverageXP(100, 200, 300));

        Console.WriteLine(HasEnoughMana(50, 30));

        Console.WriteLine(GoldToCrystals(1000, 10));

        Console.WriteLine(GetWinner("Камінь", "Ножиці"));

        Console.WriteLine(CalculateDamage(50, 20, "меч"));

        Item[] items =
        {
            new Item("Меч", 10),
            new Item("Сокира", 15),
            new Item("Посох", 12)
        };

        Item strongest = StrongestItem(items);
        
        Console.WriteLine(strongest.Name);

        Console.WriteLine(CheckPassword("Password1"));
    }

    // 🔹 Рівень 1
    static void GreetHero(string name)
    {
        Console.WriteLine($"Ласкаво просимо в гру, {name}!");
    }

    static int HealthLoss(int enemyPower)
    {
        return enemyPower;
    }

    // 🔹 Рівень 2
    static string StrongerEnemy(int power1, int power2)
    {
        if (power1 > power2) return "Перший ворог сильніший";
        if (power2 > power1) return "Другий ворог сильніший";
        return "Вороги однакові";
    }

    static double AverageXP(int a, int b, int c)
    {
        return (a + b + c) / 3.0;
    }

    // 🔹 Рівень 3
    static bool HasEnoughMana(int mana, int cost)
    {
        return mana >= cost;
    }

    static double GoldToCrystals(int gold, int rate)
    {
        return (double)gold / rate;
    }

    // 🔹 Рівень 4
    static string GetWinner(string p1, string p2)
    {
        if (p1 == p2) return "Нічия";

        if (
            (p1 == "Камінь" && p2 == "Ножиці") ||
            (p1 == "Ножиці" && p2 == "Папір") ||
            (p1 == "Папір" && p2 == "Камінь")
        )
            return "Переміг гравець 1";

        return "Переміг гравець 2";
    }

    static int CalculateDamage(int attack, int defense, string weapon)
    {
        double multiplier = 1;

        if (weapon == "меч") multiplier = 1.2;
        else if (weapon == "лук") multiplier = 1.1;
        else if (weapon == "магія") multiplier = 1.5;

        int damage = (int)(attack * multiplier - defense);
        return damage > 0 ? damage : 0;
    }

    // 🔹 Рівень 5
    static Item StrongestItem(Item[] items)
    {
        Item strongest = items[0];

        foreach (Item item in items)
        {
            if (item.Power > strongest.Power)
                strongest = item;
        }

        return strongest;
    }

    static bool CheckPassword(string password)
    {
        bool hasLength = password.Length >= 8;
        bool hasUpper = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        return hasLength && hasUpper && hasDigit;
    }
}

class Item
{
    public string Name;
    public int Power;

    public Item(string name, int power)
    {
        Name = name;
        Power = power;
    }
}