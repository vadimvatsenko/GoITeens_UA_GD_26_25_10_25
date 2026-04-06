// 10. Героїчний похід: Гравець вирушає у героїчний похід через ліс,
// збираючи на своєму шляху магічні артефакти. 
// Кожен наступний артефакт розташований на відстані, 
// яка дорівнює сумі вже зібраних артефактів. 
// Створіть список відстаней до кожного артефакту.

namespace _07_List_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> artifacts = new List<int>() { 5, 7 };
            int artifatsLength = 10;

            int summ = artifacts[0] + artifacts[1];
            for (int i = 1; i < artifatsLength; i++)
            {
                summ += artifacts[i];
                artifacts.Add(summ);
            }

            foreach (int art in artifacts)
            {
                Console.WriteLine(art);
            }
            
            Console.ReadKey();
        }
    }
}
