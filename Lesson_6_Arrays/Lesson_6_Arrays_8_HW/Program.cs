namespace Lesson_6_Arrays_8_HW
{
    class Program
    {
        static void Main()
        {
            // Пленгей Євген Богданович 
            // Масив з назвами пісень

            string[] songs =
            {
                "Bohemian Rhapsody",
                "Imagine",
                "Hotel California",
                "Smells Like Teen Spirit",
                "Billie Jean",
            };

            // Масив з рейтингами пісень
            int[] ratings = { 5, 2, 5, 3, 5 };

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

            /*Console.WriteLine("\nПісня з найвищим рейтингом:");
            Console.WriteLine($"Пісня: {songs[maxIndex]} - Рейтинг: {maxRating}");*/

            for (int i = 0; i < ratings.Length; i++)
            {
                if (ratings[i] == maxRating)
                {
                    Console.WriteLine(songs[i]);
                }
            }
            
            Console.ReadKey();
        }
    }
}
