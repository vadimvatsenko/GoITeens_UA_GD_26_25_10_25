// Заняття 1,5 години,
// Кахут

// Сьогодні ми ознайомимось з основними класами для роботи з файлами та директоріями.
// Навчимося читати та записувати дані.
// Опрацюємо команди файлової системи.
// Розглянемо, як правильно обробляти винятки за допомогою try-catch.
// Розглянемо типи винятків.


class Program
{
    public static void Main(string[] args)
    {
        string dirFrom = "data/dirFrom/";
        string dirTo1 = "data/dirTo1/";
        string dirTo2 = "data/dirTo2/";
        string dirTo3 = "data/dirTo3/";
        
        string fileName = "saveData.txt";
        
        string fullPathFrom = dirFrom + fileName; // "data/dirFrom/saveData.txt"
        
        // створить директорію
        Directory.CreateDirectory(dirFrom);

        // створить файл в директорії
        bool isFileInDirect = File.Exists(fullPathFrom);
        Console.WriteLine(isFileInDirect);
        
        if (!isFileInDirect)
        {
            // чи є файл в директорії
            using (File.Create(fullPathFrom))
            {
                Console.WriteLine("File created {0}.", fullPathFrom);
            }
        }
        
        // 
        File.AppendAllText(fullPathFrom, "Hello \nRoman fr \nom Cherkasy \nGoIteens");
        
        
        string text = File.ReadAllText(fullPathFrom);
        Console.WriteLine(text);
        
        string[] lines = File.ReadAllLines(fullPathFrom);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        
        Console.ReadKey();
    }
}