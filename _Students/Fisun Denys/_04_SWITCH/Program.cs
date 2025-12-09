namespace _04_SWITCH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ConsoleColor> dict = new Dictionary<string, ConsoleColor>()
            {
                { "Dragon", ConsoleColor.Red }, // 0
                { "Fairy", ConsoleColor.Blue }, // 1
                { "Forest guy", ConsoleColor.Green}, // 2
                { "Black sword man", ConsoleColor.Black}, // 3
            };


            Console.WriteLine(
                $"Hello! Welcome to our world! If you want to know who are living here write down a color ");
            string color = Console.ReadLine().Trim().ToLower();
            
            // добавлено. 
            int numbOfColor;

            if (int.TryParse(color, out numbOfColor) && numbOfColor >= 0 && numbOfColor < dict.Count)
            {
                Console.WriteLine(dict.ElementAt(numbOfColor).Key);
            }
            else
            {
                Console.WriteLine("That is not a valid color");
                return;
            }
            //

            switch (numbOfColor)
            {
                case 0:
                    Console.ForegroundColor = dict.ElementAt(numbOfColor).Value;
                    Console.WriteLine($"It is {dict.ElementAt(numbOfColor).Key}");
                    break;

                case 1:
                    Console.ForegroundColor = dict.ElementAt(numbOfColor).Value;
                    Console.WriteLine($"It is {dict.ElementAt(numbOfColor).Key}");
                    break;

                case 2:
                    Console.ForegroundColor = dict.ElementAt(numbOfColor).Value;
                    Console.WriteLine($"It is {dict.ElementAt(numbOfColor).Key}");
                    break;
				
                case 3:
                    Console.ForegroundColor = dict.ElementAt(numbOfColor).Value;
                    Console.WriteLine($"It is {dict.ElementAt(numbOfColor).Key}");
                    break;
				
                default:
                    Console.WriteLine($"There is no such color!");
                    break;
            }

            Console.ReadKey();
        }
    }
}