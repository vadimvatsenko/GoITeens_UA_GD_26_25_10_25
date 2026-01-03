namespace SuperMarioBros.GameData;

public static class ColorsPalette
{
    public static readonly Dictionary<char, ConsoleColor> Palette = new()
    {
        ['.'] = ConsoleColor.Black,
        ['R'] = ConsoleColor.Red,
        ['O'] = ConsoleColor.Yellow, // "оранжевый" приближаем желтым
        ['G'] = ConsoleColor.DarkGreen,
        ['K'] = ConsoleColor.DarkCyan,
        
    };
}