using System;
using System.Collections.Generic;
using System.Drawing; // оставил как у тебя, но тут не используется
using System.Threading;

namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pixel> pixelsList = new List<Pixel>();

            Dictionary<char, string[]> font = GetSpaceInvadersFont();

            AddText(pixelsList, font, "SPACE", new Vector2(5, 3), ConsoleColor.Green);
            AddText(pixelsList, font, "INVADERS", new Vector2(5, 12), ConsoleColor.Magenta);

            Console.Clear();
            Console.CursorVisible = false;

            // 1) Рисуем пиксельный логотип (статично)
            DrawPixels(pixelsList);

            // 2) Мигающий текст снизу (обычный текст, не пиксели)
            string blinkText = "PRESS START";
            int blinkX = 5 * 2; // чтобы совпадало с логикой X*2
            int blinkY = 23; // ниже логотипа
            bool visible = false;

            while (true)
            {
                // выход по Enter / Space / Esc
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar || key == ConsoleKey.Escape)
                        break;
                }

                visible = !visible;

                Console.SetCursorPosition(blinkX, blinkY);

                if (visible)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(blinkText);
                }
                else
                {
                    Console.Write(new string(' ', blinkText.Length)); // "стереть" текст
                }

                Console.ResetColor();
                Thread.Sleep(350);
            }

            Console.ResetColor();
            Console.CursorVisible = true;
        }

        static void DrawPixels(List<Pixel> scene)
        {
            foreach (Pixel pixel in scene)
            {
                Console.ForegroundColor = pixel.color;
                Console.SetCursorPosition((int)pixel.Position.X * 2, (int)pixel.Position.Y);
                Console.Write(pixel.Symbol);
            }

            Console.ResetColor();
        }

        // Добавление пиксельного текста в сцену
        static void AddText(List<Pixel> scene, Dictionary<char, string[]> font, string text, Vector2 startPos,
            ConsoleColor color)
        {
            float currentX = startPos.X;

            foreach (char raw in text)
            {
                char c = char.ToUpperInvariant(raw);

                if (!font.ContainsKey(c))
                {
                    currentX += 6;
                    continue;
                }

                string[] sprite = font[c];

                for (int y = 0; y < sprite.Length; y++)
                {
                    for (int x = 0; x < sprite[y].Length; x++)
                    {
                        if (sprite[y][x] == '1')
                        {
                            scene.Add(new Pixel(new Vector2((int)currentX + x, startPos.Y + y), "██", color));
                        }
                    }
                }

                currentX += sprite[0].Length + 1;
            }
        }

        // Шрифт 7×5 для нужных букв
        static Dictionary<char, string[]> GetSpaceInvadersFont()
        {
            return new Dictionary<char, string[]>()
            {
                { ' ', new[] { "00000", "00000", "00000", "00000", "00000", "00000", "00000" } },

                // A-Z (7x5)
                { 'A', new[] { "01110", "10001", "10001", "11111", "10001", "10001", "10001" } },
                { 'B', new[] { "11110", "10001", "10001", "11110", "10001", "10001", "11110" } },
                { 'C', new[] { "01111", "10000", "10000", "10000", "10000", "10000", "01111" } },
                { 'D', new[] { "11110", "10001", "10001", "10001", "10001", "10001", "11110" } },
                { 'E', new[] { "11111", "10000", "10000", "11110", "10000", "10000", "11111" } },
                { 'F', new[] { "11111", "10000", "10000", "11110", "10000", "10000", "10000" } },
                { 'G', new[] { "01111", "10000", "10000", "10111", "10001", "10001", "01111" } },
                { 'H', new[] { "10001", "10001", "10001", "11111", "10001", "10001", "10001" } },
                { 'I', new[] { "11111", "00100", "00100", "00100", "00100", "00100", "11111" } },
                { 'J', new[] { "00111", "00010", "00010", "00010", "00010", "10010", "01100" } },
                { 'K', new[] { "10001", "10010", "10100", "11000", "10100", "10010", "10001" } },
                { 'L', new[] { "10000", "10000", "10000", "10000", "10000", "10000", "11111" } },
                { 'M', new[] { "10001", "11011", "10101", "10101", "10001", "10001", "10001" } },
                { 'N', new[] { "10001", "11001", "10101", "10011", "10001", "10001", "10001" } },
                { 'O', new[] { "01110", "10001", "10001", "10001", "10001", "10001", "01110" } },
                { 'P', new[] { "11110", "10001", "10001", "11110", "10000", "10000", "10000" } },
                { 'Q', new[] { "01110", "10001", "10001", "10001", "10101", "10010", "01101" } },
                { 'R', new[] { "11110", "10001", "10001", "11110", "10100", "10010", "10001" } },
                { 'S', new[] { "01111", "10000", "10000", "01110", "00001", "00001", "11110" } },
                { 'T', new[] { "11111", "00100", "00100", "00100", "00100", "00100", "00100" } },
                { 'U', new[] { "10001", "10001", "10001", "10001", "10001", "10001", "01110" } },
                { 'V', new[] { "10001", "10001", "10001", "10001", "10001", "01010", "00100" } },
                { 'W', new[] { "10001", "10001", "10001", "10101", "10101", "11011", "10001" } },
                { 'X', new[] { "10001", "10001", "01010", "00100", "01010", "10001", "10001" } },
                { 'Y', new[] { "10001", "10001", "01010", "00100", "00100", "00100", "00100" } },
                { 'Z', new[] { "11111", "00001", "00010", "00100", "01000", "10000", "11111" } },
            };
        }
    }
}
