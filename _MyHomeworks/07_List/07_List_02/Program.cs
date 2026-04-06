// 2. Будівництво міст: Гравець будує своє власне королівство та міста на території. 
// Кількість міст визначається числами, які представляють ступені двійки. 
// Створіть список кількості міст для кожного рівня.
// List<int> порожній, заповнити у циклі 11 чисел від 0 до 10 включно 
// Ступені двійки: 
// 2^0 = 1 (важливе правило)
// 2^1 = 2
// 2^2 = 4 (2×2)
// 2^3 = 8 (2×2×2)
// 2^4 = 16
// 2^5 = 32
// 2^6 = 64
// 2^7 = 128
// 2^8 = 256
// 2^9 = 512
// 2^10 = 1024

namespace _07_List_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbsPowTwo = new List<int>();
            int numb = 2;

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
