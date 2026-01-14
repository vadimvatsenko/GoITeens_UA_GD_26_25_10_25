// Для рефакторінга на 17.01.2026

namespace Lesson_9_Methods_5
{
    class Program
    {
        static void Main()
        {
            
            Random random = new Random();
            int secretNumber = random.Next(1, 101); // Комп'ютер загадує число від 1 до 100
            int attempts = 0;
            bool guessed = false;

            Console.WriteLine("Гра 'Вгадай число'");
            Console.WriteLine("Комп'ютер загадав число від 1 до 100.");
            Console.WriteLine("Введіть число або 'exit' для завершення гри.");

            while (!guessed)
            {
                Console.Write("Ваш варіант: ");
                string? input = Console.ReadLine();

                // Перевірка на null
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Введено порожнє значення. Спробуйте ще раз.");
                    continue;
                }

                if (input.ToLowerInvariant() == "exit")
                {
                    Console.WriteLine("Гру завершено. Загадане число було: " + secretNumber);
                    break;
                }

                bool isParsed = int.TryParse(input, out int userNumber);

                if (!isParsed)
                {
                    Console.WriteLine("Будь ласка, введіть ціле число або 'exit'.");
                    continue;
                }

                attempts++;

                if (userNumber < secretNumber)
                {
                    Console.WriteLine("Загадане число більше.");
                }
                else if (userNumber > secretNumber)
                {
                    Console.WriteLine("Загадане число менше.");
                }
                else
                {
                    Console.WriteLine($"Вітаємо! Ви вгадали число {secretNumber} за {attempts} спроб(и).");
                    guessed = true;
                }
            }
        }
    }
}