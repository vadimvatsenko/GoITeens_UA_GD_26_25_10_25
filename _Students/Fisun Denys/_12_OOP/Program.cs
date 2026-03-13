

   namespace Homework_12._1
   {

      class Enemy
      {
         public string Name = "Enemy";
         private int Health = 100;

         public void Hit(int damage)
         {
            Health -= damage;
            Console.WriteLine(Name + " attacked. You got damaged " + damage + " Healf");
         }
      }
      
      class Program
      {
         static void Main()
         {
            Enemy enemy = new Enemy();
            Console.WriteLine("Enemy's name:" + enemy.Name);
            enemy.Hit(20);
            
            Magic magic = new Magic();
            magic.CastSpell(); 
            Console.WriteLine("Name of ze potion: " + magic.NameOfPotion);
            magic.UsePotion(45);
            
            TreasureChest chest = new TreasureChest();
            chest.Chest();
            chest.TakeItems("gold");
            chest.TakeItems("silver");
            chest.TakeItems("gun");
         }
      }
   };

2)

namespace Homework_12._2
{
    class Magic
    {
        public string NameOfPotion = "HealthPotion";
        private int Health = 55;
        
        public void CastSpell()
        {
            Console.WriteLine("I said Cast Spell");
        }

        public void UsePotion(int HealthCores)
        {
            Health += HealthCores;
            Console.WriteLine(NameOfPotion + " healed you. Now you have " + Health);
        }
    }
    
   
};

3)
using System;
namespace Homework_12_3
{
	class TreasureChest
	{
		private List<string> treasure = new List<string>();

		public void Chest()
		{
			treasure.Add("gold");
			treasure.Add("silver");
			treasure.Add("bronze");
			treasure.Add("diamond");
			Console.WriteLine("Treasure chest is open");
		}

		public void TakeItems(string item)
		{
			if (treasure.Contains(item))
			{
				treasure.Remove(item);
				Console.WriteLine("You have taken " + item);
			}
			else
			{
				Console.WriteLine("There is no such item");
			}
		}

		class Program
		{
			static void Main()
			{
				
			}
		}
	}

3)
using System;
namespace Homework_12_3
{
	class TreasureChest
	{
		private List<string> treasure = new List<string>();

		public void Chest()
		{
			treasure.Add("gold");
			treasure.Add("silver");
			treasure.Add("bronze");
			treasure.Add("diamond");
			Console.WriteLine("Treasure chest is open");
		}

		public void TakeItems(string item)
		{
			if (treasure.Contains(item))
			{
				treasure.Remove(item);
				Console.WriteLine("You have taken " + item);
			}
			else
			{
				Console.WriteLine("There is no such item");
			}
		}

		class Program
		{
			static void Main()
			{
				TreasureChest chest = new TreasureChest();
				chest.Chest();
				chest.TakeItems("gold");
				chest.TakeItems("silver");
				chest.TakeItems("gun");
			}
		}
	}
}

4)
namespace Homework_12._4
{
    class Inventory
    {
        private List<string> items = new List<string>() { "AK-47", "M16", "Knife", "Bonk!" };

        public void ItemsFound()
        {
            items.Add("30 rounds (7.62 X 39)");
            items.Add("beef");
        }
        
        public void TakingItems(string itemName)
        {
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                items.Add(itemName);
                Console.WriteLine($"Item: {itemName} added to inventory.");
            }
        }
        
        public bool RemovingItem(string itemName)
        {
            if (items.Remove(itemName))
            {
                Console.WriteLine($"Item: {itemName} removed from inventory.");
                return true;
            }

            Console.WriteLine($"There is no {itemName}.");
            return false;
        }
    }
    
    class Program
    {
        static void Main()
        {
            Inventory myInventory = new Inventory();

            myInventory.TakingItems("30 rounds (7.62 X 39)");
            myInventory.TakingItems("beef");
            myInventory.RemovingItem("Bonk!");
            
        }
    }
}

5)
namespace Homework_12._5
{
    class MedicinalPlant
    {
        private List<string> medicinalPlants = new List<string>();

        public void Plants()
        {
            medicinalPlants.Add("Roslina");
            medicinalPlants.Add("Likyvalnik");
            medicinalPlants.Add("Grasssss");
        }

        public void ZelyeVarinnya(string plants)
        {
            if (medicinalPlants.Contains(plants))
            {
                medicinalPlants.Remove(plants);
                Console.WriteLine("You have colected " + plants);
            }
            else
            {
                Console.WriteLine("You don't have found " + plants);
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            MedicinalPlant plant =  new MedicinalPlant();
            plant.Plants();
            plant.ZelyeVarinnya("Roslina");
            plant.ZelyeVarinnya("Likyvalnik");
            plant.ZelyeVarinnya("Grasssss");
            plant.ZelyeVarinnya("Hahovina");
            
            Console.WriteLine("Now you can make medicine!");
        }
    }
};
