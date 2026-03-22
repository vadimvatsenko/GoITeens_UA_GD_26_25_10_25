
using System;

namespace MyNamespace;

class Program
{
    static void Main(string[] args)
    {
        //List_1();
        //List_2();
        // List_3();
        // List_4();
        // List_5();
        // List_6();
        List_7(); 
        //List_8();
        //List_9();
        //List_10();
    }

    private static void List_10()
    {
        // OK
        // Героїчний похід: Гравець вирушає у героїчний похід через ліс, збираючи на своєму шляху магічні артефакти.
        // Кожен наступний артефакт розташований на відстані, яка дорівнює сумі вже зібраних артефактів.
        // Створіть список відстаней до кожного артефакту.
        
        List<int> number = new List<int>()
        {
            2,
            5,
        };
            
        int sum = number.Sum();

        for (int i = 2; i < 10; i++)
        {
            number.Add(sum);
            sum += number[i];
        }

        foreach (int i in number)
        {
            Console.WriteLine(i);
        }
            
        Console.ReadKey();
    }

    private static void List_9()
    {
        // OK
        // Подорож у часі: Гравець подорожує у минуле, відвідуючи різні епохи.
        // Кожен наступний рік у минулому знаходиться вдвічі далі за попередній.
        // Створіть список років, які відвідав гравець.
        
        List<int> year = new List<int>()
        {
            2026,
            1984
        };

        for (int i = 1; i < 10; i++)
        {
            int targetYear = year[i] - ((year[i - 1] - year[i]) * 2);
            year.Add(targetYear);
        }

        foreach (int i in year)
        {
            Console.WriteLine(i);
        }
            
        Console.ReadKey();
    }

    private static void List_8()
    {
        // OK
        /*Магічні кристали: Гравець збирає магічні кристали, розташовані у лісі на деревах.
        Кількість кристалів на кожному дереві визначається числами, що представляють степені чотирьох.
        Створіть список кількості кристалів на кожному дереві.*/
        
        List<double> numbers = new List<double>();

        for (int i = 1; i < 10; i++)
        {
            numbers.Add(Math.Pow(i, 4));
        }

        foreach (double i in numbers)
        {
            Console.WriteLine(i);
        }
    }

    private static void List_7()
    {
        //Будівництво космічних станцій: Гравець будує космічні станції на орбіті навколо планети.
        //Кількість станцій на кожній орбіті визначається числами, що представляють ступені трійки.
        //Створіть список кількості станцій для кожної орбіти.
        
        List<int> orbit = new List<int>()
        {
            1,
            2,
            3,
            4,
            5,
            6
        };

        List<int> station = new List<int>()
        {
            1,
            3,
            9,
            27,
            81,
            243
        };

        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"You have unlocked a new orbit {orbit[i]} the number of station is {station[i]}!");
        }
        
        Console.ReadKey();
    }

    private static void List_6()
    {
        // Розвиток цивілізації: Гравець розвиває свою цивілізацію.
        // Перший елемент списку є початковим станом,
        // кожен наступний елемент — це сума попередніх елементів.
        
        List<int> civilization = new List<int>()
        {
            3, 10, // 13 // 26 // 52
        };

        int sum = civilization[0];

        for (int i = 1; i <= 10; i++)
        {
            sum += civilization[i];
            civilization.Add(sum);
        }

        foreach (int i in civilization)
        {
            Console.WriteLine(i);
        }
        
        
        Console.ReadKey();
    }

    private static void List_5()
    {
        // Скарби на островах: Гравець шукає легендарні скрині зі скарбами, розташовані на островах.
        // Кількість скарбів на кожному острові визначається числами Фібоначчі.
        // Створіть список кількості скарбів на кожному острові.
        
        // послідовність, де кожне наступне число дорівнює сумі двох попередніх, починаючи з 0 та 1: 
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946
        
        
        List<int> fibanachi = new List<int>()
        {
            0,
            1
        };

        for (int i = 1; i <= 10; i++)
        {
            int targetFibanachi = fibanachi[i - 1] +  fibanachi[i];
            fibanachi.Add(targetFibanachi);
        }

        foreach (int i in fibanachi)
        {
            Console.WriteLine(i);
        }
        
        Console.ReadKey();
    }

    private static void List_4()
    {
        /*Подорож на планети: Гравець здійснює подорож на планети галактики.
    Кожна наступна планета вдвічі віддаленіша за попередню.
    Створіть список відстаней до кожної планети*/

        // (500 - 170) * 2 + 500
        List<int> distance = new List<int>()
        {
            170, // 0
            500 // 1
        };

        for (int i = 1; i <= 10; i++)
        {
            int numb = distance[i] + (distance[i] - distance[i - 1]) * 2;
            distance.Add(numb);
        }

        foreach (int i in distance)
        {
            Console.WriteLine(i);
        }

        Console.ReadKey();

    }

    private static void List_3()
        {
            /*Магічні портали: Гравець відкриває магічні портали на інші світи.
        Кожен наступний світ має бути вдвічі більшим за попередній.
        Створіть список кількості порталів для кожного світу.*/
            
            
            List<int> portals = new List<int>()
            {
                17 // 0
            };
    
            for (int i = 1; i <= 10; i++)
            {
                int number = portals[i - 1] * 2;
                portals.Add(number);
            }

            foreach (int i in portals)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
    
        private static void List_2()
        {
            /*Будівництво міст: Гравець будує своє власне королівство та міста на території.
            Кількість міст визначається числами, які представляють ступені двійки.
            Створіть список кількості міст для кожного рівня.*/
    
            List<double> towns = new List<double>()
            {
                
            };

            for (int i = 2; i <= 10; i++)
            {
                double numb = Math.Pow(i, 2);
                towns.Add(numb);
            }
        
            foreach (var item in towns)
            {
                Console.WriteLine($"You have reached a new level! {item} towns are available!");
            }
        
            Console.ReadKey();
            
        }
    
        private static void List_1()
        {
            // OK
            // Збір скарбів: Гравець повинен зібрати скарби, розташовані на рядку.
            // Кожен скарб — це номер клітинки. Створіть і виведіть список цих скарбів.
    
            List<int> numbs = new List<int>()
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9
            };
    
            foreach (var item in numbs)
            {
                Console.WriteLine($"On the square {item} is a treasure!");
            }
    
            Console.ReadKey();
        }
}


