using System;

public class Program
{
    public static void Main(string [] args)
    {
        // приклади змін
        int numb = 1; // Ціле число.
        float numbFloat = 1.5f; //  Число з плаваючою комою.
        double numbDouble = 1.5d; // Можна d ставити в кінці, а можна і ні. Більш точне значення ніж float.
        decimal numbDecimal = 1.5m; // Тут дуже точне число, для банківських операцій, великих математичних та фізичних розрахунків. 
        char numbChar = '@'; // Символ.
        string numbStr = "Hello World"; // Строка
        bool isTrueOrFalse = true; // Правда або брехня.
        
        Console.WriteLine(); // Вивід інформації на екран
        Console.ReadKey(); // Чекає на натискання любої клавіші. 
        Console.Clear(); // Очищення консолі
    }
}

