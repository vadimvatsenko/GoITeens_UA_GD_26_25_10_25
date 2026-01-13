using System;

class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        
        /*Console.Write("Введіть поточний час (0–23): ");
        int hour = int.Parse(Console.ReadLine());*/
        
        CheckHours(now.Hour);

        Console.ReadKey();
    }

    private static void CheckHours(int hour)
    {
        if (hour >= 6 && hour <= 11)
        {
            Print("Доброго ранку!");
        }
        else if (hour >= 12 && hour <= 17)
        {
            Print("Доброго дня!");
        }
        else if (hour >= 18 && hour <= 22)
        {
            Print("Доброго вечора!");
        }
        else
        {
            Print("Доброї ночі!");
        }
    }

    private static void Print(string message)
    {
        Console.WriteLine(message);
    }
    
    
}