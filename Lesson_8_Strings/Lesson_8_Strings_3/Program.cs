// Змінення строк

// string.Concat - З'єднає слова разом 
// string.Join З'єднає слова в одне речення через символ
// void Insert
// void Remove(1)
// void Remove(2,6)
// void Replace("V", "W")
// void Split(';') - розділить у масив слова
// void ToCharArray() - розділить строку на массив символів
// void ToLower() ToUpper()
// void Trim()

// List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' }; - ДЗ


namespace Lesson_8_Strings_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = "Nikita";
            string name2 = "Roman";
            
            string nameConcat = string.Concat("Denys", "Tanya", "Vlad", "Mitya", "Egor", name2, name1);
            //Console.WriteLine(nameConcat);
            
            /*nameConcat = string.Join(" ", name1, name2);
            Console.WriteLine(nameConcat);

            nameConcat = nameConcat.Insert(2, " By the way ");
            Console.WriteLine(nameConcat);*/

            nameConcat = nameConcat.Remove(2, 5);
            Console.WriteLine(nameConcat);
            
            string replaced = nameConcat.Replace(name1, "sdfsdfsdfds");
            Console.WriteLine(replaced);

            string data = "15;40;70;100;101;15;16;17;96";
            string[] dataSplit = data.Split(';');

            foreach (string s in dataSplit)
            {
                Console.Write($"{s} ");
            }

            string name = "Tolik";
            char[] chars = name.ToCharArray();

            Console.WriteLine();
            
            foreach (char c in chars)
            {
                Console.Write($"{c} ");
            }
            
            Console.ReadKey();
        }
    }
}