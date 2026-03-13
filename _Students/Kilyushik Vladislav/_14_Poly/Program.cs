namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
        }
    }
}


/*
public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public virtual void Attack()
    {
        Console.WriteLine($"{Name} завдає {Damage} шкоди.");
    }

    public virtual void DisplayWeaponStats()
    {
        Console.WriteLine($"Назва: {Name}, Шкода: {Damage}");
    }
}
public class Sword : Weapon
{
    public int BladeLength { get; set; }
    public bool IsSharpened { get; private set; }

    public Sword(string name, int damage, int bladeLength)
        : base(name, damage)
    {
        BladeLength = bladeLength;
        IsSharpened = false;
    }

    public override void Attack()
    {
        Console.WriteLine($"{Name} атакує мечем довжиною {BladeLength} см, шкода: {Damage}");
    }

    public void SpecialAttack()
    {
        Console.WriteLine($"{Name} виконує спеціальну атаку! Подвійна шкода: {Damage * 2}");
    }

    public void Sharpen()
    {
        if (!IsSharpened)
        {
            Damage += 10;
            IsSharpened = true;
            Console.WriteLine($"{Name} був нагострений. Шкода тепер: {Damage}");
        }
        else
        {
            Console.WriteLine($"{Name} вже гострий.");
        }
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Довжина леза: {BladeLength}, Гострий: {IsSharpened}");
    }
}
public class Bow : Weapon
{
    public int ArrowCount { get; private set; }
    private int maxArrows;

    public Bow(string name, int damage, int arrowCount)
        : base(name, damage)
    {
        ArrowCount = arrowCount;
        maxArrows = arrowCount;
    }

    public override void Attack()
    {
        if (ArrowCount > 0)
        {
            ArrowCount--;
            Console.WriteLine($"{Name} випускає стрілу. Залишилось стріл: {ArrowCount}, шкода: {Damage}");
        }
        else
        {
            Console.WriteLine($"{Name} не має стріл!");
        }
    }

    public void SpecialAttack()
    {
        if (ArrowCount > 0)
        {
            Console.WriteLine($"{Name} випускає всі {ArrowCount} стріли одночасно! Загальна шкода: {Damage * ArrowCount}");
            ArrowCount = 0;
        }
        else
        {
            Console.WriteLine("Немає стріл для спеціальної атаки!");
        }
    }

    public void Reload()
    {
        ArrowCount = maxArrows;
        Console.WriteLine($"{Name} перезаряджено. Стріл тепер: {ArrowCount}");
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Кількість стріл: {ArrowCount}/{maxArrows}");
    }
}
public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public virtual void Attack()
    {
        Console.WriteLine($"{Name} завдає {Damage} шкоди.");
    }

    public virtual void DisplayWeaponStats()
    {
        Console.WriteLine($"Назва: {Name}, Шкода: {Damage}");
    }
}
public class Sword : Weapon
{
    public int BladeLength { get; set; }

    public Sword(string name, int damage, int bladeLength)
        : base(name, damage)
    {
        BladeLength = bladeLength;
    }

    public override void Attack()
    {
        Console.WriteLine($"{Name} атакує мечем довжиною {BladeLength} см, шкода: {Damage}");
    }

    public void SpecialAttack()
    {
        Console.WriteLine($"{Name} виконує спеціальну атаку! Подвійна шкода: {Damage * 2}");
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Довжина леза: {BladeLength}");
    }
}
public class Bow : Weapon
{
    public int ArrowCount { get; private set; }
    private int maxArrows;

    public Bow(string name, int damage, int arrowCount)
        : base(name, damage)
    {
        ArrowCount = arrowCount;
        maxArrows = arrowCount;
    }

    public override void Attack()
    {
        if (ArrowCount > 0)
        {
            ArrowCount--;
            Console.WriteLine($"{Name} випускає стрілу. Залишилось стріл: {ArrowCount}, шкода: {Damage}");
        }
        else
        {
            Console.WriteLine($"{Name} не має стріл!");
        }
    }

    public void SpecialAttack()
    {
        if (ArrowCount > 0)
        {
            Console.WriteLine($"{Name} випускає всі {ArrowCount} стріли одночасно! Загальна шкода: {Damage * ArrowCount}");
            ArrowCount = 0;
        }
        else
        {
            Console.WriteLine("Немає стріл для спеціальної атаки!");
        }
    }

    public void Reload()
    {
        ArrowCount = maxArrows;
        Console.WriteLine($"{Name} перезаряджено. Стріл тепер: {ArrowCount}");
    }

    public override void DisplayWeaponStats()
    {
        base.DisplayWeaponStats();
        Console.WriteLine($"Кількість стріл: {ArrowCount}/{maxArrows}");
    }
}
public class Sword : Weapon
{
    public int BladeLength { get; set; }
    public bool IsSharpened { get; private set; }

    public Sword(string name, int damage, int bladeLength)
        : base(name, damage)
    {
        BladeLength = bladeLength;
        IsSharpened = false;
    }

    public void Sharpen()
    {
        if (!IsSharpened)
        {
            Damage += 10;
            IsSharpened = true;
            Console.WriteLine($"{Name} був нагострений. Шкода тепер: {Damage}");
        }
        else
        {
            Console.WriteLine($"{Name} вже гострий.");
        }
    }
}
public void Reload()
{
    ArrowCount = maxArrows;
    Console.WriteLine($"{Name} перезаряджено. Стріл тепер: {ArrowCount}");
}
public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    private double fatigue = 1.0;

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public virtual void Attack()
    {
        int effectiveDamage = (int)(Damage * fatigue);
        Console.WriteLine($"{Name} атакує. Ефективна шкода: {effectiveDamage}");
        fatigue -= 0.1;
        if (fatigue < 0.5) fatigue = 0.5; // мінімум 50% ефективності
    }

    public virtual void DisplayWeaponStats()
    {
        Console.WriteLine($"Назва: {Name}, Базова шкода: {Damage}, Ефективність: {fatigue * 100}%");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Sword sword = new Sword("Меч Лицаря", 30, 80);
        Bow bow = new Bow("Лук Ельфа", 15, 5);

        Console.WriteLine("=== Початок бою ===");
        sword.DisplayWeaponStats();
        bow.DisplayWeaponStats();

        sword.Attack();
        sword.SpecialAttack();
        sword.Sharpen();
        sword.Attack();

        bow.Attack();
        bow.SpecialAttack();
        bow.Reload();
        bow.Attack();

        Console.WriteLine("=== Кінець бою ===");
    }
}
*/
