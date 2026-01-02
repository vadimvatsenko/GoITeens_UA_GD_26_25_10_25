// Створіть список цілих чисел. Додайте в цей список 10 випадкових чисел за допомогою циклу та методу Add(). 
// Переверніть список у зворотному порядку. 

namespace Lesson_7_List_Dictionary_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numb = new List<int>()
            {
                10,
                20,
                70,
                40,
                50,
            };

            List<char> symbol = new List<char>()
            {
                'b',
                'a',
                'a',
                'n',
            };
            
            numb.Insert(0, 0);
            
            List<int> sort = new List<int>(numb.Count);

            for (int i = 0; i < numb.Count; i++)
            {
                for (int j = 1; j < numb.Count; j++)
                {
                    if (numb[i] < numb[j])
                    {
                        sort.Add(numb[j]);
                    }
                }
            }

            foreach (var s in sort)
            {
                Console.WriteLine($"{s} ");
            }
            
            
            
            /*Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                numb.Add(random.Next(1, 101));
            }

            foreach (var n in numb)
            {
                Console.Write($"{n} ");
            }*/
            
            

            //numb.Reverse();
            Console.WriteLine();
            
            /*foreach (var n in numb)
            {
                Console.Write($"{n} ");
            }*/
            
            //int lastIndex = numb.Count - 1;
            
            

            /*for (int i = numb.Count - 1; i >= 0; i--)
            {
                Console.Write($"{numb[i]} ");
            }*/
            
            
            Console.ReadKey();
        }
    }
}