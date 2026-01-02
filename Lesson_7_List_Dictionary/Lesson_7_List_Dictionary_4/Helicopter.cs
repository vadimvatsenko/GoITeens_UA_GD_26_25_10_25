namespace Lesson_7_List_Dictionary_4;

public class Helicopter: IDisposable
{
    private InputSystem _inputSystem;
    
    Random random = new Random();
    
    private List<Armor> _bullets = new List<Armor>();
    
    Dictionary<Armor, int> _armorsCouts = new Dictionary<Armor, int>();
    
    Armor _defaultArmor;

    public Helicopter(InputSystem inputSystem, List<Armor> bullets)
    {
        _inputSystem = inputSystem;
        _bullets = bullets;

        foreach (var bullet in _bullets)
        {
            if (!_armorsCouts.ContainsKey(bullet))
            {
                _armorsCouts.Add(bullet, random.Next(1,101));
            }
            else
            {
                _armorsCouts[bullet] += 10;
            }
        }
        
        _defaultArmor = bullets[0];
        _inputSystem.OnFire += Fire;
        _inputSystem.OnChangeWeapon += ChangeArmor;
        
    }

    public void Fire()
    {
        _armorsCouts[_defaultArmor]--;
        if(_armorsCouts[_defaultArmor] < 0) return;
        Print();
    }

    public void ChangeArmor()
    {
        int currentArmorIndex = _bullets.IndexOf(_defaultArmor);
        int nextArmorIndex = (currentArmorIndex + 1) % _bullets.Count;
        _defaultArmor = _bullets[nextArmorIndex];

        Print();
    }

    public void Dispose()
    {
        _inputSystem.OnFire -= Fire;
        _inputSystem.OnChangeWeapon -= ChangeArmor;
    }

    public void Print()
    {
        Console.Clear();
        Console.SetCursorPosition(5, 5);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{_defaultArmor.ArmorType} - {_armorsCouts[_defaultArmor]}");
    }
}