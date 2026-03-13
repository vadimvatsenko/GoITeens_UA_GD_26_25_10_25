using System;

class Program
{
    private static Dictionary<int, string> games = new Dictionary<int, string>()
    {
        [1] = "Камінь-Ножиці-Папір",
        [2] = "Калькулятор пошкоджень",
        [0] = "Вихід",
    };
    
    private static Dictionary<int, string> rockPaperScissorsnew =  new Dictionary<int, string>()
    {
        [1] = "Папір",
        [2] = "Ножиці",
        [0] = "Камінь",
    };
    
    
    
    static void Main()
    {
        while (true)
        {
            
            Console.WriteLine("Оберіть опцію:");
            foreach (var g in games)
            {
                Console.WriteLine(g.Key + ": " + g.Value);
            }

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Гравець 1 (Камінь/Ножиці/Папір): ");
                string p1 = Console.ReadLine();

                Console.Write("Гравець 2 (Камінь/Ножиці/Папір): ");
                string p2 = Console.ReadLine();

                Console.WriteLine(GetWinner(p1, p2));
            }
            else if (choice == "2")
            {
                Console.Write("Сила атаки: ");
                int attack = int.Parse(Console.ReadLine());

                Console.Write("Сила захисту: ");
                int defense = int.Parse(Console.ReadLine());

                Console.Write("Тип зброї (меч/лук/магія): ");
                string weapon = Console.ReadLine();

                int damage = CalculateDamage(attack, defense, weapon);
                Console.WriteLine($"Завдано пошкоджень: {damage}");
            }
            else if (choice == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Невірний вибір!");
            }

            Console.WriteLine();
        }
    }

    static string GetWinner(string player1, string player2)
    {
        if (player1 == player2)
            return "Нічия";

        if (
            (player1 == "Камінь" && player2 == "Ножиці") ||
            (player1 == "Ножиці" && player2 == "Папір") ||
            (player1 == "Папір" && player2 == "Камінь")
        )
        {
            return "Переміг гравець 1";
        }
        else
        {
            return "Переміг гравець 2";
        }
    }

    static int CalculateDamage(int attack, int defense, string weapon)
    {
        double multiplier = 1.0;

        switch (weapon.ToLower())
        {
            case "меч":
                multiplier = 1.2;
                break;
            case "лук":
                multiplier = 1.0;
                break;
            case "магія":
                multiplier = 1.5;
                break;
        }

        int damage = (int)((attack - defense) * multiplier);
        return damage > 0 ? damage : 0;
    }
}