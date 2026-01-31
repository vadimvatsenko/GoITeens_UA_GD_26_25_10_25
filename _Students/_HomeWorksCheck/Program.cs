using System.Globalization;
using System.Text;

namespace _HomeWorksCheck
{
    internal class Program
    {
        private static int _goldCost = 200;
        private static decimal _dollarCost = 42.000m;
        
        static void Main(string[] args)
        {
            
            Dictionary<int, string> nameOfOperation = new Dictionary<int, string>()
            {
                [1] = "Currency exchange",
                [2] = "Gold to cristals"
            };
            
            int myMoney = 1000;
            
            int keyOfOperation = ValidOperation(nameOfOperation);
            
            Console.WriteLine(nameOfOperation[keyOfOperation]);

            ChooseOperation(keyOfOperation, myMoney, nameOfOperation);
            
            Console.ReadKey();
        }

        private static int ValidOperation(Dictionary<int, string> nameOfOperation)
        {
            bool isCorrectOperation = false;
            int key = 0;
            while (!isCorrectOperation)
            {
                ShowOperation(nameOfOperation);
                Console.WriteLine("Enter Operation:");
                
                bool tryParce = int.TryParse(Console.ReadLine(), out int numberOfOperation);
                
                if (nameOfOperation.ContainsKey(numberOfOperation) && tryParce)
                {
                    isCorrectOperation = true;
                    key = numberOfOperation;
                }
                else
                {
                    isCorrectOperation = false;
                    Console.WriteLine("Wrong Operation!");
                }
            }

            return key;
        }

        private static void ChooseOperation(int numberOfOperation, int myMoney, Dictionary<int, string> nameOfOperation)
        {
            switch (numberOfOperation)
            {
                case 1:
                    Console.WriteLine($"Operation is {nameOfOperation[numberOfOperation]}");
                    Console.WriteLine($"{myMoney/_dollarCost:F2}$");
                    break;
                case 2:
                    Console.WriteLine($"Operation is {nameOfOperation[numberOfOperation]}");
                    Console.WriteLine($"{myMoney/_goldCost:F2} Golds");
                    break;
                default:
                    Console.WriteLine("Wrong Operation!");
                    break;
            };
        }

        private static void ShowOperation(Dictionary<int, string> nameOfOperation)
        {
            foreach (var item in nameOfOperation)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        
    }
}

    


