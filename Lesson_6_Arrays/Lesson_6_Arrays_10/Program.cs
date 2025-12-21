namespace Lesson_6_Arrays_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit unit1 = new Unit("Bob", 100, new Vector2(5, 51));
            Unit unit2 = new Unit("Mary", 100, new Vector2(54, 5));
            Unit unit3 = new Unit("Kristin", 100, new Vector2(5, 55));

            Unit[] units = {unit1, unit2, unit3};

            foreach (Unit unit in units)
            {
                Console.WriteLine(unit.Name + " " + unit.Health + " " + unit.Position.X + " " + unit.Position.Y);
            }
            
            Console.ReadKey();
        }
    }
}