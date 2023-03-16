using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int numNations, numWars, currentWar = 0;
        Random random = new Random();

        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("===================");
        System.Console.WriteLine("=== Bad AI Warz ===");
        System.Console.WriteLine("===================\n");

        numNations = GetNumberOfNations(random);
        numWars = GetNumberOfWars(random, numNations);
        WorldMap worldMap = new WorldMap(numNations);

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

            War war = new War(worldMap.Nations[attackerIndex], worldMap.Nations[defenderIndex], currentWar, numWars);
            war.Simulate();
        }

        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("\n=== Thanks for playing BadAIWarz, The Friends of BadAIWarz ===\n");
        System.Console.ResetColor();
        System.Console.Write("Press any key to exit BadAIWarz...");
        System.Console.ReadKey();
    }

    private static int GetNumberOfNations(Random r)
    {
        int numNationsEntry = 0;

        System.Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("How many nations would you like (0 for random): ");
        numNationsEntry = int.Parse(Console.ReadLine());

        if (numNationsEntry <= 0) { numNationsEntry = r.Next(1, 500); }

        return numNationsEntry;

    }
    private static int GetNumberOfWars(Random r, int n)
    {
        int numWarsEntry = 0;

        System.Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("How many wars would you like (0 for random): ");
        numWarsEntry = int.Parse(Console.ReadLine());

        if(numWarsEntry <= 0) { numWarsEntry = r.Next(1, n); }

        return numWarsEntry;
    }
}
