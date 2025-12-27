namespace Lesson_7_List_Dictionary_2;

public struct Vector2
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Vector2 v1, Vector2 v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y;
    }

    public static bool operator !=(Vector2 v1, Vector2 v2)
    {
        return !(v1 == v2);
    }
}