namespace Lesson_6_Arrays_10;

public class Unit
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public Vector2 Position { get; set; }

    public Unit(string name, int health, Vector2 position)
    {
        Name = name;
        Health = health;
        Position = position;
    }
}