namespace _11_MagicalCrystal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ConsoleColor> colors = GetColorsDict();

            int colorNumber = GetValidColorNumber(colors);

            if (AskSecretQuestion())
            {
                Colorazer(colorNumber, colors);
            }
            else
            {
                Console.WriteLine("The crystal remains silent...");
            }

            Console.ResetColor();
            Console.ReadKey();
        }

        private static Dictionary<int, ConsoleColor> GetColorsDict()
        {
            return new Dictionary<int, ConsoleColor>()
            {
                {1, ConsoleColor.Red},
                {2, ConsoleColor.Blue},
                {3, ConsoleColor.Green},
                {4, ConsoleColor.Yellow},
                {5, ConsoleColor.Magenta}
            };
        }

        private static int GetValidColorNumber(Dictionary<int, ConsoleColor> colors)
        {
            while (true)
            {
                Console.Clear();
                ShowColors(colors);
                Console.Write("Enter number of Color: ");

                if (int.TryParse(Console.ReadLine(), out int number) &&
                    colors.ContainsKey(number))
                {
                    return number;
                }

                Console.WriteLine("Not valid color number!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void Colorazer(int colorNumber, Dictionary<int, ConsoleColor> colors)
        {
            Console.ForegroundColor = colors[colorNumber];

            Console.WriteLine(GetRandomMessage());

            switch (colorNumber)
            {
                case 1:
                    Console.WriteLine("Dragon");
                    break;
                case 2:
                    Console.WriteLine("Magic Fairy");
                    break;
                case 3:
                    Console.WriteLine("Green Goblin");
                    break;
                case 4:
                    Console.WriteLine("Sun Elf");
                    break;
                case 5:
                    Console.WriteLine("Magician Mage");
                    break;
            }
        }

        private static string GetRandomMessage()
        {
            string[] messages =
            {
                "The crystal is glowing...",
                "Magic flows through the air...",
                "You feel ancient power...",
                "The crystal whispers your fate...",
                "A strange energy surrounds you..."
            };

            Random random = new Random();
            return messages[random.Next(messages.Length)];
        }

        private static bool AskSecretQuestion()
        {
            Console.Write("Do you believe in magic? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            return answer == "yes";
        }

        private static void ShowColors(Dictionary<int, ConsoleColor> colors)
        {
            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Key} - {color.Value}");
            }
        }
    }
}