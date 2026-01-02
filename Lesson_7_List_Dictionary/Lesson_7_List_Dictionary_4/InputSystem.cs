namespace Lesson_7_List_Dictionary_4;

public class InputSystem
{
    public Action OnFire;
    public Action OnChangeWeapon;

    public void Update()
    {
        if(!Console.KeyAvailable) return;
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.Spacebar:
                OnFire?.Invoke();
                break;
            case ConsoleKey.E:
                OnChangeWeapon?.Invoke();
                break;
        }
    }
}