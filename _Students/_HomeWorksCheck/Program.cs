using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        
        //Масив з назвами пісень
        string[] songs = {
            "Bohemian Rhapsody",
            "Imagine",
            "Hotel California",
            "Smells Like Teen Spirit",
            "Billie Jean"
        };

        // Масив з рейтингами пісень
        int[] ratings = { 5, 4, 5, 4, 5 };
        
        Console.WriteLine("Список пісень та рейтингів:\n");
        for (int i = 0; i < songs.Length; i++)
        {
            Console.WriteLine($"Пісня: {songs[i]} - Рейтинг: {ratings[i]}");
        }
        
        int maxRating = ratings[0];
        int maxIndex = 0;

        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] > maxRating)
            {
                maxRating = ratings[i];
                maxIndex = i;
            }
        }
        
        Console.WriteLine("\nПісня з найвищим рейтингом:");
        Console.WriteLine($"Пісня: {songs[maxIndex]} - Рейтинг: {maxRating}");

            Console.ReadKey();
        
    }
}










