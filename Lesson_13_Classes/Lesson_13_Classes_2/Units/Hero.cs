using Lesson_13_Classes_2.Strategy;

namespace Lesson_13_Classes_2;

public class Hero : Unit
{
    public InventoryComponent Inventory {get; private set;}
    public ICombatStrategy  Strategy {get; private set;}
    
    public Hero(string name, int startedHealth) : base(name, startedHealth)
    {
        Inventory = new InventoryComponent();
    }

    public override void Attack(Unit unit)
    {
        base.Attack(unit);
        Weapon weapon = Inventory.CurrentWeapon;

        if (weapon == null)
        {
            Console.WriteLine("You don`t have a weapon");
        }

        weapon.Attack(this, unit);
    }

    public void SwitchWeaponNext()
    {
        Inventory.NextWeapon();
        Console.WriteLine($"Your weapon is {Inventory.CurrentWeapon.Name}");
    }

    public void SelectWeaponNumber(int number)
    {
        Inventory.SelectWeaponFromIndex(number - 1);
        Console.WriteLine($"Your weapon is {Inventory.CurrentWeapon.Name}");
    }
    
    public void SetStrategy(ICombatStrategy strategy)
    {
        Strategy = strategy;
        Console.WriteLine($"Target Strategy: {Strategy.Name}");
    }
    
    public void Act(Enemy enemy)
    {
        Strategy?.Execute(this, enemy);
    }
}