using System.Resources;
using Lesson_12_OOP_2.Engine;

namespace Lesson_12_OOP_2;

public class UI : IUpdatable
{
    private Renderer _renderer;
    private HealthComponent _heroHealthComponent;
    private char[,] _uiLayer;

    public UI(Renderer renderer, HealthComponent heroHealthComponent,  char[,] uiLayer)
    {
        _renderer = renderer;
        _heroHealthComponent = heroHealthComponent;
        _uiLayer = uiLayer;
    }
    
    public void Update(double deltaTime)
    {
        _renderer.DrawString(_uiLayer, 50, 0, $"hero health: {_heroHealthComponent.Health.ToString()}" );
    }
}