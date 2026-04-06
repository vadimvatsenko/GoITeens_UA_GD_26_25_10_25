// 3. Магічні портали: Гравець відкриває магічні портали на інші світи. 
// Кожен наступний світ має бути вдвічі більшим за попередній. 
// Створіть список кількості порталів для кожного світу.


namespace _07_List_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> portalDistance = new List<int>() { 150 };
            int portalLength = 10;

            for (int i = 1; i < portalLength; i++)
            {
                portalDistance.Add(portalDistance[i - 1] * 2);
            }

            foreach (var item in portalDistance)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }
}

