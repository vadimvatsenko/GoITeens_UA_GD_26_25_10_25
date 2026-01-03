namespace Lesson_7_List_Dictionary_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            Armor armor =  new Armor("base Armor", 100);
            Armor bullet = new Bullet("Bullet Armor", 50);
            
            
            Dictionary<Armor, int> names2 = new Dictionary<Armor, int>()
            {
                {armor, 10},
                {bullet, 100}
                
            };

            foreach (var name in names2)
            {
                Console.WriteLine(name.Key.Name + " : " + name.Key.Health + " " + name.Value);
            }
            
            
            Console.ReadKey();
        }
        
        
    }

    class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    class Enemy
    {
        
    }

    class Armor
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Armor(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }

    class  Bullet : Armor
    {
        public Bullet(string name, int health) : base(name, health)
        {
        }
    }
}