namespace Lesson_12_OOP_2;

public class Inventory
{
    private Dictionary<string, int> _items;

    public Inventory()
    {
        _items = new Dictionary<string, int>();
    }
    
    public void AddItem(string item, int amount)
    {
        if (!_items.ContainsKey(item))
        {
            _items.Add(item, amount);
        }
        else
        {
            _items[item] += amount;
        }
    }
    
    public void RemoveItem(string item)
    {
        if (_items.ContainsKey(item))
        {
            _items.Remove(item);
        }
    }

    public string GetItem(string item)
    {
        if (_items.TryGetValue(item, out int amount) && amount > 0)
        {
            amount--;

            if (amount == 0)
                _items.Remove(item);
            else
                _items[item] = amount;

            return item; 
        }

        return string.Empty;
    }

    public void ShowInventory()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }
}