using System;

class Program
{
    static void Main(string[] args)
    {
        int hour;
        while (true)
        {
            
            Console.Write("Введіть поточний час (0-23): ");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Введення пусте. Спробуйте ще раз.");
                continue;
            }
            
            if (!int.TryParse(input.Trim(), out hour))
            {
                Console.WriteLine("Потрібно ввести ціле число. Спробуйте ще раз.");
                continue;
            }
            
            if (hour < 0 || hour > 23)
            {
                Console.WriteLine("Час повинен бути в діапазоні 0–23. Спробуйте ще раз.");
                continue;
            }
            
            break;
        }

        if (hour >= 6 && hour <= 11)
        {
            Console.WriteLine("Доброго ранку!");
        }
        else if (hour >= 12 && hour <= 17) ;
    }
}