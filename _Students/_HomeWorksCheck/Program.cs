using System;

namespace magicCrystal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть рядок: ");
            string text = Console.ReadLine().ToLower();

            int count = 0;
            string vowels = "аеєиіїоуюя";

            foreach (char c in text.ToLower())
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            Console.WriteLine("Кількість українських голосних: " + count);

            Console.ReadKey();
        }
    }
}