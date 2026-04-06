

namespace SuperMarioBros.Engine
{
    public class ConsoleRenderer

    {
    private readonly char[,] _prevPixels;
    private readonly byte[,] _prevColorByte;
    public int width { get; private set; } // ширина консольного вікна
    public int height { get; private set; } // висота консольного вікна

    private const int MaxColors = 8; // обмежує кількість підтримуваних кольорів до 8.

    private readonly ConsoleColor[] _colors; // масив кольорів, що використовуються для відрисовування
    public ConsoleColor bgColor { get; set; } // зберігає колір фону консолі

    private readonly char[,] _pixels; // двовимірний масив символів, що представляють «пікселі» в консолі
    private readonly byte[,] _pixelColors; // двовимірний масив індексів кольорів, що відповідають кожному пікселю

    private readonly int _maxWidth; // максимальна ширина консольного вікна, яку можна використати для відрисовування
    private readonly int _maxHeight; // максимальна висота консольного вікна, яку можна використати для відрисовування

    public bool IsRenderChanged = true;

    // Індексатор. Дозволяє отримати або встановити символ для конкретної координати пікселя (w, h),
    // використовуючи синтаксис renderer[w, h]
    public char this[int w, int h]
    {
        get { return _pixels[w, h]; }
        set { _pixels[w, h] = value; }
    }

    // Конструктор
    public ConsoleRenderer(ConsoleColor[] colors)
    {
        if (colors.Length > MaxColors)
        {
            // Приймає масив кольорів colors. Якщо кількість кольорів перевищує MaxColors, вони обрізаються до цього значення.
            var tmp = new ConsoleColor[MaxColors];
            Array.Copy(colors, tmp, tmp.Length);
            colors = tmp;
        }

        _colors = colors;

        _maxWidth = Console.LargestWindowWidth; // встановлення максимальної ширини вікна
        _maxHeight = Console.LargestWindowHeight; // встановлення максимальної висоти вікна
        width = Console.WindowWidth; // ширина консольного вікна
        height = Console.WindowHeight; // висота консольного вікна
        //width = 100;
        //height = 40;

        _pixels = new char[_maxWidth, _maxHeight]; // ініціалізація масиву «пікселів»
        _pixelColors = new byte[_maxWidth, _maxHeight]; // ініціалізація кольорів «пікселів»

        _prevColorByte = new byte[_maxWidth, _maxHeight];
        _prevPixels = new char[_maxWidth, _maxHeight];
    }

    // Встановлює символ (val) та індекс кольору (colorIdx) для пікселя за координатами w, h
    public void SetPixel(int w, int h, char val, byte colorIdx)
    {
        _pixels[w, h] = val;
        _pixelColors[w, h] = colorIdx;
    }

    // Відповідає за відрисовування вмісту масиву _pixels у консоль.
    public void Render()
    {
        if (IsRenderChanged)
        {
            Console.Clear(); // очищає екран
            Console.BackgroundColor = bgColor; // встановлює колір фону

            for (var w = 0; w < width; w++) // заповнюємо консоль
            for (var h = 0; h < height; h++)
            {
                var colorIdx = _pixelColors[w, h]; // кольори
                var color = _colors[colorIdx];
                var symbol = _pixels[w, h]; // символи

                if (symbol == 0 || color == bgColor) // якщо немає символу або колір збігається з bgColor — пропускаємо
                    continue;

                Console.ForegroundColor = color; // встановлення кольору символу (переднього плану)

                Console.SetCursorPosition(w, h); // встановлення курсора
                Console.Write(symbol); // виведення символу
            }

            Console.ResetColor(); // скидає налаштування кольорів консолі
            Console.CursorVisible = false; // приховує курсор
        }
    }

    // відрисовування тексту в потрібному місці
    public void DrawString(string text, int atWidth, int atHeight, ConsoleColor color)
    {
        var colorIdx = Array.IndexOf(_colors, color); // перевіряє, чи є колір у масиві _colors
        if (colorIdx < 0) // якщо немає — перериваємо виконання
            return;

        for (int i = 0; i < text.Length; i++)
        {
            _pixels[atWidth + i, atHeight] = text[i]; // заповнює кожен символ тексту в потрібну комірку
            _pixelColors[atWidth + i, atHeight] = (byte)colorIdx; // заповнюємо кожну комірку кольором по горизонталі
        }
    }

    // очищення консолі
    public void Clear()
    {
        for (int w = 0; w < width; w++)
        for (int h = 0; h < height; h++)
        {
            _pixelColors[w, h] = 0;
            _pixels[w, h] = (char)0;
        }
    }

    // Перевіряє, чи є цей об’єкт ідентичним іншому екземпляру ConsoleRenderer.
    // Порівнює розміри вікон та масив кольорів.
    // Перевіряє всі елементи масивів _pixels і _pixelColors
    public override bool Equals(object? obj)
    {
        if (obj is not ConsoleRenderer casted)
            return false;

        if (_maxWidth != casted._maxWidth || _maxHeight != casted._maxHeight ||
            width != casted.width || height != casted.height ||
            _colors.Length != casted._colors.Length)
        {
            return false;
        }

        for (int i = 0; i < _colors.Length; i++)
        {
            if (_colors[i] != casted._colors[i])
                return false;
        }

        for (int w = 0; w < width; w++)
        for (var h = 0; h < height; h++)
        {
            if (_pixels[w, h] != casted._pixels[w, h] ||
                _pixelColors[w, h] != casted._pixelColors[w, h])
            {
                return false;
            }
        }

        return true;
    }

    // Генерує унікальний хеш-код для об’єкта, враховуючи розміри, масив кольорів і значення пікселів
    public override int GetHashCode()
    {
        var hash = HashCode.Combine(_maxWidth, _maxHeight, width, height);

        for (int i = 0; i < _colors.Length; i++)
        {
            hash = HashCode.Combine(hash, _colors[i]);
        }

        for (int w = 0; w < width; w++)
        for (var h = 0; h < height; h++)
        {
            hash = HashCode.Combine(hash, _pixelColors[w, h], _pixels[w, h]);
        }

        return hash;
    }
    }
}
