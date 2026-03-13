using System;
using System.Collections.Generic;
using System.Text;

// Dictionary 1
// проблема з кодуванням відповіді
class Program
{
    static void Main()
    {
        
        Console.OutputEncoding = Encoding.UTF8;   // для виводу
        Console.InputEncoding  = Encoding.UTF8; 
        // Створюємо словник з країнами та столицями
        Dictionary<string, string> countriesAndCapitals = new Dictionary<string, string>()
        {
            { "Україна", "Київ" },
            { "Франція", "Париж" },
            { "Італія", "Рим" },
            { "Німеччина", "Берлін" },
            { "Японія", "Токіо" }
        };

        Console.WriteLine("Гра: Вгадай столицю країни!");
        Console.WriteLine("Щоб вийти, введіть 'exit'.\n");

        Random random = new Random();
        string[] countries = new string[countriesAndCapitals.Count];
        countriesAndCapitals.Keys.CopyTo(countries, 0);

        while (true)
        {
            // Вибираємо випадкову країну
            string randomCountry = countries[random.Next(countries.Length)];
            Console.Write($"Яка столиця країни {randomCountry}? ");

            string answer = Console.ReadLine();

            if (answer.ToLower() == "exit")
            {
                Console.WriteLine("Дякую за гру!");
                break;
            }
            
            
            
            if (answer.Equals(countriesAndCapitals[randomCountry], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Правильно! \n");
            }
            else
            {
                Console.WriteLine($"Неправильно. Правильна відповідь: {countriesAndCapitals[randomCountry]}\n");
            }
        }
    }
}