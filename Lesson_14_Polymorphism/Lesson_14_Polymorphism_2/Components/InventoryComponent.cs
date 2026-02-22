using Lesson_14_Polymorphism_2.Weapons;

namespace Lesson_14_Polymorphism_2.Components;

public class InventoryComponent
{
    public event Action<List<Weapon>, int> OnInventoryChanged;

    private List<Weapon> _weapons;
    public int CurrentWeaponIndex { get; private set; } = 0;
    public Weapon CurrentWeapon => _weapons.Count == 0 ? null : _weapons[CurrentWeaponIndex];

    public InventoryComponent()
    {
        _weapons = new List<Weapon>();
    }
    
    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
        
        OnInventoryChanged?.Invoke(_weapons, CurrentWeaponIndex);
    }
    
    public void NextWeapon()
    {
        if (_weapons.Count <= 0)
        {
            Console.WriteLine($"In Inventory Component, No weapons ");
            return;
        }
        
        // 0 1 2 - 0 1 2 - 0 1 2 - 0 1 2
        CurrentWeaponIndex = (CurrentWeaponIndex + 1) % _weapons.Count;
        OnInventoryChanged?.Invoke(_weapons, CurrentWeaponIndex);
    }

    public void SelectWeaponFromIndex(int index)
    {
        if (index < 0 || index >= _weapons.Count || _weapons.Count <= 0)
        {
            Console.WriteLine($"In Inventory Component, No weapons in index {index} ");
            return;
        }
        
        CurrentWeaponIndex = index;
        OnInventoryChanged?.Invoke(_weapons, CurrentWeaponIndex);
    }
    
    public List<Weapon> GetAllWeapons()
    {
        if (_weapons.Count <= 0)
            return null;
        return _weapons;
    }
}