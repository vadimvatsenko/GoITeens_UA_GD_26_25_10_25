using System;
using System.Collections.Generic;

class Program
{
    class Riddle
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public Riddle(string question, string answer)
        {
            Question = question;
            Answer = answer.ToLower(); // Відповідь зберігається у нижньому регістрі
        }
    }

    static void Main()
    {
        Console.WriteLine("Ласкаво просимо до текстового квесту із загадками!");
        Console.WriteLine("Ваша мета – відгадати ключові слова кожної загадки.\n");

        // Створюємо список загадок
        List<Riddle> riddles = new List<Riddle>
        {
            new Riddle("Що завжди йде, але ніколи не приходить?", "час"),
            new Riddle("Мене можна зламати, але я не можу падати. Що я?", "обіцянка"),
            new Riddle("Що має руки, але не може обіймати?", "годинник")
        };

        foreach (var riddle in riddles)
        {
            bool correct = false;

            while (!correct)
            {
                Console.WriteLine(riddle.Question);
                Console.Write("Ваша відповідь: ");
                string playerAnswer = Console.ReadLine().ToLower().Trim();

                if (playerAnswer == riddle.Answer)
                {
                    Console.WriteLine("Правильно! \n");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Неправильно. Спробуйте ще раз.\n");
                }
            }
        }

        Console.WriteLine("Вітаємо! Ви відгадали всі загадки! ");
    }
}