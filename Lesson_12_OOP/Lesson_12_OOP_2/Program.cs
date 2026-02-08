// Hero

using Lesson_12_OOP_2.Engine;
namespace Lesson_12_OOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            
            Renderer renderer = new Renderer();
            Map map = new Map(100, 25);
            Input heroInput = new Input();
            
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var walls = renderer.CreateLayer(map.Width, map.Height);
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var itemsLayer = renderer.CreateLayer(map.Width, map.Height);
            
            Hero hero = new Hero(heroInput, renderer, heroLayer);
            UI ui = new UI(renderer, hero.HealthComponent, uiLayer);

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
            
            update.AddUpdatable(hero, heroInput, ui);
            update.RunUpdate();
        }
    }
}