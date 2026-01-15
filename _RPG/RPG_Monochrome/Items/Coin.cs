using RPG_Monochrome.Engine;
using RPG_Monochrome.Engine.Collider;

namespace RPG_Monochrome.Items;

public class Coin: Creature, IDisposable
{
    public Collider2D  Collider {get; private set;}
    public Coin(Vector2 position, Renderer renderer, BaseAnimator baseAnimator) 
        : base(position, renderer, baseAnimator)
    {
        Collider = new BoxCollider2D(this.Position, new Vector2(6, 6));
    }

    public void Update(float deltaTime)
    {
        BaseAnimator.Update(deltaTime);
    }
    
    public void Dispose()
    {
        
    }
}