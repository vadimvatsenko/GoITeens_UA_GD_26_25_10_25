namespace Lesson_13_Classes_2.Strategy;

public class KeepDistanceStrategy : ICombatStrategy
{
    public string Name => nameof(KeepDistanceStrategy);
    
    public void Execute(Hero hero, Unit target)
    {
        InventoryComponent inventoryComponent = hero.Inventory;
        
        Weapon bestWeaponForAttack = inventoryComponent.CurrentWeapon;
        
        List<Weapon> allWeaponsInInventory = inventoryComponent.GetAllWeapons();

        bestWeaponForAttack = allWeaponsInInventory.FirstOrDefault(w => w.Range > 3);
        
        Console.WriteLine($"Strategy {Name} choose {bestWeaponForAttack}");
        
        hero.Attack(target);

    }
}