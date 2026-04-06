// 1. Збір скарбів: Гравець повинен зібрати скарби, розташовані на рядку. 
// Кожен скарб — це номер клітинки. 
// Створіть і виведіть список цих скарбів.
/// List<int> з числами, заповніть 10 будь-яких чисел, та виведіть список.

namespace _07_List_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> numbs = new List<int>();
            
            for (int i = 0; i < 11; i++)
            {
                numbs.Add(rnd.Next(1, 101));
            }

            foreach (int numb in numbs)
            {
                Console.WriteLine(numb);
            }
            
            Console.ReadKey();
        }
    }
}