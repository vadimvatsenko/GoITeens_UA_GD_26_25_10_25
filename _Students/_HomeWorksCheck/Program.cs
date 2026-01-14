using System.Globalization;
using System.Text;

namespace _HomeWorksCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> planets = new List<int>() { 150, 350 };
            
            for(int i= 0;i < 5 ;i++)
            {
                int next = planets[i + 1] + (planets[i + 1] - planets[i]) * 2 ;
                planets.Add(next);
            }
            Console.WriteLine(string.Join(", ", planets));
            
            Console.ReadKey();
        }
    }
}

    


