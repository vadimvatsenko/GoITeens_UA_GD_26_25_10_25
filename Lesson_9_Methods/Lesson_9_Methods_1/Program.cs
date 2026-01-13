
namespace Lesson_9_Methods_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print();
            Print();
            Print();
            Print();
            Print();
            Print();
            
            PrintString("Goodbye");
            PrintString("Hello");
            
            Calc(5,6);

            int a = 5;
            
            Increment(a);
            Console.WriteLine($"a without method {a}"); // 5

            Console.WriteLine(Sum(10,6));
            
            int summ = Sum(7, 8);
            Console.WriteLine($"summ without method {summ}");


            List<int> testList = FillList(20);

            foreach (var it in testList)
            {
                Console.WriteLine(it);
            }

            int bigestNumber = IsBigOrSmallNumber(5, 11);

            int multiNumbers = Multy(10, 55);
            Console.WriteLine(multiNumbers);

            Attack();
            
            Console.ReadKey();
        }

        private static int Multy(int a, int b)
        {
            return a * b;
        }

        private static int IsBigOrSmallNumber(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        private static List<int> FillList(int size)
        {
            List<int> numbs = new List<int>();
            
            for (int i = 0; i < size; i++)
            {
                numbs.Add(i);
            }

            return numbs;
        }

        private static int Sum(int a, int b)
        {
            int summ = a + b;
            return summ;
        }

        private static void Print()
        {
            Console.WriteLine("Hello World!");
        }

        private static void Attack()
        {
            Print();
        }
        
        private static void PrintString(string text)
        {
            Console.WriteLine(text);
        }

        private static void Calc(int x1, int y1)
        {
            int calc = x1 + y1;
            Console.WriteLine(calc);
        }

        private static void Increment(int b)
        {
            b++;
            Console.WriteLine($"a in method {b}"); // 
        }
    }
}