using System.Drawing;

namespace SpaceInvaders;

public class Pixel
{
    public readonly Vector2 Position;
    public string Symbol;
    public ConsoleColor color;
    
    public Pixel(Vector2 position, string symbol, ConsoleColor color)
    {
        this.Position = position;
        this.Symbol = symbol;
        this.color = color;
    }
}