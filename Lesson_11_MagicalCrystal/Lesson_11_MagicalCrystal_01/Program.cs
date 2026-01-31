using System;

// Заняття 1,5 год 5хв перева.
// Опитування по методах.
// Магічний кристал - на одне заняття
// На друге ООП та класи

// Мета:
// Створимо Чарівний кристал.
// Створити інтерактивний кристал, який відповідає на запитання за допомогою різних кольорів та повідомлень,
// наприклад, кристал може відповідати тільки, "Так", "Ні", "Можливо"

// Відео по силка викачка.

namespace Lesson_11_MagicalCrystal_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> answers = GetAnswers();
            Random random = new Random();

            do
            {
                ClearConsole();
                Greetings();
                
                string question = Console.ReadLine();
                
                string answer = GetAnswer(answers, random);

                Console.ForegroundColor = GetConsoleColor(answer);
                Console.WriteLine($"Кристал каже {answer}");
                
                Console.ReadKey();
                
            } while (true);
            
        }

        private static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }
        
        private static void Greetings()
        {
            Console.WriteLine("Вітаю в Чарівному Кристалі!");
            Console.WriteLine("Задайте питання (так чи ні), а я дам відповідь");
        }

        private static string GetAnswer(List<string> answers, Random random)
        {
            int randomIndex = random.Next(0, answers.Count); // від 0 до 2
            
            string answer = answers[randomIndex]; 
            return answer;
        }
        
        private static List<string> GetAnswers()
        {
            List<string> answers = new List<string>()
            {
                "Yes", // 0
                "No", // 1
                "Maybe" // 2
            };
            return answers;
        }

        private static ConsoleColor GetConsoleColor(string answer)
        {
            switch (answer)
            {
                case "Yes":
                    return ConsoleColor.Green;
                case "No":
                    return ConsoleColor.Red;
                case "Maybe":
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}