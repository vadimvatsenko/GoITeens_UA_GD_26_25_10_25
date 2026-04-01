namespace Hearthstone;

public class HealthComponent
{
    public int Health { get; private set; }
    public bool IsAlive = true;

    public HealthComponent(int health)
    {
        Health = health;
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            IsAlive = false;
        }
    }
}