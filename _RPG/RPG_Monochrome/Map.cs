namespace RPG_Monochrome;

public class Map
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
    }
}