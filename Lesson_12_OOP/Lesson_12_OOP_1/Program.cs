// Заняття 1,5 години
// Плани на сьогодні, рефакторинг на методи, що ми не доробили учора
// Та нова тема ООП

// OOP
// Абстракція, Інкапсуляція, Поліморфізм, Наслідування
// абстрактний класс Animal
// конструктор Animal, поля(не абстрактні), абстракні методи
// класи Cat, Dog, Mouse
// що є спільне у Cat, Dog, Mouse?

// інтерфейс IWalkable

// переписати abstract Walk, добавити інтерфейс в Animal, зродити Walk virtual

// створити додатковий клас, який немає відношення до Animal
// колекція тварин та інших сущностей рухатися.

// клас Hero
// HealthComponent, метод TakeDamage та Heal
// IHealthComponent реалізує Поле HealthComponent

// public, private, protected, internal

namespace Lesson_12_OOP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal cat =  new Cat("Tom", 12);
            Animal dog = new Dog("Spike", 12);
            Animal mouse = new Mouse("Jerry", 12);
            
            Hero hero = new Hero("BillyBoy");
            
            List<Cat> cats = new List<Cat>()
            {
                new Cat("Tom", 12),
            };
            
            List<Animal> allAnimals = new List<Animal>()
            {
                cat, dog, mouse
            };

            List<IHealthable> allUnits = new List<IHealthable>()
            {
                cat, dog, mouse, hero
            };

            Random random = new Random();
            
            foreach (IHealthable unit in allUnits)
            {
                unit.HealthComponent.TakeDamage(random.Next(0, 101));
            }
            
            foreach (IHealthable unit in allUnits)
            {
                Console.WriteLine($"Health of {unit.Name} is {unit.HealthComponent.Health}");
            }
            
            foreach (IHealthable unit in allUnits)
            {
                unit.HealthComponent.Heal(random.Next(0, 101));
            }

            // Hero => HealthComponent => TaleDamage
            foreach (IHealthable unit in allUnits)
            {
                Console.WriteLine($"Health of {unit.Name} is {unit.HealthComponent.Health}");
            }
            
            Console.ReadKey();
        }
    }
}