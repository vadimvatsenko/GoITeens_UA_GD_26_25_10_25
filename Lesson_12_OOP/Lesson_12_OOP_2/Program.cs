using Lesson_12_OOP_2.Engine;

namespace Lesson_12_OOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Item item = new Item("Health", new Vector2(5, 3));
            
            
            
            Console.CursorVisible = false;
            
            Input input = new Input();
            Renderer renderer = new Renderer();
            Hero hero = new Hero(input);
            
            int mapWidth = 100;
            int mapHeight = 50;
            Map map = new Map(mapWidth, mapHeight);
            
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var walls = renderer.CreateLayer(map.Width, map.Height);
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var itemsLayer = renderer.CreateLayer(map.Width, map.Height);
            
            renderer.Fill(backgroundLayer, '.');

            while (true)
            {
                input.Update(16);

                if (hero.Position == item.InWorldCoordinates)
                {
                    hero.Inventory.AddOrPutItem(item, 1);
                }
                
                renderer.Clear(heroLayer);
                renderer.Clear(itemsLayer);
                renderer.Clear(uiLayer);
                renderer.Clear(walls);
                
                renderer.DrawRect(walls, 0, 0, map.Width, map.Height, '#');
                renderer.DrawChar(heroLayer, hero.Position.X, hero.Position.Y, hero.Symbol);
                //renderer.DrawString(uiLayer, 1, 1, $"FPS: {fps:F2} | deltaTime: {deltaTime:F4}s");
                var frame = renderer.Compose(mapWidth, mapHeight,walls, backgroundLayer, uiLayer, heroLayer,
                    itemsLayer);
                renderer.Render(frame);
            }
        }
    }
}