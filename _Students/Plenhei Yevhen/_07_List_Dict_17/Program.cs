using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> translationDict = new Dictionary<string, string>()
        {
            { "hola", "hello" },
            { "adios", "goodbye" },
            { "gracias", "thank you" },
            { "como estas", "how are you" },
            { "ayuda", "help" }
        };

        Console.WriteLine("Ви зустріли NPC, який говорить іншою мовою.");
        Console.WriteLine("Він каже: 'hola'");
        
        Console.WriteLine("Введіть вашу відповідь англійською або переклад з NPC мови:");
        string playerInput = Console.ReadLine().ToLower();
        
        string npcMessage = "hola";
        string translatedMessage = Translate(npcMessage, translationDict);

        Console.WriteLine($"Переклад NPC: {translatedMessage}");
        
        if (playerInput == translatedMessage)
        {
            Console.WriteLine("NPC посміхається: Ви зрозуміли одне одного!");
        }
        else
        {
            Console.WriteLine("NPC нахмурився: Я не розумію вас.");
        }

        Console.ReadKey();
    }
    
    static string Translate(string message, Dictionary<string, string> dict)
    {
        if (dict.ContainsKey(message))
        {
            return dict[message];
        }
        return message;
    }
}