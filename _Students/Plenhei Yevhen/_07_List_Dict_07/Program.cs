using System;
using System.Collections.Generic;
using System.Numerics;

// &
class SpaceStations
{
    static List<BigInteger> CreateStationList(int orbitCount)
    {
        var stations = new List<BigInteger>();
        BigInteger value = 1;

        for (int i = 0; i < orbitCount; i++)
        {
            stations.Add(value);
            value *= 3;
        }

        return stations;
    }

    static void Main()
    {
        int orbitCount = 6;
        var stationList = CreateStationList(orbitCount);

        for (int i = 0; i < stationList.Count; i++)
        {
            Console.WriteLine($"Орбіта {i + 1}: {stationList[i]} станцій");
        }
        
        Console.ReadKey();
    }
}