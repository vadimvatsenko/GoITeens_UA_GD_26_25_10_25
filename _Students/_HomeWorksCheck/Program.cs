class Program
{
    static void Main()
    {
        Enemy enemy = new Enemy("Орк", 100);
        enemy.Attack();

        Magic magic = new Magic();
        magic.CastSpell("Вогняна пуля");
        magic.UsePotion("Зілля здоров'я");
        TreasureChest chest = new TreasureChest();
        chest.OpenChest();
        chest.TakeTreasure("Золото");
        Inventory inventory = new Inventory();
        inventory.AddItem("Меч");
        inventory.RemoveItem("Меч");
        MedicinalPlant plant = new MedicinalPlant();
        plant.CollectPlant("Роза");
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
        Console.ReadKey();
    }



    class Enemy
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
            Console.WriteLine(Name + " атакує!");
        }
    }

    class Magic
    {
        public void CastSpell(string spell)
        {
            Console.WriteLine("Використано заклинання " + spell);
        }

        public void UsePotion(string potion)
        {
            Console.WriteLine("Використано зілля " + potion);
        }
    }


    class TreasureChest
    {
        public void OpenChest()
        {
            Console.WriteLine("Скриню відкрито");
        }

        public void TakeTreasure(string treasure)
        {
            Console.WriteLine("Взято скарб " + treasure);
        }
    }


    class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine(item + " додано до інвентаря");
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
            Console.WriteLine(item + " видалено з інвентаря");
        }
    }


    class MedicinalPlant
    {
        public void CollectPlant(string plant)
        {
            Console.WriteLine("Зібрано рослину" + plant);
        }

        public void MakeMedicine()
        {
            Console.WriteLine("Ліки виготовлено");
        }
    }

    class Trap
    {
        public void SetTrap()
        {
            Console.WriteLine("Пастку встановлено");
        }

        public void TriggerTrap()
        {
            Console.WriteLine("Пастка спрацювала");
        }
    }

    class KnightSword
    {
        public int Durability { get; set; } = 100;

        public void Attack()
        {
            Durability -= 10;
            Console.WriteLine("Меч атакуе Міцність " + Durability);
        }

        public void ShowState()
        {
            Console.WriteLine("Стан меча " + Durability);
        }
    }


    class Recipe
    {
        private List<string> ingredients = new List<string>();

        public void AddIngredient(string ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void ShowRecipe()
        {
            Console.WriteLine("Інгредієнти рецепту");
            foreach (var i in ingredients)
            {
                Console.WriteLine(i);
            }
        }
    }
}