namespace Lesson_12_OOP_1;

public class Hero: IHealthable
{
    public HealthComponent HealthComponent { get; set; }
    
    public string Name { get; set; }

    public Hero(string name)
    {
        Name = name;
        HealthComponent = new HealthComponent(100);
    }
}