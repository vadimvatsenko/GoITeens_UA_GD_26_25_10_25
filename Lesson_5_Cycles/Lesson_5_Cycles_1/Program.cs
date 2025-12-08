// 1. Запросіть користувача ввести 2 числа.
// Створіть простий цикл for з повтореннями від першого числа до другого,

using System;

namespace Lesson_5_Cycles_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int number1;
            int number2;
            string input;
            bool isFirstNumber = false;
            bool isSecondNumber = false;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter First number: ");
                input = Console.ReadLine();
                isFirstNumber = int.TryParse(input, out number1);

                if (!isFirstNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered an invalid number");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You entered correct number");
                }
                
                Thread.Sleep(500);
                
            } while (!isFirstNumber);
            
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter Second number: ");
                input = Console.ReadLine();
                isSecondNumber = int.TryParse(input, out number2);

                if (!isSecondNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered an invalid number");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You entered correct number");
                }
                
                Thread.Sleep(500);
                
            } while (!isSecondNumber);

            // свап чисел, якщо друге число меньше першого
            if (number2 < number1)
            {
                int temp = number2;
                number2 = number1;
                number1 = temp;
            }

            for (int i = number1; i <= number2; i++)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
    }
}

