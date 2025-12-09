namespace Hearthstone;

public class Card
{
    public string Name { get; private set; }
    public int AttackPower {get; private set;}
    public int Health {get; private set;}

    public Card(string name, int attackPower, int health)
    {
        Name = name;
        AttackPower = attackPower;
        Health = health;
    }

    public void Draw()
    {
        Console.WriteLine($"------------");
        Console.WriteLine($"|{Name, -11}|");
        Console.WriteLine($"|           |");
        Console.WriteLine($"| ({AttackPower, 2}/{Health, 2})   |");
        Console.WriteLine($"|           |");
        Console.WriteLine($"------------");
    }
}