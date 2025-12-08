using System;

public class Program
{
    public static void Main()
    {
        string myName = "John"; // string текст;
        int myAge = 30; // ціле число
        bool isILoveUnity = true; // булеве значення, може бути або true або false

        // Варіанти виводу у консоль
        // 1. Кожен по черзі через пробіл 
        Console.WriteLine(myName + " " + myAge + " " + isILoveUnity);

        Console.WriteLine("------");
        
        // 2. Кожна зміна окремо по черзі.
        Console.WriteLine(myName);
        Console.WriteLine(myAge);
        Console.WriteLine(isILoveUnity);

        Console.WriteLine("------");
        
        // 3. Варіант, в один рядок, у фігурних дужках кожна змінна окремо
        Console.WriteLine($"My name is {myName} . My age is {myAge}. I love unity? {isILoveUnity}");
        
        Console.WriteLine("------");
        
        // 4. Як варіант №3 тільки використовується . \n - кожне речення перенесе на нову строку. 
        Console.WriteLine($"My name is {myName} \nMy age is {myAge} \nI love unity? {isILoveUnity} ");
    }
}