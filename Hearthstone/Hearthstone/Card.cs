using System.Text.Json.Serialization;

namespace Hearthstone;

[Serializable]
public class Card
{
    [JsonPropertyName("name")]
    public string Name { get; private set; }
    [JsonPropertyName("power")]
    public int AttackPower {get; private set;}

    [JsonPropertyName("health")] 
    public int Health {get; private set;}
    public HealthComponent HealthComponent {get; private set;}

    [JsonConstructor]
    public Card(string name, int attackPower, int health)
    {
        Name = name;
        AttackPower = attackPower;
        Health = health;
        HealthComponent = new HealthComponent(Health);
    }
    
    public void Draw()
    {
        Console.WriteLine("┌────────────────┐");
        Console.WriteLine($"│░{Name.PadRight(15,'░')}│");
        Console.WriteLine("│░░░░░░░░░░░░░░░░│");
        Console.WriteLine($"│░⚔ Power: {AttackPower.ToString().PadRight(6,'░')}│");
        Console.WriteLine($"│░♥ Health: {Health.ToString().PadRight(5, '░')}│");
        Console.WriteLine($"│░░░░░░░░░░░░░░░░│");
        Console.WriteLine("└────────────────┘");
    }
}