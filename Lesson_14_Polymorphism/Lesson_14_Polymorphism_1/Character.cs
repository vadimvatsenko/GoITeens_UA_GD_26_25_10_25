namespace Lesson_14_Polymorphism_1;

public abstract class Character
{
    public int Health {get; private set;}
    public int Strength {get; private set;}

    public Character(int health, int strength)
    {
        Health = health;
        Strength = strength;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    
    public virtual void Attack()
    {
        Console.WriteLine("Attacking...");
    }

    public virtual void Move()
    {
        Console.WriteLine("Moveing...");
    }
}

public class Warrior : Character
{
    public string WarriorType {get; private set;}
    public int ArmorLevel {get; private set;}
    public Warrior(int health, int strength, string warriorType, int armorLevel) 
        : base(health, strength)
    {
        WarriorType = warriorType;
        ArmorLevel = armorLevel;
    }

    public override void Attack()
    {
        //base.Attack(); 
        Console.WriteLine($"Warrior, attacking {WarriorType}..., Armor - {ArmorLevel}");
        
        //BerserkMode();
    }

    private void BerserkMode()
    {
        Console.WriteLine("Berserk mode...");
    }

    public void AddArmorLevel(int level)
    {
        ArmorLevel += level;
    }
}

public class Mage : Character
{
    public int ManaLevel {get; private set;}
    
    public Mage(int health, int strength, int manaLevel) : base(health, strength)
    {
        ManaLevel = manaLevel;
    }

    public override void Attack()
    {
        base.Attack(); 
        Console.WriteLine($"Spell mana {ManaLevel}.");
    }

    public void CastSpell()
    {
        Console.WriteLine("Casting spell...");
    }
}