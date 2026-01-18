namespace Lesson_9_Methods_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10; // обов
            Function(ref number1);
        }

        static void Function(ref int number)
        {
            number += number;
        }
    }
}