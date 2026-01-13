using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
// установка SixLabors із nuget.org

public static class SpriteCharMaskLoader
{
    public static char[,] LoadCharMask2D(
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