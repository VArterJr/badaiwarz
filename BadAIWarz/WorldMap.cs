using System;
using System.Collections.Generic;
using System.Drawing;

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
                Name = "Nation " + i,
                ForeColor = GetRandomConsoleColor(),
                BackColor = GetRandomConsoleColor(),
                MilitaryStrength = random.Next(1, 101),
                TerritorySize = random.Next(1, 101)
            });
        }

        return nations;
    }

    private static ConsoleColor GetRandomConsoleColor()
    {
        Random random = new Random();
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
    }
}
