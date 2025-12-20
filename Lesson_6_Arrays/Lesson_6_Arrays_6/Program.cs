// Дано цілочисельний масив (15 елементів, згенерованих випадковим чином у діапазоні від 1 до 10). 
// Потрібно визначити, чи є в масиві елемент, що дорівнює N (N вводиться). 
// Виведіть «так» або «ні» один раз. Для пошуку елемента використайте цикл foreach


namespace TRYING_TO_DO_SMT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int[] numbers = new int[15];
            Random rnd = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 11);
            }

            Console.WriteLine($"Enter random number please :)");
            a = int.Parse(Console.ReadLine());
            
            bool isEqual = false;
            
            foreach (var number in numbers)
            {
                if (number == a)
                {
                    isEqual = true;
                    break;
                }
                /*else
                {
                    isEqual = false;
                }*/
            }

            foreach (var n in numbers)
            {
                Console.Write($"{n} ");
            }
            
            Console.WriteLine(isEqual? "YES" : "NO" );
            
            Console.ReadKey();
        }
    }
}