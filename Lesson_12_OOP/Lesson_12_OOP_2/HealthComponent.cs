namespace Lesson_12_OOP_2;

public class HealthComponent
{
    private int _health;
    private int _maxHealth = 100;
    public HealthComponent(int health)
    {
        
    }

    public void Damage(int damage)
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
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}