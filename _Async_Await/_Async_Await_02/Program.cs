namespace _Async_Await_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1
            // End
            // 2
            // 3
            // 4
            // 5
            Method();
            Console.WriteLine("End");
            Console.ReadKey();
        }

        private static async void Method()
        {
            // await Task.Delay(1000); задержка
            
            int counter = 0;
            // выполняется асинхронно основному потоку
            // (синхронно в простонароде)
            await Task.Run(() =>
            {
                while (counter < 30)
                {
                    counter++;
                    Console.WriteLine($"Counter: {counter}");
                }
            });
        }
    }
}