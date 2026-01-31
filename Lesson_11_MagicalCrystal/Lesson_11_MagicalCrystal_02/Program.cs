using System.Drawing;

// Colorizer

namespace Lesson_11_MagicalCrystal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ConsoleColor> colors = new Dictionary<int, ConsoleColor>()
            {
                [1] = ConsoleColor.Red,
                [2] = ConsoleColor.Blue,
                [3] = ConsoleColor.Green,
                [4] = ConsoleColor.Yellow,
                [5] = ConsoleColor.Magenta,
            };

            bool isNumber = false;
            bool isValidColorNumber = false;
            
            
            while (!isNumber || !isValidColorNumber)
            {
                Console.Clear();
                ShowDict(colors);
                Console.WriteLine("Введіть номер кольору: ");
                
                string color = Console.ReadLine().ToLower();
                
                isNumber =  int.TryParse(color, out int numberColor);
                isValidColorNumber = colors.ContainsKey(numberColor);

                if (!isNumber || !isValidColorNumber)
                {
                    Console.WriteLine("Not Valid Color number");
                    Console.ReadKey();
                }
            }

            /*switch (color)
            {
                case "червоний":
                    Console.WriteLine("Дракон");
                    break;

                case "синій":
                    Console.WriteLine("Чарівна Фея");
                    break;

                case "зелений":
                    Console.WriteLine("Лісовик");
                    break;

                case "жовтий":
                    Console.WriteLine("Сонячний Ельф");
                    break;

                case "фіолетовий":
                    Console.WriteLine("Маг Чарівник");
                    break;

                default:
                    Console.WriteLine("Не відомий колір");
                    break;
            }
            */
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