using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "У кімнаті є меч, щит і зілля. Меч лежить на столі, а щит біля дверей.";

        Dictionary<string, int> items = new Dictionary<string, int>()
        {
            {"меч", 0},
            {"щит", 0},
            {"зілля", 0}
        };

        foreach (var key in new List<string>(items.Keys))
        {
            items[key] = text.ToLower().Split(key).Length - 1;
        }

        foreach (var item in items)
        {
            Console.WriteLine($"Предмет '{item.Key}' зустрічається {item.Value} раз(ів)");
        }
        
        Console.ReadKey();
    }
}