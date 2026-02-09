// Hero - Input Renderer Layer HealthComponent

using Lesson_12_OOP_2.Engine;
namespace Lesson_12_OOP_2
{
    public class Test
    {
        
    }
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
            
            Hero hero = new Hero(renderer, new Vector2(1,1));
            hero.TakeDamage(10);
            
            Console.WriteLine(hero.HealthComponent.Health);
            
            hero.BuffHealth(50);
            
            Console.WriteLine(hero.HealthComponent.Health);
            
            hero.TakeDamage(100);
            
            Console.WriteLine(hero.HealthComponent.Health);
            
            hero.Inventory.AddItem("Sword", 10);
            hero.Inventory.AddItem("Axe", 15);
            hero.Inventory.AddItem("Armor", 13);
            hero.Inventory.AddItem("Shield", 14);
            
            Console.WriteLine("before");
            hero.Inventory.ShowInventory();
            
            Console.WriteLine("after");
            hero.Inventory.RemoveItem("Sword");
            hero.Inventory.ShowInventory();
            
            hero.EquiptWeapon("Sword");
            hero.Attack();

            Console.ReadKey();
            
            /*Update update
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
            update.RunUpdate();*/
        }
    }

    
}