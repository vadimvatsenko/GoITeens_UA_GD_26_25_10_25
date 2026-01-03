using System;
using System.Collections.Generic;

class TimeTravel
{
    static void Main()
    {
        Console.Write("Введіть початковий рік: ");
        int startYear = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість подорожей: ");
        int steps = int.Parse(Console.ReadLine());

        List<int> visitedYears = new List<int>();

        int currentYear = startYear;
        int jump = 1;

        for (int i = 0; i < steps; i++)
        {
            currentYear -= jump;
            visitedYears.Add(currentYear);
            jump *= 2;
        }

        Console.WriteLine("\nРоки, які відвідав гравець:");
        foreach (int year in visitedYears)
        {
            Console.WriteLine(year);
        }
        
        Console.ReadKey();
    }
}