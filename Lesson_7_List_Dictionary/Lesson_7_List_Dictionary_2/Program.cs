namespace Lesson_7_List_Dictionary_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Enemy enemy = new Enemy('@', new Vector2(0, 0));

            while (true)
            {
                //enemy.Update();
                //Console.Clear();
                enemy.Update();
                Thread.Sleep(500);
            }
        }
    }
}