namespace Lesson_13_Classes_1;

public class Hero
{
    public string Name { get; private set; } 
    public Weapon _weapon {get; private set;}

    public Hero(string name, Weapon weapon)
    {
        Name = name;
        _weapon = weapon;
    }

    public void Shoot() => _weapon.Shoot();
    
    public void ReloadWeapon() => _weapon.ReloadWeapon();

    public void ChangeWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
    
}