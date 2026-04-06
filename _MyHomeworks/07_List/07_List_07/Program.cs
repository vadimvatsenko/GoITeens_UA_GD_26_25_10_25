// 7. Будівництво космічних станцій: Гравець будує космічні станції на орбіті навколо планети. 
// Кількість станцій на кожній орбіті визначається числами, що представляють ступені трійки. 
// Створіть список кількості станцій для кожної орбіти.

namespace _07_List_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbsPowTwo = new List<int>();
            int numb = 3;

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