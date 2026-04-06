// 6. Розвиток цивілізації: Гравець розвиває свою цивілізацію. 
// Перший елемент списку є початковим станом, 
// кожен наступний елемент — це сума попередніх елементів.

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> civilization = new List<int>() { 5, 7 };
            int civilizationLength = 10;

            for (int i = 1; i < civilizationLength; i++)
            {
                civilization.Add(civilization[i - 1] + civilization[i]);
            }

            foreach (var item in civilization)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}