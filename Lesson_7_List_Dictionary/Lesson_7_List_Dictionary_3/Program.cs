namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> crystals = new Dictionary<int, string>()
            {
                { -1000, "Item1"},
                { 2, "Item2"},
                { 3, "Item3"},
                { 4, "Item4"},
                { 5, "Item5"},
                { 6, "Item6"},
                { 7, "Item7"},
            };

            foreach (var item in crystals)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            
            string element = crystals[4];
            
            Console.WriteLine(element);
            
            bool contansKey = crystals.ContainsKey(7);
            Console.WriteLine(contansKey);
            
            bool containsValue = crystals.ContainsValue("Item8");
            Console.WriteLine(containsValue);
            
            Console.ReadKey();
        }
    }
}

