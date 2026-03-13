using  System;


class Program
{
    static void Main(string[] args)
    {
        // Створення персонажа
        Character hero = new Character("Archer", 100);
        hero.DisplayInfo();

        // Створення зброї
        Weapon bow = new Weapon(25, 10);
        hero.EquippedWeapon = bow;

        // Створення ворога
        Enemy goblin = new Enemy("Goblin", 60);
        goblin.DisplayInfo();

        Console.WriteLine("\n--- Battle Start ---");

        // Бій
        hero.UseWeaponOnEnemy(goblin, 5);
        hero.UseWeaponOnEnemy(goblin, 12);
        hero.UseWeaponOnEnemy(goblin, 3);

        Console.WriteLine("\n--- Battle End ---");

        Console.ReadLine();
    }
}

class Weapon
{
    private int _damage;
    private int _range;

    public int Damage
    {
        get => _damage;
        set
        {
            _damage = value < 0 ? 0 : value;
        }
    }

    public int Range
    {
        get => _range;
        set
        {
            _range = value < 0 ? 0 : value;
        }
    }

    public Weapon(int damage, int range)
    {
        Damage = damage;
        Range = range;
    }

    // Атака персонажа
    public void Attack(Character target, int distance)
    {
        if (distance <= Range)
        {
            Console.WriteLine($"Attacking {target.Name} for {Damage} damage!");
            target.TakeDamage(Damage);
        }
        else
        {
            Console.WriteLine("Target is out of range!");
        }
    }

    // Атака ворога
    public void Attack(Enemy target, int distance)
    {
        if (distance <= Range)
        {
            Console.WriteLine($"Attacking enemy {target.Type} for {Damage} damage!");
            target.TakeDamage(Damage);
        }
        else
        {
            Console.WriteLine("Enemy is out of range!");
        }
    }
}

class Character
{
    private string _name; //
    private int _health; //

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
        } 
    }

    public int Health
    {
        get => _health;
        set
        {
            _health = value < 0 ? 0 : value;
        } 
    }

    public Weapon EquippedWeapon { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Character: {Name}, Health: {Health}");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
        }
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }

    public void UseWeaponOnEnemy(Enemy enemy, int distance)
    {
        if (EquippedWeapon != null)
        {
            EquippedWeapon.Attack(enemy, distance);
        }
        else
        {
            Console.WriteLine("No weapon equipped!");
        }
    }
}

class Enemy
{
    private int _health; //

    public string Type { get; }

    public int Health
    {
        get => _health;
        set
        {
            _health = value < 0 ? 0 : value;
        }
    }

    public Enemy(string type, int health)
    {
        Type = type;
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage; //
        Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Enemy: {Type}, Health: {Health}");
    }
}








