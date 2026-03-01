using System;
using System.Collections.Generic;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1️ Enemy
            Enemy enemy = new Enemy("Orc", 100);
            enemy.Attack();

            // 2️ Magic
            Magic magic = new Magic();
            magic.CastSpell();
            magic.UsePotion();

            // 3️ TreasureChest
            TreasureChest chest = new TreasureChest("Gold");
            chest.OpenChest();
            chest.TakeTreasure();

            // 4️ Inventory
            Inventory inventory = new Inventory();
            inventory.AddItem("Sword");
            inventory.AddItem("Potion");
            inventory.RemoveItem("Potion");

            // 5️ MedicinalPlant
            MedicinalPlant plant = new MedicinalPlant();
            plant.CollectPlant();
            plant.MakeMedicine();

            // 6️ Trap
            Trap trap = new Trap();
            trap.SetTrap();
            trap.TriggerTrap();

            // 7️ KnightSword
            KnightSword knightSword = new KnightSword(50);
            knightSword.Attack();
            knightSword.DisplayStatus();

            // 8️ Recipe
            Recipe recipe = new Recipe("Health Potion");
            recipe.AddIngredient("Herb");
            recipe.AddIngredient("Water");
            recipe.ShowRecipe();

            Console.ReadKey();
        }
    }

    // 1️ Enemy
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} attacks! Health: {Health}");
        }
    }

    // 2️ Magic
    public class Magic
    {
        public void CastSpell()
        {
            Console.WriteLine("Spell has been cast!");
        }

        public void UsePotion()
        {
            Console.WriteLine("Potion used!");
        }
    }

    // 3️ TreasureChest
    public class TreasureChest
    {
        public string Treasure { get; set; }
        private bool isOpen = false;

        public TreasureChest(string treasure)
        {
            Treasure = treasure;
        }

        public void OpenChest()
        {
            isOpen = true;
            Console.WriteLine("Chest opened!");
        }

        public void TakeTreasure()
        {
            if (isOpen)
                Console.WriteLine($"You took: {Treasure}");
            else
                Console.WriteLine("Chest is closed!");
        }
    }

    // 4️ Inventory
    public class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"{item} added to inventory.");
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
            Console.WriteLine($"{item} removed from inventory.");
        }
    }

    // 5️ MedicinalPlant
    public class MedicinalPlant
    {
        private bool collected = false;

        public void CollectPlant()
        {
            collected = true;
            Console.WriteLine("Plant collected.");
        }

        public void MakeMedicine()
        {
            if (collected)
                Console.WriteLine("Medicine created!");
            else
                Console.WriteLine("No plant collected.");
        }
    }

    // 6️ Trap
    public class Trap
    {
        private bool isSet = false;

        public void SetTrap()
        {
            isSet = true;
            Console.WriteLine("Trap is set.");
        }

        public void TriggerTrap()
        {
            if (isSet)
                Console.WriteLine("Trap triggered!");
            else
                Console.WriteLine("Trap is not set.");
        }
    }

    // 7️ KnightSword
    public class KnightSword
    {
        public int Damage { get; set; }
        public int Durability { get; set; } = 100;

        public KnightSword(int damage)
        {
            Damage = damage;
        }

        public void Attack()
        {
            Durability -= 10;
            Console.WriteLine($"Knight sword attacks for {Damage} damage!");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Sword durability: {Durability}");
        }
    }

    // 8️ Recipe
    public class Recipe
    {
        public string Name { get; set; }
        private List<string> ingredients = new List<string>();

        public Recipe(string name)
        {
            Name = name;
        }

        public void AddIngredient(string ingredient)
        {
            ingredients.Add(ingredient);
            Console.WriteLine($"{ingredient} added.");
        }

        public void ShowRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            foreach (var item in ingredients)
                Console.WriteLine($"- {item}");
        }
    }
}