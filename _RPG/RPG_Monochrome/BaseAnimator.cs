using RPG_Monochrome.Engine;
using RPG_Monochrome.Utils;

namespace RPG_Monochrome;

public class BaseAnimator: IUpdatable
{
    // Const Field
    private const int SYMBOL_STEP = 1;
    private readonly Renderer _renderer;
    private Creature _creture;
    private readonly char[,] _targetLayer;
    //
    private List<char[,]> _targetAnimation;
    
    public Action OnFinishAnimation;
    
    // Sprite Render Info
    private int _spriteIndex = 0; // index of Frame
    private double _animTimer = 0; // 
    private const double FRAME_TIME = 0.12;

    Dictionary<string, List<char[,]>> _animations = new Dictionary<string, List<char[,]>>();
    
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
                if (!_animations.TryGetValue(s.Key, out var frames))
                {
                    frames = new List<char[,]>();
                    _animations[s.Key] = frames;
                }

                frames.AddRange(s.Value); // добавляем все кадры этой анимации
            }
        }
        
        _targetAnimation = _animations["WalkRight"];
        
    }

    public void SetCreature(Creature creature)
    {
        _creture =  creature;
    }

    public void SetTargetAnimation(string spriteName)
    {
        if (_animations.ContainsKey(spriteName))
        {
            _targetAnimation = _animations[spriteName];
        }
    }

    
    public void Update(double deltaTime)
    {
        AnimationUpdate(deltaTime);
    }

    private void AnimationUpdate(double deltaTime)
    {
        
        for (int y = 0; y < _targetAnimation[_spriteIndex].GetLength(0); y++)
        {
            for (int x = 0; x < _targetAnimation[_spriteIndex].GetLength(1); x++)
            {
                char tile = _targetAnimation[_spriteIndex][y, x];

                if(tile == ' ') continue;

                int startX = x * SYMBOL_STEP;

                for (int i = 0; i < SYMBOL_STEP; i++)
                {
                    _renderer.DrawChar(
                        _targetLayer, startX + i + _creture.Position.X, y + _creture.Position.Y, tile);
                }
            }
        }
        
        _animTimer += deltaTime;

        if (_animTimer >= FRAME_TIME)
        {
            _spriteIndex = (_spriteIndex + 1) % _targetAnimation.Count;
            _animTimer = 0;
        }

        if (_spriteIndex >= _targetAnimation[_spriteIndex].Length)
        {
            OnFinishAnimation?.Invoke();
        }
    }
}