using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Creature
{
    public Vector2 Position {get; protected set;}

    public Creature(Vector2 position)
    {
        Position = position;
    }
}