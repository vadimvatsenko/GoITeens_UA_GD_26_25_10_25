// Пустота строк
// string.IsNullOrEmpty
// string.IsNullOrWhiteSpace

namespace Lesson_8_Strings_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string empty = "";
            string empty2 = String.Empty;
            string withWhiteSpace = " ";
            string notEmpty = " a";
            string nullString = null;
            
            bool isNullorEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine($"{nameof(empty)}: {isNullorEmpty}");
            
            isNullorEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine($"{nameof(notEmpty)}: {isNullorEmpty}");
            
            isNullorEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine($"{nameof(nullString)}: {isNullorEmpty}");
            
            isNullorEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine($"{nameof(isNullorEmpty)}: {isNullorEmpty}");
            
            Console.WriteLine();
            
            bool isNullOrEhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine($"{nameof(empty)}: {isNullOrEhiteSpace}");
            
            isNullOrEhiteSpace = string.IsNullOrWhiteSpace(withWhiteSpace);
            Console.WriteLine($"{nameof(withWhiteSpace)}: {isNullOrEhiteSpace}");
            
            isNullOrEhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine($"{nameof(notEmpty)}: {isNullOrEhiteSpace}");
            
            isNullOrEhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine($"{nameof(nullString)}: {isNullOrEhiteSpace}");
            
            Console.ReadKey();
        }
    }
}