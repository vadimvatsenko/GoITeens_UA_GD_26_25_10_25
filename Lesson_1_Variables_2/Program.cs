using System;

public class Program
{
    public static void Main()
    {
        string myName = "John";
        int myAge = 30;
        char myGender = '←';

        Console.WriteLine(myName + " " + myAge + " " + myGender);

        bool isILoveUnity = true;

        Console.WriteLine(myName);
        Console.WriteLine(myAge);
        Console.WriteLine(isILoveUnity);
        
        Console.WriteLine($"My name is {myName} . My age is {myAge}. I love unity? {isILoveUnity}");
        
        Console.WriteLine(myName + " " + myAge  + " " + isILoveUnity);

        Console.WriteLine($"My name is {myName} \nMy age is {myAge} \nI love unity? {isILoveUnity} ");
    }
}