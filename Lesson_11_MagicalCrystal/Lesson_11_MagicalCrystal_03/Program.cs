namespace Lesson_11_MagicalCrystal_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаю в Чарівному Кристалі!");
            Console.WriteLine("Задайте так/ні питання, і я дам вам відповідь...");
            
            string question = Console.ReadLine(); // Читаємо питання від користувача
            Random random = new Random(); // Генератор випадкових чисел для відповіді

            // Масив можливих відповідей
            string[] answers = { "Так", "Ні", "Можливо" };
            
            // Обираємо відповідь випадково
            string answer = answers[random.Next(answers.Length)];

            // Виводимо відповідь та колір
            Console.ForegroundColor = GetAnswerColor(answer);
            Console.WriteLine($"Кристал каже: {answer}");

            // Скидуємо колір до стандартного
            Console.ResetColor();
            
            // Метод для визначення кольору в залежності від відповіді

        }
        
        static ConsoleColor GetAnswerColor(string answer)
        {
            switch (answer)
            {
                case "Так":
                    return ConsoleColor.Green;
                case "Ні":
                    return ConsoleColor.Red;
                case "Можливо":
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}