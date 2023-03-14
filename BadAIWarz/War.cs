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

            Console.Write($"Attacker ");
            Console.ForegroundColor = Attacker.ForeColor;
            Console.BackgroundColor = Attacker.BackColor;
            Console.Write($"{Attacker.Name}");
            Console.ResetColor();
            Console.Write($" has won the battle against Defender ");
            Console.ForegroundColor = Defender.ForeColor;
            Console.BackgroundColor = Defender.BackColor;
            Console.WriteLine($"{Defender.Name}!");
            Console.ResetColor();
        }
        else
        {
            Defender.TerritorySize += Attacker.TerritorySize / 2;
            Attacker.TerritorySize /= 2;

            Console.Write($"Defender ");
            Console.ForegroundColor = Defender.ForeColor;
            Console.BackgroundColor = Defender.BackColor;
            Console.Write($"{Defender.Name}");
            Console.ResetColor();
            Console.Write($" has won the battle against Attacker ");
            Console.ForegroundColor = Attacker.ForeColor;
            Console.BackgroundColor = Attacker.BackColor;
            Console.WriteLine($"{Attacker.Name}!");
            Console.ResetColor();
        }
    }
}
