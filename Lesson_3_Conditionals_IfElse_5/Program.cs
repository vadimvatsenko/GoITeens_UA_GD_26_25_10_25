using System;

namespace Lesson_3_Conditionals_IfElse_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int health = 100;
            
            while (health > 0)
            {
                int damage = rnd.Next(1, 101);
                
                health -= damage;
                if (health < 0)
                {
                    health = 0;
                }
                Console.WriteLine($"Enemy Take damage: {damage}, health: {health}");
                Thread.Sleep(2000);
            }
            
            Console.WriteLine("Enemy is dead");
        }
    }
}
