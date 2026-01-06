// Console.OutputEncoding = Encoding.UTF8;   // для виводу
// Console.InputEncoding  = Encoding.UTF8; 
// answer.Equals(countriesAndCapitals[randomCountry], StringComparison.OrdinalIgnoreCase) // перевірка укр вводу

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>()
            {
                {"Україна", "Київ"},
                {"Франція", "Париж"},
                {"Німеччина", "Берлін"},
                {"Італія", "Рим"},
                {"Іспанія", "Мадрид"}
            };

            foreach (var pair in countries)
            {
                while (true)
                {
                    Console.Write(pair.Key + ": ");
                    string answer = Console.ReadLine();

                    if (answer.Equals(pair.Value, StringComparison.OrdinalIgnoreCase))
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}


