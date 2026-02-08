namespace Lesson_12_OOP_2;

public class Inventory
{
    public int InventorySize { get; private set; }
    public Dictionary<Item, int> ItemsInventory { get; private set; }

    public Inventory(int inventorySize)
    {
        ItemsInventory =  new Dictionary<Item, int>();
        InventorySize = inventorySize;
    }
    
    public  void AddOrPutItem(Item item,  int amount)
    {
        if (!ItemsInventory.ContainsKey(item))
        {
            ItemsInventory.Add(item, amount);
            Console.WriteLine($"Item {item.Name} added to Inventory");
            Console.ReadKey();
        }
        else
        {
            ItemsInventory[item] += amount;
        }
    }

    public void RemoveItem(Item item)
    {
        if (ItemsInventory.ContainsKey(item))
        {
            ItemsInventory.Remove(item);
        }
    }

    public Item GetItem(Item item, int amount)
    {
        if (ItemsInventory.ContainsKey(item))
        {
            if (ItemsInventory[item] >= amount)
            {
                Console.WriteLine($"Item {item.Name} not anfe Count");
                return null;
            }
            Console.WriteLine($"User get {item.Name} item");
            return item;
        }
        else
        {
            Console.WriteLine($"Item {item} doesn't exist");
            return null;
        }
    }
    
    
    public void ShowInventory()
    {
        foreach (KeyValuePair<Item, int> kvp in ItemsInventory)
        {
            Console.WriteLine($"{kvp.Key.Name}: {kvp.Value}");
        }
    }
}