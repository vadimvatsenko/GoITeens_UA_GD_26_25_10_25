// Дано масив розмірністю 12, випадково заповнений числами від -20 до 20. Виведіть суму сусідніх елементів.
// Приклад:[12, 2, -5, 6, 7, 8]
// Вивід: 14, 1, 15,

namespace Lesson_6_Arrays_7
{
    internal class Program
    {
        static void Main()
        {
            int[] array = new int[12];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-20, 21);
            }

            foreach (var ar in array)
            {
                Console.Write($"{ar} ");
            }
            
            Console.WriteLine();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int sum = array[i] + array[i + 1];
                Console.Write(sum + " ");
            }
            
            Console.ReadKey();
        }
    }
}
