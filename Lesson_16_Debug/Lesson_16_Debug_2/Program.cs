// Потрібно написати функцію, яка перетворює значення кута з градусів у радіани.
// Використовуйте таку формулу для перетворення:

// радіани = градуси * pi(3,14) / 180

// 3,1415926535

// Обмеження: Значення кута в градусах має бути в межах від 0 до 360 (не включаючи 0 і 360).
// Розглянемо наступний скрипт. Де допущені помилки?


namespace Lesson_16_Debug_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] anglesInDegrees = { 30, 45, 60, 90, 120 };

            /*foreach (var an in anglesInDegrees)
            {
                double rad = DegToRag(an);
                Console.WriteLine($"{an} to {rad}");
            }
            
            Console.ReadKey();*/

            int widht = 41;
            int height = 41;
            int centerX = widht / 2;
            int centerY = height / 2;
            int radius = 10;

            for (int i = 0; i <= 360; i+=20)
            {
                double rad = DegToRag(i);
                
                int x = (int)(centerX + radius * Math.Cos(rad));
                int y = (int)(centerY + radius * Math.Sin(rad));
                
                Console.SetCursorPosition(x, y);
                Console.Write('*');
            }
            
            Console.ReadKey();
        }

        private static double DegToRag(double D) => D * Math.PI / 180;
    }
}