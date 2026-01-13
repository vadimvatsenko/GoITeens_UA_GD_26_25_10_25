namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[]
            {
                1, // 0 - індекс
                70, // 1 - індекс
                13, // 2 - індекс
                100, // 3 - індекс
                12, // 4 - індекс
            };
            

            string[] songs = new[]
            {
                "The Weeknd — “Blinding Lights”", // 0
                "Ed Sheeran — “Shape of You”", // 1
                "Adele — “Rolling in the Deep”", // 2
                "Imagine Dragons — “Believer”", // 3
                "Billie Eilish — “bad guy”" // 4
            };

            Console.WriteLine(songs[3]);


            for (int i = 0; i < songs.Length; i++)
            {
                Console.WriteLine(songs[i] + " " + numbers[i]);
            }


            int songWithMaxIndex = CalcMaxNumberIndex(numbers); // 3

            Console.WriteLine(songs[songWithMaxIndex]);

            int[] sortNumbers = new int[numbers.Length];

            sortNumbers = Sort(numbers);
            
            Sort(numbers);
            
            Console.WriteLine("==============");

            
            foreach (var n in sortNumbers)
            {
                Console.WriteLine(n);
            }

            Console.ReadKey();
        }

        /*int[] numbers = new[]
        {
            1, // 0 - індекс
            70, // 1 - індекс
            13, // 2 - індекс
            100, // 3 - індекс
            12, // 4 - індекс
        };*/
       
        private static int[] Sort(int[] numbers)
        {
            int[] sort =  new int[numbers.Length];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    int temp = 0;
                    
                    if (numbers[i] < temp)
                    {
                        sort[i] =  numbers[i];
                    }
                    else if (numbers[j] > temp)
                    {
                        sort[j] = numbers[j];
                    }
                    
                }
            }
            
            return sort;
        }
        
        private static int CalcMaxNumberIndex(int[] numbers)
        {
            int maxNumber = numbers[0]; // 1 // 70 // 100 
            int maxNumberIndex = 0; // 0 // 1 // 3
            
            for (int i = 1; i < numbers.Length; i++)
            {
                // 1ша ітерація - 70 > 1 = true
                // 2га ітерація - 13 > 70 = false
                // 3тя ітерація - 100 > 70 = true
                // 4та ітерація - 12 > 100 = false
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i]; // maxNumber = 70 // 70 // 100
                    maxNumberIndex = i; // maxNumberIndex = 1 // 1 // 3
                }
            }
            
            return maxNumberIndex;
        }
    }
}