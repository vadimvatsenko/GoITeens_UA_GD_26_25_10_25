namespace Lesson_12_OOP_2.Engine.Collider;

public abstract class Collider2D
{
    public Vector2 Position { get; protected set; }

    public Collider2D(Vector2 position)
    {
        Position = position;
    }

    public void UpdateColliderPosition(Vector2 delta)
    {
        Position = delta;
    }
    
    public abstract bool IsColliding(Collider2D other);
}