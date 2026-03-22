namespace Homework_13._5
   {
       class Character
       {
           private string _name;
           private int _health;

           private Weapon _weapon;
		
           public string Name
           {
               get  => _name;
               set { _name = value; }
           }
		
           public int Health
           {
               get => _health;
               set
               {
                   _health = value;
                   if (_health <= 0)
                   {
                       _health = 0;
                   }
				
                   Console.WriteLine(_health);
               }
           }

           public Character(string name, int health)
           {
               _name = name;
               _health = health;
           }
           public void DisplayInfo()
           {
               Console.WriteLine("Name: " + _name);
               Console.WriteLine("Health: " + _health);
           }

           public void AddWeapon(Weapon weapon)
           {
               _weapon = weapon;
           }

           public void Attack(Enemy enemy)
           {
               _weapon.AttackEnemy(enemy, 20, 10);
           }
       }

       class Enemy
       {
           private int _health; 
           private string _type;
           
           public string Type
           {
               get  => _type;
               set { _type = value; }
           }

           public Enemy(string type, int health)
           {
               _type = type;
               _health = health;
           }
       }
	
       class Weapon
       {
           private string _name;
           private int _damage;
           private int _range;

           public Weapon(string name, int damage, int range)
           {
               _name = name;
               _damage = damage;
               _range = range;
           }
           
           public void AttackEnemy(Enemy target, int distance, int enemyMinArmor)
           {
               if (distance > _range)
               {
                   Console.WriteLine($"You can't hit the {target.Type}, too far!");
               }
               else if (_damage < enemyMinArmor) 
               {
                   Console.WriteLine($"You can't attack the {target.Type}, you are too weak!");
               }
               else
               {
                   Console.WriteLine($"BOOM! You hit the {target.Type}!");
               }
           }
       }
	
       class Program
       {
           static void Main(string[] args)
           {
               Character character = new Character("Dimon", 100);
               Enemy enemy = new Enemy("Potyzhnolit", 1000);
               Weapon AK47 = new Weapon("AK47", 20, 500);
               
               character.DisplayInfo();
               
               character.AddWeapon(AK47);
               character.Attack(enemy);
               
               int enemyArmor = 15;
               AK47.AttackEnemy(enemy, 100, enemyArmor);
           }
       }
   }