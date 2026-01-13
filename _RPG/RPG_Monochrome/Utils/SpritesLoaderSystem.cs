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
    }
    
    public List<Sprite> Sprites { get => _sprites; }

    private async void AllPathes()
    {
        // підпапки Directory.EnumerateDirectories(path)
        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            string dirBaseFolder = Path.GetFileName(dir); // Character Fonts Items
            
            Console.ResetColor();
            Console.WriteLine($"\n{dirBaseFolder}\t");
            
            foreach (var subBaseFolder in Directory.EnumerateDirectories(dir))
            {
                // Отримає назву файла Path.GetFileName(file)
                // Hero MainFont Items
                string subFolderName = Path.GetFileName(subBaseFolder);
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.Write($"\t{subFolderName} ");
                //Console.WriteLine();
                
                foreach (var animFolder in Directory.EnumerateDirectories(subBaseFolder))
                {
                    string animFolderName = Path.GetFileName(animFolder);
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.Write($"\t \t{animFolderName} ");
                    //Console.WriteLine();

                    foreach (var dirAnimFolder in Directory.EnumerateDirectories(animFolder))
                    {
                        string animDirFolderName = Path.GetFileName(dirAnimFolder);
                        //Console.ForegroundColor = ConsoleColor.Cyan;
                        //Console.Write($"\t \t \t{animDirFolderName} ");
                        //Console.WriteLine();
                        
                        foreach (var fileNamePath in Directory.EnumerateFiles(dirAnimFolder, "*.png"))
                        {
                            //Console.ForegroundColor = ConsoleColor.Magenta;
                            //Console.WriteLine($"\t \t \t \t{fileNamePath} ");
                            Sprite sprite = new Sprite(dirBaseFolder);
                            char[,] currentSprite = LoadCharMask2D(fileNamePath);
                            sprite.AddAnimation(animFolderName+animDirFolderName, currentSprite);
                        
                            _sprites.Add(sprite);
                        }
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