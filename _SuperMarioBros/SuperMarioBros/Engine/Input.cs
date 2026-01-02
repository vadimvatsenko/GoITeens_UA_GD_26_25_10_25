namespace SuperMarioBros.Engine;

public class Input: IUpdatable
{
    public Action OnLeft;
    public Action OnRight;


    public void Update(double deltaTime)
    {
        if(!Console.KeyAvailable) return;
        
        ConsoleKeyInfo  keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.LeftArrow or ConsoleKey.A:
                OnLeft?.Invoke();
                Console.WriteLine("Left Arrow");
                break;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                OnRight?.Invoke();
                Console.WriteLine("Right Arrow");
                break;
        }
    }
}