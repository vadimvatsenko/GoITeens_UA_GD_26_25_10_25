using System;
using System.Collections.Generic;

// Завдання 1: Клас "Ворог"

public class Program
{
    public static void Main()
    {
        Enemy enemy = new Enemy("Bob", 100);
        enemy.Attack();

        TreasureChest treasureChest = new TreasureChest();
        treasureChest.OpenChest();
        treasureChest.PutTreasure("sword");
        
        MedicinalPlant med =  new MedicinalPlant();
        
        med.CollectPlant("red");
        med.CollectPlant("yellow");
        med.CollectPlant("green");
        
        med.MakeMedicine();

        Console.ReadKey();
    }
}
class Enemy
{
    private string _name;
    private int _health;

    public Enemy(string name, int health)
    {
        _name = name;
        _health = health;
    }

    public void Attack()
    {
        Console.WriteLine(_name + " атакує!");
    }
}

// Завдання 2: Клас "Магія"
class Magic
{
    public void CastSpell(string spellName)
    {
        Console.WriteLine("Використано заклинання: " + spellName);
    }

    public void UsePotion(string potionName)
    {
        Console.WriteLine("Використано зілля: " + potionName);
    }
}

// Завдання 3: Клас "Скринька з Скарбами"
class TreasureChest
{
    private List<string> _treasures = new List<string>();
    private bool _isOpen = false;
    
    public void OpenChest()
    {
        _isOpen =  true;
        Console.WriteLine("Скринька відкрита!");
    }

    public void CloseChest()
    {
        _isOpen = false;
        Console.WriteLine("Treasure is closed!");
    }

    public void TakeTreasure(string item)
    {
        if (_isOpen)
        {
            if (_treasures.Contains(item))
            {
                _treasures.Remove(item);
                Console.WriteLine("Ви взяли: " + item);
            }
            else
            {
                ////
            }
        }
    }

    public void PutTreasure(string item)
    {
        if (_isOpen)
        {
            _treasures.Add(item);
            Console.WriteLine($"Add item in chest: {item}");
        }
        else
        {
            Console.WriteLine("Can`t put item, Treasure is closed!");
        }
    }
}

// Завдання 4: Клас "Інвентар"
class Inventory
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
        Console.WriteLine("Додано предмет: " + item);
    }

    public void RemoveItem(string item)
    {
        _items.Remove(item);
        Console.WriteLine("Видалено предмет: " + item);
    }
}

// Завдання 5: Клас "Лікарська Рослина"
class MedicinalPlant
{
    private Dictionary<string, int> _medicinalPlants = new Dictionary<string, int>()
    {
        ["green"] = 0,
        ["red"] = 0,
        ["yellow"] = 0,
    };
    
    
    public void CollectPlant(string plantName)
    {
        if (_medicinalPlants.ContainsKey(plantName))
        {
            _medicinalPlants[plantName]++;
        }
        else
        {
            _medicinalPlants.Add(plantName, 1);
        }
        Console.WriteLine("Зібрано рослину: " + plantName);
    }

    public void MakeMedicine()
    {
        bool isEnough = false;
        
        foreach (var item in _medicinalPlants)
        {
            if (item.Value > 0)
            {
                isEnough = true;
            }
            else
            {
                isEnough =  false;
            }
        }
        
        Console.WriteLine($"Enough medicine {isEnough}");
        if (isEnough)
        {
            Console.WriteLine("Make a first aid kit");
        }
        
    }
}

// Завдання 6: Клас "Пастка"
class Trap
{
    private bool _isPutTrap = false;

    public Trap()
    {
        _isPutTrap = true;
    }
    
    public void SetTrap()
    {
        _isPutTrap = true;
        Console.WriteLine("Пастку встановлено.");
    }

    public void TriggerTrap()
    {
        _isPutTrap = false;
        Console.WriteLine("Пастка спрацювала!");
    }
}

// Завдання 7: Клас "Меч Лицаря"
class KnightSword
{
    private int _durability  = 100;

    public void Attack()
    {
        if (_durability <= 0) return;
        _durability -= 10;
        Console.WriteLine("Атака мечем! Міцність: " + _durability);
    }

    public void ShowStatus()
    {
        Console.WriteLine("Стан меча: " + _durability);
    }

    public void RepairSward(int heal = 10)
    {
        _durability += heal;
        if (_durability > 100)
        {
            _durability = 100;
        }
    }
}

// Завдання 8: Клас "Рецепт"
class Recipe
{
    private List<string> ingredients = new List<string>();

    public void AddIngredient(string ingredient)
    {
        ingredients.Add(ingredient);
        Console.WriteLine("Додано інгредієнт: " + ingredient);
    }

    public void ShowRecipe()
    {
        Console.WriteLine("Інгредієнти рецепту:");
        foreach (var item in ingredients)
        {
            Console.WriteLine("- " + item);
        }
    }
}