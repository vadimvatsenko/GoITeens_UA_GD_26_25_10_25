using System;
using System.Collections.Generic;

// Ok
class Program
{
    static void Main()
    {
        int numberOfIslands = 10; // кількість островів
        List<long> treasuresPerIsland = GenerateFibonacciTreasures(numberOfIslands);

        Console.WriteLine("Кількість скарбів на кожному острові:");
        for (int i = 0; i < treasuresPerIsland.Count; i++)
        {
            Console.WriteLine($"Острів {i + 1}: {treasuresPerIsland[i]} скарбів");
        }
        
        Console.ReadKey();
    }

    static List<long> GenerateFibonacciTreasures(int count)
    {
        List<long> fibonacci = new List<long>();

        if (count <= 0)
            return fibonacci;

        fibonacci.Add(0);
        if (count == 1)
            return fibonacci;

        fibonacci.Add(1);

        for (int i = 2; i < count; i++)
        {
            long next = fibonacci[i - 1] + fibonacci[i - 2];
            fibonacci.Add(next);
        }

        return fibonacci;
    }
}