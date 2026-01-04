// Базовий API по роботі з строками 
// OK - void Contains(x) - чи є літера
// Ok - void StartsWith(x) - чи починається з
// OK - void EndsWith(x) - чи закінчується на
// void IndexOf(x) - перший індекс входження
// void IndexOf(x,y) - перший індекс входження символа x починаючи з y
// void LastIndexOf(x) - останній індекс входження символа x
// void LastIndexOf(x, y) - перший індекс входження символа x до y
// OK - властивість Length - довжина - OK
// void Substring(x) - виріже строку з x індекса
// void Substring(x, y) -  виріже строку з x індекса y елементів

namespace Lesson_8_Strings_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "abracadabra";
            Console.WriteLine(name.Length); // властивість Length - довжина

            int cout = 0;
            foreach (var s in name)
            {
                Console.Write($"{s} ");
            }
            
            Console.WriteLine();
            
            bool isAInString = name.Contains("a");
            bool isEInString = name.Contains("E");
            Console.WriteLine(isAInString);
            Console.WriteLine(isEInString);
            
            Console.WriteLine();
            
            bool IsabraInString = name.StartsWith("abra");
            bool IsEabraInString = name.EndsWith("abra!");
            
            Console.WriteLine(IsabraInString);
            Console.WriteLine(IsEabraInString);
            
            Console.WriteLine();
            
            int indexOfa = name.IndexOf('r');
            Console.WriteLine(indexOfa);
            
            int indexOfB =  name.IndexOf('b', 2);
            Console.WriteLine(indexOfB);
            
            Console.WriteLine();
            
            int lastIndex = name.LastIndexOf('r');
            Console.WriteLine(lastIndex);
            
            Console.WriteLine("==LastIndexOf==");
            int lastIndexOfA = name.LastIndexOf('b', 4);
            Console.WriteLine(lastIndexOfA);
            
            string newName = name.Substring(3);
            Console.WriteLine(newName);
            
            string newName1 = name.Substring(3, 3);
            Console.WriteLine(newName1);
            
            
            Console.ReadKey();
        }
    }
    
    
}