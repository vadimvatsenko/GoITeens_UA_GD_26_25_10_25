namespace Lesson_13_Classes_1;

public class Weapon
{
    public string Name { get; private set; }
    public int MaxAmmo { get; private set; }
    private int _currentAmmo;
    
    private List<Bullet> _bullets = new List<Bullet>();

    public Weapon(string name,  int maxAmmo, int currentAmmo)
    {
        Name = name;
        MaxAmmo = maxAmmo;
        _currentAmmo = currentAmmo;
    }
    
    
    public void Shoot()
    {
        
        if (_currentAmmo > 0)
        {
            _currentAmmo--;
            
            Bullet bullet = new Bullet(20, 10);
            _bullets.Add(bullet);
            
            Console.WriteLine($"{Name} Shooting");
        }
        else
        {
            Console.WriteLine("Out of Ammo");
        }
    }

    public void ReloadWeapon()
    {
        _currentAmmo = MaxAmmo;
    }

    public List<Bullet> GetBullets()
    {
        return _bullets;
    }
}