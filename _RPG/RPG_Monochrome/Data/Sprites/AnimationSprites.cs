namespace RPG_Monochrome.Data.Sprites.Bat;

public static class AnimationSprites
{
    public static Dictionary<SpriteName, List<char[,]>> BatAnimation = new Dictionary<SpriteName, List<char[,]>>()
    {
        { SpriteName.WalkRight, BatIdeWalk.BatIdleWalkRightListSprites },
        { SpriteName.WalkLeft, BatIdeWalk.BatIdleWalkLeftListSprites },
    };
    
    
}