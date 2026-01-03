using System;
using System.Collections.Generic;

// 04-List
// Якщо ти робиш парсинг, то непогано було б зробити перевірку на число
// Console.ReadKey(); не вистачає.
class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість планет: ");
        int numberOfPlanets = int.Parse(Console.ReadLine());

        Console.Write("Введіть відстань до першої планети: ");
        double firstDistance = double.Parse(Console.ReadLine());

        List<double> distances = new List<double>();

        double currentDistance = firstDistance;

        for (int i = 0; i < numberOfPlanets; i++)
        {
            distances.Add(currentDistance);
            currentDistance *= 2;
        }

        Console.WriteLine("Відстані до планет:");
        foreach (double distance in distances)
        {
            Console.WriteLine(distance);
        }
        
        Console.ReadKey();
    }
}