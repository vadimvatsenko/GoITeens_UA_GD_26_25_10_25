using System;
using System.Collections.Generic;

// 10 не вірно
class Program
{
    static void Main()
    {
        int numberOfArtifacts = 10; // скільки артефактів
        List<int> distances = new List<int>();

        // Початкові відстані
        distances.Add(1);
        distances.Add(1);

        int sum = 0;
        
        for (int i = 2; i < numberOfArtifacts; i++)
        {
            sum += distances[i - 1] +  distances[i - 2];
            distances.Add(sum);
        }

        Console.WriteLine("Відстані до артефактів:");
        foreach (int distance in distances)
        {
            Console.Write(distance + " ");
        }
        
        Console.ReadKey();
    }
}