using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfTrees = 6; // кількість дерев
        List<int> crystalsOnTrees = new List<int>();

        for (int i = 0; i < numberOfTrees; i++)
        {
            crystalsOnTrees.Add((int)Math.Pow(4, i));
        }

        Console.WriteLine("Кількість магічних кристалів на кожному дереві:");
        foreach (int crystals in crystalsOnTrees)
        {
            Console.WriteLine(crystals);
        }
        
        Console.ReadKey();
    }
}