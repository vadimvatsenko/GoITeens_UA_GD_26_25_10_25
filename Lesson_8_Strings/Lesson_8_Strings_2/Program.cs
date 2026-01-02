// Пустота строк

namespace Lesson_8_Strings_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string empty = "";
            string withSpace = " ";
            string notEmpty = " a";
            string nullString = null;
            
            Console.WriteLine("=========isNullOrEmpty===========");
            
            bool isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine($"{nameof(empty)} is {isNullOrEmpty}");
            
            isNullOrEmpty = string.IsNullOrEmpty(withSpace);
            Console.WriteLine($"{nameof(withSpace)} is {isNullOrEmpty}");
            
            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine($"{nameof(notEmpty)}  is {isNullOrEmpty}");
            
            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine($"{nameof(nullString)}  is {isNullOrEmpty}");
            
            Console.WriteLine("=========IsNullOrWhiteSpace===========");
            
            // якщо у строкі є пробіл, то строка пуста
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine($"{nameof(empty)} is {isNullOrWhiteSpace}");
            
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(withSpace);
            Console.WriteLine($"{nameof(withSpace)} is {isNullOrWhiteSpace}");
            
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine($"{nameof(notEmpty)}  is {isNullOrWhiteSpace}");
            
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine($"{nameof(nullString)}  is {isNullOrWhiteSpace}");
            
            Console.ReadKey();
        }
    }
}