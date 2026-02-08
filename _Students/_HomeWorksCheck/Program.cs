using System;

public class Unit
{
    public int Health { get; private set; }
    public bool IsImmortal { get; private set; } = false;

    public Unit(int health)
    {
        Health = health;
    }

    public void AddHealth(int health)
    {
        Health += health;
    }

    public void addDamage(int Damage)
    {
        if (this.IsImmortal) return;
        Health -= Damage;
        Console.ReadKey();
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello!");
        {
            Console.WriteLine("***");
        }
        Console.ReadLine();
        Console.WriteLine("Congratulations, you've made it to the Hunger Games.!");

        List<Unit> units = new List<Unit>()
        {
            new Unit(100),
            new Unit(200),
            new Unit(300),
        };
        
        Unit unitminHealth = units[0];
        Console.WriteLine(unitminHealth.Health);
        Console.ReadKey();
        for (int i = 1; i < units.Count; i++)
        {
            if (units[i].Health < unitminHealth.Health)
            {
                unitminHealth = units[i];
            }
        }

        Console.WriteLine(unitminHealth.Health);
        unitminHealth.AddHealth(1000);
        Console.WriteLine(unitminHealth.Health);
        foreach (Unit v in units)
        {
            Console.WriteLine(v.Health);
        }

        {

        }

        static string StrongerEnemy(int enemy1Strength, int enemy2Strength)
        {
            if (enemy1Strength > enemy2Strength)
                return "first monster strength ";
            else if (enemy2Strength > enemy1Strength)
                return "second monster strength ";
            else
                return " monster  the strongest ";
        }


        static double AverageExperience(double player1, double player2, double player3)
        {
            return (player1 + player2 + player3) / 3.0;
        }

        static void Main()
        {

            Console.WriteLine("=== Порівняння ворогів ===");
            Console.WriteLine(StrongerEnemy(120, 90));
            Console.WriteLine(StrongerEnemy(50, 50));

            Console.WriteLine("\n=== Середній досвід гравців ===");
            double avgExp = AverageExperience(1500, 2000, 1800);
            Console.WriteLine($"Середній досвід команди: {avgExp}");
        }
    }
}