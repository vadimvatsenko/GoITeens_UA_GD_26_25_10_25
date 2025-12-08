using System;

namespace Lesson_4_Conditionals_Switch_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 1000;

            string message = score switch
            {
                < 50             => "Незадовільно",
                >= 50 and < 70   => "Задовільно",
                >= 70 and < 90   => "Добре",
                >= 90 and <= 100 => "Відмінно",
                > 999            => "Чітер",
                _                => "Не має такого"
            };
            
            Console.WriteLine(message);
            
            Console.ReadKey();
        }
    }
}