namespace Lesson_12_OOP_1;

public abstract class Animal : IHealthable
{
    public HealthComponent HealthComponent { get; set; }
    public string Name {get; set;}
    public int Age {get; protected set;}

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
        HealthComponent = new HealthComponent(100);
    }
    
    public abstract void Say();
    public abstract void Eat();
    public abstract void Walk();
    
}