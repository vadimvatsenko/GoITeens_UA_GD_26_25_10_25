using RPG_Monochrome.Engine;

namespace RPG_Monochrome.Layers;

public class Layer
{
    protected int _maxWidth;
    protected int _maxHeight;
    protected Renderer _renderer;
    
    public char[,] LayerMap {get; protected set;}

    public Layer(int maxWidth, int maxHeight, Renderer renderer)
    {
        _maxWidth = maxWidth;
        _maxHeight = maxHeight;
        _renderer = renderer;
        
        LayerMap = _renderer.CreateLayer(_maxWidth, _maxHeight);
    }
    
}