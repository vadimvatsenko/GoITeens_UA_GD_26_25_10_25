namespace Lesson_5_Cycles_7_Update;

public class Input
{
    public Action OnMoveLeft;
    public Action OnMoveRight;
    public Action OnMoveDown;
    public Action OnMoveUp;

    public void Update(double delta)
    {
        if(!Console.KeyAvailable) return;
        
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.A or ConsoleKey.LeftArrow:
                OnMoveLeft?.Invoke();
                break;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                OnMoveRight?.Invoke();
                break;
            case ConsoleKey.W or ConsoleKey.UpArrow:
                OnMoveUp?.Invoke();
                break;
            case ConsoleKey.S or ConsoleKey.DownArrow:
                OnMoveDown?.Invoke();
                break;
        }
    }
}