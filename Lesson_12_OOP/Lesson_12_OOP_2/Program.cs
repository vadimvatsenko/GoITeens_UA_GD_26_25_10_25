// Hero - Input Renderer Layer HealthComponent

using Lesson_12_OOP_2.Engine;
namespace Lesson_12_OOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Renderer renderer = new Renderer();
            Map map = new Map(100, 25);
            
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var walls = renderer.CreateLayer(map.Width, map.Height);
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var itemsLayer = renderer.CreateLayer(map.Width, map.Height);
            
            
            renderer.Fill(backgroundLayer, '.');
            
            Update update 
                = new Update(60, 
                    renderer, 
                    map, 
                    backgroundLayer,
                    walls,
                    heroLayer,
                    itemsLayer,
                    uiLayer
                    );
            
            //update.AddUpdatable(hero, heroInput, ui, damager);
            update.RunUpdate();
        }
    }
}