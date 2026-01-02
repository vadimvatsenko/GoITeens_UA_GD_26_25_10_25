using SuperMarioBros.Animation;
using SuperMarioBros.Engine;
using SuperMarioBros.GameData;
using SuperMarioBros.GameData.Sprites;
using SuperMarioBros.Mario;

namespace SuperMarioBros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[][] SmallMarioIdle = { SmallMarioSpritesData.SmallMarioIdle};
            
            string[][] SmallMarioWalkToRight 
                = { SmallMarioSpritesData.SmallMarioWalk0Right, SmallMarioSpritesData.SmallMarioWalk1Right, SmallMarioSpritesData.SmallMarioWalk2Right };
            
            string[][] SmallMarioWalkToLeft 
                = { SmallMarioSpritesData.SmallMarioWalk0Left, SmallMarioSpritesData.SmallMarioWalk1Left, SmallMarioSpritesData.SmallMarioWalk2Left };
            
            AnimationClip smallMarioIdle = new AnimationClip("smallMarioIdle", SmallMarioIdle, false, false);
            AnimationClip smallMarioWalkRight =  new AnimationClip("smallMarioWalkRight", SmallMarioWalkToRight, false, false);
            AnimationClip smallMarioWalkLeft =  new AnimationClip("smallMarioWalkLeft", SmallMarioWalkToLeft, false, false);

            List<AnimationClip> marioAnimClips = new List<AnimationClip>()
            {
                smallMarioIdle,
                smallMarioWalkRight,
                smallMarioWalkLeft
            };
            
            Update update = new Update(60);
            Input input = new Input();
            update.AddUpdateable(input);
            
            AnimationSystem animationSystem = new AnimationSystem(marioAnimClips);
            update.AddUpdateable(animationSystem);
            SmallMario mario = new SmallMario(animationSystem, input);
            
            
            update.AddUpdateable(mario);
            update.RunUpdate();
            
            Console.CursorVisible = false;
        }
    }
}