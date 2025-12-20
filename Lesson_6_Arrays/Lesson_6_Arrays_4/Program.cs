// Дано масив рядків {"Hello", "it", "is", "me"}. 
// Зробіть так, щоб у кінець кожного слова додався знак оклику. ['Hello!', 'it!', 'is!', 'me!'],


namespace Lesson_6_Arrays_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "Hello", "it", "is", "me" };
            string space = " ";

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += '!';
                
            }
            
            string line = arr[0];

            for (int i = 0; i < arr.Length - 1; i+=2)
            {
                line += space + arr[i + 1];
            }

            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
            
            Console.WriteLine(line);
        }
    }
}