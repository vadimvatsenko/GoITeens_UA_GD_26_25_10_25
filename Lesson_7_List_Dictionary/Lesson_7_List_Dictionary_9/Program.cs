//4) Подорож на планети
// Гравець здійснює подорож на планети галактики.
// Кожна наступна планета вдвічі віддаленіша за попередню.
// Створіть список відстаней до кожної планети.
// Пояснення:
//- Створіть список з двома числами, наприклад 170 та 500.
//- Створіть цикл: починається з індекса 1 і закінчується на 10.
//- У циклі:
//nextDistance = 500 + ((500 - 170) * 2)
//              - Додайте отриману відстань у кінець списку.
//- Далі рахуйте аналогічно, використовуючи останні значення.


namespace Lesson_7_List_Dictionary_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distanceBetweenPlanets = new List<int>() 
                { 
                    170, // 0
                    500 // 1
                };
            
            for (int i = 1; i < 10; i++)
            {
                // distanceBetweenPlanets[i] = 500
                // distanceBetweenPlanets[i - 1] = 170
                // 330 * 2 = 680 + 500 = 1180
                int nextDistance =  
                    distanceBetweenPlanets[i] + ((distanceBetweenPlanets[i] - distanceBetweenPlanets[i - 1]) * 2);
                distanceBetweenPlanets.Add(nextDistance);
                
            }

            foreach (var planet in distanceBetweenPlanets)
            {
                Console.WriteLine(planet);
            }
            
            Console.ReadKey();
        }
    }
}