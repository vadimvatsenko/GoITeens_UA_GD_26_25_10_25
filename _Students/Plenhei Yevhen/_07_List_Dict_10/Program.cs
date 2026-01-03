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

        for (int i = 2; i < numberOfArtifacts; i++)
        {
            int nextDistance = distances[i - 1] + distances[i - 2];
            distances.Add(nextDistance);
        }

        Console.WriteLine("Відстані до артефактів:");
        foreach (int distance in distances)
        {
            Console.Write(distance + " ");
        }
        
        Console.ReadKey();
    }
}