// План
// Борги по ДЗ
// Нова тема ООП
// 

// Armor - Name - Strength
// Inventory - List<Armor> AddArmor - RemoveArmor - ShowAllArmors
// Hero - Inventory - current Armor - PutArmorInInventory - RemoveArmorInInventory - PutOnArmorOnHero - RemoveArmorFromHero - AttackCurrentArmor
// HealthComponent - AddHealth - AddHeal
// Heart

// Можна додати позицію по гравцю та об'єктів

namespace Lesson_12_OOP_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Car mustang = new Car("Mustang", "Red", 1989);
            Car lanos = new Car("Lanos", "Golden", 2001);
            Car brabus = new Car("Brabus", "White", 2002);

            List<Car> cars = new List<Car>()
            {
                mustang,
                lanos,
                brabus,
                new Car("Lada7", "Chery", 1977),
                new Car("Lada6", "Blue", 1965),
            };

            Console.WriteLine($"cars before colorize");

            foreach (var car in cars)
            {
                car.PrintCar();
            }

            foreach (Car car in cars)
            {
                if (car.Age <= 1977)
                {
                    car.ChangeColor("White");
                    car.ChangeAge(2026);
                    car.ChangeName("TeslA");

                }
            }

            Console.WriteLine($"cars after colorize");
            foreach (var car in cars)
            {
                car.PrintCar();
            }

            Console.ReadKey();
        }
    }
}