// 8. Магічні кристали: Гравець збирає магічні кристали, розташовані у лісі на деревах. 
// Кількість кристалів на кожному дереві визначається числами, що представляють степені чотирьох. 
// Створіть список кількості кристалів на кожному дереві.

namespace _07_List_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbsPowTwo = new List<int>();
            int numb = 4;

            for (int i = 0; i <= 10; i++)
            {
                if (i == 0)
                {
                    numbsPowTwo.Add(1);
                }
                else
                {
                    int[] numbs = new int[i];

                    for (int j = 0; j < numbs.Length; j++)
                    {
                        numbs[j] = numb;
                    }

                    int value = numbs[0];

                    for (int k = 1; k < numbs.Length; k++)
                    {
                        value *= numbs[k];
                    }

                    numbsPowTwo.Add(value);
                }
            }

            foreach (var item in numbsPowTwo)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}