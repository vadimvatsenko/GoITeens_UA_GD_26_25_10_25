using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Ghost: Creature, IUpdatable
{
    
    private Vector2 _direction = Vector2.Zero;
    
    public Ghost(Vector2 position) : base(position)
    {
    }

    public void Update(double deltaTime)
    {
        
    }
}