using Lesson_14_Polymorphism_2.Engine;

namespace Lesson_14_Polymorphism_2.Weapons;

public class Unit
{
    protected Vector2 _pos;
    protected Renderer _renderer;
    protected Weapon _currentWeapon;
    protected char[,] _layer;
    protected Map _map;
    protected char _symbol;
    
    public Unit(Vector2 pos, char symbol, Renderer renderer, char[,] layer, Map map)
    {
        _pos = pos;
        _symbol = symbol;
        _renderer = renderer;
        _layer = layer;
        _map = map;
    }

    public virtual void Update()
    {
        Draw();
    }
    
    public void Draw()
    {
        _renderer.DrawChar(_layer, _pos.X, _pos.Y, _symbol);
    }
}