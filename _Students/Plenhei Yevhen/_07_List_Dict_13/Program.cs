using System;
using System.Collections.Generic;

class TextAdventure
{
    static void Main()
    {
        Dictionary<string, string> items = new Dictionary<string, string>()
        {
            {"ключ", "кухня"},
            {"меч", "печера"},
            {"ліхтар", "ліс"},
            {"зілля", "аптека"}
        };

        Console.WriteLine("Ласкаво просимо у текстову пригоду!");
        Console.WriteLine("Ваша задача — знайти предмети. Введіть назву предмета, щоб шукати його.");

        while (items.Count > 0)
        {
            Console.WriteLine("\nЯкий предмет ви шукаєте?");
            string input = Console.ReadLine().ToLower();

            if (items.ContainsKey(input))
            {
                Console.WriteLine($"Ви знайшли {input} у {items[input]}!");
                items.Remove(input);
            }
            else
            {
                Console.WriteLine("Цього предмета тут немає або він уже знайдений. Спробуйте ще раз.");
            }

            Console.WriteLine($"Залишилося предметів: {items.Count}");
        }

        Console.WriteLine("Ви знайшли всі предмети! Гра завершена.");
    }
}