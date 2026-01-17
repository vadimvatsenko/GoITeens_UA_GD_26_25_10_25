// Функція здоров’я: створи функцію, яка приймає силу удару ворога і повертає, скільки здоров’я втратить герой.

namespace Lesson_9_Methods_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            
            Console.Write("Enter HitPower: ");
            int.TryParse(Console.ReadLine(), out int hitPower);

            int healDam = HealDamager(hitPower);
            Console.WriteLine(healDam);

            health -= healDam;
            Console.WriteLine(health);
            
            Console.ReadKey();
        }

        static int HealDamager(int hitPower)
        {
            Random random = new Random();
            switch (hitPower)
            {
                case < 10: 
                    return random.Next(0, 11);
                case > 10 and < 50:
                    return random.Next(10, 51);
                case >= 50 and < 101:
                    return random.Next(50, 101);
                default:
                    return 0;
            }
        }
    }
}