namespace Lesson_12_OOP_2;

public class HealthComponent
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public HealthComponent(int health, int maxHealth)
    {
        Health = health;
        MaxHealth = maxHealth;
    }

    public void TakeDamage(int damage)
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

    public void BuffHealth(int buff)
    {
        MaxHealth += buff;
        Health = MaxHealth;
    }
}