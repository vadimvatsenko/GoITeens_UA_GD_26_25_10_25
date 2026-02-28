// Продовжуемо Поліморфізм
// Практика

// ДЗ Килюшик Влад
// ДЗ Роман Подорожу часі та Магічний Кристал
// ДЗ Скурту ООП


// Мітя ДЗ поправка
// ДЗ розібрати

// Hero
// Weapon в инвентарь

using System.Text;
using Lesson_14_Polymorphism_2.Engine;



namespace Lesson_14_Polymorphism_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            char backgroundSymbol = '░';
            
            char heroSymbol = '❖';
            char warriorSymbol = '◙';
            char archer = '▲';
            char mage = '◉';

            char bow = '◗';
            //char shogun = ''
            char projectTile = '▫';
            char arrow = '◃';
            
            Map map = new Map(100, 25);
            Renderer renderer = new Renderer();
            Input input = new Input();
            
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var enemiesLayer = renderer.CreateLayer(map.Width, map.Height);
            
            renderer.Fill(backgroundLayer, backgroundSymbol);

            while (true)
            {
                //renderer.Clear(uiLayer);
                renderer.Clear(enemiesLayer);
                renderer.Clear(heroLayer);
                
                input.Update(16666);
               
                // hero upppppdate
                
                var frame 
                    = renderer.Compose(map.Width,  map.Height, backgroundLayer, uiLayer, enemiesLayer, heroLayer);
                renderer.Render(frame);
                
                Thread.Sleep(16666);
            }
        }
    }
    
}