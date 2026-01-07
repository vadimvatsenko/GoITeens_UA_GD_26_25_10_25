namespace RPG_Monochrome.Data.Utils;

public static class MirrowSprites
{
    public static char[,] MirrorHorizontally(char[,] sprite)
    {
        int h = sprite.GetLength(0);
        int w = sprite.GetLength(1);

        var result = new char[h, w];

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                result[y, w - 1 - x] = sprite[y, x];
            }
        }

        return result;
    }
    
    public static char[,] MirrorVertically(char[,] sprite)
    {
        int h = sprite.GetLength(0);
        int w = sprite.GetLength(1);

        var result = new char[h, w];

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                result[h - 1 - y, x] = sprite[y, x];
            }
        }

        return result;
    }
}