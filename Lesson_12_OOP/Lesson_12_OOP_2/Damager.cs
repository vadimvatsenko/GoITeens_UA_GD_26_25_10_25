using Lesson_12_OOP_2.Engine;

namespace Lesson_12_OOP_2;

public class Damager : IUpdatable, IDisposable
{
    public string Name { get; private set; }
    private char _symbol = 'B';
    private char[,] _itemLayer;
    public Hero Hero { get; private set; }
    private Renderer _renderer;
    private Vector2 Position;
    private bool _isAttacking =  false;

    public Damager(string name, Hero hero, Renderer renderer,  char[,] itemLayer,  Vector2 position)
    {
        Name = name;
        Hero = hero;
        _renderer = renderer;
        _itemLayer = itemLayer;
        Position = position;
    }
    
    public void AttackHero()
    {
        Hero.HealthComponent.Damage(30);
    }

    public void Update(double deltaTime)
    {
        _renderer.DrawChar(_itemLayer, Position.X, Position.Y, _symbol);

        if (this.Position.Equals(Hero.Position))
        {
            if (!_isAttacking)
            {
                _isAttacking = true;
                AttackHero();
                this.Dispose();
            }
        }
    }

    public void Dispose()
    {
        _symbol = 'X';
        Console.WriteLine("Dead");
    }
}