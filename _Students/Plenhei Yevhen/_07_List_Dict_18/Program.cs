using System;
using System.Collections.Generic;

class FruitOrchardGame
{
    static void Main()
    {
        Dictionary<string, int> orchard = new Dictionary<string, int>()
        {
            {"Apple", 0},
            {"Orange", 0},
            {"Cherry", 0}
        };

        bool playing = true;

        Console.WriteLine(" Вітаємо у фруктовому саду!");
        while (playing)
        {
            Console.WriteLine("\nВаші дії:");
            Console.WriteLine("1. Посадити фрукти");
            Console.WriteLine("2. Збирати фрукти");
            Console.WriteLine("3. Перевірити сад");
            Console.WriteLine("4. Вийти");

            Console.Write("Виберіть дію (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlantFruits(orchard);
                    break;
                case "2":
                    HarvestFruits(orchard);
                    break;
                case "3":
                    ShowOrchard(orchard);
                    break;
                case "4":
                    playing = false;
                    Console.WriteLine("Дякуємо за гру! ");
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void PlantFruits(Dictionary<string, int> orchard)
    {
        Console.WriteLine("\nЯкі фрукти ви хочете посадити?");
        foreach (var fruit in orchard.Keys)
        {
            Console.WriteLine("- " + fruit);
        }

        string fruitChoice = Console.ReadLine();
        if (orchard.ContainsKey(fruitChoice))
        {
            orchard[fruitChoice] += 1;
            Console.WriteLine($"Ви посадили одне дерево {fruitChoice}.");
        }
        else
        {
            Console.WriteLine("Немає такого виду фрукту.");
        }
    }

    static void HarvestFruits(Dictionary<string, int> orchard)
    {
        Console.WriteLine("\nЯкий фрукт збираємо?");
        string fruitChoice = Console.ReadLine();

        if (orchard.ContainsKey(fruitChoice))
        {
            if (orchard[fruitChoice] > 0)
            {
                Console.WriteLine($"Ви зібрали {orchard[fruitChoice]} {fruitChoice}.");
                orchard[fruitChoice] = 0;
            }
            else
            {
                Console.WriteLine($"На деревах {fruitChoice} ще немає фруктів.");
            }
        }
        else
        {
            Console.WriteLine("Немає такого виду фрукту.");
        }
    }

    static void ShowOrchard(Dictionary<string, int> orchard)
    {
        Console.WriteLine("\nСтан вашого саду:");
        foreach (var kvp in orchard)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} фруктів");
        }
    }
}