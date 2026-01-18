
namespace Lesson_9_Methods_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            int sum;
            
            Calc(number1, number2, out sum);
            
            Console.WriteLine($"out method number1 = {number1}"); // 10
            Console.WriteLine(sum);
            
            ChangeSum(out sum);
            
            //Zero(out number1, out number2);
            
            Console.WriteLine($"{number1} - {number2}");
            
            ChangeSum(out sum);
            
            Console.WriteLine(sum);
            
            Console.ReadKey();
        }

        static void Calc(int number1, int number2, out int sum)
        {
            number1 = 120;
            sum = number1 + number2;
            
            Zero(out number1, out number2);
            
            Console.WriteLine("Sum: " + sum);
            
            Console.WriteLine($"in method number1 = {number1}"); // 120
        }

        static void Zero(out int number1, out int number2)
        {
            number1 = 0;
            number2 = 0;
        }

        static void ChangeSum(out int sum)
        {
            sum = 300;
        }
        
    }
}