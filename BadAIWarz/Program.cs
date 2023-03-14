using System;

class Program
{
    static void Main(string[] args)
    {
        WorldMap worldMap = new WorldMap(5); // 5 randomly generated nations
        Random random = new Random();

        for (int i = 0; i < 10; i++) // Simulate 10 wars
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
    }
}
