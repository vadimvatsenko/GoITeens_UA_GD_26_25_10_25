namespace _HomeWorksCheck;  
  
class Program  
{  
    static void Main(string[] args)
    {
        Console.WriteLine("Write A name of your character:");
        
        string name =  Console.ReadLine();

        Character character = new Character(name);
        
        Console.Clear();
        
        character.DisplayInfo();

        Console.WriteLine("Press Any Key To Continue...");
        
        Console.ReadKey();
        
        Enemy enemy = new Enemy(100, 5);
        
        character.Attack(enemy, 3);
        
        enemy.Attack(character, 3);
        
        Console.ReadKey();
        
    }

    public abstract class Creature
    {
        public abstract void Attack(Creature character, int distance);
        public abstract void TakeDamage(int damage);
    }
    
    public class Character : Creature
    {
        private string _name;
        private int _health;
        private Weapon _weapon;

        public int Health
        {
            get => _health;
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
            }
        }
    
        public Character (string name, int health = 100)
        {  
            _name = name;
            _health = health;
            _weapon = new Weapon(10, 5);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Health: {_health}");
        }
        
        public override void Attack(Creature character, int distance) => _weapon.Atack(character,  distance);
        public override void TakeDamage(int damage) => Health -= damage;
        
    }

    public class Weapon
    {
        private int _range;
        private int _damage;

        public Weapon(int range, int damage)
        {
            _range = range;
            _damage = damage;
        }

        public void Atack(Creature enemy, int distance)
        {
            if (distance <= _range)
            {
                enemy.TakeDamage(_damage);
            }
            else
            {
                Console.WriteLine("Not enough damage");
            }
        }
    }
    
    public class Enemy : Creature
    {
        private int _health;
        private int _damage;
        private Weapon _weapon;

        public Enemy (int health, int damage)
        {
            _health = health;
            _damage = damage;
            _weapon = new Weapon(10, 20);
        }
        
        public override void Attack(Creature creature, int distance) => _weapon.Atack(creature, distance);
        
        public override void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
            }
        }
    }
}