namespace _05_CYCLES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int input = -1;
            int randomNumber = rnd.Next(1, 100);

            int a = 0;
            bool b = false;


            Console.WriteLine("If you want to stop tell me 'Stop'");

            while (input != randomNumber && b == false)
            {

                string stringinput = Console.ReadLine();

                if (int.TryParse(stringinput, out input))
                {
                }
                else if (stringinput == "Stop")
                {
                    b = true;
                }
                else
                {
                    Console.WriteLine("Please enter an integer");
                }

                a++;

            }

            if (b == true)
            {
                Console.WriteLine("Session was terminated");
            }
            else
            {
                Console.WriteLine(
                    $"You got the number right! It's {randomNumber}. And also you needed {a} attempts to guess the number. Congrats!");
            }

            Console.ReadKey();
        }
    }
}

