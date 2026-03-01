using System;

public class Program
{
    public static async Task Main()
    {
        
        Console.WriteLine("Start");

        // Запускаем "тикер" в фоне: печатает точку каждые 200мс
        var ticker = Task.Run(async () =>
        {
            while (true)
            {
                Console.Write(".");
                await Task.Delay(200);
            }
        });

        Console.WriteLine("\nBefore await");
        await Task.Delay(2000); // ждём 2 секунды, но программа "живая"
        Console.WriteLine("\nAfter await");

        // Чтобы пример не висел бесконечно:
        // (в реальной жизни ты бы управлял отменой через CancellationToken)
        Console.ReadKey();

    }
}