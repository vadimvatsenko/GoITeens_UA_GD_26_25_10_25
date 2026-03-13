
namespace Lesson_15_FileSystem_1;

public class Program
{
    public static void Main()
    {
        string mainDir = @"data";
        string dirFrom = @"data/dirFrom/";
        string dirTo1 = @"data/dirTo1/";
        string dirTo2 = @"data/dirTo2/";
        string dirTo3 = @"data/dirTo3/";

        string fileName = $"data.txt";
        
        string fullPathFrom = dirFrom + fileName;
        string fullPathTo1 = dirTo1 + fileName;
        string fullPathTo2 = dirTo2 + fileName;
        
        // ця команда створює директорію за вказаним шляхом
        Directory.CreateDirectory(dirFrom);
        
        // створить файл за вказаною адресою
        using (File.Create(fullPathFrom))
        {
            Console.WriteLine(fileName + " " + "created");
        } 
        
        // чи є файл у даній директорії
        bool isFileExist = File.Exists(fullPathFrom);
        Console.WriteLine(isFileExist);
        
        // Запише даний текст перезаписавши, що там було
        File.WriteAllText(fullPathFrom, "Hello \nWorld");
        
        // зчитає текст з файла
        string linesBefore = File.ReadAllText(fullPathFrom);
        Console.WriteLine(linesBefore);
        
        // додасть текст у кінець
        File.AppendAllText(fullPathFrom, " \nRoman");
        string linesAfter = File.ReadAllText(fullPathFrom);
        Console.WriteLine(linesAfter);
        
        // копіювання файла, створення директорії обов'їязково
        Directory.CreateDirectory(dirTo1);
        File.Copy(fullPathFrom, fullPathTo1, true);
        
        // видалить файл з директорії
        File.Delete(fullPathFrom);
        // true false, для видалення всього вмісту
        Directory.Delete(dirFrom, true);
        
        // 
        Directory.CreateDirectory(dirTo3);
        File.Move(fullPathTo1, fullPathTo2,  false);
        Directory.Move(dirTo2, dirTo3);
        
        // Кожен рядок файлу в окремий масив
        string[] lines = File.ReadAllLines(fullPathTo2);
        Console.WriteLine($"line {lines[0]}");
        
        // зчитує кожен рядок тексту в окремий массив.
        string[] words = lines[0].Split(' ');
        Console.WriteLine($"words {words[0]}");
        
        // директорія свіх файлів у папці
        string[] directoryPathFiles = Directory.GetFiles(dirTo3);
        Console.WriteLine($"directory path files {directoryPathFiles[0]}");
        
        // директорія свіх підпапок
        string[] directoryPathDirectories = Directory.GetDirectories(mainDir);
        Console.WriteLine($"directory path directories {directoryPathDirectories[0]}");

        // абсолютний шлях до файлів
        string absolutePath = @"C:\Users\user\Documents\EA Games\Dead Space 2";
        string[] allFilesInPath = Directory.GetFiles(absolutePath);
        foreach (string file in allFilesInPath)
        {
            Console.WriteLine(file);
        }
        
        string relativePath = @"\Documents\EA Games\Dead Space 2";
        string[] allFilesFromRelativePath = Directory.GetFiles(relativePath);
        foreach (string file in allFilesFromRelativePath)
        {
            Console.WriteLine(file);
        }
        Console.ReadKey();
    }
}
