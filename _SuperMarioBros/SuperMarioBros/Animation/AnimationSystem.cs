using SuperMarioBros.Engine;
using SuperMarioBros.GameData;
using SuperMarioBros.GameData.Sprites;

namespace SuperMarioBros.Animation;

public class AnimationSystem : IUpdatable
{
    private List<AnimationClip> _clips;
    private AnimationClip _targetAnimationClip;

    private readonly int y = 6;
    private int _x = 2;
    
    private int tick = 0;

    private int _dir = +6; // +1 вправо, -1 влево
    private int _frame = 0;

    private int _spriteW;
    private int _spriteH;

    // границы по X (в "пикселях")
    private readonly int minX = 1;
    private int _maxX;
    

    public AnimationSystem(List<AnimationClip> animationClips)
    {
        _clips = animationClips;
        
        _targetAnimationClip = _clips[1];
        
        _spriteW = _targetAnimationClip.Sprite[0][0].Length;
        _spriteH = _targetAnimationClip.Sprite[0].Length;
        _maxX = Math.Max(minX, (Console.WindowWidth / 2) - _spriteW - 1);
    }
    
    public void Update(double deltaTime)
    {
        /*ClearRect(_x, y, _spriteW, _spriteH);
        // переключаем кадр
        _frame = (_frame + 1) % _targetAnimationClip.Sprite.Length;
        // двигаем раз в N тиков

        tick++;
        if (tick % 2 == 0)
        {
            double culc = 0;
            culc += deltaTime;

            if (culc < 1)
            {
                return;
            }
            
            _x += _dir;

            if (_x <= minX)
            {
                _x = minX;
                _dir = +6;
                _targetAnimationClip = _clips[0];
            }

            if (_x >= _maxX)
            {
                _x = _maxX;
                _dir = -6;
                _targetAnimationClip = _clips[1];
            }
        }

        // рисуем в новой позиции

        double time = 0;
        double delay = 1;

        while (time < delay)
        {
            time += deltaTime * 1000;
        }
        
        //DrawFrame(_targetAnimationClip.Sprite[_frame], _x, y);
        
        Console.ResetColor();
        Console.CursorVisible = true;*/
    }

    private void ClearRect(int x, int y, int w, int h)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Black;

        string blank = new string(' ', w * 2);

        for (int row = 0; row < h; row++)
        {
            Console.SetCursorPosition(x * 2, y + row);
            Console.Write(blank);
        }

        Console.ResetColor();
    }

    public void DrawFrameFromMario(int x, int y)
    {
        ClearRect(_x, y, _spriteW, _spriteH);
        for (int row = 0; row < SmallMarioSpritesData.Ground.Length; row++)
        {
            Console.SetCursorPosition(x * 2, y + row);
            
            for (int col = 0; col < SmallMarioSpritesData.Ground[row].Length; col++)
            {
                
                char c = SmallMarioSpritesData.Ground[row][col];
                var color = ColorsPalette.Palette.ContainsKey(c) ? ColorsPalette.Palette[c] : ConsoleColor.Black;

                //Console.BackgroundColor = color;
                Console.ForegroundColor = color;
                Console.Write("██");
            }

            Console.ResetColor();
        }
    }

    private void DrawFrame(string[] sprite, int x, int y)
    {
        for (int row = 0; row < sprite.Length; row++)
        {
            Console.SetCursorPosition(x * 2, y + row);

            for (int col = 0; col < sprite[row].Length; col++)
            {
                char c = sprite[row][col];
                var color = ColorsPalette.Palette.ContainsKey(c) ? ColorsPalette.Palette[c] : ConsoleColor.Black;

                Console.BackgroundColor = color;
                Console.ForegroundColor = color;
                Console.Write("██");
            }

            Console.ResetColor();
        }
    }
}