namespace Lesson_13_Classes_2;

public class InventoryComponent
{
    private readonly List<Weapon> _weapons = new List<Weapon>();
    public int CurrentWeaponIndex { get; private set; } = 0;
    
    public Weapon CurrentWeapon => _weapons.Count == 0 ? null : _weapons[CurrentWeaponIndex];
    
    public void AddWeapon(Weapon weapon) => _weapons.Add(weapon);

    public void NextWeapon()
    {
        if (_weapons.Count <= 0)
        {
            Console.WriteLine("No more weapons left in this list!");
            return;
        }
        
        CurrentWeaponIndex = (CurrentWeaponIndex + 1) % _weapons.Count;
        Console.WriteLine($"Current Weapon {_weapons[CurrentWeaponIndex].Name}");
    }

    public void SelectWeaponFromIndex(int index)
    {
        if (index < 0 || index >= _weapons.Count || _weapons.Count == 0)
        {
            Console.WriteLine("No more weapons left in this list!");
        }
        CurrentWeaponIndex = index;
        Console.WriteLine($"Current Weapon {_weapons[CurrentWeaponIndex].Name}");
    }

    public void ShowWeapons()
    {
        Console.WriteLine("Inventory Weapons:");
        for (int i = 0; i < _weapons.Count; i++)
        {
            string marker = (i == CurrentWeaponIndex) ? "==>" : "   ";
            Console.WriteLine($"{marker}  [{i + 1}] {_weapons[i].Name} (DMG {_weapons[i].Damage}, RNG {_weapons[i].Range})");
        }
    }
    
    public List<Weapon> GetAllWeapons() => _weapons;
    
}