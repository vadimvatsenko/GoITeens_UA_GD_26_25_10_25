using  System;
namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon("AK-47", 5, 1, 100, 0);
            weapon.Attack();
            Sword sword = new Sword("Sword", 20, 5, 5, 100, 0);
            sword.Attack();
            Bow bow = new Bow("Bow", 40, 20, 50, 100, 0);
            bow.Attack();
            Unit unit = new Unit("Bob", 100);
            sword.SpecialAttack(unit);
            bow.SpecialAttack(unit);
            bow.Reload(unit);
            Console.ReadKey();
        }
    }
    public class Unit
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public Unit(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
            }
            Console.WriteLine($"{Name} damaged {damage}");
            Console.WriteLine($"Health is {Health}");
        }
    }
    public class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Range { get; private set; }
        public int Status { get; private set; } = 100;
        public int StatusVtoma { get; protected set; }
        public Weapon(string name, int damage, int range, int status, int statusVtoma)
        {
            Name = name;
            Damage = damage;
            Range = range;
            Status = status;
            StatusVtoma = statusVtoma;
        }
        public virtual void Attack()
        {
            Console.WriteLine("{0} attacks {1} damage {2} range {3} status", Name, Damage, Range, Status);
        }
        public virtual void SpecialAttack(Unit unit)
        {
            Console.WriteLine($"Weapon {Name} damage {Damage} ");
        }
        public virtual void Vtoma()
        {
            Console.WriteLine($"Weapon have {StatusVtoma}% status inefficiency");
        }
    }
    public class Sword: Weapon
    {
        public int BladeLength { get; private set; }
        public Sword(string name, int damage, int bladelength, int range, int status, int statusVtoma) : base(name, damage, range, status, statusVtoma)
        {
            BladeLength = bladelength;
        }
        public override void Attack()
        {
            StatusVtoma += 15;
            base.Attack();
            base.Vtoma();
            Console.WriteLine($"Blade length is {BladeLength}");
        }
        public override void SpecialAttack(Unit unit)
        {
            base.SpecialAttack(unit);
            int prevdamage = Damage;
            Damage *= 2;
            unit.TakeDamage(Damage);
            Damage = prevdamage;
        }
    }
    public class Bow: Weapon
    {
        public int ArrowCount  { get; private set; }
        public Bow(string name, int damage, int arrowcount, int range, int status, int statusVtoma) : base(name, damage, range, status, statusVtoma)
        {
            ArrowCount = arrowcount;
        }
        public override void Attack()
        {
            StatusVtoma += 10;
            base.Attack();
            base.Vtoma();
            Console.WriteLine($"Arrow count is {ArrowCount}");
        }
        public override void SpecialAttack(Unit unit)
        {
            int maxdamage = Damage * ArrowCount;
            unit.TakeDamage(maxdamage);
            ArrowCount = 0;
        }
        public void Reload(Unit unit)
        {
            ArrowCount = 20;
        }
    }
}