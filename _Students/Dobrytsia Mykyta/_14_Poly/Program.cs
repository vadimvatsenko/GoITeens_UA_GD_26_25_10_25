using System;


class Weapon
{
    public string Name { get; private set; }
    protected int Damage;
    protected int Fatigue = 0;
    protected int FinalDamage;

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public virtual void Attack()
    {
        FinalDamage = Damage - Fatigue;
        if (FinalDamage < 1) FinalDamage = 1;
        Fatigue++;

        Console.WriteLine($"{Name} attacks for {FinalDamage} damage.");
    }

    public virtual void DisplayWeaponStats()
    {
        Console.WriteLine($"Weapon: {Name}, Damage: {Damage}, Fatigue: {Fatigue}");
    }
}
class Sword : Weapon
{
    public float bladeLength;
    public bool isSharpened = false;

    public Sword(string name, int damage, float bladeLength)
        : base(name, damage)
    {
        this.bladeLength = bladeLength;
    }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine($"{Name} slashes with blade ({bladeLength}m) for {FinalDamage} damage.");
        
    }

    public void SpecialAttack()
    {
        int finalDamage = (Damage * 2) - Fatigue;
        if (finalDamage < 1) finalDamage = 1;

        Console.WriteLine($"{Name} performs SPECIAL SLASH for {finalDamage} damage!");
        Fatigue += 2;
    }

    public void Sharpen()
    {
        if (!isSharpened)
        {
            Damage += 5;
            isSharpened = true;
            Console.WriteLine($"{Name} has been sharpened! Damage increased.");
        }
        else
        {
            Console.WriteLine($"{Name} is already sharpened.");
        }
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Blade Length: {bladeLength}, Sharpened: {isSharpened}");
    }
}
class Bow : Weapon
{
    private int _arrowCount;
    private int _maxArrows;

    public Bow(string name, int damage, int arrows)
        : base(name, damage)
    {
        _arrowCount = arrows;
        _maxArrows = arrows;
    }

    public override void Attack()
    {
        if (_arrowCount <= 0)
        {
            Console.WriteLine($"{Name} has no arrows! Reload!");
            return;
        }

        base.Attack();

        Console.WriteLine($"{Name} shoots an arrow ({_arrowCount - 1} left) for {FinalDamage} damage.");
        _arrowCount--;
        
    }

    public void SpecialAttack()
    {
        if (_arrowCount <= 0)
        {
            Console.WriteLine($"{Name} has no arrows for special attack!");
            return;
        }

        int totalDamage = (Damage * _arrowCount) - Fatigue;

        Console.WriteLine($"{Name} fires ALL arrows ({_arrowCount}) for {totalDamage} total damage!");
        _arrowCount = 0;
        Fatigue += 2;
    }

    public void Reload()
    {
        _arrowCount = _maxArrows;
        Console.WriteLine($"{Name} reloaded to {_arrowCount} arrows.");
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Arrows: {_arrowCount}/{_maxArrows}");
    }
}
class Program
{
    static void Main()
    {
        Sword sword = new Sword("Steel Sword", 15, 1.2f);
        Bow bow = new Bow("Hunter Bow", 10, 5);

        Console.WriteLine("=== STATS ===");
        sword.DisplayWeaponStats();
        bow.DisplayWeaponStats();

        Console.WriteLine("\n=== COMBAT ===");

        sword.Attack();
        sword.SpecialAttack();
        sword.Sharpen();
        sword.Attack();

        Console.WriteLine();

        bow.Attack();
        bow.SpecialAttack();
        bow.Reload();
        bow.Attack();

        Console.WriteLine("\n=== FINAL STATS ===");
        sword.DisplayWeaponStats();
        bow.DisplayWeaponStats();
        Console.ReadKey();
    }
}