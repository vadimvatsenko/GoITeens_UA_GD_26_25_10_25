// Плани на сьогодні
// Практикуватися, Писати ігровий цикл, він затронє сьогоднішню тему за насткпнк, Наслідування таполіморфізм


// Завдання 6: Розширення Геймплея
// Розробіть систему інвентаря, де персонаж може зберігати кілька предметів зброї.
// Реалізуйте можливість зміни зброї персонажем під час бою.
// Створіть ігровий цикл, де персонаж має виконати місію, перемігши декілька ворогів за допомогою вибору стратегії та відповідної зброї.

using Lesson_13_Classes_2.Strategy;

namespace Lesson_13_Classes_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Hero", 100);

            hero.Inventory.AddWeapon(new Sword());
            hero.Inventory.AddWeapon(new Bow());
            hero.Inventory.AddWeapon(new Shotgun());


            var enemies = new List<Enemy>
            {
                new Enemy("Швидкий ворог", 15, 4),
                new Enemy("Броньований ворог", 25, 6),
                new Enemy("Банда слабких", 18, 3)
            };

            Console.WriteLine("=== Mission  ===");
            
            hero.SetStrategy(new AggressiveStrategy());

            foreach (var enemy in enemies)
            {
                Console.WriteLine(
                    $"\n=== Бій з ворогом: {enemy.Name} (HP {enemy.HealthComponent.CurrentHealth}, DMG {enemy.Damage}) ===");

                while (!enemy.IsDead && hero.HealthComponent.CurrentHealth > 0)
                {
                    
                    hero.Inventory.ShowWeapons();
                    Console.WriteLine(
                        "\nДії: [1][2][3] вибір зброї | [Q] стратегія Агресія | [W] Дистанція | [E] Проти броні | [F] атака");
                    Console.Write("Введи команду: ");
                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.D1) hero.SelectWeaponNumber(1);
                    else if (key == ConsoleKey.D2) hero.SelectWeaponNumber(2);
                    else if (key == ConsoleKey.D3) hero.SelectWeaponNumber(2);
                    else if (key == ConsoleKey.Q) hero.SetStrategy(new AggressiveStrategy());
                    else if (key == ConsoleKey.W) hero.SetStrategy(new KeepDistanceStrategy());
                    else if (key == ConsoleKey.E) hero.SetStrategy(new AntiArmorStrategy());
                    else if (key == ConsoleKey.F)
                    {
                        // ход героя (используем стратегию)
                        hero.Act(enemy);

                        // если враг жив — отвечает
                        if (!enemy.IsDead)
                            enemy.Attack(hero);
                    }

                    if (enemy.IsDead)
                        Console.WriteLine($"✅ {enemy.Name} переможений!");
                }

                if (hero.HealthComponent.CurrentHealth <= 0)
                {
                    Console.WriteLine("💀 Герой програв місію...");
                    return;
                }
            }

            Console.WriteLine("\n🏁 Місія виконана! Всі вороги переможені!");
            
            Console.ReadKey();
        }
    }
}
