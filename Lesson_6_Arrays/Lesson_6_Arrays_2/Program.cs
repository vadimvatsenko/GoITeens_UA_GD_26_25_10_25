namespace Lesson_6_Arrays_2
{
    // Сума всіx чисел у масиві
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbs = { 12, 2, -5, 6, 7, 8 };

            int summ = 0;

            for (int i = 0; i < numbs.Length; i++)
            {
                summ += numbs[i];
            }
            
            Console.WriteLine(summ);

            Console.ReadKey();
        }
    }
}


    


