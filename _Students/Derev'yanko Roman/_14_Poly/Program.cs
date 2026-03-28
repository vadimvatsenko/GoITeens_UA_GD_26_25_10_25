using System;












namespace WeaponsGame
{
    // OK
    //Завдання 1: Основи Класу "Зброя"
    //Розробіть базовий клас Weapon з властивостями name, damage, та методом Attack(), який друкує базовий опис атаки.
    // OK
    //Завдання 4: Розширення Класу "Зброя"
    //Додайте до класу Weapon новий метод DisplayWeaponStats(), який виводить усі характеристики зброї, включаючи назву, шкоду, та інші специфічні властивості.
    
    //Завдання 9: Впровадження Втоми від Використання Зброї
    //Розширте клас Weapon механізмом втоми, який зменшує ефективність атаки з кожним використанням.
    class Weapon
    {
        protected string Name;
        protected int Damage;
        protected int Fatigue = 0;

        public Weapon(string name, int damage)
        {
            Name = name; 
            Damage = damage;
        }

        public virtual void Attack()
        {
            int realDamage = Damage - Fatigue;
            if (realDamage < 1) realDamage = 1;
            
            Console.WriteLine($"{Name} атакує і наносить {realDamage} шкоди.");
            Fatigue++;
        }

        public virtual void DisplayWeaponStats()
        {
            Console.WriteLine($"Зброя: {Name}");
            Console.WriteLine($"Шкода: {Damage}");
        }
    }

    // OK
    //Завдання 2: Створення Класу "Меч"
    //Розробіть клас Sword, який успадковує від Weapon, додає властивість bladeLength, та перевизначає метод Attack()
    //для включення деталей про довжину леза.
    
    // OK
    //Завдання 5: Спеціальна Атака для "Меча"
    //Розширте клас Sword методом SpecialAttack(), який реалізує унікальну атаку, наносячи подвійну шкоду.
    
    // OK
    //Завдання 7: Додавання Властивостей Модифікації
    //Включіть до класу Sword властивість isSharpened та метод Sharpen(), який збільшує шкоду меча.
    class Sword : Weapon
    {
        private int _bladeLength;
        private bool _isSharpened = false;

        public Sword(string name, int damage, int bladeLength) : base(name, damage)
        {
            _bladeLength = bladeLength;
            _isSharpened = true;
        }

        public override void Attack()
        {
            int realDamage = Damage - Fatigue;
            if (realDamage < 1) realDamage = 1;
            Console.WriteLine($"Меч {Name} атакує. Довжина леза: {_bladeLength}. Шкода: {realDamage}");
            Fatigue++;
        }

        public void SpecialAttack()
        {
            Console.WriteLine($"Спеціальна атака мечем! Шкода: {Damage * 2}");
        }

        public void Sharpen()
        {
            if (!_isSharpened)
            {
                Damage += 5;
                _isSharpened = true;
            }
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Довжина леза: {_bladeLength}");
            Console.WriteLine($"Заточений: {_isSharpened}");
        }
    }

    // OK
    //Завдання 3: Створення Класу "Лук"
    //Створіть клас Bow на основі Weapon, із додаванням властивості arrowCount та перевизначенням методу Attack() для показу кількості стріл.
    
    // OK
    //Завдання 6: Спеціальна Атака для "Лука"
    //Реалізуйте в класі Bow метод SpecialAttack(), що дозволяє випустити всі стріли одночасно для масової атаки.
    
     // OK
    //Завдання 8: Розробка Системи Перезарядки для "Лука"
    //Додайте до класу Bow метод Reload(), що збільшує arrowCount до початкової кількості стріл.
    class Bow : Weapon
    {
        private int _arrowCount;
        private int _maxArrows;

        public Bow(string name, int damage, int arrows) : base(name, damage)
        {
            _arrowCount = arrows;
            _maxArrows = arrows;
        }

        public override void Attack()
        {
            if (_arrowCount > 0)
            {
                int realDamage = Damage - Fatigue;
                if (realDamage < 1) realDamage = 1;

                _arrowCount--;
                Console.WriteLine($"Лук {Name} стріляє. Стріл залишилось: {_arrowCount}. Шкода: {realDamage}");
                Fatigue++;
            }
            else
            {
                Console.WriteLine("Немає стріл!");
            }
        }

        public void SpecialAttack()
        {
            if (_arrowCount > 0)
            {
                Console.WriteLine($"Масова атака! Випущено {_arrowCount} стріл.");
                _arrowCount = 0;
            }
        }

        public void Reload()
        {
            _arrowCount = _maxArrows;
        }

        public override void DisplayWeaponStats()
        {
            base.DisplayWeaponStats();
            Console.WriteLine($"Стріли: {_arrowCount}");
        }
    }

    //(Додатково) Завдання 10: Візуалізація Бою
    //Створіть просту симуляцію бою, де персонажі з різними типами зброї (меч, лук) використовують стандартні та спеціальні атаки,
    //демонструючи різницю в ефективності та стратегії бою.
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