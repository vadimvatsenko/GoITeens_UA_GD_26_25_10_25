using System.Text.Json;

namespace English
{
    public class Program
    {
        private static readonly string DirPath = "A0";
        
        private static readonly string FilePath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, $"..\\..\\..\\{DirPath}\\A0_1.json")
        );
        
        /*private static readonly string FilePath 
            = Path.Combine(AppContext.BaseDirectory, DirPath, "A0_1.json");*/
        
        public static async Task Main(string[] args)
        {
            
            Console.WriteLine(FilePath);
            
            bool isFileExist = File.Exists(FilePath);
            
            Console.WriteLine(isFileExist);
            
            List<Vocabulary> vocabularies = new List<Vocabulary>();
            
            vocabularies = await GetAsync();

            foreach (var vocabulary in vocabularies)
            {
                Console.WriteLine(vocabulary.En);
            }
            
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }

        public static async Task<List<Vocabulary>?> GetAsync()
        {

            string json = await File.ReadAllTextAsync(FilePath);
            
            List<Vocabulary> vocabularies = new List<Vocabulary>();
            
            try
            {
                return JsonSerializer.Deserialize<List<Vocabulary>>(json) ?? new List<Vocabulary>();
            }
            catch (Exception e)
            {
                return vocabularies;
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class Vocabulary
    {
        public string En { get; set; }
        public string Ipa { get; set; }
        public string Ru { get; set; }
    }

    public class Sections
    {
        public string Title { get; set; }
        public string Rule {get; set;}
        public Examples[] Examples {get; set;}
    }

    public class Examples
    {
        public string En { get; set; }
        public string Ipa { get; set; }
        public string Ru { get; set; }
    }

    
}

