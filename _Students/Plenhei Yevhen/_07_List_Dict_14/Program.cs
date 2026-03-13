using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, decimal> shopItems = new Dictionary<string, decimal>()
        {
            {"Яблуко", 10.5m},
            {"Хліб", 25.0m},
            {"Молоко", 30.0m}
        };

        while (true)
        {
            Console.WriteLine("\n--- Крамниця ---");
            Console.WriteLine("1. Показати товари");
            Console.WriteLine("2. Додати товар");
            Console.WriteLine("3. Змінити ціну товару");
            Console.WriteLine("4. Вийти");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowItems(shopItems);
                    break;
                case "2":
                    AddItem(shopItems);
                    break;
                case "3":
                    UpdatePrice(shopItems);
                    break;
                case "4":
                    Console.WriteLine("Вихід з гри...");
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ShowItems(Dictionary<string, decimal> items)
    {
        Console.WriteLine("\nСписок товарів:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key} - {item.Value} грн");
        }
    }

    static void AddItem(Dictionary<string, decimal> items)
    {
        Console.Write("Введіть назву товару: ");
        string name = Console.ReadLine();

        if (items.ContainsKey(name))
        {
            Console.WriteLine("Товар вже існує!");
            return;
        }

        Console.Write("Введіть ціну товару: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            items[name] = price;
            Console.WriteLine($"Товар {name} додано з ціною {price} грн.");
        }
        else
        {
            Console.WriteLine("Некоректна ціна!");
        }
    }

    static void UpdatePrice(Dictionary<string, decimal> items)
    {
        Console.Write("Введіть назву товару для зміни ціни: ");
        string name = Console.ReadLine();

        if (items.ContainsKey(name))
        {
            Console.Write("Введіть нову ціну: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                items[name] = newPrice;
                Console.WriteLine($"Ціна товару {name} змінена на {newPrice} грн.");
            }
            else
            {
                Console.WriteLine("Некоректна ціна!");
            }
        }
        else
        {
            Console.WriteLine("Товар не знайдено.");
        }
    }
}