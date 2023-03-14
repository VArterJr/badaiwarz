using System;

public class War
{
    public Nation Attacker { get; set; }
    public Nation Defender { get; set; }

    public War(Nation attacker, Nation defender)
    {
        Attacker = attacker;
        Defender = defender;
    }

    public void Simulate()
    {
        double battleOutcome = new Random().NextDouble();
        if (battleOutcome < 0.5)
        {
            Attacker.TerritorySize += Defender.TerritorySize / 2;
            Defender.TerritorySize /= 2;
            Console.WriteLine($"{Attacker.Name} has won the battle against {Defender.Name}!");
        }
        else
        {
            Defender.TerritorySize += Attacker.TerritorySize / 2;
            Attacker.TerritorySize /= 2;
            Console.WriteLine($"{Defender.Name} has won the battle against {Attacker.Name}!");
        }
    }
}
