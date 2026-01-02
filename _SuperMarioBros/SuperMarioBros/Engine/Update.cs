using System.Diagnostics;

namespace SuperMarioBros.Engine;

public class Update
{
    private List<IUpdatable> _updateables;
    
    private int _targetFps;
    private double _targetFrameMs;
    private Stopwatch _sw;

    // Час, коли "має" закінчитися наступний кадр (у мс від старту програми)
    private double _nextFrameMs;

    // === deltaTime ==============================================================
    // Зберігаємо час старту попереднього кадру (в мс)
    private double _lastFrameStartMs;

    // === Лічильники для FPS =====================================================
    private int _frames; // скільки кадрів пройшло за поточну секунду
    private double _fpsTimerStartMs; // старт відліку "секунди"

    public Update(int targetFps = 60)
    {
        // === Налаштування цільового FPS ============================================
        _targetFps = targetFps;

        // Час одного кадру в мілісекундах.
        // 1000 мс / 60 ≈ 16.666... мс на кадр
        _targetFrameMs = 1000.0 / targetFps;

        // Stopwatch — точніший таймер, ніж DateTime.Now
        _sw = new Stopwatch();

        _updateables = new List<IUpdatable>();
    }
    
    public void AddUpdateable(IUpdatable updateable) => _updateables.Add(updateable);
    public void RemoveUpdateable(IUpdatable updateable) => _updateables.Remove(updateable);

    public void RunUpdate()
    {
        _sw.Start();
        _nextFrameMs = 0;
        _lastFrameStartMs = _sw.Elapsed.TotalMilliseconds;
        _frames = 0;
        _fpsTimerStartMs = _sw.Elapsed.TotalMilliseconds;
        
        while (true)
        {
            // === 1) ПОЧАТОК КАДРУ ==================================================
            double frameStartMs = _sw.Elapsed.TotalMilliseconds;

            // deltaTime — час між стартом цього кадру і стартом попереднього кадру
            // В секундах (бо в іграх dt зазвичай у секундах)
            double deltaTime = (frameStartMs - _lastFrameStartMs) / 1000.0;

            // Оновлюємо "останній час" для наступної ітерації
            _lastFrameStartMs = frameStartMs;

            // Тут зазвичай викликають ігрову логіку:
            // Update(deltaTime);
            foreach (IUpdatable updateable in _updateables)
            {
                updateable.Update(deltaTime);
            }

            // === 2) ОБМЕЖЕННЯ FPS ===================================================
            // Ми хочемо, щоб кожен кадр закінчувався не раніше, ніж через targetFrameMs
            // Тому плануємо "час завершення" поточного кадру:
            _nextFrameMs += _targetFrameMs;

            // Скільки часу ще залишилось до nextFrameMs
            double nowMs = _sw.Elapsed.TotalMilliseconds;
            double remainingMs = _nextFrameMs - nowMs;

            // Якщо залишилось більше ~1 мс — можна приспати потік (економить CPU)
            if (remainingMs > 1)
            {
                // Sleep приймає ціле число мілісекунд -> дробова частина губиться
                Thread.Sleep((int)remainingMs);
            }

            // Доробляємо "точність" коротким активним очікуванням (busy-wait)
            // Це дає рівніший таймінг, ніж один лише Sleep
            while (_sw.Elapsed.TotalMilliseconds < _nextFrameMs)
            {
                // нічого не робимо — просто чекаємо
            }

            // === 3) ПІДРАХУНОК FPS (раз на ~1 секунду) ==============================
            _frames++;

            double passedMs = _sw.Elapsed.TotalMilliseconds - _fpsTimerStartMs;

            // Якщо пройшла (або майже) секунда — виводимо FPS
            if (passedMs >= 1000)
            {
                double fps = _frames / (passedMs / 1000.0);

                // Показуємо також останній deltaTime для наочності
                Console.WriteLine($"FPS: {fps:F2} | deltaTime: {deltaTime:F4}s");

                // Скидаємо лічильники на наступну секунду
                _frames = 0;
                _fpsTimerStartMs = _sw.Elapsed.TotalMilliseconds;
            }
        }
    }
}