// Дано масив розмірністю 10, випадково заповнений числами від -10 до 10. 
// Помножте кожен елемент масиву на 2 і виведіть масив на екран.

using System;

class ConsoleApp11
{
    static void Main()
    {
        int[] array = new int[10];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10, 11);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= 2;
            Console.Write(array[i] + " ");
        }
    }
}


