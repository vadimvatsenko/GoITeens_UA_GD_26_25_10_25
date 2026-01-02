// Базовий API по роботі з строками 

namespace Lesson_8_Strings_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "abracadabra";
            bool containsA = name.Contains("a"); // чи є літера а
            bool containsE = name.Contains("E"); // чи є літера E
            
            Console.WriteLine($"Contains a: {containsA}");
            Console.WriteLine($"Contains E: {containsE}");
            
            Console.WriteLine("========================");
            
            bool startWithAbra = name.StartsWith("abra");
            bool endWithAbra = name.EndsWith("abra");
            
            Console.WriteLine($"Starting with abra: {startWithAbra}");
            Console.WriteLine($"Ending with abra: {endWithAbra}");
            
            Console.WriteLine("========================");
            
            int indexOfa = name.IndexOf('a'); // перший індекс входження
            int indexOfb = name.IndexOf('b', 2); // індекс входження з другого індекса пошук
            Console.WriteLine($"Index of 'a': {indexOfa}");
            Console.WriteLine($"Index of 'b': {indexOfb}");
            
            Console.WriteLine("========================");
            
            int lastIndexOfa = name.LastIndexOf('a'); // перший індекс входження з кінця
            int lastIndexOfb = name.LastIndexOf('b', 3); // перший індекс входження з кінця до startIndex(3)
            
            Console.WriteLine($"Last index of 'a': {lastIndexOfa}");
            Console.WriteLine($"Last index of 'b': {lastIndexOfb}");
            
            Console.WriteLine("========================");
            
            Console.WriteLine(name.Length); // довжина строки
            
            Console.WriteLine("========================");
            
            string subStringFrom5 =  name.Substring(5); // виріже строку з п'ятого індекса
            string subStringFrom5_5Symbols =  name.Substring(5, 5); // виріже строку з п'ятого індекса п'ять символів
            
            Console.WriteLine($"Substring from 5: {subStringFrom5}");
            Console.WriteLine($"Substring from 5_5: {subStringFrom5_5Symbols}");
            
            Console.ReadKey();
        }
    }
}