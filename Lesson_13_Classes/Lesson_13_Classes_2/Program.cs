// Плани на сьогодні
// Практикуватися, Писати ігровий цикл, він затронє сьогоднішню тему за насткпнк,
//
// Наслідування таполіморфізм
// ДЗ в ЛМС дедлайн до 22.02.2026


// Завдання 6: Розширення Геймплея
// Розробіть систему інвентаря, де персонаж може зберігати кілька предметів зброї.
// Реалізуйте можливість зміни зброї персонажем під час бою.
// Створіть ігровий цикл, де персонаж має виконати місію, перемігши декілька ворогів за допомогою вибору стратегії та відповідної зброї.

using Lesson_13_Classes_2.Components;
using Lesson_13_Classes_2.Weapons;

namespace Lesson_13_Classes_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Weapon sword = new Sword();
            Weapon shotgun = new Shorgun();
            Weapon bow = new Bow();

            InventoryComponent inventory = new InventoryComponent();
            inventory.AddWeapon(sword);
            inventory.AddWeapon(shotgun);
            inventory.AddWeapon(bow);
            
            inventory.SelectWeaponFromIndex(2);
            
            inventory.ShowWeapons();
            
            Console.WriteLine("-------");
            
            inventory.SelectWeaponFromIndex(0);
            inventory.ShowWeapons();
            

            
            
            /*inventory.NextWeapon();
            inventory.ShowCurrentWeapon();
            inventory.NextWeapon();
            inventory.ShowCurrentWeapon();
            inventory.NextWeapon();
            inventory.ShowCurrentWeapon();
            
            Console.WriteLine("-----------");
            Console.WriteLine(inventory.CurrentWeapon.Name);*/

            /*while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    inventory.NextWeapon();
                    inventory.ShowCurrentWeapon();
                }
            }*/
            
            
            Console.ReadKey();
        }
    }
}
