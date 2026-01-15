using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public interface IMovable
{
    public Vector2 Position { get; protected set; }
}