// Порівняння

using System.Text;

namespace Lesson_8_Strings_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  
            Console.InputEncoding  = Encoding.UTF8; 
            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ua-UA");
            
            string str1 = " Привіт";
            string str2 = "приВіт ";
            
            Console.WriteLine(str1 ==  str2);
            bool isEqual5 = string.Equals(str1.ToLower().Trim(), str2.ToLower().Trim());
            Console.WriteLine(isEqual5);
            
            Console.WriteLine("Enter \"привіт\" ");
            string str3 = Console.ReadLine();
            
            Console.WriteLine(str3);
            
            bool isInputEqualsStr1 = str1.Equals(str3);
            Console.WriteLine(isInputEqualsStr1);
            
            bool isEqual = str1.Equals(str2);
            bool isEqual2 = str1 == str2;
            bool isEqual3 = string.Equals(str1, str2);
            
            bool isEqual4 = string.Equals(str1, str2);
            
            //Console.WriteLine(isEqual5);
            
            Console.ReadKey();
        }
    }
}