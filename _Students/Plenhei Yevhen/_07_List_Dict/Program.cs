using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1 ОК
        // Зчитуємо рядок з номерами клітинок
        Console.WriteLine("Введіть номери клітинок зі скарбами (через пробіл):");
        string input = Console.ReadLine();

        // Список скарбів
        List<int> treasures = new List<int>();

        // Розбиваємо рядок і додаємо числа до списку
        string[] parts = input.Split(' ');
        foreach (string part in parts)
        {
            treasures.Add(int.Parse(part));
        }

        // Виводимо список скарбів
        Console.WriteLine("Скарби: " + string.Join(", ", treasures));
        
        Console.ReadKey();
    }
}