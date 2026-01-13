using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RPG_Monochrome.Utils;

public class SpritesLoaderSystem
{
    string path = Path.Combine("..", "..", "..", "Sprites");
    
    private List<Sprite> _sprites = new List<Sprite>();
    

    public SpritesLoaderSystem()
    {
        AllPathes();


        foreach (var sprite in _sprites)
        {
            Console.WriteLine(sprite.Owner);

            foreach (var s in sprite.animation)
            {
                Console.WriteLine(s.Key);
                
                foreach (var v in s.Value)
                {
                    Console.WriteLine(v);
                }
            }
        }
    }

    private void AllPathes()
    {
        // підпапки Directory.EnumerateDirectories(path)
        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            string dirName = Path.GetFileName(dir);
            
            foreach (var file in Directory.EnumerateDirectories(dir))
            {
                // Отримає назву файла Path.GetFileName(file)
                string fileName = Path.GetFileName(file);

                foreach (var fl in Directory.EnumerateDirectories(file))
                {
                    string flName = Path.GetFileName(fl);
                    foreach (var f in Directory.EnumerateFiles(fl, "*.png"))
                    {
                        Sprite sprite = new Sprite(dirName);
                        char[,] currentSprite = LoadCharMask2D(f);
                        sprite.AddAnimation(flName, currentSprite);
                        
                        _sprites.Add(sprite);
                        
                    }
                }
            }
        }
    }

    
    private char[,] LoadCharMask2D(
        string path,
        char fillChar = '█',
        char emptyChar = ' ',
        byte threshold = 128,
        bool invert = false)
    {
        
        using var img = Image.Load<Rgba32>(path);

        int width = img.Width;
        int height = img.Height;

        // ВАЖНО: ширина x2
        var mask = new char[height, width * 2];

        img.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < height; y++)
            {
                var row = accessor.GetRowSpan(y);

                for (int x = 0; x < width; x++)
                {
                    var p = row[x];

                    bool isDark = p.A >= 10 && p.R < threshold && p.G < threshold && p.B < threshold;
                    if (invert) isDark = !isDark;

                    char c = isDark ? fillChar : emptyChar;

                    int xx = x * 2;
                    mask[y, xx] = c;
                    mask[y, xx + 1] = c; // второй символ подряд
                }
            }
        });

        return mask;
    }
    
}