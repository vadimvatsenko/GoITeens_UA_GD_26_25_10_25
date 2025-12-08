
// Табличка множення
namespace Lesson_5_Cycles_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    Console.WriteLine($"{x} * {y} = {x * y}");
                }
            }
            Console.ReadKey();
        }
    }
}