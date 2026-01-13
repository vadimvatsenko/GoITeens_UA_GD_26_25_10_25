using System.Diagnostics;
using RPG_Monochrome.Data.Sprites;
using RPG_Monochrome.Engine;
using RPG_Monochrome.Items;
using RPG_Monochrome.Utils;

namespace RPG_Monochrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpritesLoaderSystem spritesLoader = new SpritesLoaderSystem();


            int score = 0;

            Console.CursorVisible = false;
            Random random = new Random();

            Input input = new Input();
            Renderer renderer = new Renderer();


            //створення ігрових слоїв та мапи
            int mapWidth = 100;
            int mapHeight = 50;
            Map map = new Map(mapWidth, mapHeight);
            var backgroundLayer = renderer.CreateLayer(map.Width, map.Height);
            var uiLayer = renderer.CreateLayer(map.Width, map.Height);
            var enemyLayer = renderer.CreateLayer(map.Width, map.Height);
            var heroLayer = renderer.CreateLayer(map.Width, map.Height);
            var itemsLayer = renderer.CreateLayer(map.Width, map.Height);
            //

            List<Coin> coins = new List<Coin>();
            int coinCount = 10;

            for (int i = 0; i < coinCount; i++)
            {
                Animator coinAnimator = new Animator(renderer, itemsLayer, AnimationSprites.CoinAnimation);
                Coin coin = new Coin(new Vector2(random.Next(0, mapWidth - 6), random.Next(0, mapHeight - 6)), renderer,
                    coinAnimator);
                coinAnimator.SetCreature(coin);
                coins.Add(coin);
            }

            Animator heroAnimator = new Animator(renderer, heroLayer, spritesLoader.Sprites(x => ));
            Animator ghostAnimator = new Animator(renderer, enemyLayer, AnimationSprites.GhostAnimation);

            Hero hero = new Hero(new Vector2(10, 10), renderer, input, heroAnimator, coins, map);
            Ghost ghost = new Ghost(new Vector2(1, 1), renderer, ghostAnimator, hero, map);

            heroAnimator.SetCreature(hero);
            ghostAnimator.SetCreature(ghost);

            renderer.Fill(backgroundLayer, '.');

            // Stopwatch — точніший таймер, ніж DateTime.Now
            Stopwatch sw = Stopwatch.StartNew();
            // === Налаштування цільового FPS ============================================
            int targetFps = 60;

            // Час одного кадру в мілісекундах.
            // 1000 мс / 60 ≈ 16.666... мс на кадр
            double targetFrameMs = 1000.0 / targetFps;

            // Час, коли "має" закінчитися наступний кадр (у мс від старту програми)
            double nextFrameMs = 0;

            // === deltaTime ==============================================================
            // Зберігаємо час старту попереднього кадру (в мс)
            double lastFrameStartMs = sw.Elapsed.TotalMilliseconds;

            // === Лічильники для FPS =====================================================
            double fps = 0;
            int frames = 0; // скільки кадрів пройшло за поточну секунду
            double fpsTimerStartMs = sw.Elapsed.TotalMilliseconds; // старт відліку "секунди"

            while (true)
            {

                // === 1) ПОЧАТОК КАДРУ ==================================================
                double frameStartMs = sw.Elapsed.TotalMilliseconds;

                // deltaTime — час між стартом цього кадру і стартом попереднього кадру
                // В секундах (бо в іграх dt зазвичай у секундах)
                double deltaTime = (frameStartMs - lastFrameStartMs) / 1000.0;

                // Оновлюємо "останній час" для наступної ітерації
                lastFrameStartMs = frameStartMs;

                // Тут зазвичай викликають ігрову логіку:
                // Update(deltaTime);

                ///////////////////////////////
                input.Update(deltaTime);

                renderer.Clear(heroLayer);
                renderer.Clear(enemyLayer);
                renderer.Clear(itemsLayer);
                renderer.Clear(uiLayer);

                ghost.Update(deltaTime);
                hero.Update(deltaTime);

                ghostAnimator.Update(deltaTime);

                coins.ForEach(coin => coin.Animator.Update(deltaTime));

                renderer.DrawString(uiLayer, 1, 1, $"FPS: {fps:F2} | deltaTime: {deltaTime:F4}s");
                var frame = renderer.Compose(mapWidth, mapHeight, backgroundLayer, uiLayer, enemyLayer, heroLayer,
                    itemsLayer);
                renderer.Render(frame);

                ////////////////////////////////

                // === 2) ОБМЕЖЕННЯ FPS ===================================================
                // Ми хочемо, щоб кожен кадр закінчувався не раніше, ніж через targetFrameMs
                // Тому плануємо "час завершення" поточного кадру:
                nextFrameMs += targetFrameMs;

                // Скільки часу ще залишилось до nextFrameMs
                double nowMs = sw.Elapsed.TotalMilliseconds;
                double remainingMs = nextFrameMs - nowMs;

                // Якщо залишилось більше ~1 мс — можна приспати потік (економить CPU)
                if (remainingMs > 1)
                {
                    // Sleep приймає ціле число мілісекунд -> дробова частина губиться
                    Thread.Sleep((int)remainingMs);
                }

                // Доробляємо "точність" коротким активним очікуванням (busy-wait)
                // Це дає рівніший таймінг, ніж один лише Sleep
                while (sw.Elapsed.TotalMilliseconds < nextFrameMs)
                {
                    // нічого не робимо — просто чекаємо
                }

                // === 3) ПІДРАХУНОК FPS (раз на ~1 секунду) ==============================
                frames++;

                double passedMs = sw.Elapsed.TotalMilliseconds - fpsTimerStartMs;

                // Якщо пройшла (або майже) секунда — виводимо FPS
                if (passedMs >= 1000)
                {
                    fps = frames / (passedMs / 1000.0);

                    //Console.WriteLine($"FPS: {fps:F2} | deltaTime: {deltaTime:F4}s");
                    // Показуємо також останній deltaTime для наочності


                    // Скидаємо лічильники на наступну секунду
                    frames = 0;
                    fpsTimerStartMs = sw.Elapsed.TotalMilliseconds;

                }
            }
        }
    }
}


    

