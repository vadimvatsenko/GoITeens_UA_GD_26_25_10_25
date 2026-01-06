using System.Text;

namespace RPG_Monochrome.Engine;

public class Renderer: IUpdatable
{
    private const char Transparent = '\0';
    
    private List<IRenderer> _renderer = new List<IRenderer>();

    public void AddRenderer(IRenderer renderer) => _renderer.Add(renderer);
    public void RemoveRenderer(IRenderer renderer) => _renderer.Remove(renderer);
    
    public void Fill(char[,] layer, char s)
        {
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            
            for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = s;
        }
    
        // стрворить масив слоя
        public char[,] CreateLayer(int w, int h)
        {
            return new char[h, w]; // [y,x]
        }
        
        // Clear
        public void Clear(char[,] layer)
        {
            // Заполняем прозрачностью
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                layer[y, x] = Transparent;
        }
        
        // Draw Char
        public void DrawChar(char[,] layer, int x, int y, char c)
        {
            int h = layer.GetLength(0);
            int w = layer.GetLength(1);
            if (x < 0 || y < 0 || x >= w || y >= h) return;
            layer[y, x] = c;
        }
        
        // Draw String
        private void DrawString(char[,] layer, int x, int y, string s)
        {
            for (int i = 0; i < s.Length; i++)
                DrawChar(layer, x + i, y, s[i]);
        }
        
        // Квадрат
        private void DrawRect(char[,] layer, int x, int y, int w, int h, char c)
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

        public char[,] Compose(int w, int h, params char[][,] layers)
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

        
        public void Render(char[,] frame)
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

        public void Update(double deltaTime)
        {
            foreach (var r in _renderer)
            {
               Render(r.Layer.LayerMap);
            }
        }
}
