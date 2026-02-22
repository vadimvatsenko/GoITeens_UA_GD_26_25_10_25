using System.Reflection.Metadata;

namespace Lesson_14_Polymorphism_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HealthComponent healthComponent1 = new HealthComponent(100, 100);
            HealthComponent healthComponent2 = new HealthComponent(100, 100);

            Unit warrior1 = new Warrior(healthComponent1, "warrior1");
            Unit warrior2 = new Warrior(healthComponent2, "warrior2");
            
            warrior1.Attack(warrior2);
        }
    }

    public class HealthComponent
    {
        private int _health;
        private int _maxHealth;
        
        public int Health => _health;
        public int MaxHealth => _maxHealth;

        public HealthComponent(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }
        
        public  void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
            }
        }
        
        public void  Heal(int heal)
        {
            _health += heal;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
    }
    
    public abstract class Unit
    {
        private readonly HealthComponent _healthComponent;
        private readonly Weapon _weapon;
        private string _name;
        public string Name => _name;
        public HealthComponent HealthComponent => _healthComponent;
        
        public Unit(HealthComponent healthComponent,  string name)
        {
            _healthComponent = healthComponent;
            _name = name;
        }
        
        public virtual void Attack(Unit damager)
        {
            _weapon.Attack(this, damager);
            Console.WriteLine($"name {typeof(Unit)} is attacking");
        }
    }

    public class Weapon
    {
        private int _power;

        public void Attack(Unit attacker, Unit damager)
        {
            Console.WriteLine($"{attacker.Name} is attacking {damager.Name} ");
            damager.HealthComponent.TakeDamage(_power);
        }
    }

    public class Warrior : Unit
    {
        
        public Warrior(HealthComponent healthComponent, string name) : base(healthComponent, name)
        {
        }
    }
}