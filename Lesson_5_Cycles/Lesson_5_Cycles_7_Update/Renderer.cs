
namespace Lesson_5_Cycles_7_Update;

public class Renderer: IRenderer
{
    private readonly char[,] _prevPixels;
    private readonly byte[,] _prevColorByte;
    public int Width { get; private set; } // ширина консольного вікна
    public int Height { get; private set; } // висота консольного вікна

    private const int MaxColors = 8; // обмежує кількість підтримуваних кольорів до 8.
    
    private readonly ConsoleColor[] _colors; // масив кольорів, що використовується для відмалювання
    public ConsoleColor BgColor { get; set; }  // зберігає колір фону консолі
    
    private readonly char[,] _pixels; // двовимірний масив символів, що представляють пікселі в консолі
    private readonly byte[,] _pixelColors; // двовимірний масив індексів кольорів, що відповідають кожному пікселю
    
    private readonly int _maxWidth; // максимальна ширина консольного вікна, яку можна використовувати для відмалювання
    private readonly int _maxHeight; // максимальна висота консольного вікна, яку можна використовувати для відмалювання
    
    public bool IsRenderChanged = true;
    
    // Індексатор: дозволяє отримати або встановити символ для конкретної координати пікселя (w, h), використовуючи синтаксис renderer[w, h]
    public char this[int w, int h]
    {
        get { return _pixels[w, h]; }
        set { _pixels[w, h] = value; }
    }

    // Конструктор
    public Renderer(ConsoleColor[] colors)
    {
        if (colors.Length > MaxColors) 
        {
            // Приймає масив кольорів colors. Якщо кількість кольорів перевищує MaxColors, вони обрізаються до цього значення.
            var tmp = new ConsoleColor[MaxColors];
            Array.Copy(colors, tmp, tmp.Length);
            colors = tmp;
        }

        _colors = colors;

        _maxWidth = Console.LargestWindowWidth; // встановлення максимальної ширини екрана
        _maxHeight = Console.LargestWindowHeight; // встановлення максимальної висоти екрана
        Width = Console.WindowWidth; // ширина консольного вікна
        Height = Console.WindowHeight; // висота консольного вікна
        //width = 100;
        //height = 40;

        _pixels = new char[_maxWidth, _maxHeight]; // ініціалізація масиву пікселів
        _pixelColors = new byte[_maxWidth, _maxHeight]; // ініціалізація кольору пікселів
        
        _prevColorByte = new byte[_maxWidth, _maxHeight];
        _prevPixels = new char[_maxWidth, _maxHeight];
    }

    // Встановлює символ (val) та індекс кольору (colorIdx) для пікселя в координатах w, h
    public void SetPixel(int w, int h, char val, byte colorIdx)
    { 
        _pixels[w, h] = val;
        _pixelColors[w, h] = colorIdx;
    }
    
    // Відповідає за відмалювання вмісту масиву _pixels у консоль.
    public void Render()
    {
        
        if (IsRenderChanged)
        {
            Console.Clear(); // очищає екран
            Console.BackgroundColor = BgColor; // встановлює колір фону

            for (var w = 0; w < Width; w++) // заповнюємо консоль
            for (var h = 0; h < Height; h++)
            {
                var colorIdx = _pixelColors[w, h]; // кольори
                var color = _colors[colorIdx]; // 
                var symbol = _pixels[w, h]; // символи

                if (symbol == 0 || color == BgColor) // якщо немає символу або колір збігається з bgColor — пропускаємо
                    continue;

                Console.ForegroundColor = color; // встановлення кольору тексту

                Console.SetCursorPosition(w, h); // встановлення курсора
                Console.Write(symbol); // відмалювання символа
            }

            Console.ResetColor(); // скидає колірні налаштування консолі
            Console.CursorVisible = false; // ховає курсор
        }
    }

    

    // відмалювання тексту в потрібному місці
    public void DrawString(string text, int atWidth, int atHeight, ConsoleColor color)
    {
        var colorIdx = Array.IndexOf(_colors, color); // перевіряє, чи є колір у масиві _colors
        if (colorIdx < 0) // якщо немає — перериваємо виконання
            return;

        for (int i = 0; i < text.Length; i++)
        {
            _pixels[atWidth + i, atHeight] = text[i]; // заповнює кожен символ тексту у потрібну комірку
            _pixelColors[atWidth + i, atHeight] = (byte)colorIdx; // заповнюємо кожну комірку кольором по горизонталі
        }
    }

    // очищення консолі
    public void Clear()
    {
        for (int w = 0; w < Width; w++)
        for (int h = 0; h < Height; h++)
        {
            _pixelColors[w, h] = 0;
            _pixels[w, h] = (char)0;
        }
    }

    // Перевіряє, чи є даний об’єкт ідентичним іншому екземпляру Renderer
    // Порівнює розміри вікон і масив кольорів.
    // Перевіряє всі елементи масивів _pixels та _pixelColors
    public override bool Equals(object? obj)
    {
        if (obj is not Renderer casted)
            return false;

        if (_maxWidth != casted._maxWidth || _maxHeight != casted._maxHeight ||
            Width != casted.Width || Height != casted.Height ||
            _colors.Length != casted._colors.Length)
        {
            return false;
        }


        for (int i = 0; i < _colors.Length; i++)
        {
            if (_colors[i] != casted._colors[i])
                return false;
        }

        for (int w = 0; w < Width; w++)
        for (var h = 0; h < Height; h++)
        {
            if (_pixels[w, h] != casted._pixels[w, h] ||
                _pixelColors[w, h] != casted._pixelColors[w, h])
            {
                return false;
            }
        }

        return true;
    }

    // Генерує унікальний хеш-код для об’єкта, враховуючи розміри, масив кольорів та значення пікселів
    public override int GetHashCode()
    {
        var hash = HashCode.Combine(_maxWidth, _maxHeight, Width, Height);

        for (int i = 0; i < _colors.Length; i++)
        {
            hash = HashCode.Combine(hash, _colors[i]);
        }

        for (int w = 0; w < Width; w++)
        for (var h = 0; h < Height; h++)
        {
            hash = HashCode.Combine(hash, _pixelColors[w, h], _pixels[w, h]);
        }

        return hash;
    }
}

