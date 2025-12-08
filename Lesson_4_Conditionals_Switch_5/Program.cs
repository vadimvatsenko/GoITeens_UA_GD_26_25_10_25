using System;
using System.Globalization;
using System.Text;

// Switch pattern and TimeValidation
class Program
{
    static void Main(string[] args)
    {
        string input;
        bool isValidTime = false;
        string format = "hh\\:mm";
        
        do
        {
            Console.WriteLine("What's the time? Format hh:mm ");
            input = Console.ReadLine()?.Trim();
            
            isValidTime = TimeSpan.TryParseExact(input, format, CultureInfo.CurrentCulture, out _);

            if (!isValidTime)
            {
                Console.WriteLine("Invalid time");
                Console.WriteLine("Try again.");
            }
        } while (!isValidTime);
        
        string[] times = input.Split(':');
        int hours = int.Parse(times[0]);
        int minutes = int.Parse(times[1]);

        if (minutes >= 30)
            hours++;
        
        string message = hours switch
        {
            >= 6  and <= 11 => "Good Morning!",
            >= 12 and <= 17 => "Good Afternoon!",
            >= 18 and <= 22 => "Good Evening!",
            _               => "Good Night!"
        };

        Console.WriteLine(message);
        
        Console.ReadKey();
    }
}