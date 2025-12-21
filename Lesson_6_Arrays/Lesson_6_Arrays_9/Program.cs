// ref type
// різниця між List та Масивами 

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*int[] numbs1 = new int[5]
            {
                1, 2, 3, 4, 5
            };
            */
            
            //Console.WriteLine(numbs1[2]);

            /*int[] numbs2 = numbs1;
            int[] numbs3 = numbs2;
            
            numbs2[2] = 1111;
            
            numbs2[3] = 2222;
            
            Console.WriteLine(numbs2[2]);
            Console.WriteLine(numbs1[2]);
            Console.WriteLine();
            
            Console.WriteLine(numbs1[3]);
            Console.WriteLine(numbs2[3]);
            Console.WriteLine(numbs3[3]);*/
            
            Console.WriteLine();

            List<int> numbs1 = new List<int>()
            {
                2, 3
            };

            List<int> numbs2 = numbs1;

            numbs2[1] = 5;

            Console.WriteLine(numbs1[1]);
            Console.WriteLine(numbs2[1]);

            Console.ReadKey();
        }
    }
}