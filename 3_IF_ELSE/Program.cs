

// ДЗ Рома 
namespace _3_IF_ELSE
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101); // Загадане число від 1 до 100
            int attempts = 0;
            bool isPlaying = true;

            Console.WriteLine("=== ГРА: ВГАДАЙ ЧИСЛО ===");
            Console.WriteLine("Я загадав число від 1 до 100.");
            //Console.WriteLine("Введіть 'exit', щоб вийти з гри.");

            while (isPlaying)
            {
                
                Console.WriteLine("Натисніть ESC, щоб вийти, або будь-яку іншу клавішу, щоб продовжити...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                
                Console.Write("Введіть ваше число: ");
                string input = Console.ReadLine();
                

                // Можливість завершити гру
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Гру завершено.");
                    Console.WriteLine("Загадане число було: " + secretNumber);
                    break;
                }

                // Перевірка, чи введено число
                if (!int.TryParse(input, out int userNumber))
                {
                    Console.WriteLine("❗ Помилка: введіть число!");
                    continue;
                }

                attempts++;

                // Перевірка числа
                if (userNumber < secretNumber)
                {
                    Console.WriteLine("Моє число БІЛЬШЕ ✅");
                }
                else if (userNumber > secretNumber)
                {
                    Console.WriteLine("Моє число МЕНШЕ ✅");
                }
                else
                {
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
