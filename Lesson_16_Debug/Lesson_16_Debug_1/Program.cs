namespace Lesson_16_Debug_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 10, 15 };
            int sum = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = numbers[i];
            }
            
            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}