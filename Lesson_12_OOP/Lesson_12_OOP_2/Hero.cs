using Lesson_12_OOP_2.Engine;

namespace Lesson_12_OOP_2;

public class Hero
{
    public char HeroSymbol { get; private set; } = '@';
    private Renderer _renderer;
    private Vector2 _position;

    private string _targetWeapon;
    public HealthComponent HealthComponent { get; private set; }
    public Inventory Inventory {get; private set;}
    
    private int _health;

    public Hero(Renderer renderer, Vector2 position)
    {
        _renderer = renderer;
        _position = position;
        HealthComponent =  new HealthComponent(90, 100);
        Inventory = new Inventory();
    }
    
    public void TakeDamage(int amount) => HealthComponent.TakeDamage(amount);
    public void Heal(int amount) => HealthComponent.Heal(amount);
    public void BuffHealth(int amount) =>  HealthComponent.BuffHealth(amount);

    public void Attack()
    {
        Console.WriteLine($"Hero is attacking {_targetWeapon}");
    }

    public void EquiptWeapon(string name)
    {
        _targetWeapon = Inventory.GetItem(name);
    }
   
}