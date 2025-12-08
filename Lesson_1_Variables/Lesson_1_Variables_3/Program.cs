using System;  

public class Program  
{  
    static void Main(string[] args)  
    {        
        string name;  // Оголошення пустої текстової змінної
        int age;  // Оголошення пустої цілочисельної змінної
        
        Console.WriteLine("Enter Your Name: ");
        Console.WriteLine(); 
        name = Console.ReadLine(); // Те що ввів у консоль, запишеться у змінну name
        
        Console.WriteLine("Enter Your Age: ");
        age = int.Parse(Console.ReadLine()); // Те що ввів у консоль, запишеться у змінну age
        // чому int.Parse(Console.ReadLine()) - метод int.Parse у int переводить строку у число.
        
        Console.WriteLine($"My name is {name}, I am {age} years old.");  
  
        Console.ReadKey();  
    }
}