using System.Drawing;

// Dictionary int Action

namespace Lesson_11_MagicalCrystal
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ConsoleColor> colors = GetColorsDict();
            int colorNumber = CheckColorNumber(colors);
            
            Colorazer(colorNumber, colors);
            Console.ReadKey();
        }

        private static Dictionary<int, ConsoleColor> GetColorsDict()
        {
            Dictionary<int, ConsoleColor> colors = new Dictionary<int, ConsoleColor>()
            {
                [1] = ConsoleColor.Red,
                [2] = ConsoleColor.Blue,
                [3] = ConsoleColor.Green,
                [4] = ConsoleColor.Yellow,
                [5] = ConsoleColor.Magenta,
            };
            return colors;
        }

        private static void Colorazer(int colorNumber, Dictionary<int, ConsoleColor> colors)
        {
            switch (colorNumber)
            {
                case 1:
                    Final("Dragon", colors[colorNumber]);
                    break;

                case 2:
                    Final("Magic Fairy", colors[colorNumber]);
                    break;

                case 3:
                    Final("Green Goblin", colors[colorNumber]);
                    break;

                case 4:
                    Final("Sun Elf", colors[colorNumber]);
                    break;

                case 5:
                    Final("Magician Mage", colors[colorNumber]);
                    break;
                default:
                    Console.WriteLine("Color Not Known");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        private static void Final(string name, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name);
        }

        private static int CheckColorNumber(Dictionary<int, ConsoleColor> colors)
        {
            bool isNumber = false;
            bool isValidColorNumber = false;
            
            while (!isNumber || !isValidColorNumber)
            {
                Console.Clear();
                ShowDict(colors);
                Console.Write("Enter number of Color: ");
                
                string color = Console.ReadLine().ToLower();
                
                isNumber =  int.TryParse(color, out int numberOfColors);
                isValidColorNumber = colors.ContainsKey(numberOfColors);

                if (!isNumber || !isValidColorNumber)
                {
                    Console.WriteLine("Not Valid Color number");
                    Console.WriteLine("Press Any Key to Continue...");
                    Console.ReadKey();
                    continue;
                }

                return numberOfColors;
            }
            return 0;
        }

        private static void ShowDict(Dictionary<int, ConsoleColor> colors)
        {
            foreach (var col in colors)
            {
                Console.WriteLine(col.Key + " " + col.Value);
            }
        }
    }
}