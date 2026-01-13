using RPG_Monochrome.Data.Sprites;
using RPG_Monochrome.Engine;
using RPG_Monochrome.Engine.Collider;
using RPG_Monochrome.Items;

namespace RPG_Monochrome;

public class Hero: Creature, IDisposable
{
    private readonly Input _input;
    private readonly Collider2D _collider;
    private readonly Map _map;
    
    private Vector2 _direction = Vector2.Zero;
    List<Coin> _coins = new List<Coin>();
    
    public Hero(Vector2 position, Renderer renderer, Input input, Animator animator, List<Coin> coins, Map map) 
        : base(position, renderer, animator)
    {
        _collider = new BoxCollider2D(this.Position, new Vector2(32, 16));
        _coins =  coins;
        _map = map;
        
        _input = input;
        
        _input.OnAttack += Attack;
        _input.OnRight += MoveRight;
        _input.OnLeft += MoveLeft;
        _input.OnUp += MoveUp;
        _input.OnDown += MoveDown;
        _input.OnCancel += ResetDirection;
    }

    private void ResetDirection()
    {
        _direction = Vector2.Zero;
    }

    
    
    private void MoveLeft()
    {
        _direction = Vector2.Left;
        Position = CalculatePosition(_direction);
    }
    
    private void MoveRight()
    {
        _direction = Vector2.Right;
        Position = CalculatePosition(_direction);
    }

    private void MoveUp()
    {
        _direction = Vector2.Up;
        Position = CalculatePosition(_direction);
    }

    private void MoveDown()
    {
        _direction = Vector2.Down;
        Position = CalculatePosition(_direction);
    }
    
    private Vector2 CalculatePosition(Vector2 direction)
    {
        Vector2 targetDirection = Vector2.Zero;

        if (direction == Vector2.Right)
        {
            targetDirection = Vector2.Right * 2;
        } 
        else if (direction == Vector2.Left)
        {
            targetDirection = Vector2.Left * 2;    
        }
        else if (direction == Vector2.Up)
        {
            targetDirection = Vector2.Up;
        }
        else if (direction == Vector2.Down)
        {
            targetDirection = Vector2.Down;
        }
        else
        {
            targetDirection = Vector2.Zero;
        }
        
        return 
            Vector2.Clamp(
                Position + targetDirection, Vector2.Zero,new Vector2(_map.Width - 32, _map.Height - 16)); 
    }

    private void Attack()
    {
        Console.WriteLine("Attack");
    }
    
    public void Update(double deltaTime)
    {
        base.Update(deltaTime);

        _collider.UpdateColliderPosition(Position);
        
        var coin = _coins.Find(x => _collider.IsColliding(x.Collider));
        
        if (coin != null)
        {
            Console.WriteLine(coin.Position.X + " " + coin.Position.Y);
            _coins.Remove(coin);
            coin.Dispose();
        }
    }

    public void Dispose()
    {
        _input.OnAttack -= Attack;
        _input.OnRight -= MoveRight;
        _input.OnLeft -= MoveLeft;
        _input.OnUp -= MoveUp;
        _input.OnDown -= MoveDown;
        _input.OnCancel -= ResetDirection;
    }
}