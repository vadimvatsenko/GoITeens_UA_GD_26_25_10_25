// Console.OutputEncoding = Encoding.UTF8;   // для виводу
// Console.InputEncoding  = Encoding.UTF8; 
// answer.Equals(countriesAndCapitals[randomCountry], StringComparison.OrdinalIgnoreCase) // перевірка укр вводу

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            
            string vowels = "aeiou";

            string lowerInput = input.ToLower();
            
            int count = 0; 
        
            foreach (char c in lowerInput)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"Number of vowels: {count}");
            
            Console.ReadKey();
            
        }
    }
}

