using RPG_Monochrome.Engine;
using RPG_Monochrome.Utils;

namespace RPG_Monochrome;

public class CoinsAnimator : BaseAnimator
{
    public CoinsAnimator(Renderer renderer, char[,] targetLayer, List<Sprite> sprites) : base(renderer, targetLayer, sprites)
    {
        
    }
    protected override void SetStartedAnimation()
    {
        TargetAnimation = Animations["IdleBase"];
    }
}