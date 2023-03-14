using System;
using System.Collections.Generic;

public class WorldMap
{
    public List<Nation> Nations { get; set; }

    public WorldMap(int numberOfNations)
    {
        Nations = GenerateRandomNations(numberOfNations);
    }

    private List<Nation> GenerateRandomNations(int numberOfNations)
    {
        List<Nation> nations = new List<Nation>();
        Random random = new Random();

        for (int i = 0; i < numberOfNations; i++)
        {
            nations.Add(new Nation
            {
                Name = "Nation" + i,
                MilitaryStrength = random.Next(1, 101),
                TerritorySize = random.Next(1, 101)
            });
        }

        return nations;
    }
}
