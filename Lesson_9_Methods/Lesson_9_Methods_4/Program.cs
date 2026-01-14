

//Для рефакторінга на 17.01.2026
namespace Lesson_9_Methods_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors =
            {
                "red", "yellow", "blue", "green", "pink", "orange", "purple", "black", "white",
            };

            
            string input = String.Empty;

            do
            {
                ShowMessage(colors);
                input = Console.ReadLine();

                if (input.Trim() == String.Empty || !colors.Contains(input))
                {
                    
                }
                
            } while (!colors.Contains(input));
            

            switch (input)
            {
                case "red":
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.WriteLine("You got a dragon");
                  break;
                
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You got a king");
                    break;
                
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You got a fairy");
                    break;
                
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You got a woodman");
                    break;
                
                case "pink":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You got a rose");
                    break;
                
                case "orange":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You got an orange");
                    break;
                
                case "purple":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You got an octupus");
                    break;
                
                case "black":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("You got a black swan");
                    break;
                
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You got a white swan");
                    break;
                
                default:
                    Console.WriteLine("The color does not exist");
                    break;
            }
            Console.ReadKey();
        }

        private static void ShowMessage(string[] colors)
        {
            Console.WriteLine("Enter your color: ");
            foreach (var c in colors)
            {
                Console.Write($"{c} ");
            }
        }
    }
};