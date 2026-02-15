using Lesson_13_Classes_2.Weapons;

namespace Lesson_13_Classes_2.Components;

public class InventoryComponent
{
    
    private List<Weapon> _weapons = new List<Weapon>();
    public int CurrentWeaponIndex { get; private set; } = 0;

    public Weapon CurrentWeapon => _weapons.Count == 0 ? null : _weapons[CurrentWeaponIndex];

    public void AddWeapon(Weapon weapon) => _weapons.Add(weapon);

    public void NextWeapon()
    {
        if (_weapons.Count <= 0)
        {
            Console.WriteLine($"In Inventory Component, No weapons ");
            return;
        }
        
        // 0 1 2 - 0 1 2 - 0 1 2 - 0 1 2
        CurrentWeaponIndex = (CurrentWeaponIndex + 1) % _weapons.Count;
        
    }

    public void SelectWeaponFromIndex(int index)
    {
        if (index < 0 || index >= _weapons.Count || _weapons.Count <= 0)
        {
            Console.WriteLine($"In Inventory Component, No weapons in index {index} ");
            return;
        }
        
        CurrentWeaponIndex =  index;
        ShowCurrentWeapon();
    }

    public void ShowCurrentWeapon()
    {
        Console.WriteLine(_weapons[CurrentWeaponIndex].Name);
    }

    public void ShowWeapons()
    {
        Console.WriteLine("Inventory Weapons");

        for (int i = 0; i < _weapons.Count; i++)
        {
            string marker = (i == CurrentWeaponIndex) ? "==>" : "   ";
            Console.WriteLine($"{marker}: {_weapons[i].Name}");
        }
    }

    public List<Weapon> GetAllWeapons()
    {
        if (_weapons.Count <= 0)
            return null;
        return _weapons;
    }
    
}