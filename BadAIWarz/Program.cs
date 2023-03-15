using System;

class Program
{
    static void Main(string[] args)
    {
        int numNations, numWars, currentWar = 0;
        Random random = new Random();

        numNations = random.Next(1, 500);
        numNations = 4; // For testing

        WorldMap worldMap = new WorldMap(numNations);

        numWars = numNations / 2;

        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("===================");
        System.Console.WriteLine("=== Bad AI Warz ===");
        System.Console.WriteLine("===================\n");

        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Simulating " + numWars + " wars between " + 
            numNations + " nations...\n");
        Console.ResetColor();

        for (int i = 0; i < numWars; i++)
        {
            int attackerIndex = random.Next(worldMap.Nations.Count);
            int defenderIndex = random.Next(worldMap.Nations.Count);

            currentWar++;

            while (attackerIndex == defenderIndex)
            {
                defenderIndex = random.Next(worldMap.Nations.Count);
            }

            War war = new War(worldMap.Nations[attackerIndex], worldMap.Nations[defenderIndex]);
            war.Simulate();
        }

        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("\n=== Thanks for playing BadAIWarz, The Friends of BadAIWarz ===\n");
        System.Console.ResetColor();
        System.Console.Write("Press any key to exit BadAIWarz...");
        System.Console.ReadKey();
    }
}
