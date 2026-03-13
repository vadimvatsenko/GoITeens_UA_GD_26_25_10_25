using System;
namespace Dz_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            
            Dictionary<int, string> _gameMenu = new Dictionary<int, string>()
            {
                [1] = "Ви хочете додати предмети в інвертар?",
                [2] = "Ви хочете видалити предмети з інвертаря?",
                [3] = "Хочете вивести Інвертар?"
            };

            

            bool isValudMenuNumber = false;

            while (!isValudMenuNumber)
            {
                Console.Write($"Enter value from 1 to {_gameMenu.Count} ");
                foreach (var item in _gameMenu)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
                
                string input = Console.ReadLine();
            
                isValudMenuNumber = CheckNumber(input, _gameMenu.Count);

                if (isValudMenuNumber)
                {
                    int numb = int.Parse(input);
                    Console.WriteLine(_gameMenu[numb]);
                    EnterGame(numb, inventory);
                }
                else
                {
                    Console.WriteLine("Not Valid Input");
                }
            }
            
            
            Console.ReadKey();
        }

        private static void EnterGame(int numb, Inventory inventory)
        {
            switch (numb)
            {
                case 1:
                    AddItemsInInventory(inventory);
                    break;
            }
        }

        private static void AddItemsInInventory(Inventory inventory)
        {
            string[] items = new[]
            {
                "USP", "RPG", "Gold M4A1-S"
            };

            string input = String.Empty;
            bool isValitItem = false;
            
            while (!isValitItem)
            {
                Console.WriteLine($"Enter item for Inventory ADD");
            
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            
                input = Console.ReadLine();
                isValitItem = items.Contains(input);

                if (items.Contains(input))
                {
                    inventory.AddItem(input);
                    return;
                }
                else
                {
                    Console.WriteLine("Not Valid Input");
                }
            }
            
        }


        private static bool CheckNumber(string? input, int count)
        {
            bool parseValid = int.TryParse(input, out int number);

            bool isValidNumber = number <= count && number > 0;
            
            return parseValid && isValidNumber;
        }
    }
}