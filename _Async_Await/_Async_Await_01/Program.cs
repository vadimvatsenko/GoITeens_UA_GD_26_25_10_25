// Асинхронный метод обладает следующими признаками:
// В заголовке метода используется модификатор async
// Метод содержит одно или несколько выражений await
// В качестве возвращаемого типа используется один из следующих:
// - void
// - Task
// - Task<T>
// - ValueTask<T>

// Однако асинхронный метод не может определять параметры с модификаторами out, ref и in.

// 1. Асинхронный метод Main
namespace _Async_Await_01
{
    internal class Program
    {
        
        async static Task Main(string[] args)
        {
            await PrintAsync();                                // вызов асинхронного метода
            Console.WriteLine("Некоторые действия в методе Main");
            
            void Print()
            {
                Thread.Sleep(3000);           // имитация продолжительной работы
                Console.WriteLine("Hello METANIT.COM");
            }
 
            // определение асинхронного метода
            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
                await Task.Run(Print);                         // выполняется асинхронно
                Console.WriteLine("Конец метода PrintAsync");
            }

            Console.ReadKey();
        }
    }
}