namespace Lesson_13_Classes_1;

public class Bullet
{
    public int Damage { get; private set; }
    public int Speed { get; private set; }
    
    public int XPosition { get; private set; }
    
    public Bullet(int damage, int speed)
    {
        Damage = damage;
        Speed = speed;
    }
}