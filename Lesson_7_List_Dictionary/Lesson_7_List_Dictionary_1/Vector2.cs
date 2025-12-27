namespace Lesson_7_List_Dictionary_1;

public struct Vector2
{
    public int X { get; private set; }
    public int Y  { get; private set; }
    
    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }


    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }
}