namespace Lesson_4_Conditionals_Switch_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 2;
            char symbol = '@';
            
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        y--;
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        y++;
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        x--;
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        x++;
                        break;
                }
                
                /*if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                }
                else if(keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    x++;
                }
                else if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }
                else if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }*/
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y);
                Console.Write(symbol);
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.WriteLine($"posX = {x},  posY = {y}");
            }
            
            Console.ReadKey();
        }
    }
}