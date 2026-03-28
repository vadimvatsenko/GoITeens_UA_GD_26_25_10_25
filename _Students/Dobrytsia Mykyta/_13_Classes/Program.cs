using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword("Sword", 20, 5, 1);
            Bow bow = new Bow("Bow", 15, 4, 20);
            Poison poison = new Poison("Poison", 8, 10);

            Unit unit = new Unit("Biba", 109, 33, 29);
            Unit unit1 = new Unit("Boba", 141, 11, 35);

            sword.Sharpen();
            bow.Reload();

            unit.TakeWeapon(sword);
            unit.Attack(unit1);
            
            Console.WriteLine();

            unit1.TakeWeapon(bow);
            unit1.Attack(unit);
            
            Console.WriteLine();
            
            Console.ReadKey();
        }
    }

    public class Unit
    {
        private static Random rnd = new Random();
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Defence { get; private set; }
        public int DodgeChance { get; private set; }
        
        public Weapon Weapon {get; private set;}

        public Unit(string name, int health, int defence, int dodgeChance)
        {
            Name = name;
            Health = health;
            Defence = defence;
            DodgeChance = dodgeChance;
        }

        public void TakeDamage(string attacker, int damage, bool ignoreDef = false)
        {
            if (rnd.Next(100) < DodgeChance)
            {
                Console.WriteLine($"{Name} DODGED the attack from {attacker}!");
                return;
            }

            int finalDamage = ignoreDef ? damage : damage - Defence;
            if (finalDamage < 0) finalDamage = 0;

            Health -= finalDamage;
            if (Health < 0) Health = 0;

            if (ignoreDef)
                Console.WriteLine($"{attacker} hit {Name} for {finalDamage} PURE damage");
            else
                Console.WriteLine($"{attacker} hit {Name} for {finalDamage} damage");

            Console.WriteLine($"{Name} health: {Health}");
        }

        public void TakeWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void Attack(Unit unit)
        {
            Weapon.SpecialAtack(unit);
        }
    }

    public class Weapon
    {
        protected static Random rnd = new Random();
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Range { get; private set; }

        protected int fatigue = 0;

        public Weapon(string name, int damage, int range)
        {
            Name = name;
            Damage = damage;
            Range = range;
        }

        protected bool IsCrit()
        {
            return rnd.Next(100) < 30;
        }

        protected int ApplyFatigue(int damage)
        {
            int final = damage - fatigue;
            if (final < 1) final = 1;
            fatigue++;
            return final;
        }

        public virtual void SpecialAtack(Unit unit)
        {
            Console.WriteLine($"{Name} special attack!");

            int dmg1 = ApplyFatigue(Damage * 2);
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }
            unit.TakeDamage(Name, dmg1);
        }
    }

    public class Sword : Weapon
    {
        public int BladeLength { get; private set; }
        public bool IsSharpened { get; private set; }

        public Sword(string name, int damage, int bladeLength, int range)
            : base(name, damage, range)
        {
            BladeLength = bladeLength;
        }

        public void Sharpen()
        {
            if (!IsSharpened)
            {
                Damage += 10;
                IsSharpened = true;
                Console.WriteLine($"{Name} was sharpened!");
            }
        }

        public override void SpecialAtack(Unit unit)
        {
            base.SpecialAtack(unit);
        }
    }

    public class Bow : Weapon
    {
        public int ArrowCount { get; private set; }
        private int _maxArrows;

        public Bow(string name, int damage, int count, int range)
            : base(name, damage, range)
        {
            ArrowCount = count;
            _maxArrows = count;
        }

        public void Reload()
        {
            ArrowCount = _maxArrows;
            Console.WriteLine($"{Name} reloaded!");
        }

        public override void SpecialAtack(Unit unit)
        {
            if (ArrowCount == 0)
            {
                Console.WriteLine("No arrows!");
                return;
            }

            Console.WriteLine($"{Name} arrow rain!");

            int baseDmg = ApplyFatigue(Damage * ArrowCount);

            int dmg1 = baseDmg;
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }
            unit.TakeDamage(Name, dmg1);
            
            ArrowCount = 0;
        }
    }

    public class Poison : Weapon
    {
        public Poison(string name, int damage, int range)
            : base(name, damage, range)
        {
        }

        public override void SpecialAtack(Unit unit)
        {
            Console.WriteLine($"{Name} poison spell!");

            int dmg1 = ApplyFatigue(Damage);
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }
            unit.TakeDamage(Name, dmg1, true);
            
        }
    }
}