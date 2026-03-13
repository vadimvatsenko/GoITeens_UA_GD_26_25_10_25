using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; }

    public Student(string name)
    {
        Name = name;
        Grades = new List<int>();
    }

    public double GetAverage()
    {
        if (Grades.Count == 0) return 0;
        double sum = 0;
        foreach (int grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Олексій"),
            new Student("Марія"),
            new Student("Іван"),
            new Student("Софія")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Список студентів:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name} (Середня оцінка: {students[i].GetAverage():0.00})");
            }

            Console.WriteLine("\nВиберіть студента для виставлення оцінки (0 для виходу):");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > students.Count)
            {
                Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                Console.ReadKey();
                continue;
            }

            if (choice == 0)
                break;

            Student selectedStudent = students[choice - 1];

            Console.WriteLine($"Введіть оцінку для {selectedStudent.Name} (1-12):");
            if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 1 || grade > 12)
            {
                Console.WriteLine("Невірна оцінка, спробуйте ще раз.");
                Console.ReadKey();
                continue;
            }

            selectedStudent.Grades.Add(grade);
            Console.WriteLine($"Оцінка {grade} додана для {selectedStudent.Name}.");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }

        Console.WriteLine("Гра завершена. Середні оцінки студентів:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: {student.GetAverage():0.00}");
        }
    }
}