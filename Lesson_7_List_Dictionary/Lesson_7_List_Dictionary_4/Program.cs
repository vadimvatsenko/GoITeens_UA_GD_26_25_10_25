// клас Armor => type та damage
// клас Laser, Bullet, Fire, Missile
// emum ArmorType
// клас InputSystem => 
// клас Helicopter


namespace Lesson_7_List_Dictionary_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputSystem inputSystem = new InputSystem();
            
            Armor fire = new Fire(ArmorType.Fire, 50);
            Armor laser = new Laser(ArmorType.Laser, 100);
            Armor bullet = new Bullet(ArmorType.Bullet, 5);
            Armor missile = new Missile(ArmorType.Missile, 200);

            List<Armor> armors = new List<Armor>()
            {
                fire,
                laser,
                missile,
                bullet,
            };
            
            Helicopter helicopter = new Helicopter(inputSystem, armors);

            Console.ReadKey();
            while (true)
            {
                inputSystem.Update();
            }
        }
    }
}