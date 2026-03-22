using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Кухар поставив варитися суп");
        
        Task coockSoup = CookSoup();
        Task cookSalad = MakeSalad();
        Task makePotato = MakePotato();
        
        await Task.WhenAll(coockSoup, cookSalad,  makePotato); // 
        
        Console.WriteLine("Обід готовий");
        Console.ReadKey();
    }

    public static async Task CookSoup()
    {
        await Task.Delay(3000);
        Console.WriteLine("Cуп приготувався");
    }
    
    public static async Task MakeSalad()
    {
        await Task.Delay(1000);
        Console.WriteLine("Салат приготувався");
    }
    
    public static async Task MakePotato()
    {
        await Task.Delay(500);
        Console.WriteLine("Картопля приготувався");
    }
}