namespace Lesson_9_Methods_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Створи метод Swap, який міняє місцями значення двох змінних.
            //Вимоги:
            //Метод має називатися Swap.
            //Метод приймає два параметри з ref.
            int a = 5;
            int b = 10;
            
            Console.WriteLine($"Before Swap a {a} - b {b}");
            
            //Swap();
            Swap(ref a, ref b); // передаеш по посиланню дві змінні

            Console.WriteLine($"Before Swap a {a} - b {b}");
            Console.ReadKey();
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a; // тимчасово записуешь змінну a в temp
            a = b; // потім b в a
            b = temp; // далі temp в b
        }
    }
}