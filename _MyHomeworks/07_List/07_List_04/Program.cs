// 4. Подорож на планети: Гравець здійснює подорож на планети галактики. 
// Кожна наступна планета вдвічі віддаленіша за попередню. 
// Створіть список відстаней до кожної планети.

// Не виканано

namespace _07_List_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> planetDistance = new List<int>() {170, 500};
            
            int planetDistanceLength = 10;

            for (int i = 1; i < planetDistanceLength; i++)
            {
                int nextDistance = planetDistance[i] + ((planetDistance[i] -  planetDistance[i - 1]) * 2);
                planetDistance.Add(nextDistance);
            }

            foreach (var item in planetDistance)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }
}