using RPG_Monochrome.Data.Sprites.Bat;
using RPG_Monochrome.Data.Sprites.Coin;
using RPG_Monochrome.Data.Sprites.Priest;

namespace RPG_Monochrome.Data.Sprites;

public static class AnimationSprites
{
    public static Dictionary<SpriteName, List<char[,]>> GhostAnimation = new Dictionary<SpriteName, List<char[,]>>()
    {
        { SpriteName.WalkRight, GhostIdeWalk.BatIdleWalkRightListSprites },
        { SpriteName.WalkLeft, GhostIdeWalk.BatIdleWalkLeftListSprites },
    };
    
    public static Dictionary<SpriteName, List<char[,]>> PriestAnimation = new Dictionary<SpriteName, List<char[,]>>()
    {
        { SpriteName.IdleDawn, PriestIdle.PriestIdleDownListSprites },
        { SpriteName.WalkDown, PriestWalk.PriestWalkDownListSprites },
    };

    public static Dictionary<SpriteName, List<char[,]>> CoinAnimation = new Dictionary<SpriteName, List<char[,]>>()
    {
        {SpriteName.Idle, CoinIdle.CoinIdleAnimation}
    };
    
    


}