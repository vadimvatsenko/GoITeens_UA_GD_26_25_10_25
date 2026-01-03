
using System;
using System.Collections.Generic;

// OK
class Program
{
    static void Main()
    {
        int maxLevel = 10; // максимальний рівень
        List<int> citiesPerLevel = GenerateCitiesPerLevel(maxLevel);

        for (int level = 0; level < citiesPerLevel.Count; level++)
        {
            Console.WriteLine($"Рівень {level}: {citiesPerLevel[level]} міст");
        }
        
        Console.ReadKey();
    }

    static List<int> GenerateCitiesPerLevel(int maxLevel)
    {
        List<int> result = new List<int>();

        for (int level = 0; level <= maxLevel; level++)
        {
            int cities = (int)Math.Pow(2, level);
            result.Add(cities);
        }

        return result;
    }
}