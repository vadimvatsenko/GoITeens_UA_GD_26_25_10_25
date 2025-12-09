using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess = 0;

        Console.WriteLine("Вгадай число від 1 до 100");

        while (guess != secretNumber)
        {
            Console.Write("Введи число: ");
            guess = int.Parse(Console.ReadLine());

            if (guess > secretNumber)
            {
                Console.WriteLine("Менше");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Більше");
            }
        }

        Console.WriteLine("Ти вгадав!");

        Console.ReadKey();
    }
}







