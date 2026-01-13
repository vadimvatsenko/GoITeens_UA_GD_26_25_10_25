using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Creature: IUpdatable
{
    public Vector2 Position {get; protected set;}
    public Renderer Renderer {get; protected set;}
    
    public Animator Animator {get; protected set;}

    public Creature(Vector2 position,  Renderer renderer, Animator animator)
    {
        Position = position;
        Renderer = renderer;
        Animator = animator;
    }

    public void Update(double deltaTime)
    {
        Animator.Update(deltaTime);
    }
}