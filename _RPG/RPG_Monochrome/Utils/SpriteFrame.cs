namespace RPG_Monochrome.Utils;

// sealed забороня наслідування цього класу
// init в C# — це “сетер только при стровенні об'екта”.
// required - обов'язкове поле

public sealed class SpriteFrame
{
    public required string FileName { get; init; }
    public required int Width { get; init; }
    public required int Height { get; init; }

    // 2D “картинка” символів
    public required char[,] Pixels { get; init; }
}