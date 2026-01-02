using SuperMarioBros.Animation;
using SuperMarioBros.Engine;

namespace SuperMarioBros.Mario;

public class SmallMario : IUpdatable, IDisposable
{
    private readonly Input _input;
    private Vector2 _position;
    private AnimationSystem _animSystem;
    
    public SmallMario(AnimationSystem animSystem, Input input)
    {
        _position = new Vector2(20, 20);
        _input = input;
        _animSystem = animSystem;
        
        _input.OnLeft += MoveLeft;
        _input.OnRight += MoveRight;
    }
    
    public void Update(double deltaTime)
    {
        
    }

    public void MoveRight()
    {
        _position.X++;
        _animSystem.DrawFrameFromMario(_position.X, _position.Y);
        //_animUpdateOld.AddAnimationClip(_animationClips[0]);
    }

    public void MoveLeft()
    {
        _position.X--;
        _animSystem.DrawFrameFromMario(_position.X, _position.Y);
    }

    public void Dispose()
    {
        _input.OnLeft -= MoveLeft;
        _input.OnRight -= MoveRight;
    }

    public void DrawMario()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write('@');
    }
}