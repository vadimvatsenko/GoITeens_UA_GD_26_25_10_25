// && (логічне І): Повертає true, якщо обидва вирази є істинними.
// || (логічне АБО): Повертає true, якщо хоча б один з виразів є істинним.
// ! (логічне НЕ): Інвертує булеве значення.

using System;

namespace Lesson_2_Operators_LogicOperators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // ((a > b) | | (c < d) | | (a < b) | | (c > d))
            int a = 7;
            int b = 10;
            int c = 0;
            int d = 2;

            bool isEq = (a < b) && ((c < d) || (a < b) || (c > d));

            Console.WriteLine(isEq);
        }
    }
}

