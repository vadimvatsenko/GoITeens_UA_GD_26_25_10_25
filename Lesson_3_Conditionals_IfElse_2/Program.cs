using System;
using System.Text;

// написати програму, яка запитує 2 числа, потім запитує оператор, та згідно з оператором робить математичні розрахунки
namespace Lesson_3_Conditionals_IfElse_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            char symbolMath;
            
            Console.WriteLine("Enter A number: ");

            Console.WriteLine();
            
            string aNumber = Console.ReadLine();
            bool isANumber = int.TryParse(aNumber, out a);
            
            /*Console.ForegroundColor = isANumber ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"{(isANumber ? a.ToString() : "не число")}");*/
            
            if (isANumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{a} correct number entered.");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{(a == 0 ? "incorrect number entered" : "not null")}");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter B number: ");

            Console.WriteLine();
            bool isBNumber = int.TryParse(Console.ReadLine(), out b);
            
            if (isBNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{b} correct number entered.");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{(b == 0 ? "incorrect number entered" : "not null")}");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Math Operationt");
            Console.WriteLine();
            bool isCharMathCorrect =  char.TryParse(Console.ReadLine(), out symbolMath);
            
            if (symbolMath == '+' || symbolMath == '-' ||  symbolMath == '*' || symbolMath == '/')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{symbolMath} correct number math symbol entered.");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{symbolMath} incorrect number math symbol entered.");
            }

            if (symbolMath == '+')
            {
                Console.WriteLine(a + b);
            }
            else if (symbolMath == '-')
            {
                Console.WriteLine(a - b);
            }
            else if (symbolMath == '*')
            {
                Console.WriteLine(a * b);
            }
            else if (symbolMath == '/')
            {
                Console.WriteLine(a / b);
            }
            else
            {
                Console.WriteLine("Error");
            }
            
            Console.ReadKey();
        }
    }
}

