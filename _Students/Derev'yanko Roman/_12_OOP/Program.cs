/*Завдання 1: Створення Класу "Ворог" 

Створіть клас "Enemy" з властивостями "ім'я" та "здоров'я". 
    Додайте метод "Attack", який дозволяє ворогу атакувати.


    Завдання 2: Створення Класу "Магія"

Створіть клас "Magic" з методами "CastSpell" та "UsePotion", які відображають використання заклинання та зілля.


    Завдання 3: Створення Класу "Скринька з Скарбами" 

Створіть клас "TreasureChest" з можливістю відкривати та взяти скарби.


    Завдання 4: Створення Класу "Бойовий Інвентар" 

Створіть клас "Inventory" з можливістю додавати та видаляти предмети.


    Завдання 5: Створення Класу "Лікарська Рослина" 

Створіть клас "MedicinalPlant" з можливістю зібрати лікарські рослини та виготовити ліки.


    Завдання 6: Створення Класу "Засідка" 

Створіть клас "Trap" з можливістю встановити пастку та спрацювання пастки.


    Завдання 7: Створення Класу "Меч Лицаря" 

Створіть клас "KnightSword" з можливістю атакувати та відображати стан меча.

Завдання 8: Створення Класу "Рецепт" 

Створіть клас "Recipe" з можливістю додавати інгредієнти та переглядати рецепт.*/

using System;
using System.Collections.Generic;

public class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }

    public Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} атакує!");
    }
}

public class Magic
{
    public void CastSpell()
    {
        Console.WriteLine("Заклинання використано.");
    }

    public void UsePotion()
    {
        Console.WriteLine("Зілля випито.");
    }
}

public class TreasureChest
{
    // метод покласти у скриньку
    public bool IsOpen { get; private set; }
    private List<string> treasures = new List<string> { "Золото", "Діамант", "Смарагд" };

    public void Open()
    {
        IsOpen = true;
        Console.WriteLine("Скринька відкрита.");
    }

    public void PutInTreasure(string treasure)
    {
        if (IsOpen)
        {
            treasures.Add(treasure);
        }
    }

    public void TakeTreasures()
    {
        if (!IsOpen)
        {
            Console.WriteLine("Скринька закрита.");
            return;
        }

        Console.WriteLine("Ти отримав:");
        foreach (var t in treasures)
            Console.WriteLine("- " + t);

        treasures.Clear();
    }
}

public class Inventory
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine(item + " додано.");
    }

    public void RemoveItem(string item)
    {
        if (items.Remove(item))
            Console.WriteLine(item + " видалено.");
        else
            Console.WriteLine("Предмет не знайдено.");
    }

    public void ShowItems()
    {
        Console.WriteLine("Інвентар:");
        foreach (var i in items)
            Console.WriteLine("- " + i);
    }
}

public class MedicinalPlant
{
    public void Collect()
    {
        Console.WriteLine("Лікарську рослину зібрано.");
    }

    public void MakeMedicine()
    {
        Console.WriteLine("Ліки виготовлено.");
    }
}

public class Trap
{
    public bool IsSet { get; private set; }

    // конструктор

    public Trap()
    {
        SetTrap();
    }
    public void SetTrap()
    {
        IsSet = true;
        Console.WriteLine("Пастку встановлено.");
    }

    public void TriggerTrap()
    {
        if (IsSet)
        {
            Console.WriteLine("Пастка спрацювала!");
            IsSet = false;
        }
        else
        {
            Console.WriteLine("Пастка не встановлена.");
        }
    }
}

public class KnightSword
{
    public int Durability { get; private set; } = 100;

    public void Attack()
    {
        if (Durability > 0)
        {
            Durability -= 10;
            Console.WriteLine("Меч атакує! Міцність: " + Durability);
        }
        else
        {
            Console.WriteLine("Меч зламаний.");
        }
    }

    public void ShowState()
    {
        Console.WriteLine("Стан меча: " + Durability);
    }
}

public class Recipe
{
    private List<string> ingredients = new List<string>();

    public void AddIngredient(string ingredient)
    {
        ingredients.Add(ingredient);
        Console.WriteLine(ingredient + " додано до рецепту.");
    }

    public void ShowRecipe()
    {
        Console.WriteLine("Рецепт:");
        foreach (var i in ingredients)
            Console.WriteLine("- " + i);
    }

    public void RemoveIngredient(string ingredient)
    {
        if (ingredients.Contains(ingredient))
        {
            ingredients.Remove(ingredient);
        }
    }
    
}

class Program
{
    static void Main()
    {
        Enemy enemy = new Enemy("Орк", 100);
        enemy.Attack();

        Magic magic = new Magic();
        magic.CastSpell();
        magic.UsePotion();

        TreasureChest chest = new TreasureChest();
        chest.Open();
        chest.TakeTreasures();

        Inventory inventory = new Inventory();
        inventory.AddItem("Меч");
        inventory.AddItem("Зілля");
        inventory.ShowItems();
        inventory.RemoveItem("Зілля");

        MedicinalPlant plant = new MedicinalPlant();
        plant.Collect();
        plant.MakeMedicine();

        Trap trap = new Trap();
        trap.SetTrap();
        trap.TriggerTrap();

        KnightSword sword = new KnightSword();
        sword.Attack();
        sword.ShowState();

        Recipe recipe = new Recipe();
        recipe.AddIngredient("Трава");
        recipe.AddIngredient("Вода");
        recipe.ShowRecipe();
    }
}