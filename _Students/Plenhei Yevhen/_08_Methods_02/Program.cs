namespace _08_Methods_02;

internal class GameFunctions
{

    // 1. Функція-привітання гравця
    static void GreetPlayer(string heroName)
    {
        Console.WriteLine($"Ласкаво просимо в гру, {heroName}!");
    }

    // 2. Функція здоров’я
    static int HealthLoss(int enemyAttackPower)
    {
        return enemyAttackPower;
    }


    // 1. Функція вибору сильнішого ворога
    static string StrongerEnemy(int enemy1Power, int enemy2Power)
    {
        if (enemy1Power > enemy2Power)
            return "Перший ворог сильніший";
        else if (enemy2Power > enemy1Power)
            return "Другий ворог сильніший";
        else
            return "Вороги однакової сили";
    }

    // 2. Середній досвід гравців
    static double AverageExperience(int exp1, int exp2, int exp3)
    {
        return (exp1 + exp2 + exp3) / 3.0;
    }


    // 1. Перевірка "чи вистачить манни"
    static bool HasEnoughMana(int mana, int spellCost)
    {
        return mana >= spellCost;
    }

    // 2. Конвертер золота в кристали
    static double GoldToCrystals(int gold, double exchangeRate)
    {
        return gold * exchangeRate;
    }

    //  Точка входу
    static void Main()
    {
        GreetPlayer("Артур");

        Console.WriteLine("Втрачено здоров'я: " + HealthLoss(15));

        Console.WriteLine(StrongerEnemy(20, 30));

        Console.WriteLine("Середній досвід: " + AverageExperience(100, 150, 200));

        Console.WriteLine("Чи вистачить манни: " + HasEnoughMana(50, 40));

        Console.WriteLine("Кристали: " + GoldToCrystals(100, 0.5));
    }
}