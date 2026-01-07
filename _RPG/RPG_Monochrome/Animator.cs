using RPG_Monochrome.Data.Sprites;
using RPG_Monochrome.Data.Sprites.Priest;
using RPG_Monochrome.Engine;

namespace RPG_Monochrome;

public class Animator: IUpdatable
{
    // Const Field
    private const int SYMBOL_STEP = 2;
    private readonly Renderer _renderer;
    private readonly Creature _creture;
    private readonly char[,] _targetLayer;
    //
    
    // Sprite Render Info
    private int _spriteIndex = 0; // index of Frame
    private double _animTimer = 0; // 
    private const double FRAME_TIME = 0.12;
    
    
    public Dictionary<SpriteName, List<char[,]>> AnimationDictionary = new Dictionary<SpriteName, List<char[,]>>();
    
    public List<char[,]> IdleDownSprite { get; } = new List<char[,]>()
    {
        PriestIdle.PriestIdleDown_1,
        PriestIdle.PriestIdleDown_2,
        PriestIdle.PriestIdleDown_3,
        PriestIdle.PriestIdleDown_4,
        PriestIdle.PriestIdleDown_5,
        PriestIdle.PriestIdleDown_6,
    };

    public Animator(
        Renderer renderer, 
        Creature creature, 
        char[,] targetLayer, 
        Dictionary<SpriteName, List<char[,]>> animationDictionary)
    {
        _renderer = renderer;
        _creture = creature;
        _targetLayer = targetLayer;
        
        AnimationDictionary = animationDictionary;
        
    }

    
    public void Update(double deltaTime)
    {
        AnimationUpdate(deltaTime);
    }

    private void AnimationUpdate(double deltaTime)
    {
        char[,] targetAnimation = AnimationDictionary[SpriteName.WalkRight][_spriteIndex];
        
        
        
        for (int y = 0; y < AnimationDictionary[SpriteName.WalkRight][_spriteIndex].GetLength(0); y++)
        {
            for (int x = 0; x < AnimationDictionary[SpriteName.WalkRight][_spriteIndex].GetLength(1); x++)
            {
                char tile = AnimationDictionary[SpriteName.WalkRight][_spriteIndex][y, x];

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
            _spriteIndex = (_spriteIndex + 1) % IdleDownSprite.Count;
            _animTimer = 0;
        }
    }
}