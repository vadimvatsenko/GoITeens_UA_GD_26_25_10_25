
namespace Homework_14._6
{
    class Weapon
    {
        protected string _name;
        protected double _damage;

        public Weapon(string name, double damage)
        {
            _name = name;
            _damage = damage;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"Name of weapon: {_name} \nDamage: {_damage}");
        }
    }

    class Sword : Weapon
    {
        private double _bladeLength;

        public Sword(string name, double damage, double bladeLength) : base(name, damage)
        {
            _bladeLength = bladeLength;
        }
        
        public override void Attack()
        {
            base.Attack(); 
            Console.WriteLine($"Blade Length: {_bladeLength} cm");
        }
    }

    class Bow : Weapon
    {
        private int _arrowCount;

        public Bow(string name, double damage, int arrowCount) : base(name, damage)
        {
            _arrowCount = arrowCount;
        }

        public override void Attack()
        {
            base.Attack();
            Console.WriteLine($"Arrow Count: {_arrowCount}");
        }

        public void SpecialAttack()
        {
            Console.WriteLine("Special attack: All arrows are used! Total damage: " + _damage * _arrowCount);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon("Spear", 20);
            weapon.Attack();
            
            Console.WriteLine();
            
            Sword sword = new Sword("Excalibur", 50, 80);
            sword.Attack();
            
            Console.WriteLine();
            
            Bow bow = new Bow("Strila", 10, 54);
            bow.Attack();
            bow.SpecialAttack();
        }
    }
}