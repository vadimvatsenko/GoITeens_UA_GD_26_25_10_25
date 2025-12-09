

// ДЗ Рома 

using System.Text;

namespace _3_IF_ELSE
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Random random = new Random();
            int secretNumber = random.Next(1, 101); // Загадане число від 1 до 100
            int attempts = 0;
            bool isPlaying = true;

            Console.WriteLine("=== ГРА: ВГАДАЙ ЧИСЛО ===");
            Console.WriteLine("Я загадав число від 1 до 100.");
            //Console.WriteLine("Введіть 'exit', щоб вийти з гри.");

            while (isPlaying)
            {
                Console.ResetColor();
                
                Console.WriteLine("Натисніть ESC, щоб вийти, або будь-яку іншу клавішу, щоб продовжити...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Можливість завершити гру по кнопці
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Гру примусово завершено");
                    Console.WriteLine("Загадане число було: " + secretNumber);
                    Console.WriteLine("Кількість спроб: " + attempts);
                    Console.WriteLine("Натисніть будь-яку клавішу для завершення");
                    Console.ReadKey();
                    break;
                }
                
                Console.Write("Введіть ваше число: ");
                string input = Console.ReadLine();
                
                // Перевірка, чи введено число
                if (!int.TryParse(input, out int userNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❗ Помилка: введіть число!");
                    continue;
                }

                attempts++;

                // Перевірка числа
                if (userNumber < secretNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Моє число БІЛЬШЕ ✅");
                }
                else if (userNumber > secretNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Моє число МЕНШЕ ✅");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n🎉 ВІТАЮ! Ви вгадали число!");
                    Console.WriteLine("✅ Загадане число: " + secretNumber);
                    Console.WriteLine("✅ Кількість спроб: " + attempts);
                    isPlaying = false;
                }
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
