













// Завдання 9: Впровадження Втоми від Використання Зброї
// Розширте клас Weapon механізмом втоми, який зменшує ефективність атаки з кожним використанням.

//(Додатково) Завдання 10: Візуалізація Бою
//Створіть просту симуляцію бою, де персонажі з різними типами зброї (меч, лук)
//використовують стандартні та спеціальні атаки, демонструючи різницю в ефективності та стратегії бою.


using System;
namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword("Sword", 20, 10, 2);
            Unit unit = new Unit("Bob", 100, 50, 50);
            
            sword.Attack(unit);
            sword.Attack(unit);
            
            /*Sword sword = new Sword("Sword", 20, 5, 1);
            Bow bow = new Bow("Bow", 15, 4, 20);
            Poison poison = new Poison("Poison", 8, 10);

            Unit unit = new Unit("Biba", 109, 33, 29);
            Unit unit1 = new Unit("Boba", 141, 11, 35);

            sword.SpecialAtack(unit, unit1);
            Console.WriteLine();

            bow.SpecialAtack(unit, unit1);
            Console.WriteLine();

            poison.SpecialAtack(unit, unit1);*/

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
                Console.WriteLine($"{attacker} hit {Name} for {finalDamage} PURE damage (def ignored)");
            else
                Console.WriteLine($"{attacker} hit {Name} for {finalDamage} damage (def: {Defence})");
            Console.WriteLine($"{Name} health: {Health}");
        }
    }

    // OK
    // Завдання 1: Основи Класу "Зброя"
    // Розробіть базовий клас Weapon з властивостями name, damage, та методом Attack(), який друкує базовий опис атаки.
    
    // OK
    // Завдання 4: Розширення Класу "Зброя"
    // Додайте до класу Weapon новий метод DisplayWeaponStats(), який виводить усі характеристики зброї, включаючи назву, шкоду, та інші специфічні властивості.
    public class Weapon
    {
        protected static Random rnd = new Random();
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Range { get; private set; }

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

        public virtual void Attack(Unit unit)
        {
            unit.TakeDamage(Name, Damage);
        }

        public virtual void DisplayWeaponStats()
        {
            Console.WriteLine($"Name {Name}");
            Console.WriteLine($"Damage {Damage}");
            Console.WriteLine($"Range {Range}");
        }
        
        public virtual void SpecialAtack(Unit unit) { }
    }
    
    // OK
    //Завдання 2: Створення Класу "Меч"
    //Розробіть клас Sword, який успадковує від Weapon, додає властивість bladeLength, та перевизначає метод Attack() для включення деталей про довжину леза.
    
    // OK
    // Завдання 5: Спеціальна Атака для "Меча"
    // Розширте клас Sword методом SpecialAttack(), який реалізує унікальну атаку, наносячи подвійну шкоду.
    
    // OK
    // Завдання 7: Додавання Властивостей Модифікації
    // Включіть до класу Sword властивість isSharpened та метод Sharpen(), який збільшує шкоду меча.
    public class Sword : Weapon
    {
        public int BladeLength { get; private set; }

        private bool _isSharpened = false;
        private int _healthSword = 100;

        public Sword(string name, int damage, int bladeLength, int range)
            : base(name, damage, range)
        {
            BladeLength = bladeLength;
        }

        public override void Attack(Unit unit)
        {
            
            if(_isSharpened) return;
            _healthSword -= new Random().Next(1, 55);
            
            base.Attack(unit);
            
            CheckHealthSword();
        }

        private void Sharpen() => _isSharpened = true;
        
        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Blade length {BladeLength}");
        }

        public override void SpecialAtack(Unit unit)
        {
            if(_isSharpened) return;
            
            Console.WriteLine($"{Name} special attack!");
            
            int dmg1 = Damage * 2;
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }

            unit.TakeDamage(Name, dmg1);
            
            _healthSword -= new Random().Next(1, 55);

            CheckHealthSword();
        }

        private void CheckHealthSword()
        {
            if (_healthSword <= 0)
            {
                _isSharpened = false;
                _healthSword = 0;
            }
        }
    }

    // OK
    // Завдання 3: Створення Класу "Лук"
    // Створіть клас Bow на основі Weapon, із додаванням властивості arrowCount та перевизначенням методу Attack() для показу кількості стріл.
    
    // OK
    // Завдання 6: Спеціальна Атака для "Лука"
    // Реалізуйте в класі Bow метод SpecialAttack(), що дозволяє випустити всі стріли одночасно для масової атаки.
    
    // Завдання 8: Розробка Системи Перезарядки для "Лука"
    // Додайте до класу Bow метод Reload(), що збільшує arrowCount до початкової кількості стріл.
    public class Bow : Weapon
    {
        public int ArrowCount { get; private set; }
        public int MaxArrowCount { get; private set; } = 20;
        
        public Bow(string name, int damage, int count, int range)
            : base(name, damage, range)
        {
            ArrowCount = count;
        }

        public override void Attack(Unit unit)
        {
            if(ArrowCount <= 0) return;
            base.Attack(unit);
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Arrow count: {ArrowCount}");
        }

        public override void SpecialAtack(Unit unit)
        {
            if(ArrowCount <= 0) return;
            
            Console.WriteLine($"{Name} arrow rain!");
            
            int baseDmg = Damage * ArrowCount;

            int dmg1 = baseDmg;
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }
            unit.TakeDamage(Name, dmg1);
            
            ArrowCount = 0;
        }

        public void Reload() => ArrowCount =  MaxArrowCount;
        
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

            int dmg1 = Damage;
            if (IsCrit())
            {
                dmg1 *= 5;
                Console.WriteLine($"{unit.Name} received CRIT!");
            }
            unit.TakeDamage(Name, dmg1, true);
        }
    }
}