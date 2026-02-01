namespace Lesson_12_OOP_1;

public class HealthComponent
{
    private int _health;
    private int _maxHealth;

    public int Health => _health;

    public HealthComponent(int health)
    {
        _health = health;
        _maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
        }
    }

    public void Heal(int heal)
    {
        _health += heal;
    }
}