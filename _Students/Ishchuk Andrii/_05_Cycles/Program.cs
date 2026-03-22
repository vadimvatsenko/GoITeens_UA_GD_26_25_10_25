using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess = 0;
        int attempts = 0;

        Console.WriteLine("Я загадав число від 1 до 100");
        

        while (guess != secretNumber)
        {
            Console.Write("Введи число: ");
            string input = Console.ReadLine();

        
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Введи число: ");
                continue;
            }


            if (guess == 0)
            {
                Console.WriteLine("Загадане число було: " + secretNumber);
                break;
            }

            attempts++;

            if (guess > secretNumber)
            {
                Console.WriteLine("Загадане число менше");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Загадане число більше");
            }
            else
            {
                Console.WriteLine("Ти вгадав!");
                Console.WriteLine("Кількість спроб: " + attempts);
            }
        }
        Console.ReadKey();
    }
}