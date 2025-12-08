using System;

// Приклади з конспекту
namespace Lesson_5_Cycles_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // for
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            // while
            int j = 0;

            while (j < 5)
            {
                Console.WriteLine(j);
                j++;
            }
            
            for (int k = 5; k >= 0; k--)
            {
                Console.WriteLine(k);
            }

            int l = 5;
            
            while (l >= 0)
            {
                l--;
                Console.WriteLine(l);
            }
            
            int m = 5;
            
            do
            {
                Console.WriteLine(m);
                m++;
            } while (m < 5);
            
            Console.ReadKey();
        }
    }
}