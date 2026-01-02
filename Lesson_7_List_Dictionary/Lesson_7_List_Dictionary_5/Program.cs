// 1) Створіть список цілих чисел. Додайте в цей список 10 випадкових чисел за допомогою циклу та методу Add(). 
// Виведіть максимальний і мінімальний елементи списку та їх індекси. 

namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            
            numbers.Add(-100);
            numbers.Add(-30);
            numbers.Add(-20);
            numbers.Add(12);
            numbers.Add(30);
            numbers.Add(96);
            numbers.Add(101);
            numbers.Add(-150);

            /*for (int i = 0; i < 10; i++)
            {
                numbers.Add(random.Next(-100, 101));
            }*/

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
            
            int maxValue = int.MinValue; // -20000000
            int minValue = int.MaxValue; // 20000000

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > maxValue)
                {
                    // 0. -100 > -20000000 // maxValue = -100
                    // 1. -30 > -100 // maxValue = -30
                    // 2. -20 > -30 // maxValue = -20
                    // 3. 12 > -20 // maxValue = 12
                    // xx -150 > 101 //
                    maxValue = numbers[i];
                }

                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }
            
            Console.WriteLine($"maxValue = {maxValue} === minValue {minValue}");
            
            Console.ReadKey();
        }
    }
}