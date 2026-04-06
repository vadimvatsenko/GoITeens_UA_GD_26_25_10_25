// 1. Країни та столиці у грі: Створіть словник, який містить назви країн та їх столиці. 
// Використовуйте цей словник для створення інтерактивної гри,
// де гравцеві потрібно буде вгадати столицю країни.

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<string, string> capital = new Dictionary<string, string>()
            {
                { "Ukraine", "Kyiv" },
                { "France", "Paris" },
                { "Germany", "Berlin" },
                { "Italy", "Rome" },
                { "Spain", "Madrid" },
                { "Poland", "Warsaw" },
                { "United Kingdom", "London" },
                { "United States", "Washington" },
                { "Canada", "Ottawa" },
                { "Japan", "Tokyo" }
            };

            List<string> countries = new List<string>();

            foreach (string country in capital.Keys)
            {
                countries.Add(country);
            }
            
            
            Random rnd = new Random();
            string targetCountry = countries[rnd.Next(0, countries.Count)];
            string? inputCapital;

            do
            {
                
                Console.Write($"Capital of targetCountry {targetCountry} :");
                inputCapital = Console.ReadLine();

                if (capital[targetCountry].Equals(inputCapital))
                {
                    Console.WriteLine($"The capital of {targetCountry} is {capital[targetCountry]}");
                }
                else
                {
                    Console.WriteLine("You don't have the capital of that, Try again");
                }
                
                Console.ReadKey();
                
            } while (!capital[targetCountry].Equals(inputCapital));
        }
    }
}