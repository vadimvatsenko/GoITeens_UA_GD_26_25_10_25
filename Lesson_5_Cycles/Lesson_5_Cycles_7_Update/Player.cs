using Sample;

namespace Lesson_5_Cycles_7_Update;

public class Player
{
    public char Symbol { get; private set; }
    public double Speed {get; private set;}

    private Vector2 Position = new Vector2(1, 1);
    public Vector2 Direction {get; private set;} =  new Vector2(1, 0);

    private readonly Input _playerInput;
    
    private readonly Renderer _renderer;

    public Player(Input input, Renderer renderer, char symbol, double speed)
    {
        Symbol = symbol;
        Speed = speed;
        _playerInput =  input;
        _renderer = renderer;
        
        /*Console.SetCursorPosition((int)Position.X, (int)Position.Y);
        Console.Write(symbol);*/
        
        _renderer.SetPixel((int)Position.X, (int)Position.Y, Symbol, 3);

        _playerInput.OnMoveLeft += MoveLeft;
        _playerInput.OnMoveRight += MoveRight;
        _playerInput.OnMoveUp += MoveUp;
        _playerInput.OnMoveDown += MoveDown;
    }

    public void MoveLeft() => Direction = new Vector2(-1 , 0);
    public void MoveRight() => Direction = new Vector2(1, 0);
    public void MoveUp() => Direction = new Vector2(0, 1);
    public void MoveDown() => Direction = new Vector2(0, -1);
    

    public void Update(double delta)
    {
        Draw(Direction, delta);
    }
    
    public void Draw(Vector2 direction, double deltaTime)
    {
        //if (PreviousPosition.X == Position.X && PreviousPosition.Y == Position.Y) return;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Position = new Vector2(
            Position.X + direction.X * (Speed * deltaTime),
            Position.Y + direction.Y * (Speed * deltaTime)
        );
        
        int x = (int)Math.Round(Position.X);
        int y = (int)Math.Round(Position.Y);

        x = Math.Clamp(x, 0, Console.WindowWidth - 1);
        y = Math.Clamp(y, 0, Console.WindowHeight - 1);

        /*Console.SetCursorPosition(x, y);
        Console.Write(Symbol);*/
        
        _renderer.SetPixel(x, y, Symbol, 3);
        
    }

    public void Dispose()
    {
        _playerInput.OnMoveLeft -= MoveLeft;
        _playerInput.OnMoveRight -= MoveRight;
        _playerInput.OnMoveUp -= MoveUp;
        _playerInput.OnMoveDown -= MoveDown;
    }
}