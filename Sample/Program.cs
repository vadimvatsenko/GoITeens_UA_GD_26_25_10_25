// Console.OutputEncoding = Encoding.UTF8;   // для виводу
// Console.InputEncoding  = Encoding.UTF8; 
// answer.Equals(countriesAndCapitals[randomCountry], StringComparison.OrdinalIgnoreCase) // перевірка укр вводу
using System;

namespace Sample
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<int> numbs = new List<int>
            {
                5, 
                6, 
                10, 
                15, 
                12 // 4
            };
            
            Console.WriteLine(numbs.Count); // 5
            
            Console.WriteLine(numbs[numbs.Count - 1]);

            foreach (var n in numbs)
            {
                Console.WriteLine(n);
            }

            for (int i = 0; i < numbs.Count; i++)
            {
                Console.WriteLine(numbs[i]);
            }
            
        }
    }
}


