using System;

public class Program
{
    public static void Main()
    {
        int numb = 1; // Ціле число  
        float numbFloat = 1.5f; //  число з плаваючою комою.   
        double numbDouble = 1.5d; // Можна d ставити в кінці, а можна і ні. Більш точне значення ніж float
        decimal numbDecimal = 1.5m; // тут дуже точне число, для банківськіх розрахунків,    
        char numbChar = '@'; // символ  
        string numbStr = "Hello World"; // строка
        bool isTrueOrFalse = true; // правда або брехня.
        
        Console.WriteLine(); // вивід інформації на екран
        Console.ReadKey(); // чекає на натискання любої клавіші. 
        Console.Clear(); // очистка консолі
    }
}

