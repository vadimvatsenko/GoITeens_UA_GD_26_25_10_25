using System;
using System.Text;
using System.Text.Json;

// Карткова Гра
// Сьогодні ми розпочнемо реалізовувати карткову гру.
// Основною метою проекту є створення схожої гри по прикладу: «Hearthstone», «Legends of Runeterra».

// Частина 1
// Реалізація шаблону карт. Поля даних, метод відображення карточки.
// Система зберігання інформації карт, що використовуватимуться.

// Частина 2
// Шаблон гравців. Поля даних, метод взяття карт з колоди, відображення руки.
// Реалізація об’єкту гравця, ворога, взяття карточок з колоди.

// Частина 3
// Реалізація головного ігрового циклу.
// Вибір карт гравцем, ворогом.
// Реалізація бойової сцени.
// Перевірка хто переміг в грі.
// Перевірка на перемогу, поразку.
 
//
//
// HealthComponent для Character та карти  + 10 балів
// Завдання, реестрація та логінізація нового гравця + 10 балів
// Кількість поразок та виграшів + 5 балів
// UI хто проти кого грає + 5 балів
// На вибір гра з людиною або опонентом + 10 балів
// Цікавий візуал

namespace Hearthstone
{
    public class Program
    {
        // main асинхроний
        public static async Task Main(string[] args)
        {
            Console.Title = "Hearthstone";
            
            SetSettings(150, 50);
            
            string path = Path.Combine(AppContext.BaseDirectory, "Data");
            
            //string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, $"Data"));
            
            string jsonPath = Directory.GetFiles(path).First(x => x.EndsWith(".json"));
            
            List<Card> allCards = await GetCardsFromJsonAsync(jsonPath);
            
            Character player = new Character("Player", 3, allCards);
            Character enemy = new Character("Enemy",  3, allCards);

             for (int i = 0; i < 3; i++)
            {
                player.ChooseCard();
                enemy.ChooseCard();
                await Task.Delay(1000);
            }
             
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player Choose Card");
                player.ChooseCard();
                
                Console.WriteLine("Show all Player's Cards: ");
                player.DisplayCardsOnHand();
                
                Card playerCard = null;

                while (playerCard == null)
                {
                    Console.Write("Player Choose Cards: ");
                    int selectedIndex = int.Parse(Console.ReadLine());
                    playerCard = player.GetCardFromIndex(selectedIndex);
                }
                
                /*Console.WriteLine($"{player.Name} Choose Card: {playerCard.Name}");
                playerCard.Draw();*/
                
                Console.WriteLine("Enter any key for continue");
                Console.ReadKey();
                
                Console.Clear();
                
                Console.WriteLine($"{enemy.Name} start play");
                enemy.ChooseCard();
                
                Random random = new Random();
                int index = random.Next(0, enemy.CardsOnHand.Count);
                
                Card enemyCard = enemy.GetCardFromIndex(index);
                
                Console.WriteLine($"{enemy.Name} play card {enemyCard.Name}");
                
                await Task.Delay(3000);
                
                Console.Clear();
                
                Console.WriteLine($"{player.Name} attack card: {playerCard.Name}");
                Console.ForegroundColor = ConsoleColor.Green;
                playerCard.Draw();
                
                Console.ResetColor();
                
                Console.WriteLine($"{enemy.Name} attack card: {enemyCard.Name}");
                Console.ForegroundColor = ConsoleColor.Red;
                enemyCard.Draw();
                
                playerCard.HealthComponent.TakeDamage(enemyCard.AttackPower);
                enemyCard.HealthComponent.TakeDamage(playerCard.AttackPower);

                if (!enemyCard.HealthComponent.IsAlive && playerCard.HealthComponent.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{player.Name} is win");
                    Console.ResetColor();
                    enemy.HealthComponent.TakeDamage(1);
                }
                else if(!playerCard.HealthComponent.IsAlive && enemyCard.HealthComponent.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} is lose");
                    Console.ResetColor();
                    player.HealthComponent.TakeDamage(1);
                }
                else
                {
                    Console.ForegroundColor =  ConsoleColor.Yellow;
                    Console.WriteLine($"It's a draw!");
                    Console.ResetColor();
                }
                
                await Task.Delay(2000);
                
                enemy.RemoveCardFromHand(enemyCard);
                player.RemoveCardFromHand(playerCard);
                
                Console.WriteLine($"PlayerHealth {player.HealthComponent.Health}  - EnemyHealth {enemy.HealthComponent.Health}");
                Console.WriteLine($"Player {player.HealthComponent.IsAlive} - Enemy {enemy.HealthComponent.IsAlive}");

                if (!player.HealthComponent.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} is dead");
                    Console.WriteLine($"{enemy.Name} is win!");
                    Console.WriteLine("Enter any key for exit...");
                    Console.ReadKey();
                    break;
                }
                else if(!enemy.HealthComponent.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{enemy.Name} is dead");
                    Console.WriteLine($"{player.Name} is win!");
                    Console.WriteLine("Enter any key for exit...");
                    Console.ReadKey();
                    break;
                }
                else if(player.CardsOnHand.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"It's a draw!");
                    Console.WriteLine("Enter any key for exit...");
                    Console.ReadKey();
                    break;
                }
                
                Console.ReadKey();
            }
        }

        private static void SetSettings(int width, int height)
        {
            Console.CursorVisible = false;
            if (OperatingSystem.IsWindows())
            {
                Console.WindowWidth = width;
                Console.WindowHeight = height;
            }
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
        }

        private static async Task<List<Card>> GetCardsFromJsonAsync(string jsonPath)
        {
            List<Card> allcards = new List<Card>();

            try
            {
                string json = await File.ReadAllTextAsync(jsonPath);
                allcards = JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>() ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            return allcards;
        }
    }
}

