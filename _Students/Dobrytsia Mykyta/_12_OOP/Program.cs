
// public 
public class Enemy
{
    // private
    public string Name { get; private set; }
    public int Health { get; private set; }

    public Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} атакує! Здоров'я: {Health}");
    }
}

public class Magic
{
    public void CastSpell(string spell) => Console.WriteLine($"Заклинання {spell} використано!");
    public void UsePotion(string potion) => Console.WriteLine($"Зілля {potion} випито!");
}

// GetItems
// IsOpen
public class TreasureChest
{
    public bool IsOpen { get; private set; }
    private List<string> _treasures = new List<string>();
    
    public void AddTreasure(string item)
    {
        if (IsOpen)
        {
            _treasures.Add(item);
        }
        else
        {
            Console.WriteLine("Is Closed");
        }
    }

    public void OpenChest()
    {
        IsOpen = true;
        Console.WriteLine("Відкрито скриньку:");
        _treasures.ForEach(item => Console.WriteLine($"- {item}"));
    }

    public void CloseChest() => IsOpen = false;

    public string GetItem(string item)
    {
        if (IsOpen)
            if (_treasures.Contains(item))
            {
                _treasures.Remove(item);
                return item;
            }
        
        return null;       
    }
    
    public void PutItem(string item)
    {
        if (IsOpen)
        {
            _treasures.Add(item);
        }
    }
}

// clear inventory

public class Inventory
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
        Console.WriteLine($"{item} додано");
    }

    public void RemoveItem(string item) =>
        Console.WriteLine(_items.Remove(item) ? $"{item} видалено" : $"{item} не знайдено");
    
    public void Clear() => _items.Clear();
}

public class MedicinalPlant
{
    public void GatherPlant(string plant) => Console.WriteLine($"{plant} зібрано");
    public void MakeMedicine(string plant) => Console.WriteLine($"Ліки з {plant} виготовлено");
}


// bool 
public class Trap
{
    private string _name;

    private bool _isActive;
    
    public Trap(string name)
    {
        _name = name;
        
        SetTrap(_name);
    }

    public void SetTrap(string trapName)
    {
        _isActive =  true;
        Console.WriteLine($"Пастка '{trapName}' встановлена");
    }

    public void TriggerTrap()
    {
        Console.WriteLine("Пастка спрацювала!");
        _isActive = false;
    }
}

// статус 
public class KnightSword
{
    public int Status { get; private set; } = 100;

    public void Attack()
    {
        Status = -10;
        if (Status < 0)
        {
            Console.WriteLine("Sword is brocken");
            return;
        }
        Console.WriteLine("Меч завдає удару!");
    }
    public void ShowStatus() => Console.WriteLine($"Стан меча: {Status}");
}

// remove
// clear
public class Recipe
{
    private List<string> _ingredients = new List<string>();
    public void AddIngredient(string ingredient) => _ingredients.Add(ingredient);

    public void ShowRecipe()
    {
        Console.WriteLine("Рецепт включає:");
        _ingredients.ForEach(i => Console.WriteLine($"- {i}"));
    }
}

class Program
    {
        static void Main()
        {
            Enemy goblin = new Enemy("Гоблін", 50);
            goblin.Attack();

            Magic magic = new Magic();
            magic.CastSpell("Вогняна куля");
            magic.UsePotion("Зілля здоров'я");

            TreasureChest chest = new TreasureChest();
            chest.AddTreasure("Золотий меч");
            chest.AddTreasure("Срібна монета");
            chest.OpenChest();

            Inventory inventory = new Inventory();
            inventory.AddItem("Щит");
            inventory.AddItem("Броня");
            inventory.RemoveItem("Щит");

            MedicinalPlant plant = new MedicinalPlant();
            plant.GatherPlant("Алоє");
            plant.MakeMedicine("Алоє");

            Trap trap = new Trap("superTrap");
            trap.SetTrap("Секретна пастка");
            trap.TriggerTrap();

            KnightSword sword = new KnightSword();
            sword.Attack();
            sword.ShowStatus();

            Recipe recipe = new Recipe();
            recipe.AddIngredient("Яйце");
            recipe.AddIngredient("Борошно");
            recipe.AddIngredient("Молоко");
            recipe.ShowRecipe();
        }
    }
