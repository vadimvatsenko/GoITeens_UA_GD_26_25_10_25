using System;

namespace Lesson_4_Conditionals_Switch_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть поточний час (0-23): ");
            int hour = int.Parse(Console.ReadLine());
            

            switch (hour)
            {
                case >= 6 and <= 11:
                    Console.WriteLine("Доброго ранку!");
                    break;
                case >= 12 and <= 17:
                    Console.WriteLine("Доброго дня!");
                    break;
                case >= 18 and <= 22:
                    Console.WriteLine("Доброго вечора!");
                    break;
                default:
                    Console.WriteLine("Доброї ночі!");
                    break;
            }
            
            /*if (hour >= 6 && hour <= 11)
            {
                Console.WriteLine("Доброго ранку!");
            }
            else if (hour >= 12 && hour <= 17)
            {
                Console.WriteLine("Доброго дня!");
            }
            else if (hour >= 18 && hour <= 22)
            {
                Console.WriteLine("Доброго вечора!");
            }
            else
            {
                Console.WriteLine("Доброї ночі!");
            }*/
        }
    }
}
