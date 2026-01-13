using System.Globalization;
using System.Text;

namespace _HomeWorksCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            char[] vowelsUa =
            {
                'а','е','є','и','і','ї','о','у','ю','я'
            };
            
            int count = 0;
            foreach (char c in text)
            {
                if (vowelsUa.Contains(c))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}

    


