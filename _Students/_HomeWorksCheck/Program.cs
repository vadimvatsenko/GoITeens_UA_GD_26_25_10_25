
class Program
{
    static void Main(string[] args)
    {
        
        string[] songs =
        {
            "And One - Panzermensch", "Modern Talking - Cherry Cherry Lady", "Bee Gees - Stayin' Alive",
            "And One - Steine sind Steine", "U96 - Das Boot"
        };

        int[] ratings = { 5, 1, 5, 3, 4 };

        int minRating = ratings[0];

        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i - 1] > ratings[i])
            {
                (ratings[i - 1], ratings[i]) = (ratings[i], ratings[i - 1]);

                (songs[i - 1], songs[i]) = (songs[i], songs[i - 1]);
            }
        }

        for (int i = 0; i < ratings.Length; i++)
        {
            Console.WriteLine($"{songs[i]} - {ratings[i]}");
        }

        int maxRatings = ratings[0];
        int maxIndex = 0;
            
        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] > maxRatings)
            {
                maxRatings = ratings[i];
                maxIndex = i;
            }
        }
            
        //Console.Write($" The maxRating :{songs[maxIndex]} - {ratings[maxIndex]}");

        Console.ReadKey();
        
    }
        
}



        
    



    













