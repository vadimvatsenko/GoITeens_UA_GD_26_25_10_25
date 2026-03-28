namespace Hearthstone;

public class Character
{
    public string Name {get; private set;}
    public int Health { get; private set; }
    public bool IsAlive = true;
    public List<Card> CardsOnHand { get; private set; } 
    private List<Card> _cardsOnDeck;

    public Character(string name, int health, List<Card> cardsOnDeck)
    {
        Name = name;
        Health = health;
        _cardsOnDeck = cardsOnDeck;
        CardsOnHand = new List<Card>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            IsAlive = false;
        }
    }

    public void ChooseCard()
    {
        if (_cardsOnDeck.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(0, _cardsOnDeck.Count); // 10 (1 2 3 4 5 6 7 8 9 10) (0 1 2 3 4 5 6 7 8 9)
            
            Card card = _cardsOnDeck[index];
            
            CardsOnHand.Add(card);
            _cardsOnDeck.Remove(card);
            
            //Console.WriteLine($"{Name} take card {card.Name}");
        }
        else
        {
            Console.WriteLine("Deck is empty");
        }
    }

    public Card GetCardFromIndex(int index)
    {
        if (index >= 0 && index < CardsOnHand.Count)
        {
            Console.WriteLine($"{CardsOnHand[index].Name}");
            return CardsOnHand[index];
        }
        else
        {
            Console.WriteLine($"No card found from index {index}");
            return null;
        }
    }

    public void RemoveCardFromHand(Card card)
    {
        if (CardsOnHand.Contains(card))
        {
            CardsOnHand.Remove(card);
        }
    }

    public void DisplayCardsOnHand()
    {
        foreach (Card card in CardsOnHand)
        {
            card.Draw();
        }
    }
}