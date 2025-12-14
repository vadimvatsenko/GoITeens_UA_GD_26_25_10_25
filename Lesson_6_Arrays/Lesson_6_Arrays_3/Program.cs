namespace Lesson_6_Arrays_2
{
    // Найменьше число та найбільше число
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbs = { 12, 2, -5, 6, 7, 8 };

            int minNumber = numbs[0];
            int maxNumber = numbs[0];

            for (int i = 1; i < numbs.Length; i++)
            {
                if (numbs[i] < minNumber)
                {
                    minNumber = numbs[i];
                }

                if (numbs[i] > maxNumber)
                {
                    maxNumber = numbs[i];
                }
            }
            
            Console.WriteLine(minNumber);
            Console.WriteLine(maxNumber);

            Console.ReadKey();
        }
    }
}