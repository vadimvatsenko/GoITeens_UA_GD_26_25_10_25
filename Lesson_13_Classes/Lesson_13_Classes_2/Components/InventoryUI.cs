using Lesson_13_Classes_2.Weapons;

namespace Lesson_13_Classes_2.Components;

public class InventoryUI
{
    private readonly InventoryComponent _inventory;

    public InventoryUI(InventoryComponent inventory)
    {
        _inventory = inventory;
        _inventory.OnInventoryChanged += RenderWeapons;
    }
    
    private void RenderWeapons(List<Weapon> weapons, int currentIndex)
    {
        Console.WriteLine("Inventory Weapons");

        for (int i = 0; i < weapons.Count; i++)
        {
            string marker = (i == currentIndex) ? "==>" : "   ";
            Console.WriteLine($"{marker}: {weapons[i].Name}");
        }
    }
}