using System;

// приклад з днями тижня.
namespace Lesson_4_Conditionals_Switch_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] weekDays = new[]
            {
                "Monday", // 0
                "Tuesday", // 1
                "Wednesday", // 2
                "Thursday", // 3
                "Friday", // 4
                "Saturday", // 5
                "Sunday" // 6
            };

            int dayNumber;
            
            Console.Write("Enter the day number: 1 - 7 ");
            dayNumber = int.Parse(Console.ReadLine());

            switch (dayNumber)
            {
                case 1:
                    Console.WriteLine(weekDays[0]);
                    break;
                case 2:
                    Console.WriteLine(weekDays[1]);
                    break;
                case 3:
                    Console.WriteLine(weekDays[2]);
                    break;
                case 4:
                    Console.WriteLine(weekDays[3]);
                    break;
                case 5:
                    Console.WriteLine(weekDays[4]);
                    break;
                case 6:
                    Console.WriteLine(weekDays[5]);
                    break;
                case 7:
                    Console.WriteLine(weekDays[6]);
                    break;
                default:
                    Console.WriteLine("Is not a valid day number");
                    break;
            }

            Console.ReadKey();
            
        }
        
    }
}



