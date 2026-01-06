using RPG_Monochrome.Layers;

namespace RPG_Monochrome.Engine;

public interface IRenderer
{
    Layer Layer { get; set; }
}