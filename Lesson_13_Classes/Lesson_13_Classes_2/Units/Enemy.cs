namespace Lesson_13_Classes_2;

public class Enemy : Unit
{
    public int Damage { get; private set; }
    
    public Enemy(string name, int startedHealth, int damage) : base(name, startedHealth)
    {
        Damage = damage;
    }

    public override void Attack(Unit unit)
    {
        base.Attack(unit);
        unit.TakeDamage(Damage);
    }
}