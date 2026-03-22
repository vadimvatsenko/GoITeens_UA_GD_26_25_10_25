using System;

namespace WeaponsGame
{
    class Weapon
    {
        public string name;
        public int damage;
        protected int fatigue = 0;

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public virtual void Attack()
        {
            int realDamage = damage - fatigue;
            if (realDamage < 1) realDamage = 1;
            Console.WriteLine($"{name} атакує і наносить {realDamage} шкоди.");
            fatigue++;
        }

        public virtual void DisplayWeaponStats()
        {
            Console.WriteLine($"Зброя: {name}");
            Console.WriteLine($"Шкода: {damage}");
        }
    }

    class Sword : Weapon
    {
        public int bladeLength;
        public bool isSharpened = false;

        public Sword(string name, int damage, int bladeLength) : base(name, damage)
        {
            this.bladeLength = bladeLength;
        }

        public override void Attack()
        {
            int realDamage = damage - fatigue;
            if (realDamage < 1) realDamage = 1;
            Console.WriteLine($"Меч {name} атакує. Довжина леза: {bladeLength}. Шкода: {realDamage}");
            fatigue++;
        }

        public void SpecialAttack()
        {
            Console.WriteLine($"Спеціальна атака мечем! Шкода: {damage * 2}");
        }

        public void Sharpen()
        {
            if (!isSharpened)
            {
                damage += 5;
                isSharpened = true;
            }
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Довжина леза: {bladeLength}");
            Console.WriteLine($"Заточений: {isSharpened}");
        }
    }

    class Bow : Weapon
    {
        public int arrowCount;
        private int maxArrows;

        public Bow(string name, int damage, int arrows) : base(name, damage)
        {
            arrowCount = arrows;
            maxArrows = arrows;
        }

        public override void Attack()
        {
            if (arrowCount > 0)
            {
                int realDamage = damage - fatigue;
                if (realDamage < 1) realDamage = 1;

                Console.WriteLine($"Лук {name} стріляє. Стріл залишилось: {arrowCount - 1}. Шкода: {realDamage}");
                arrowCount--;
                fatigue++;
            }
            else
            {
                Console.WriteLine("Немає стріл!");
            }
        }

        public void SpecialAttack()
        {
            if (arrowCount > 0)
            {
                Console.WriteLine($"Масова атака! Випущено {arrowCount} стріл.");
                arrowCount = 0;
            }
        }

        public void Reload()
        {
            arrowCount = maxArrows;
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Стріли: {arrowCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword("Екскалібур", 10, 100);
            Bow bow = new Bow("Ельфійський лук", 8, 5);

            sword.DisplayWeaponStats();
            sword.Attack();
            sword.SpecialAttack();
            sword.Sharpen();
            sword.DisplayWeaponStats();

            Console.WriteLine();

            bow.DisplayWeaponStats();
            bow.Attack();
            bow.SpecialAttack();
            bow.Reload();
            bow.DisplayWeaponStats();
        }
    }
}