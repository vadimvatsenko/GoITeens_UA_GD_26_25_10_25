namespace WeaponsGame
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        protected int fatigueLevel = 0;          
        protected int fatigueIncrease = 1;       
        protected int maxFatigue = 5;            

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        protected int GetEffectiveDamage()
        {
            int effectiveDamage = Damage - fatigueLevel;
            return effectiveDamage > 0 ? effectiveDamage : 1;
        }

        public virtual void Attack()
        {
            int effectiveDamage = GetEffectiveDamage();
            Console.WriteLine($"{Name} атакує та наносить {effectiveDamage} шкоди.");
            IncreaseFatigue();
        }

        protected void IncreaseFatigue()
        {
            if (fatigueLevel < maxFatigue)
                fatigueLevel += fatigueIncrease;
        }

        public virtual void DisplayWeaponStats()
        {
            Console.WriteLine(" Характеристики зброї ");
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($"Базова шкода: {Damage}");
            Console.WriteLine($"Поточна втома: {fatigueLevel}");
        }
    }
    
    public class Sword : Weapon
    {
        public double BladeLength { get; set; }
        public bool IsSharpened { get; private set; }

        public Sword(string name, int damage, double bladeLength)
            : base(name, damage)
        {
            BladeLength = bladeLength;
            IsSharpened = false;
        }

        public override void Attack()
        {
            int effectiveDamage = GetEffectiveDamage();
            Console.WriteLine($"{Name} (меч, довжина леза {BladeLength} см) атакує та наносить {effectiveDamage} шкоди.");
            IncreaseFatigue();
        }

        public void SpecialAttack()
        {
            int specialDamage = GetEffectiveDamage() * 2;
            Console.WriteLine($"{Name} виконує СПЕЦІАЛЬНУ атаку та наносить {specialDamage} шкоди.");
            IncreaseFatigue();
        }

        public void Sharpen()
        {
            if (!IsSharpened)
            {
                Damage += 5;
                IsSharpened = true;
                Console.WriteLine($"{Name} був нагострений. Шкода збільшена.");
            }
            else
            {
                Console.WriteLine($"{Name} вже нагострений.");
            }
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Довжина леза: {BladeLength} см");
            Console.WriteLine($"Нагострений: {IsSharpened}");
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
                int effectiveDamage = GetEffectiveDamage();
                Console.WriteLine($"{Name} стріляє. Залишилось стріл: {--ArrowCount}. Шкода: {effectiveDamage}");
                IncreaseFatigue();
            }
            else
            {
                Console.WriteLine($"{Name} не має стріл. Потрібна перезарядка.");
            }
        }

        public void SpecialAttack()
        {
            if (ArrowCount > 0)
            {
                int totalDamage = GetEffectiveDamage() * ArrowCount;
                Console.WriteLine($"{Name} випускає ВСІ стріли ({ArrowCount}) одночасно. Загальна шкода: {totalDamage}");
                ArrowCount = 0;
                IncreaseFatigue();
            }
            else
            {
                Console.WriteLine($"{Name} не має стріл для спеціальної атаки.");
            }
        }

        public void Reload()
        {
            ArrowCount = maxArrows;
            Console.WriteLine($"{Name} перезаряджено. Кількість стріл відновлена до {ArrowCount}.");
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Кількість стріл: {ArrowCount}/{maxArrows}");
        }
    }

    // Приклад
    class Program
    {
        static void Main(string[] args)
        {
            Sword sword = new Sword("Меч", 20, 100);
            Bow bow = new Bow("Довгий лук", 15, 5);

            sword.DisplayWeaponStats();
            sword.Attack();
            sword.Sharpen();
            sword.SpecialAttack();
            Console.WriteLine();

            bow.DisplayWeaponStats();
            bow.Attack();
            bow.SpecialAttack();
            bow.Reload();
        }
    }
}