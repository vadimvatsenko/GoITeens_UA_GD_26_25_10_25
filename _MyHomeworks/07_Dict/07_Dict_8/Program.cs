namespace _07_Dict_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            List<string> fruits = new List<string>()
            {
                "Apple",
                "Banana",
                "Pear",
                "Mango",
                "Kiwi"
            };

            Dictionary<string, int> fruitsCountDict = new Dictionary<string, int>();
            
            int count = 0;

            while (count < 10)
            {
                string fruit = fruits[rnd.Next(0, fruits.Count)];
                
                if (!fruitsCountDict.ContainsKey(fruit))
                {
                    fruitsCountDict.Add(fruit, rnd.Next(0, 101));
                }
                else
                {
                    fruitsCountDict[fruit] += rnd.Next(0, 101);
                }
                count++;
            }

            foreach (var fruit in fruitsCountDict)
            {
                Console.WriteLine($"{fruit.Key}: {fruit.Value}");
            }
            
            Console.ReadKey();
        }
    }
}