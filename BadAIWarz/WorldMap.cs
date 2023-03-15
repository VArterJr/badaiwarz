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
        ConsoleColor newForeColor, newBackColor;

        for (int i = 0; i < numberOfNations; i++)
        {
            newForeColor = GetRandomConsoleColor();
            newBackColor = GetRandomConsoleColor();
            if (newForeColor == newBackColor && (int)newBackColor != 0) { newBackColor--; }
            else if(newForeColor == newBackColor && (int)newBackColor != 15) { newBackColor++; }
            else if(newForeColor == newBackColor) { newBackColor = ConsoleColor.Black; }

            nations.Add(new Nation
            {
                Name = "Nation " + i,
                ForeColor = newForeColor,
                BackColor = newBackColor,
                MilitaryStrength = random.Next(1, 100001),
                TerritorySize = random.Next(1, 100000001),
                EconomyWorth = random.NextDouble() * 1000000.0,
                SocialTemperature = random.NextDouble(),
                PopulationSizeAdult = random.Next(2, 1000001)
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
