using System;
using System.Globalization;

// Рандом
namespace Lesson_3_Conditionals_IfElse_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            int damage = rnd.Next(1, 101);
            
            if (damage > 0 && damage <= 33)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Enemy take middle damage: {damage}");
            } 
            else if (damage > 33 && damage <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Enemy take heavy damage: {damage}");
            } 
            else if (damage > 70 && damage <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enemy take critical damage: {damage}");
            }
        }
    }
}