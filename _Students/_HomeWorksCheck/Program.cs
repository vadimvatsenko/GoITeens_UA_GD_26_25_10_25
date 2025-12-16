using System;
using System.Diagnostics;
using System.Text;

class Program
{


    static void Main(string[] args)
    {
        string str1 = "sihT si na !elpmaxe";
        
        ReverseWords(str1);

        Console.ReadKey();
    }
    
    public static string ReverseWords(string str)
      {
        
        string[] strs = str.Split(' ');
        
        string[] revers = new string[strs.Length];
        
        for(int i = 0; i < strs.Length; i++)
        {
            string tempWord = strs[i];
            
            for (int j = tempWord.Length - 1; j >= 0; j--)
            {
                revers[i] += tempWord[j];
            }
        }
        
        string reversStr = string.Join(" ", revers);
        
        return reversStr;
      }
}










