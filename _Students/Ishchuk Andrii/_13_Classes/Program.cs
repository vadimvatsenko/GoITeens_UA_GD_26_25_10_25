using System;

class Weapon
{
    private int _damage;
    private int _range;

    public Weapon(int damage, int range)
    {
        _damage = damage;
        _range = range;
    }

    public void Attack(Character target, int distance)
    {
        if (distance <= _range)
        {
            Console.WriteLine("Атака персонажа!");
            target.TakeDamage(_damage);
        }
        else
        {
            Console.WriteLine("Ціль занадто далеко!");
        }
    }

    public void AttackEnemy(Enemy enemy)
    {
        Console.WriteLine("Атака ворога!");
        enemy.TakeDamage(_damage);
    }
}

class Character
{
    private string _name;
    private int _health;

    private Weapon _weapon;

    public string Name
    {
        get => _name;
        set { _name = value; }
    }

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
                _health = 0;
            else
                _health = value;
        }
    }

    public Character(string name, int health)
    {
        _name = name;
        _health = health;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Ім'я: " + Name + " | Здоров'я: " + Health);
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine(Name + " отримав " + damage + " урону!");
    }

    public void UseWeapon(Character enemy, int distance)
    {
        if (_weapon != null)
            _weapon.Attack(enemy, distance);
    }
    
    public void AddWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
}

class Enemy : Character
{
    private string _type;
    public Enemy(string name, int health, string type) : base(name, health)
    {
        _type =  type;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine("Ворог: " + _type + " | Здоров'я: " + Health);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Console.WriteLine("Enemy take damage: " + damage);
    }
}

class Program
{
    static void Main()
    {
        Character hero = new Character("Артур", 100);
        Weapon sword = new Weapon(25, 5);
        Weapon bow = new Weapon(5, 20);

        hero.AddWeapon(sword);
        
        Enemy goblin = new Enemy("Гоблін", 60, "Fly");
        
        hero.DisplayInfo();
        goblin.DisplayInfo();

        Console.WriteLine("Бій почався!");

        hero.UseWeapon(goblin, 5);
        
        hero.AddWeapon(bow);
        
        hero.UseWeapon(goblin, 10);

        goblin.DisplayInfo();
        
        Console.ReadKey();
    }
}