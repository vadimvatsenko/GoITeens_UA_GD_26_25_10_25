using RPG_Monochrome.Engine;
using RPG_Monochrome.Utils;

namespace RPG_Monochrome;

public class Creature: IUpdatable, IMovable
{
    public Vector2 Position { get; set; }
    public Renderer Renderer {get; protected set;}
    public BaseAnimator BaseAnimator {get; protected set;}
    
    public Creature(Vector2 position,  Renderer renderer, BaseAnimator baseAnimator)
    {
        Position = new Vector2(position.X, position.Y);
        Renderer = renderer;
        BaseAnimator = baseAnimator;
    }

    public void Update(double deltaTime)
    {
        BaseAnimator.Update(deltaTime);
    }
}