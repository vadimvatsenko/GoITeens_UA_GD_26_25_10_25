using System;

namespace Lesson_4_Conditionals_Switch_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, ConsoleColor> dict = new Dictionary<string, ConsoleColor>()
            {
                { "Dragon", ConsoleColor.Red }, // 0
                { "Ent", ConsoleColor.Green }, // 1
                { "Phoenix", ConsoleColor.Yellow }, // 2
                { "Unicorn", ConsoleColor.Magenta }, // 3
                { "Kraken", ConsoleColor.Cyan }, // 4
                { "Ghost", ConsoleColor.DarkCyan }, // 5
                { "Golem", ConsoleColor.DarkGray }, // 6
                { "Troll", ConsoleColor.DarkGreen }, // 7
                { "Lich", ConsoleColor.DarkMagenta }, // 8
            };

            /*Console.WriteLine(dict.ElementAt(1).Key);
            Console.WriteLine(dict.ElementAt(1).Value);*/

            Console.WriteLine("Enter Color from 0 - 8");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int color))
            {
                if (color >= 0 && color <= 8)
                {

                    switch (color)
                    {
                        case 0:
                            Console.ForegroundColor = dict.ElementAt(0).Value;
                            Console.WriteLine(dict.ElementAt(0).Key);
                            break;

                        case 1:
                            Console.ForegroundColor = dict.ElementAt(1).Value;
                            Console.WriteLine(dict.ElementAt(1).Key);
                            break;

                        case 2:
                            Console.ForegroundColor = dict.ElementAt(2).Value;
                            Console.WriteLine(dict.ElementAt(2).Key);
                            break;

                        case 3:
                            Console.ForegroundColor = dict.ElementAt(3).Value;
                            Console.WriteLine(dict.ElementAt(3).Key);
                            break;

                        case 4:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            //Console.ForegroundColor = dict.ElementAt(4).Value;
                            Console.WriteLine(dict.ElementAt(4).Key);
                            break;
                        case 5:
                            Console.ForegroundColor = dict.ElementAt(5).Value;
                            Console.WriteLine(dict.ElementAt(5).Key);
                            break;
                        case 6:
                            Console.ForegroundColor = dict.ElementAt(6).Value;
                            Console.WriteLine(dict.ElementAt(6).Key);
                            break;
                        case 7:
                            Console.ForegroundColor = dict.ElementAt(7).Value;
                            Console.WriteLine(dict.ElementAt(7).Key);
                            break;
                        case 8:
                            Console.ForegroundColor = dict.ElementAt(8).Value;
                            Console.WriteLine(dict.ElementAt(8).Key);
                            break;
                        default:
                            Console.WriteLine("Unknown color");
                            break;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
