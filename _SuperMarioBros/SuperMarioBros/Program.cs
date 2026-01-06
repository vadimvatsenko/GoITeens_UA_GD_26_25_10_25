using System.Drawing;
using System.Text;
using SuperMarioBros.Animation;
using SuperMarioBros.Engine;
using SuperMarioBros.GameData;
using SuperMarioBros.GameData.Sprites;
using SuperMarioBros.Mario;

namespace SuperMarioBros
{
    
    internal class Program
    {
        // "Пиксель" прозрачности
        const char Transparent = '\0';
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            int tileW = 32; // ширина тайла в символах консоли
            int tileH = 16; // высота тайла

            int mapWidth = 300;
            int mapHeight = 150;
            
            string symbol = "██";
            int symbolStep = symbol.Length;
            
            // размер слоев должен быть одинаковый
            var background = CreateLayer(mapWidth, mapHeight);
            var ground = CreateLayer(mapWidth, mapHeight);
            var items = CreateLayer(mapWidth, mapHeight);
            var ui = CreateLayer(mapWidth, mapHeight);

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

            var sw = System.Diagnostics.Stopwatch.StartNew();
            long lastMs = sw.ElapsedMilliseconds;
            
            
            
            
            while (true)
            {
                long nowMs = sw.ElapsedMilliseconds;
                double dt = (nowMs - lastMs) / 1000.0;  // секунды
                lastMs = nowMs;
                
                // --- INPUT ---
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape) return;

                    if (key == ConsoleKey.LeftArrow)  px--;
                    if (key == ConsoleKey.RightArrow) px++;
                    if (key == ConsoleKey.UpArrow)    py--;
                    if (key == ConsoleKey.DownArrow)  py++;

                    px = Clamp(px, -4, mapWidth - 28);
                    py = Clamp(py, 0, mapHeight - 16);
                }

                // --- UPDATE LAYERS ---
                Clear(ground);
                Clear(items);
                Clear(ui);


                
                
                for (int y = 0; y < Map.BlockQA_.GetLength(0); y++)
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
                }

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
                for (int y = 0; y < Map.SmallMarioIdle_.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.SmallMarioIdle_.GetLength(1); x++)
                    {
                        char tile = Map.SmallMarioIdle_[y, x];
                        
                        if(tile == ' ') continue;

                        int startX = x * symbolStep;

                        for (int i = 0; i < symbolStep; i++)
                        {
                            //DrawChar(ground, startX + i + px, y + py, tile);
                            DrawChar(ground, startX + i + px, y + py, tile);
                        }
                    }
                }
                
                //DrawChar(ground, px, py,'R');
                
                // --- COMPOSE + RENDER ---
                var frame = Compose(mapWidth, mapHeight, background, ground, items);
                Render(frame);

                long frameTime = sw.ElapsedMilliseconds - nowMs;
                int sleep = frameMs - (int)frameTime;
                if (sleep > 0) Thread.Sleep(sleep);
            }
            
        }

        private static void Fill(char[,] layer, char s)
        {
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            
            for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = s;
        }

        // Установка цвета, в зависимости от символа тайла
        private static void SetColor(char tile)
        {
            Console.ForegroundColor = tile switch
            {
                'B' => ColorsPalette.Palette['B'],
                'R' => ColorsPalette.Palette['R'],
                'U' => ColorsPalette.Palette['U'],
                'G' => ColorsPalette.Palette['G'],
                'Y' => ColorsPalette.Palette['Y'],
                'P' => ColorsPalette.Palette['P'],
                ' ' => ColorsPalette.Palette[' '],
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        // создаст массив слоёв
        private static char[,] CreateLayer(int w, int h)
        {
            return new char[h, w]; // [y,x]
        }
        
        // Clear
        static void Clear(char[,] layer)
        {
            // Заполняем прозрачностью
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = Transparent;
        }
        
        // Draw Char
        static void DrawChar(char[,] layer, int x, int y, char c)
        {
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            if (x < 0 || y < 0 || x >= w || y >= h) return;
            layer[y, x] = c;
        }
        
        // Draw String
        static void DrawString(char[,] layer, int x, int y, string s)
        {
            for (int i = 0; i < s.Length; i++)
                DrawChar(layer, x + i, y, s[i]);
        }
        
        // Квадрат
        static void DrawRect(char[,] layer, int x, int y, int w, int h, char c)
        {
            for (int i = 0; i < w; i++)
            {
                DrawChar(layer, x + i, y, c);
                DrawChar(layer, x + i, y + h - 1, c);
            }
            for (int j = 0; j < h; j++)
            {
                DrawChar(layer, x, y + j, c);
                DrawChar(layer, x + w - 1, y + j, c);
            }
        }
        
        // ===== Compose + Render =====

        static char[,] Compose(int w, int h, params char[][,] layers)
        {
            var outFrame = new char[h, w];

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    char result = ' '; // если вообще ничего
                    foreach (var layer in layers)
                    {
                        char c = layer[y, x];
                        if (c != Transparent)
                            result = c; // верхний непрозрачный перекрывает
                    }
                    outFrame[y, x] = result;
                }
            }

            return outFrame;
        }

        // МЫы сначала собираем все в едино, полный кадр, только после всё прорисовываем
        /*static void Render(char[,] frame)
        {
            // позиция левый верхний угол
            Console.SetCursorPosition(0, 0);
            
            int h = frame.GetLength(0); // высота кадра
            int w = frame.GetLength(1); // ширина кадра
            
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    char c = frame[y, x];
                    //SetColor(c);     // <- цвет ставим тут
                    Console.Write('█');
                }
                   
                Console.WriteLine();
            }
        }*/
        
        static void Render(char[,] frame)
        {
            int h = frame.GetLength(0);
            int w = frame.GetLength(1);

            var sb = new StringBuilder((w + 1) * h);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    sb.Append(frame[y, x]);
                }
                sb.AppendLine(" ");
            }
            
            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }
        
        /*static void Render(char[,] frame, char pixelChar = '█')
        {
            int h = frame.GetLength(0);
            int w = frame.GetLength(1);

            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < h; y++)
            {
                char lastKey = '\0';

                for (int x = 0; x < w; x++)
                {
                    char key = frame[y, x]; // здесь лежит 'R','G','U',' ' и т.п.

                    if (key != lastKey)
                    {
                        Console.ForegroundColor = ColorsPalette.Palette.TryGetValue(key, out var c)
                            ? c
                            : ConsoleColor.White;

                        lastKey = key;
                    }

                    Console.Write(pixelChar);
                }

                Console.Write('\n');
            }
        }*/

        static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);
        
        // Target - Old
        private static void DrawBlock(int startX, int startY, int symbolStep, string symbol)
        {
            for (int y = 0; y < Map.Wall.GetLength(0); y++)
            {
                for (int x = 0; x < Map.Wall.GetLength(1); x++)
                {
                    Console.SetCursorPosition(startX + x * symbolStep, startY + y);
                    char tile =  Map.Wall[y,x];
                    
                    Console.ForegroundColor = tile switch
                    {
                        'B' => ColorsPalette.Palette['B'],
                        'R' => ColorsPalette.Palette['R'],
                        'U' => ColorsPalette.Palette['U'],
                        'G' => ColorsPalette.Palette['G'],
                        'Y' => ColorsPalette.Palette['Y'],
                        'P' => ColorsPalette.Palette['P'],
                        ' ' => ColorsPalette.Palette[' '],
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    Console.Write(symbol);
                }
            }
        }
    }
}
