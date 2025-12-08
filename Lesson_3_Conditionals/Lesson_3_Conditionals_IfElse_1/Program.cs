using System.Globalization;
using System.Text;

// приклад з днями тижня.
namespace Lesson_3_Conditionals_IfElse_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] weekDays = new[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayNumber;
            
            Console.Write("Enter the day number: ");
            dayNumber = int.Parse(Console.ReadLine());

            if (dayNumber == 1)
            {
                Console.WriteLine(weekDays[0]);
            }
            else if (dayNumber == 2)
            {
                Console.WriteLine(weekDays[1]);
            }
            else if (dayNumber == 3)
            {
                Console.WriteLine(weekDays[2]);
            }
            else if (dayNumber == 4)
            {
                Console.WriteLine(weekDays[3]);
            }
            else if (dayNumber == 5)
            {
                Console.WriteLine(weekDays[4]);
            }
            else if (dayNumber == 6)
            {
                Console.WriteLine(weekDays[5]);
            }
            else if (dayNumber == 7)
            {
                Console.WriteLine(weekDays[6]);
            }
            else
            {
                Console.WriteLine("Invalid day number");
            }
            
            Console.ReadKey();
        }
        
    }
}

