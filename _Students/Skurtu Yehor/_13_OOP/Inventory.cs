public class Inventory
{
    private List<string> _inventoryList = new List<string>();

    public Inventory()
    {
        _inventoryList.Add("Desert Eagle");
        _inventoryList.Add("M4A1");
        _inventoryList.Add("AK-47");
        _inventoryList.Add("AMMO");
        _inventoryList.Add("Grenades");
    }

    public void AddItem(string item) => _inventoryList.Add(item);

    public void RemoveItem(string item)
    {
        if (_inventoryList.Contains(item))
        {
            _inventoryList.Remove(item);
        }
        else
        {
            Console.WriteLine($"{item} is not in the inventory.");
        }
    }

    public void Clear() => _inventoryList.Clear();

    public void ShowInventory()
    {
        foreach (var item in _inventoryList)
        {
            Console.WriteLine($"{item}");
        }
    }
}


