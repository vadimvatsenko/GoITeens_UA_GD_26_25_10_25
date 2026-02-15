namespace Lesson_13_Classes_2.Strategy;

public class AntiArmorStrategy : ICombatStrategy
{
    public string Name => nameof(AntiArmorStrategy);
    
    public void Execute(Hero hero, Unit target)
    {
        InventoryComponent inventoryComponent = hero.Inventory;
        
        Weapon bestWeaponForAttack = inventoryComponent.CurrentWeapon;
        
        List<Weapon> allWeaponsInInventory = inventoryComponent.GetAllWeapons();

        // Linq
        bestWeaponForAttack = allWeaponsInInventory.OrderByDescending(w => w.Damage).First();
        
        Console.WriteLine($"Strategy {Name} choose {bestWeaponForAttack}");
        
        hero.Attack(target);
    }
}