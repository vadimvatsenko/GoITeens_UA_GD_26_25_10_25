using RPG_Monochrome.Data.Sprites.Priest;

namespace RPG_Monochrome.Engine;

public class HeroAnimator
{
    public List<char[,]> currentAnimation;
    
    public Dictionary<string, List<char[,]>> AnimationDictionary = new Dictionary<string, List<char[,]>>();
    
    public List<char[,]> IdleDownSprite { get; } = new List<char[,]>()
    {
        PriestIdle.PriestIdleDown_1,
        PriestIdle.PriestIdleDown_2,
        PriestIdle.PriestIdleDown_3,
        PriestIdle.PriestIdleDown_4,
        PriestIdle.PriestIdleDown_5,
        PriestIdle.PriestIdleDown_6,
    };

    public HeroAnimator()
    {
        AnimationDictionary.Add("Idle", IdleDownSprite);
    }

    
}