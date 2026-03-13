namespace _12_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Початок гри ===");

            // 1. Enemy
            Enemy goblin = new Enemy("Гоблін", 100);
            goblin.Attack();

            // 2. Magic
            Magic magic = new Magic();
            magic.CastSpell();
            magic.UsePotion();

            // 3. TreasureChest
            TreasureChest chest = new TreasureChest();
            chest.OpenChest();
            chest.TakeTreasure();

            // 4. Inventory
            Inventory inventory = new Inventory();
            inventory.AddItem("Меч");
            inventory.AddItem("Щит");
            inventory.ShowItems();
            inventory.RemoveItem("Щит");

            // 5. MedicinalPlant
            MedicinalPlant plant = new MedicinalPlant();
            plant.CollectPlant();
            plant.MakeMedicine();

            // 6. Trap
            Trap trap = new Trap();
            trap.SetTrap();
            trap.TriggerTrap();

            // 7. KnightSword
            KnightSword sword = new KnightSword();
            sword.Attack();
            sword.ShowStatus();

            // 8. Recipe
            Recipe recipe = new Recipe();
            recipe.AddIngredient("Трава");
            recipe.AddIngredient("Вода");
            recipe.ShowRecipe();

            Console.WriteLine("=== Кінець гри ===");
        }
    }

    // 1. Enemy
    public class Enemy
    {
        public string Name {get; private set;}
        public int Health {get; private set;}

        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Attack()
        {
            Console.WriteLine(Name + " атакує! Здоров'я: " + Health);
        }
    }

    // 2. Magic
    public class Magic
    {
        public void CastSpell()
        {
            Console.WriteLine("Використано заклинання!");
        }

        public void UsePotion()
        {
            Console.WriteLine("Використано зілля!");
        }
    }

    // 3. TreasureChest
    public class TreasureChest
    {
        private List<string> _items = new List<string>();
        public bool IsOpen {get; private set; }
        
        public void AddItem(string item)
        {
            if(IsOpen)
                _items.Add(item);
        }
        
        public void TakeTreasure()
        {
            if (IsOpen)
            {
                Console.WriteLine("Скарб взято!");
            }
        }
        
        public void OpenChest()
        {
            IsOpen = true;
            Console.WriteLine("Скриньку відкрито!");
        }

        public void CloseChest() => IsOpen = false;
    }

    // 4. Inventory
    public class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine("Додано: " + item);
        }

        public void RemoveItem(string item)
        {
            if (items.Remove(item))
                Console.WriteLine("Видалено: " + item);
            else
                Console.WriteLine("Предмет не знайдено");
        }

        public void ShowItems()
        {
            Console.WriteLine("Інвентар:");
            foreach (string item in items)
            {
                Console.WriteLine("- " + item);
            }
        }
    }

    // 5. MedicinalPlant
    public class MedicinalPlant
    {
        public void CollectPlant()
        {
            Console.WriteLine("Рослину зібрано.");
        }

        public void MakeMedicine()
        {
            Console.WriteLine("Ліки виготовлено.");
        }
    }

    // 6. Trap
    public class Trap
    {
        // bool
        public bool IsActive {get; private set; }

        public Trap()
        {
            SetTrap();
        }
        public void SetTrap()
        {
            IsActive = true;
            Console.WriteLine("Пастку встановлено.");
        }

        public void TriggerTrap()
        {
            Console.WriteLine("Пастка спрацювала!");
        }
    }

    // 7. KnightSword
    public class KnightSword
    {
        private int durability = 100;

        public void Attack()
        {
            durability -= 10;
            Console.WriteLine("Меч атакує!");
        }

        public void ShowStatus()
        {
            Console.WriteLine("Міцність меча: " + durability);
        }
    }

    // 8. Recipe
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
            Console.WriteLine("Рецепт:");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }
        }
    }
}
