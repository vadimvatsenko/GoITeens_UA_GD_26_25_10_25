using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] colors = new[]
        {
            "Red",
            "Green",
            "Blue",
            "Yellow"
        };
        
        string color = string.Empty;
        string formatedColor = string.Empty;
        
        do
        {
            Console.WriteLine("Enter color: Red, Green, Blue or Yellow");
            color = Console.ReadLine()?.Trim();
            
            for (int i = 0; i < color.Length; i++)
            {

                // formatedColor += i == 0 ? char.ToUpper(color[i]) : char.ToLower(color[i]); 
                
                if (i == 0)
                {
                    formatedColor += char.ToUpper(color[i]);
                }
                else
                {
                    formatedColor += char.ToLower(color[i]);
                }
            }

            string logMessage 
                = colors.Contains(formatedColor) ? "Color already exists" : "Color not exists, try again";
            Console.WriteLine(logMessage);
            
            /*if (colors.Contains(formatedColor))
            {
                Console.WriteLine("Color already exists");
            }
            else
            {
                Console.WriteLine("Color not exists, try again");
            }*/
            
            /*if (colors.Contains(formatedColor))
                Console.WriteLine("Color already exists");
            else
                Console.WriteLine("Color not exists, try again");*/
            
            
        } while (!colors.Contains(formatedColor));
        
        
        switch (formatedColor)
        {
            case "Red":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Red-Its a Dragon");
                break;
            case "Blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Blue-Its a Fairy");
                break;
            case "Green":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Green-Its a Woodman");
                break;
            case "Yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Yellow-Its a King");
                break;
            default:
                Console.WriteLine("In our Land there`s no one with this kind of colour :(");
                break;
        }
        
        Console.ReadLine();

    }
}

