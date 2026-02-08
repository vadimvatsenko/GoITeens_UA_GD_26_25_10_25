
using Lesson_12_OOP_2.Engine;

namespace Lesson_12_OOP_2;

public class Hero: IUpdatable, IDisposable
{
    public Inventory Inventory { get; private set; }
    public HealthComponent HealthComponent { get; private set; }
    public Renderer _renderer;
    public char[,] _layer;
    public char Symbol {get; private set;} = '\u25C9';
    private Input _input;
    public Vector2 Position {get; private set;}

    public Hero(Input input, Renderer renderer,  char[,] layer)
    {
        _input = input;
        _renderer = renderer;
        _layer = layer;
        Position = Vector2.Tree;
        _input.OnRight += TryToMoveRight;
        _input.OnLeft += TryToMoveLeft;
        _input.OnUp += TryToMoveUp;
        _input.OnDown += TryToMoveDown;

        Inventory = new Inventory(20);
        HealthComponent = new HealthComponent(100);
    }

    private void TryToMoveLeft()
    {
        Position 
            = Vector2.Clamp(Position + Vector2.Left, Vector2.Zero, new Vector2(99, 49));
        
    }

    private void TryToMoveRight()
    {
        Position 
            = Vector2.Clamp(Position + Vector2.Right, Vector2.Zero, new Vector2(99, 49));
    }

    private void TryToMoveUp()
    {
        Position 
            = Vector2.Clamp(Position + Vector2.Up, Vector2.Zero, new Vector2(99, 49));
    }

    private void TryToMoveDown()
    {
        Position 
            = Vector2.Clamp(Position + Vector2.Down, Vector2.Zero, new Vector2(99, 49));
    }
    
    
    public void Update(double deltaTime)
    {
        _renderer.DrawChar(_layer, Position.X, Position.Y, Symbol);
    }

    public void HealHero(int amount)
    {
        //if(Inventory.ItemsInventory.ContainsKey(typeof(Item))
    }
    public void TakeDamage(int amount) => HealthComponent.Damage(amount);
    
    public void Dispose()
    {
        _input.OnRight -= TryToMoveRight;
        _input.OnLeft -= TryToMoveLeft;
        _input.OnUp -= TryToMoveUp;
        _input.OnDown -= TryToMoveDown;
    }
}