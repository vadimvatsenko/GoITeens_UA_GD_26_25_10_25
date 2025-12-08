using System;

// 8. Виведіть у консоль послідовність чисел: -3 0 3 6 9 12 15 18 21 24.
// Виконайте завдання, використовуючи цикл FOR. Зміна лічильника має відповідати збільшенню його на 3.

namespace Lesson_5_Cycles_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = -3; i <= 24; i += 3)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
