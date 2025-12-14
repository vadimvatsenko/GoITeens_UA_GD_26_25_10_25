using System;

namespace hw_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            int x;
            int count;
            count = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nEnter your guess number between 0 and 100 (or write 200 to leave the game): ");
                bool success = Int32.TryParse(Console.ReadLine(), out x);

                Console.Clear();
                
                if (success == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You did not follow the rulers! " +
                                      "\nTry again!");
                    continue;
                }

                    if (x > number && x != 0 && x != 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"The number is less than {x}. " +
                                      $"\nTry again. ");
                    }

                    if (x < number && x != 0 && x != 200)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"The number is more than {x}. " +
                                          $"\nTry again");
                    }

                    if (x == number && x != 200)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Right! You guessed the number! " +
                                      $"\nNice job!");
                    }
                    
                count++;

            } while (x != number && x != 200);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nThanks for playing! Bye!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nYour attempts: {count}");


            Console.ReadKey();
        }
    }
}