

namespace _07_Dict_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string quest = "золото,меч,шолом,золото,срібло,сокира,щит,молот,щит";
            string[] questArray = quest.Split(",");

            foreach (string questItem in questArray)
            {
                Console.WriteLine(questItem);
            }
            
            Console.ReadKey();
        }
    }
}