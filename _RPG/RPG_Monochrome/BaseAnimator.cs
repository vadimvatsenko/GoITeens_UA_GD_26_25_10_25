using RPG_Monochrome.Engine;
using RPG_Monochrome.Utils;

namespace RPG_Monochrome;

public class BaseAnimator: IUpdatable
{
    // Const Field
    private const int SYMBOL_STEP = 1;
    private const int offsetX = -32;
    private const int offsetY = -16;

    private bool _loop = false;
    //
    private readonly Renderer _renderer;
    private IMovable _movableObj;
    private readonly char[,] _targetLayer;
    //
    protected List<char[,]> TargetAnimation;
    public Action OnFinishAnimation;
    
    // Sprite Render Info
    private int _spriteIndex = 0; // index of Frame
    private double _animTimer = 0; // 
    private const double FRAME_TIME = 0.12;

    protected Dictionary<string, List<char[,]>> Animations = new Dictionary<string, List<char[,]>>();
    
    public BaseAnimator(
        Renderer renderer, 
        char[,] targetLayer, 
        List<Sprite> sprites)
    {
        _renderer = renderer;
        _targetLayer = targetLayer;

        foreach (Sprite sprite in sprites)
        {
            foreach (var s in sprite.animation)
            {
                if (!Animations.TryGetValue(s.Key, out var frames))
                {
                    frames = new List<char[,]>();
                    Animations[s.Key] = frames;
                }

                frames.AddRange(s.Value); // добавляем все кадры этой анимации
            }
        }
        
        SetStartedAnimation();
    }


    protected virtual void SetStartedAnimation()
    {
        TargetAnimation = Animations["WalkRight"];
    }
    

    public void SetCreature(IMovable movableObj) => _movableObj = movableObj;
    
    public void SetTargetAnimation(string spriteName)
    {
        if (Animations.ContainsKey(spriteName))
        {
            TargetAnimation = Animations[spriteName];
        }
    }

    
    public void Update(double deltaTime)
    {
        AnimationUpdate(deltaTime);
    }

    private void AnimationUpdate(double deltaTime)
    {
        
        for (int y = 0; y < TargetAnimation[_spriteIndex].GetLength(0); y++)
        {
            for (int x = 0; x < TargetAnimation[_spriteIndex].GetLength(1); x++)
            {
                char tile = TargetAnimation[_spriteIndex][y, x];

                if(tile == ' ') continue;

                int startX = x * SYMBOL_STEP;

                for (int i = 0; i < SYMBOL_STEP; i++)
                {
                    _renderer.DrawChar(
                        _targetLayer, startX + i + _movableObj.Position.X + offsetX, y + _movableObj.Position.Y + offsetY, tile);
                }
            }
        }
        
        _animTimer += deltaTime;

        if (_animTimer >= FRAME_TIME)
        {
            _spriteIndex = (_spriteIndex + 1) % TargetAnimation.Count;
            _animTimer = 0;
        }

        if (_spriteIndex >= TargetAnimation[_spriteIndex].Length)
        {
            OnFinishAnimation?.Invoke();
        }
    }
}