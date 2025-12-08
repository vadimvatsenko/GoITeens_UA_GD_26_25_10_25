using System;

// Сума всіх чисел у циклі, пояснення
namespace Lesson_5_Cycles_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            
            for (int i = 1; i <= 10; i++)
            {
                sum += sum + i; 
                // sum += i; - синтаксичний цукор
                
                //  1. sum = 0(summ) + 1(i) = 1
                // 2. sum = 1(summ) + 2(i) = 3
                // 3. sum = 3(summ) + 3(i) = 6
                // 4. sum = 6(summ) + 4(i) = 10
                // 5. sum = 10(summ) + 5(i) = 15
                // 6. sum = 15(summ) + 6(i) = 21
                // 7. sum = 21(summ) + 7(i) = 28
                // 8. sum = 28(summ) + 8(i) = 36
                // 9. sum = 36(summ) + 9(i) = 45
                // 10. sum = 45(summ) + 10(i) = 55
            }
            
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}