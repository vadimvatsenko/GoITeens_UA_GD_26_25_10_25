using System;
using System.Diagnostics;

// 
// int inx = Array.BinarySearch(numbers, 7); // шукає в масиві numbers індекс числа 7 
// Array.Copy(numbers, copy, numbers.Length); // копіює масив numbers в масив copy де numbers.Length - це довжина елементів, в даному випадку всі елементи скопіювати
// Array.Reverse(numbers) // інверсія масиву
// Array.Sort(numbers) // сортує масив
// Array.IndexOf(masiv, value) - знаходить індекс першого входження значення.
// довжина масиву Length
// останній елемент масиву ?
// копіювання масиву. 
// Силочний тип даних

namespace Lesson_6_Arrays_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char[,] matrix = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#' }, 
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '@', ' ', '#', ' ', ' ', '#' },
                { '#', ' ', ' ', '#', ' ', ' ', '#' },
                { '#', ' ', ' ', '#', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', '&', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#' },
            };
            

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write(matrix[x, y]);
                }
                
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}

    


