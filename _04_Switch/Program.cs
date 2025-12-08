using System.Globalization;

namespace _04_Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // тут Encoding не потрібен, ми не використовуємо укр мову
            /*Console.OutputEncoding = Encoding.UTF8;   
            Console.InputEncoding  = Encoding.UTF8;*/

            const string VALIDATION_FORMAT = "hh\\:mm";
            bool isValidTime = false;
            string input = string.Empty;

            do
            {
                Console.WriteLine("What's the time?");
                input = Console.ReadLine()?.Trim();
                
                // валідація часу
                isValidTime = TimeSpan.TryParseExact(
                    input,
                    VALIDATION_FORMAT,  // формат 
                    null,  
                    out _               // саме значення не потрібно нікуди записувати
                );

                if (!isValidTime)
                {
                    Console.WriteLine("Invalid time format");
                }
                
            } while (!isValidTime);
            
            string[] time = input.Split(":"); // розділяємо час на час і хв.
            
            int hours = int.Parse(time[0]);
            int minutes = int.Parse(time[1]);

            if (minutes >= 31)
            {
                hours++;
            }
            
            string message = hours switch
            {
                >= 6 and <= 11 => "Good Morning!",
                >= 12 and <= 17 => "Good Afternoon!",
                >= 18 and <= 22 => "Good Evening",
                _ => "Good Night!"
            };
            
            Console.WriteLine(message);
            Console.ReadKey();
            
            
            
            // складна валідація, до того ж не вірно працює, наприклад якщо ввести :0115
            
            /*var trim = Console.ReadLine()?.Trim();
            
            if (trim == null || !trim.Contains(':'))
            {
                Console.WriteLine("Not a proper format.");
                return;
            }
            
            var hours = int.Parse(trim?[..trim.IndexOf(':')] ?? string.Empty);
            var minutes = int.Parse(trim?[(trim.IndexOf(':') + 1)..] ?? string.Empty);
            if  (minutes is < 0 or > 59 || hours < 0 || 24 < hours)
            {
                Console.WriteLine("Not a proper format.");
                return;
            }*/

            // можна використати більш короткий запис

            
            /*switch (hours)
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
        }
    }
}

