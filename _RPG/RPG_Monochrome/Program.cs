using System.Diagnostics;
using System.Text;
using RPG_Monochrome.Data.Sprites.Bat;
using RPG_Monochrome.Data.Sprites.Priest;
using RPG_Monochrome.Engine;
using RPG_Monochrome.Layers;

namespace RPG_Monochrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            int mapWidth = 200;
            int mapHeight = 100;
            
            Input input = new Input();
            Renderer renderer = new Renderer();
            
            // створення ігрових слоїв
            var backgroundLayer = renderer.CreateLayer(mapWidth, mapHeight);
            var heroLayer = renderer.CreateLayer(mapWidth, mapHeight);
            var enemyLayer =  renderer.CreateLayer(mapWidth, mapHeight);
            //
            
            Hero hero = new Hero(input, new Vector2(10, 10));
            Ghost ghost = new Ghost(new Vector2(1, 1));
            Animator heroAnimator = new Animator(renderer, hero, heroLayer, AnimationSprites.BatAnimation);
            Animator ghostAnimator = new Animator(renderer, ghost, heroLayer, AnimationSprites.BatAnimation);
            
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
                
                heroAnimator.Update(deltaTime);
                ghostAnimator.Update(deltaTime);
                
                var frame = renderer.Compose(mapWidth, mapHeight, backgroundLayer, heroLayer, enemyLayer);
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
                    double fps = frames / (passedMs / 1000.0);

                    // Показуємо також останній deltaTime для наочності
                    Console.WriteLine($"FPS: {fps:F2} | deltaTime: {deltaTime:F4}s");

                    // Скидаємо лічильники на наступну секунду
                    frames = 0;
                    fpsTimerStartMs = sw.Elapsed.TotalMilliseconds;

                    
                    
                    // размер слоев должен быть одинаковый
                    //var background = CreateLayer(mapWidth, mapHeight);
                    /*var ground = CreateLayer(mapWidth, mapHeight);
                    var items = CreateLayer(mapWidth, mapHeight);
                    var ui = CreateLayer(mapWidth, mapHeight);#1#

                    Fill(background, '.');

                    int px1 = 20;
                    int py1 = 20;

                    int stepX = 0;

                    int dir = 1;       // 1 = вправо, -1 = влево

                    int minX = 0;      // левая граница патруля (в символах)
                    int maxX = 40;     // правая граница патруля (в символах)
                    int spe = 1;     // скорость (сколько символов за кадр)


                    int px = mapWidth / 2, py = mapHeight / 2;

                    const int targetFps = 60;
                    const int frameMs = 1000 / targetFps;

                        // скорость: клеток в секунду
                    double speed = 20.0;

                   


                    while (true)
                    {
                        
                        // --- UPDATE LAYERS ---
                        Clear(ground);
                        Clear(items);
                        Clear(ui);


                        /*for (int y = 0; y < Map.BlockQA_.GetLength(0); y++)
                        {
                            for (int x = 0; x < Map.BlockQA_.GetLength(1); x++)
                            {
                                char tile = Map.BlockQA_[y, x];

                                if(tile == ' ') continue;

                                int startX = x * symbolStep;

                                for (int i = 0; i < symbolStep; i++)
                                {
                                    //DrawChar(ground, startX + i + px, y + py, tile);
                                    DrawChar(items, startX + stepX + i, y, tile);
                                }
                            }
                        }#1#

                        stepX += dir * spe;

                        if (stepX >= maxX)
                        {
                            stepX = maxX;
                            dir = -1;
                        }
                        else if (stepX <= minX)
                        {
                            stepX = minX;
                            dir = 1;
                        }

                        //DrawString(ui, 1, 1, $"Pos: {px},{py}   Tick: {tick}");

                        // "мир": рамка + игрок

                        for (int y = 0; y < heroIdleDownSprites[spriteIndex].GetLength(0); y++)
                        {
                            for (int x = 0; x < heroIdleDownSprites[spriteIndex].GetLength(1); x++)
                            {
                                char tile = heroIdleDownSprites[spriteIndex][y, x];

                                if(tile == ' ') continue;

                                int startX = x * symbolStep;

                                for (int i = 0; i < symbolStep; i++)
                                {
                                    //DrawChar(ground, startX + i + px, y + py, tile);
                                    DrawChar(ground, startX + i + px, y + py, tile);
                                }
                            }
                        }
                        if (nowMs - animLastMs >= animMs)
                        {
                            spriteIndex = (spriteIndex + 1) % heroIdleDownSprites.Count;
                            animLastMs = nowMs;
                        }


                        //DrawChar(ground, px, py,'R');

                        // --- COMPOSE + RENDER ---
                        var frame = Compose(mapWidth, mapHeight, background, ground, items);
                        Render(frame);

                        long frameTime = sw.ElapsedMilliseconds - nowMs;
                        int sleep = frameMs - (int)frameTime;
                        if (sleep > 0) Thread.Sleep(sleep);*/
                }
            }
        }
    }
}

    



    //static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);


    

