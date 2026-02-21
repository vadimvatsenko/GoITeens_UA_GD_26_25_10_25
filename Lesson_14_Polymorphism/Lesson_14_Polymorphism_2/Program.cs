namespace Lesson_14_Polymorphism_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> answers = new List<string>()
            {
                "Yes",
                "No",
                "Maybi"
            };
            
            Random random = new Random();
            
            Console.ForegroundColor = ReturnColor("No");
            Console.WriteLine("Welcome to Rider!");
        }

        static ConsoleColor ReturnColor(string anwer)
        {
            switch (anwer)
            {
                case "Yes":
                    return ConsoleColor.Green;
                case "No":
                    return ConsoleColor.Red;
            }
            
            return ConsoleColor.White;
            
        }
    }
}