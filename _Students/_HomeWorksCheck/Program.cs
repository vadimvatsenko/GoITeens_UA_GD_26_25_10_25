using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        
        string[] songs = { "Mozart", "Notion", "stephanie", "megusta stu", "yugoslavskiy groove" };
        int[] rating = { 5, 4, 4, 5, 4 };
        for (int i = 0; i < songs.Length; i++)
        {
            Console.WriteLine($"{songs[i]} - {rating[i]}");
        }
        int maxrating = rating[0];
        int maxIndex = 0;
		
        for (int i  = 0; i < songs.Length; i++)
        {
            if (rating[i] > maxrating)
            {
                maxrating = rating[i];
                maxIndex = i; 
            }
        }
        Console.WriteLine($"Max rating: {maxrating}");
        Console.WriteLine($"Max index: {maxIndex}");
        Console.ReadKey();
    }
}












