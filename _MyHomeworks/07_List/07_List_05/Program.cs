// 5. Скарби на островах: Гравець шукає легендарні скрині зі скарбами, розташовані на островах. 
// Кількість скарбів на кожному острові визначається числами Фібоначчі. 
// Створіть список кількості скарбів на кожному острові.


namespace _07_List_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> fibonachi = new List<int>() {0, 1};
            int fibonachiLength = 10;

            for (int i = 1; i < fibonachiLength; i++)
            {
                fibonachi.Add(fibonachi[i - 1] + fibonachi[i]);
            }

            foreach (var f in fibonachi)
            {
                Console.WriteLine(f);
            }
            
            Console.ReadKey();
        }
    }
}