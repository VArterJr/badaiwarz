using System;

class Program
{
    static void Main(string[] args)
    {
        int numNations, numWars;
        Random random = new Random();

        numNations = random.Next(100);
        WorldMap worldMap = new WorldMap(numNations);

        numWars = numNations / 2;

        System.Console.WriteLine("=== Bad AI Warz ===\n");
        System.Console.ForegroundColor = ConsoleColor.Red;
        Console.ResetColor();

        System.Console.WriteLine("Simulating " + numWars + " wars between " + numNations + " nations.\n");
        for (int i = 0; i < numWars; i++)
        {
            int attackerIndex = random.Next(worldMap.Nations.Count);
            int defenderIndex = random.Next(worldMap.Nations.Count);

            while (attackerIndex == defenderIndex)
            {
                defenderIndex = random.Next(worldMap.Nations.Count);
            }

            War war = new War(worldMap.Nations[attackerIndex], worldMap.Nations[defenderIndex]);
            war.Simulate();
        }

        System.Console.WriteLine("\n=== Thanks for playing, Vince Arter, Jr. ===");
    }
}
