using System;
using System.Collections.Generic;

// OK
class Program
{
    static void Main()
    {
        int startPortals = 1;   // кількість порталів у першому світі
        int worldsCount = 5;    // кількість світів

        List<int> portalsPerWorld = GeneratePortals(startPortals, worldsCount);

        Console.WriteLine("Кількість порталів у кожному світі:");
        
        for (int i = 0; i < portalsPerWorld.Count; i++)
        {
            Console.WriteLine($"Світ {i + 1}: {portalsPerWorld[i]} порталів");
        }
        
        Console.ReadKey();
    }

    static List<int> GeneratePortals(int start, int worlds)
    {
        List<int> portals = new List<int>();
        int current = start;

        for (int i = 0; i < worlds; i++)
        {
            portals.Add(current);
            current *= 2;
        }

        return portals;
    }
}