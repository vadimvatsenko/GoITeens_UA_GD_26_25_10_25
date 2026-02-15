namespace Lesson_13_Classes_2;

public class Unit
{
    public string Name { get; protected set; }
    public HealthComponent HealthComponent { get; protected set; }

    public bool IsDead => HealthComponent.CurrentHealth <= 0;
    
    public Unit(string name, int startedHealth)
    {
        Name = name;
        HealthComponent = new HealthComponent(startedHealth, startedHealth);
    }

    public void TakeDamage(int damage) => HealthComponent.TakeDamage(damage);
    public void Heal(int heal) => HealthComponent.Heal(heal);

    public virtual void Attack(Unit unit)
    {
        Console.WriteLine($"{Name} attacked {unit.Name}");
    }
}