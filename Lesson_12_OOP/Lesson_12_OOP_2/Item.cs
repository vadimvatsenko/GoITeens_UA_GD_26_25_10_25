using Lesson_12_OOP_2.Engine;
using Lesson_12_OOP_2.Engine.Collider;
using RPG_Monochrome.Engine.Collider;

namespace Lesson_12_OOP_2;

public class Item
{
    public string Name { get; private set; }
    public Vector2 InWorldCoordinates { get; private set; }
    public Collider2D Collider { get; private set; }

    public Item(string name, Vector2 inWorldCoordinates)
    {
        Name = name;
        InWorldCoordinates = inWorldCoordinates;
        Collider = new BoxCollider2D(inWorldCoordinates, Vector2.One);
    }
}