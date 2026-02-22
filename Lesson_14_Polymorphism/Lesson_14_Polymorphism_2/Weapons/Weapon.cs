namespace Lesson_14_Polymorphism_2.Weapons;


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

    public void Attack()
    {
        
    }
    
}