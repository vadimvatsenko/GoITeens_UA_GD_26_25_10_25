using System;
using System.Diagnostics;
using System.Text;

class Program
{


    static void Main(string[] args)
    {
        // === Налаштування цільового FPS ============================================
        int targetFps = 60;

        // Час одного кадру в мілісекундах.
        // 1000 мс / 60 ≈ 16.666... мс на кадр
        double targetFrameMs = 1000.0 / targetFps;

        // Stopwatch — точніший таймер, ніж DateTime.Now
        Stopwatch sw = Stopwatch.StartNew();

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
            }
        }

    }
}








