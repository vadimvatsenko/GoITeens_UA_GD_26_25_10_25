namespace Lesson_12_OOP_2;

public class Chest
{
    public Dictionary<string, int> chestItems = new Dictionary<string, int>();

    public void AddItem(string item, int amount)
    {
        if (!chestItems.ContainsKey(item))
        {
            chestItems.Add(item, amount);
        }
        else
        {
            chestItems[item] += amount;
        }
    }

    public void RemoveItem(string item, int amount)
    {
        if (chestItems.ContainsKey(item))
        {
            chestItems[item] -= amount;
            if (chestItems[item] <= 0)
            {
                chestItems.Remove(item);
            }
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }
}