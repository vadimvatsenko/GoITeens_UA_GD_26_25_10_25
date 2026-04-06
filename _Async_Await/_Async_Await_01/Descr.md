Время →
────────────────────────────────────────────────────────────────────

MAIN поток:
Main() старт
|
| await PrintAsync()
|   ├─ PrintAsync() старт (всё ещё MAIN)
|   |     Console.WriteLine("Начало метода PrintAsync")
|   |     await Task.Run(Print)   ← тут MAIN “встал на паузу”
|   |_____________________________ (ждёт окончания Print)
|
| (после завершения Print)
|   PrintAsync продолжает (обычно снова MAIN)
|     Console.WriteLine("Конец метода PrintAsync")
|
| PrintAsync завершился → await PrintAsync() завершён
| Console.WriteLine("Некоторые действия в методе Main")
| Console.ReadKey()  ← ждёт нажатие
|
└─ конец

────────────────────────────────────────────────────────────────────

THREADPOOL поток (Task.Run):
Print() старт
|
| Thread.Sleep(3000)  ← 3 секунды блокирует ЭТОТ поток
|
| Console.WriteLine("Hello METANIT.COM")
Print() конец
