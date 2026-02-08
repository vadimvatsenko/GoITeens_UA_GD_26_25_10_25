namespace Lesson_12_OOP_3;

public class Car
{
    public string Name { get; private set; } 
    public string Color {get; private set;}
    public int Age {get; private set;}

    public Car(string name, string color, int age)
    {
        Name = name;
        Color = color;
        Age = age;
    }

    public string GetName()
    {
        return Name;
    }
    
    public void ChangeColor(string color)
    {
        Color = color;
    }

    public void ChangeAge(int age)
    {
        Age = age;
    }
    
    public void ChangeName(string name)
    {
        Name = name;
        
    }

    public void PrintCar()
    {
        Console.WriteLine($"{Name}, {Color}, {Age}");
    }
}
    