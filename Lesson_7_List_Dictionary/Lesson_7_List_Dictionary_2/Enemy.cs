namespace Lesson_7_List_Dictionary_2;

public class Enemy
{
    public char Symbol { get; private set; }
    public Vector2 Position { get; private set; } // 0 0 
    public Vector2 TargetPosition { get; private set; }

    private List<Vector2> _route = new List<Vector2>()
    {
        new Vector2(10, 15),
        new Vector2(20, 40),
        new Vector2(13, 11),
        /*new Vector2(18, 25),
        new Vector2(21, 16),
        new Vector2(33, 1),
        new Vector2(34, 6),
        new Vector2(40, 10),
        new Vector2(45, 3),
        new Vector2(4, 1),*/

    };
    private int _routeIndex = 0;

    public Enemy(char symbol, Vector2 position)
    {
        Symbol = symbol;
        Position = position;
    }

    public void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        TargetPosition = _route[_routeIndex];

        if (Position == TargetPosition)
        {
            Console.WriteLine("New route");
            // 1 = 1
            // 2 = 2
            // 3 = 3
            
            // 11 = 10 = 1
            // 12 = 10 + 2
            // 13 =
            
            // 20 = 2 = 0
            // 21 = 2 + 1
            
            _routeIndex = (_routeIndex + 1) % _route.Count; // _route.Count = 10
        }

        Vector2 nextPosition = GetNextStep(Position, TargetPosition);
        Position = nextPosition;
        Draw(nextPosition);
    }

    private Vector2 GetNextStep(Vector2 from, Vector2 to)
    {
        int dx = Math.Sign(to.X - from.X); // -7 = -1, 6 = 1, 0 = 0
        int dy = Math.Sign(to.Y - from.Y);
        
        return new Vector2(from.X + dx, from.Y + dy);
    }

    public void Draw(Vector2 nextPosition)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(nextPosition.X, nextPosition.Y);
        Console.Write(Symbol);
    }
}