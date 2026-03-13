using System;
using System.Collections.Generic;

class Program
{
    class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }
    }

    static void Main()
    {
        List<Student> students = new List<Student>();
        Console.WriteLine("Вітаємо у грі-симуляторі вчителя!");

        Console.Write("Скільки учнів у класі? ");
        int numStudents;
        while (!int.TryParse(Console.ReadLine(), out numStudents) || numStudents <= 0)
        {
            Console.Write("Будь ласка, введіть правильне число учнів: ");
        }
        
        for (int i = 0; i < numStudents; i++)
        {
            Console.Write($"\nВведіть ім'я учня #{i + 1}: ");
            string name = Console.ReadLine();

            int grade;
            Console.Write($"Введіть оцінку для {name} (0-100): ");
            while (!int.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
            {
                Console.Write("Неправильна оцінка. Введіть число від 0 до 100: ");
            }

            students.Add(new Student { Name = name, Grade = grade });
        }
        
        Console.WriteLine("\nОцінки учнів:");
        int total = 0;
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: {student.Grade}");
            total += student.Grade;
        }

        double average = (double)total / students.Count;
        Console.WriteLine($"\nСередня оцінка класу: {average:F2}");

        Console.WriteLine("\nДякуємо за гру!");
    }
}