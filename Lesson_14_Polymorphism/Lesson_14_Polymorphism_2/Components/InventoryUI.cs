using Lesson_14_Polymorphism_2.Engine;
using Lesson_14_Polymorphism_2.Weapons;

namespace Lesson_14_Polymorphism_2.Components;

public class InventoryUI
{
    private readonly InventoryComponent _inventory;
    private readonly HealthComponent _health;
    private Renderer _renderer;
    private readonly Map _map;
    private char[,] _layer;

    public InventoryUI(InventoryComponent inventory, HealthComponent health, Renderer renderer, Map map, char[,] layer)
    {
        _inventory = inventory;
        _health = health;
        _renderer = renderer;
        _map = map;
        _layer = layer;
        
        _inventory.OnInventoryChanged += RenderWeapons;
        
    }

    public void Update()
    {
        
    }
    
    
    public void RenderWeapons(List<Weapon> weapons, int currentIndex)
    {
        _renderer.DrawString(_layer, 1,5, $"{_health.CurrentHealth} / {_health.MaxHealth}");
        
        for (int i = 0; i < weapons.Count; i++)
        {
            string marker = (i == currentIndex) ? "==>" : "   ";
            _renderer.DrawString(_layer, 1,i, $"{marker}: {weapons[i].Name}");
        }
    }
}