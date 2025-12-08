using System;
using System.Text;

// тернальні оператори
namespace Lesson_3_Conditionals_IfElse_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   
            Console.InputEncoding  = Encoding.UTF8;

            int a = 4;
            int b = 9;
            
            string result = a % 2 == 0 && b % 2 == 0 ? "парне" : "непарне";
            Console.WriteLine(result);

            int temp = 28;
            string hotOrCold = temp > 25 ? "Hot" : "Cold";
            Console.WriteLine(hotOrCold);

            bool isAdmin = true;
            string role = isAdmin ? "Admin" : "User";
            Console.WriteLine(role);

            int c = 10;
            int d = 2;
            string isDiffToZero = d != 0 ? (c / d).ToString() : "Ділити на нуль не можна";  
            Console.WriteLine(isDiffToZero);
        }
    }
}


