// 9. Подорож у часі: Гравець подорожує у минуле, відвідуючи різні епохи. 
// Кожен наступний рік у минулому знаходиться вдвічі далі за попередній. 
// Створіть список років, які відвідав гравець.

namespace _07_List_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> backToTheFuture = new List<int>() {2025, 1984};
            int timeLength = 10;

            for (int i = 1; i < timeLength; i++)
            {
                int year =
                    backToTheFuture[i] - ((backToTheFuture[i - 1] - backToTheFuture[i]) * 2);
                backToTheFuture.Add(year);
            }

            foreach (int year in backToTheFuture)
            {
                Console.WriteLine(year);
            }
            
            Console.ReadKey();
        }
    }
}