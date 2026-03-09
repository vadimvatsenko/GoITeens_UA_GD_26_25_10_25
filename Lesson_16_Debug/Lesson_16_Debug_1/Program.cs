// Женя ДЗ дебагінг

// Давайте розглянемо наступне завдання.
// Дано дійсне число A та ціле число N > 0. Необхідно знайти значення виразу:

// 1 - A + A^2 - A^3 + ... + (-1)^n * A^n

// де  (−1)N  визначає знак доданку (додатній або від'ємний), а  A^N  - це A, піднесене до степеня N.
// Розглянемо наступне вирішення завдання.  Де допущені помилки?

// На приклад 
// A = 2
// N = 3

// Простими словами
// - беремо 1
// - віднімаємо А
// - додаємо А^2
// - віднімаємо A^3

// Знаки чергуються
// - + - + - + - + - + - +

// 1 - перша ітерація 2^1 = 2 (2 * 1 = 2)
// 2 - друга ітерація 2^2 = 4 (2 * 2 = 4)
// 3 - третя ітерація 2^3 = 8 (2 * 2 * 2 = 8)

// 1 - 2 + 4 - 8 = -5

namespace Lesson_16_Debug_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isValidA = false;
            int A = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter number A: ");
                
                string numberA = Console.ReadLine();
                isValidA = int.TryParse(numberA, out A);

                if (!isValidA)
                {
                    Console.WriteLine("Invalid number A");
                    Console.ReadKey();
                    continue;
                }
                
            } while (!isValidA);
            
            bool isValidN = false;
            double N = 0.0;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Enter number N (N > 0): ");
                
                string numberN = Console.ReadLine();
                isValidN = double.TryParse(numberN, out N) && N > 0;

                if (!isValidA)
                {
                    Console.WriteLine("Invalid number A");
                    Console.ReadKey();
                    continue;
                }
                
            } while (!isValidN);
            
            
            
            double result = 1.0;
            int sign = 1;

            for (int i = 1; i <= N; i++)
            {
                sign *= -1; // sing = sing * -1 (sing = 1 * -1 = -1)
                result += sign * Math.Pow(A, i);
                
            }
            
            Console.WriteLine($"Result : {result}");
            
            Console.ReadKey();
        }
    }
}