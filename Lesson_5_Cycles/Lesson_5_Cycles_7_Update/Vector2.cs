namespace Sample;

public struct Vector2
{
    public double X {get; private set;}
    public double Y {get; private set;}
    
    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void SetPosition(Vector2 pos)
    {
        X = pos.X;
        Y = pos.Y;
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }
}