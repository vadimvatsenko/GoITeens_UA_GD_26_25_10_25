// 9) Подорож у часі
// Гравець подорожує в минуле, відвідуючи різні епохи.
// Кожен наступний рік у минулому знаходиться вдвічі далі за попередній.
// Створіть список років, які відвідав гравець.
// Пояснення:
// - Створіть список int з двома датами, наприклад 2025 та 1984.
// - Завдання схоже на №4, але потрібно рухатися у зворотному напрямку.

namespace Lesson_7_List_Dictionary_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> years = new List<int>()
            {
                2025, // 0
                1984 // 1
            };
            
            // 2025 - 1984 = 41
            // 1984 - 41 * 2 = 1902
            // 1902 - 1984 = 82
            // 1902 - 82 * 2 = 1738

            for (int i = 1; i < 10; i++)
            {
                // years[i] = 1984 - ((2025 - 1984) * 2)
                int year = years[i] - ((years[i - 1] -  years[i]) * 2);
                years.Add(year);
            }

            foreach (var n in years)
            {
                Console.WriteLine(n);
            }
            
            Console.ReadKey();
        }
    }
}