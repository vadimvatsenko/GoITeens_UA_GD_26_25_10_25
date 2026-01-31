/*Kata.SumMul(2, 9)   => 2 + 4 + 6 + 8 = 20
Kata.SumMul(3, 13)  => 3 + 6 + 9 + 12 = 30
Kata.SumMul(4, 123) => 4 + 8 + 12 + ... = 1860
Kata.SumMul(4, 1)   // throws ArgumentException
Kata.SumMul(0, 20)  // throws ArgumentException*/


namespace Lesson_10_CodeWars_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int summTest = SumMul(0, 0);
            
            int summ1 = SumMul(2, 9);
            int summ2 = SumMul(3, 13);
            int summ3 = SumMul(4, 123);
            //int summ4 = SumMul(4, 1);
            
            
            //Console.WriteLine($"summTest: {summTest}");

            Console.WriteLine($"summ1: {summ1}");
            Console.WriteLine($"summ2: {summ2}");
            Console.WriteLine($"summ3: {summ3}");
            //Console.WriteLine($"summ4: {summ4}");
            Console.ReadKey();
        }

        public static int SumMul(int n, int m)
        {
            try
            {
                if (n < m && n != 0)
                {
                    int sum = 0;

                    for (int i = n; i < m; i += n)
                    {
                        sum += i;
                    }

                    return sum;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }
            
            return 0;
        }
    }
}