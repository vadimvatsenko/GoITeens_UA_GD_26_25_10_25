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

// 60 балів
// Завдання, реестрація та логінізація нового гравця + 10 балів
// UI хто проти кого грає + 5 балів
// На вибір гра з людиною або опонентом + 10 балів
// HealthComponent для Character  + 10 балів
// Кількість поразок та виграшів + 5 балів

// Роман, ДЗ Полі
// Async
// Пригадаємо що зробили на минулому уроці
// продовжуємо писати наш додаток.

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

            Character character = new Character("Player", 3, allCards);

            for (int i = 0; i < 5; i++)
            {
                character.ChooseCard();
            }

            character.DisplayCardsOnHand();
            
            
            Console.ReadKey();
        }

        private static void SetSettings(int width, int height)
        {
            Console.CursorVisible = false;
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowWidth = width;
            Console.WindowHeight = height;
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

