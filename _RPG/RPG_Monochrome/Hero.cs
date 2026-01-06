using RPG_Monochrome.Engine;
using RPG_Monochrome.Layers;

namespace RPG_Monochrome;

public class Hero: IDisposable
{
    private Input _input;
    public Vector2 Position {get; private set;}
    private Vector2 _direction = Vector2.Zero;
    public Hero(Input input, Vector2 position)
    {
        Position =  position;
        _input = input;
        
        _input.OnAttack += Attack;
        _input.OnRight += MoveRight;
        _input.OnLeft += MoveLeft;
        _input.OnUp += MoveUp;
        _input.OnDown += MoveDown;
    }

    private void MoveLeft()
    {
        Position.X -= 2;
        _direction = Vector2.Left;
    }

    private void MoveRight()
    {
        Position.X += 2;
        _direction = Vector2.Right;
    }

    private void MoveUp()
    {
        Position.Y -= 1;
        _direction = Vector2.Up;
    }

    private void MoveDown()
    {
        Position.Y += 1;
        _direction = Vector2.Down;
        
    }

    private void Attack()
    {
        Console.WriteLine("Attack");
    }

    public void Dispose()
    {
        _input.OnAttack -= Attack;
        _input.OnRight -= MoveRight;
        _input.OnLeft -= MoveLeft;
        _input.OnUp -= MoveUp;
        _input.OnDown -= MoveDown;
    }

    public void Update(double deltaTime)
    {
        throw new NotImplementedException();
    }
}