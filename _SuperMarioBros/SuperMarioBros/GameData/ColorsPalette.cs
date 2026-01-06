namespace SuperMarioBros.GameData;

public static class ColorsPalette
{
    public static readonly Dictionary<char, ConsoleColor> Palette = new()
    {
        [' '] = ConsoleColor.Black, // Black
        ['R'] = ConsoleColor.DarkRed, // Walls and Ground Main Color 
        ['B'] = ConsoleColor.DarkCyan, // Sky
        ['U'] = ConsoleColor.DarkYellow, // 
        ['Y'] = ConsoleColor.Yellow,
        ['G'] = ConsoleColor.DarkGreen,
        ['P'] = ConsoleColor.DarkMagenta,
    };
}