using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's the time?");
        
        string? timeString = Console.ReadLine()?.Trim();
        
        if (timeString == null && !timeString.Contains(':'))
        {
            Console.WriteLine("Not a proper format.");
            return;
        }
        
        Console.WriteLine(timeString?[..timeString.IndexOf(':')]);
        Console.WriteLine(timeString?[(timeString.IndexOf(':') + 1)..]);

        int hours = int.Parse(timeString?[..timeString.IndexOf(':')] ?? string.Empty);

        string message = hours switch
        {
            >= 6 and <= 11 => "Good Morning!",
            >= 12 and <= 17 => "Good Afternoon!",
            >= 18 and <= 22 => "Good Evening!",
            _               => "Good Night!"
        };
        
        Console.WriteLine(message);
        
        /*var hours = int.Parse(trim?[..trim.IndexOf(':')] ?? string.Empty);
        var minutes = int.Parse(trim?[(trim.IndexOf(':') + 1)..] ?? string.Empty);

        if (minutes is < 0 or > 59 || hours < 0 || 24 < hours)
        {
            Console.WriteLine("Not a proper format.");
            return;
        }

        /*if (minutes < 0 || minutes > 59 && hours < 0 || 24 < hours)
        {
            Console.WriteLine("Not a proper format.");
            return;
        }#1#
        
        

        switch (hours)
        {
            case >= 6 and <= 11:
                Console.WriteLine("Good Morning!");
                break;
            case >= 12 and <= 17:
                Console.WriteLine("Good Afternoon!");
                break;
            case >= 18 and <= 22:
                Console.WriteLine("Good Evening!");
                break;
            default:
                Console.WriteLine("Good Night!");
                break;
        }*/
        
        Console.ReadKey();
    }
}