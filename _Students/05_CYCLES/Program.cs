namespace _05_CYCLES
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 101);
            int x;
            int count;
            count = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nPlease enter your guess number (1-100) or write '143' to Exit: ");

                bool success = int.TryParse(Console.ReadLine(), out x);

                Console.Clear();

                if (x == 143)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered exit from programm");
                    break;
                }

                if (success)
                {
                    if (x < 1 || x > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nPlease write a number from 1 to 100");
                        continue;
                    }
                    else
                    {
                        ///
                        count++;
                        
                        if (x > num)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"The guessed number is smaller then {x}" +
                                          $"\nTry again!");
                        }
                        else if (x < num)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"The guessed number is bigger then {x}" +
                                              $"\nTry again!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Win!" +
                                              "\nGG");
                        }
                    }
                }
                
            } while (x != num);

            Console.WriteLine("See you next time!" +
                              $"\nYour Attempts {count}");

            Console.ReadLine();
        }
    }
}
