// Форматування строк

namespace Lesson_8_Strings_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Artur";
            int age = 15;
            
            string gender = "male";
            
            
            Console.WriteLine($"My name is {name} and I am {age} years old.");
            Console.WriteLine("My name is {0} and I am {1} years old. {3} ", name, age, gender, "ertrertert");
            Console.WriteLine("My name is {0} and \nI am {1} years old. {3} ", name, age, gender, "ertrertert");
            Console.WriteLine("My name is {0} and \n \tI am {1} years old. {3} ", name, age, gender, "ertrertert");
            Console.WriteLine("My name is {0} \"and\" I am {1} years old. {3} ", name, age, gender, "ertrertert");

            int numb1 = 42;
            
            Console.WriteLine($"{numb1:F1}");
            Console.WriteLine($"{numb1:F2}");
            Console.WriteLine($"{numb1:F3}");
            Console.WriteLine($"{numb1:F4}");
            
            Console.WriteLine($"{numb1:D1}");
            Console.WriteLine($"{numb1:D2}");
            Console.WriteLine($"{numb1:D3}");
            Console.WriteLine($"{numb1:D4}");
            
            Console.ReadKey();
        }
    }
}