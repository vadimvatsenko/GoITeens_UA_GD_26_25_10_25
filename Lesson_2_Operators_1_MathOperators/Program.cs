
// + (додавання): Сума двох значень.
// - (віднімання): Різниця між двома значеннями.
// * (множення): Проlукт двох значень./ (ділення): Ділення одного значення на інше.
// % (остача від ділення): Остача від ділення одного числа на інше. 10 / 3 = 3 * 3 + 1
// 

// ++ (інкремент): Збільшує значення на 1. постфікс, предфіксний
// -- (декремент): Зменшує значення на 1. постфікс, предфіксний

// +=, -=, *=, /= - синтаксичний цукор

// Console.OutputEncoding = Encoding.UTF8;   // для виводу
// Console.InputEncoding  = Encoding.UTF8;  // для вводу

// Math.Abs, Math.Round, 

// Завдання, оголосіть дві пусті змінні, попросіть ввести у консоль два числа,
// та зробіть додавання, віднімання, тощо, та виведіть у консоль результати
using System;

namespace Lesson_2_Operators_1_Math
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = 10, b = 3, c = 7;
            int sum = (a + b + c);
            Console.WriteLine($"sum:  {sum}");

            int diff = a - b;
            Console.WriteLine($"diff:  {diff}");
            
            int multy = a * b;
            Console.WriteLine($"multy:  {multy}");
            
            int div = a / b;
            Console.WriteLine($"div:  {div}");
            
            int remainder = a % b;
            Console.WriteLine($"remainder: {remainder}");

            /*int d = a++;
            Console.WriteLine($"d: {d}, a: {a}");*/
            
            /*int x = ++a;
            Console.WriteLine($"x: {x}, a: {a}");*/

            /*a += 1;
            a = a + 1;
            Console.WriteLine($"a: {a}");*/

            a -= b - 10 * 10;
        }
    }
}

