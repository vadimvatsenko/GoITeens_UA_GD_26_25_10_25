using System;
using System.Collections.Generic;


class CivilizationDevelopment
{
    static List<int> Develop(int startValue, int count)
    {
        List<int> civilization = new List<int>();
        civilization.Add(startValue);

        for (int i = 1; i < count; i++)
        {
            int sum = 0;
            foreach (int value in civilization)
            {
                sum += value;
            }
            civilization.Add(sum);
        }

        return civilization;
    }

    static void Main()
    {
        int startValue = 1;
        int count = 5;

        List<int> result = Develop(startValue, count);

        Console.WriteLine(string.Join(", ", result));
        
        Console.ReadKey();
    }
}