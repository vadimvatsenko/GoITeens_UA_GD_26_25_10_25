namespace Lesson_12_OOP_2;

public class HealthComponent
{
    public int Health {get; private set;}
    public int MaxHealth {get; private set;}
    public HealthComponent(int health)
    {
        Health = health;
    }

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public void Heal(int heal)
    {
        Health += heal;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}