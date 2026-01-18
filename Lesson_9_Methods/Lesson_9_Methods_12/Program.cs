// Обрізання до діапазону (Clamp)
// Створи метод Clamp(int value, int min, int max), який повертає:
// min, якщо value < min
// max, якщо value > max
//value, якщо він у межах

namespace Lesson_9_Lesson_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clampValue = Clamp(40, 50, 100);
            
            Console.WriteLine("clampValue: " + clampValue);
            Console.ReadKey();
        }

        static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }
            return value;
        }

    }
}