using Lesson_14_Polymorphism_2.Components;
using Lesson_14_Polymorphism_2.Engine;
using Lesson_14_Polymorphism_2.Weapons;

namespace Lesson_14_Polymorphism_2;

public class Hero: Unit, IDisposable
{
    private InventoryComponent _inventory;
    private Input _input;

    public Hero(Vector2 pos, char symbol, Renderer renderer, char[,] layer, Map map, InventoryComponent inventory, Input input) 
        : base(pos, symbol, renderer, layer, map)
    {
        _inventory = inventory;
        _input = input;

        _inventory = inventory;

        _input.OnLeft += MoveLeft;
        _input.OnRight += MoveRight;
        _input.OnUp += MoveUp;
        _input.OnDown += MoveDown;
        _input.OnChangeWeapon += ChangeWeapon;
    }

    public override void Update()
    {
        base.Update();
    }

    public void AddWeaponInInventory(Weapon weapon) => _inventory.AddWeapon(weapon);
    public void ChangeWeapon() => _inventory.NextWeapon();

    public void Attack()
    {
        _currentWeapon.Attack();
    }
    
    private void MoveLeft() => _pos.X -= 1;
    private void MoveRight() => _pos.X += 1;
    private void MoveUp() => _pos.Y -= 1;
    private void MoveDown() => _pos.Y += 1;
    
    

    public void Dispose()
    {
        _input.OnLeft -= MoveLeft;
        _input.OnRight -= MoveRight;
        _input.OnUp -= MoveUp;
        _input.OnDown -= MoveDown;
        _input.OnChangeWeapon += ChangeWeapon;
    }
}