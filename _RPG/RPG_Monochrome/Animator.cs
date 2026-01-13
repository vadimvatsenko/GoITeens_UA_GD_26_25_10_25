using RPG_Monochrome.Data.Sprites;
using RPG_Monochrome.Data.Sprites.Priest;
using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Animator: IUpdatable
{
    // Const Field
    private const int SYMBOL_STEP = 2;
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
    
    public Dictionary<SpriteName, List<char[,]>> AnimationDictionary = new Dictionary<SpriteName, List<char[,]>>();
    
    public Animator(
        Renderer renderer, 
        char[,] targetLayer, 
        Dictionary<SpriteName, List<char[,]>> animationDictionary)
    {
        _renderer = renderer;
        _targetLayer = targetLayer;
        
        AnimationDictionary = animationDictionary;

        _targetAnimation = AnimationDictionary.ElementAt(0).Value;
    }

    public void SetCreature(Creature creature)
    {
        _creture =  creature;
    }

    public void ChangeAnimation(SpriteName spriteName)
    {
        if (AnimationDictionary.ContainsKey(spriteName))
        {
            _targetAnimation = AnimationDictionary[spriteName];
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