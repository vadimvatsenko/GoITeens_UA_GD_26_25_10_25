// Плани на сьогодні
// Опитування по файловій системі. 0,5 години
// Нова тема Дебагінг та Аналіз Коду
// А саме практика, буду по черзі давати завдання

// Нова тема дебагінг, вона більш практична
// даю задачі, 


using System;

public class Program
{
    public static async Task Main()
    {
        string mainDir = "data";
        string dirFrom1 = "data/dirFrom1/";
        string dirTo1 = "data/dirTo1/";
        
        string fileName = "data.txt";
        
        string fullPathFrom = dirFrom1 + fileName;
        string fullPathTo1 = dirTo1 + fileName;

        Directory.CreateDirectory(dirFrom1);
        Directory.CreateDirectory(dirTo1);

        if (!File.Exists(fullPathFrom))
        {
            File.Create(fullPathFrom);
        }
        
        File.Copy(fullPathFrom, fullPathTo1,  true);

        string[] files = Directory.GetFiles(dirFrom1);
        Console.WriteLine(files.Length);

        File.WriteAllText(fullPathFrom, "Hello \nWorld");
        
        Console.ReadKey();

    }
}