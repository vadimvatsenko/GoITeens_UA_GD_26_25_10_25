//7. Перекладач у грі: Створіть гру-пригоду, де гравцеві потрібно буде здійснювати комунікацію з NPC, 
// що говорять на іншій мові. Використовуйте словник для перекладу мови.

namespace _07_Dict_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "Happy New Year";

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "Happy", "Счасливого" },
                { "New", "Нового" },
                { "Year", "Року" }
            };

            string[] words = word.Split(' ');

            foreach (var item in words)
            {
                if (dict.ContainsKey(item))
                {
                    Console.WriteLine(dict[item]);
                }
            }
            
            Console.ReadKey();
        }
    }
}