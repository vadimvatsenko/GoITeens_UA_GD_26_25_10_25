
using System;


public abstract class Unit
{
    private string _name;
    private int _health;
    
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

    public Unit(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public abstract void EquiptNewWeapon(Weapon weapon);
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} отримав {damage} урону. Здоров'я: {Health}");
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Персонаж: {Name}, Здоров'я: {Health}");
    }
}

public class Character : Unit
{
    public Weapon EquippedWeapon { get; private set; }
    public Character(string name, int health) : base(name, health)
    {
    }
    
    public void UseWeapon(Unit target, int distance)
    {
        EquippedWeapon?.Attack(this, target, distance);
    }

    public override void EquiptNewWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
    }
    
}

public class Enemy : Unit
{
    public Enemy(string name, int health) : base(name, health)
    {
    }

    public override void EquiptNewWeapon(Weapon weapon)
    {
        throw new NotImplementedException();
    }
}

// private
public class Weapon
{
    // private 
    public int Damage { get; private set; }
    public int Range { get; private set; }

    public Weapon(int damage, int range)
    {
        Damage = damage;
        Range = range;
    }

    // дублювання коду
    public void Attack(Unit attacker, Unit damager, int distance)
    {
        if (distance > Range)
        {
            Console.WriteLine("Ціль занадто далеко.");
            return;
        }

        Console.WriteLine($"{attacker.Name} атакує {damager.Name} на {Damage} урону.");
        damager.TakeDamage(Damage);
    }
}


class Program
{
    static void Main()
    {
        Character hero = new Character("Лицар", 100);
        Character ally = new Character("Лучник", 80);
        Enemy enemy = new Enemy("Орк", 120);

        Weapon sword = new Weapon(25, 2);
        Weapon bow = new Weapon(15, 10);

        hero.EquiptNewWeapon(sword);
        ally.EquiptNewWeapon(bow);

        hero.DisplayInfo();
        ally.DisplayInfo();

        hero.UseWeapon(ally, 1);
        ally.UseWeapon(enemy, 5);
        hero.UseWeapon(enemy, 1);
        
        Console.ReadKey();
    }
}

    