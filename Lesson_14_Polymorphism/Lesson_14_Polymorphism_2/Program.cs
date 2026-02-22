using System.Text;
using Lesson_14_Polymorphism_2.Components;
using Lesson_14_Polymorphism_2.Engine;
using Lesson_14_Polymorphism_2.Weapons;

namespace Lesson_14_Polymorphism_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            
            char heroSymbol = '❖';
            char warriorSymbol = '◙';
            char archer = '▲';
            char mage = '◉';
            
            Map map = new Map(100, 25);
            Renderer renderer = new Renderer();
            Input input = new Input();
            
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var enemiesLayer = renderer.CreateLayer(map.Width, map.Height);
            
            InventoryComponent heroInventory = new InventoryComponent();
            HealthComponent healthComponent = new HealthComponent(100, 100);
            
            Weapon sword = new Sword();
            Weapon bow = new Bow();
            Weapon shotgun = new Shorgun();
            
            InventoryUI heroUI = new InventoryUI(heroInventory, healthComponent, renderer, map, uiLayer);
            Hero hero = new Hero(new Vector2(2,2), heroSymbol, renderer, heroLayer, map, heroInventory, input);
            
            hero.AddWeaponInInventory(sword);
            //hero.AddWeaponInInventory(bow);
            hero.AddWeaponInInventory(shotgun);
            
            renderer.Fill(backgroundLayer, '.');

            while (true)
            {
                //renderer.Clear(uiLayer);
                renderer.Clear(enemiesLayer);
                renderer.Clear(heroLayer);
                
                input.Update(16666);
                hero.Update();
                
                var frame 
                    = renderer.Compose(map.Width,  map.Height, backgroundLayer, uiLayer, enemiesLayer, heroLayer);
                renderer.Render(frame);
            }
        }
    }
    
}