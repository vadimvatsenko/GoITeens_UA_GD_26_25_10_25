namespace _HomeWorksCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string question = null;
            do
            {
                Console.WriteLine("Write your question, and magic amethyst will answer(or write 143 to exit):");
                question = Console.ReadLine();
            
                if (question == "143")
                {
                    break;
                }

                Answer();
            
                Console.ReadKey();
                Console.Clear();


            } while (true);
        
        }
        static void Answer()
        {
            string answer = null;
            int rnd = new Random().Next(1,4);
            switch (rnd)
            {
                case 1:
                    answer = "Yes";
                    break;
                case 2: 
                    answer = "No";
                    break;
                case 3:
                    answer = "Maybe";
                    break;
                
            }
            Console.WriteLine(answer);
        }
    }
}


    


