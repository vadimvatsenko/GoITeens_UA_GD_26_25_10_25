namespace Lesson_13_Classes_2;

public abstract class Weapon
{
    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public int Range { get; protected set; }

    public Weapon(string name, int damage, int range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public void Attack(Unit attacker, Unit target)
    {
        target.TakeDamage(Damage);
        Console.WriteLine($"{Name} attacked {target.Name} for {Damage} damage");
    }
}