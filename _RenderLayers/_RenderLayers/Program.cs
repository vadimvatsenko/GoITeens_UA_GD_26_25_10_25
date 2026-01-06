using System;
using System.Text;
using System.Threading;

class Program
{
    const int W = 60;
    const int H = 20;

    // "Пиксель" прозрачности
    const char Transparent = '\0';

    static void Main()
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = Encoding.UTF8;

        // Важно: если окно меньше — SetBufferSize может упасть, поэтому просто попробуем
        try
        {
            Console.SetWindowSize(Math.Min(W, Console.LargestWindowWidth), Math.Min(H + 1, Console.LargestWindowHeight));
            Console.SetBufferSize(Math.Min(W, Console.LargestWindowWidth), Math.Min(H + 1, Console.LargestWindowHeight));
        }
        catch { /* ничего страшного */ }

        var background = CreateLayer(W, H);
        var world      = CreateLayer(W, H);
        var ui         = CreateLayer(W, H);

        // Заполним фон точками (как "текстура")
        Fill(background, '.');

        int px = W / 2, py = H / 2;
        int tick = 0;

        while (true)
        {
            tick++;

            // --- INPUT ---
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) return;

                if (key == ConsoleKey.LeftArrow)  px--;
                if (key == ConsoleKey.RightArrow) px++;
                if (key == ConsoleKey.UpArrow)    py--;
                if (key == ConsoleKey.DownArrow)  py++;

                px = Clamp(px, 1, W - 2);
                py = Clamp(py, 1, H - 2);
            }

            // --- UPDATE LAYERS ---
            Clear(world);
            Clear(ui);

            // "мир": рамка + игрок
            DrawRect(world, 0, 0, W, H, '#');
            DrawChar(world, px, py, '@');

            // маленький "эффект": мигающая звёздочка поверх мира (но под UI)
            if ((tick / 10) % 2 == 0)
                DrawChar(world, px + 1, py, '*');

            // UI слой: текст всегда поверх
            DrawString(ui, 1, 0, "HUD: стрелки двигают @   ESC - выход");
            DrawString(ui, 1, 1, $"Pos: {px},{py}   Tick: {tick}");

            // --- COMPOSE + RENDER ---
            var frame = Compose(W, H, background, world, ui);
            Render(frame);

            Thread.Sleep(33); // ~30 FPS
        }
    }

    // ===== Layer helpers =====

    static char[,] CreateLayer(int w, int h)
    {
        return new char[h, w]; // [y,x]
    }

    static void Fill(char[,] layer, char c)
    {
        int h = layer.GetLength(0);
        int w = layer.GetLength(1);
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = c;
    }

    // OK
    static void Clear(char[,] layer)
    {
        // Заполняем прозрачностью
        int h = layer.GetLength(0);
        int w = layer.GetLength(1);
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = Transparent;
    }

    //OK
    static void DrawChar(char[,] layer, int x, int y, char c)
    {
        int h = layer.GetLength(0);
        int w = layer.GetLength(1);
        if (x < 0 || y < 0 || x >= w || y >= h) return;
        layer[y, x] = c;
    }

    static void DrawString(char[,] layer, int x, int y, string s)
    {
        for (int i = 0; i < s.Length; i++)
            DrawChar(layer, x + i, y, s[i]);
    }

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

    static void Render(char[,] frame)
    {
        int h = frame.GetLength(0);
        int w = frame.GetLength(1);

        var sb = new StringBuilder((w + 1) * h);
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
                sb.Append(frame[y, x]);
            sb.Append('\n');
        }

        Console.SetCursorPosition(0, 0);
        Console.Write(sb.ToString());
    }

    static int Clamp(int v, int min, int max) => v < min ? min : (v > max ? max : v);
}
