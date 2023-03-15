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
        DisplayPreBattleInfo();

        if (DoesAttackSucceed())
        {
            ProcessAttackerWin();
        }
        else
        {
            ProcessDefenderWin();
        }

        DisplayPostBattleInfo();
    }

    private bool DoesAttackSucceed()
    {
        // This is a horrible way to do this, but it's a social experiment and I wanted to start somewhere.

        int attackerPoints = 0, defenderPoints = 0;

        if (Attacker.MilitaryStrength > Defender.MilitaryStrength) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.TerritorySize > Defender.TerritorySize) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.EconomyWorth > Defender.EconomyWorth) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.SocialTemperature > Defender.SocialTemperature) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.PopulationSizeAdult > Defender.PopulationSizeAdult) { attackerPoints++; }
        else { defenderPoints++; }

        if (attackerPoints > defenderPoints) { return true; }
        else { return false; }
    }

    private void ProcessAttackerWin()
    {
        Attacker.MilitaryStrength += Defender.MilitaryStrength / 2;
        Defender.MilitaryStrength /= 2;
        Attacker.TerritorySize += Defender.TerritorySize / 2;
        Defender.TerritorySize /= 2;
        Attacker.EconomyWorth += Defender.EconomyWorth / 2;
        Defender.EconomyWorth /= 2;
        Attacker.SocialTemperature += Defender.SocialTemperature / 2;
        Defender.SocialTemperature /= 2;
        Attacker.PopulationSizeAdult += Defender.PopulationSizeAdult / 2;
        Defender.PopulationSizeAdult /= 2;

        DisplayAttackerWin();
    }

    private void ProcessDefenderWin()
    {
        Defender.MilitaryStrength += Attacker.MilitaryStrength / 2;
        Attacker.MilitaryStrength /= 2;
        Defender.TerritorySize += Attacker.TerritorySize / 2;
        Attacker.TerritorySize /= 2;
        Defender.EconomyWorth += Attacker.EconomyWorth / 2;
        Attacker.EconomyWorth /= 2;
        Defender.SocialTemperature += Attacker.SocialTemperature / 2;
        Attacker.SocialTemperature /= 2;
        Defender.PopulationSizeAdult += Attacker.PopulationSizeAdult / 2;
        Attacker.PopulationSizeAdult /= 2;

        DisplayDefenderWin();
    }

    private void DisplayPreBattleInfo()
    {
        Console.WriteLine("------------------------------------");
        Console.Write("Pre-battle info between Attacker ");
        DisplayNationName(Attacker);
        Console.Write(" and Defender ");
        DisplayNationName(Defender);
        Console.WriteLine();
        Console.WriteLine($"Attacker: MS:{Attacker.MilitaryStrength} EW: ST: PSA: ");
        Console.WriteLine($"Defender MS:{Defender.MilitaryStrength} TS: EW: ST: PSA: ");
    }

    private void DisplayPostBattleInfo()
    {
        Console.WriteLine("--- Post-battle info between X and Y ---");
        Console.WriteLine($"Attacker: MS:{Attacker.MilitaryStrength} EW: ST: PSA: ");
        Console.WriteLine($"Defender MS:{Defender.MilitaryStrength} TS: EW: ST: PSA: ");
        Console.WriteLine("------------------------------------\n");
    }

    private void DisplayNationName(Nation n)
    {
        Console.ForegroundColor = n.ForeColor;
        Console.BackgroundColor = n.BackColor;
        Console.Write($"{n.Name}");
        Console.ResetColor();
    }

    private void DisplayAttackerWin()
    {
        Console.Write($"Attacker ");
        DisplayNationName(Attacker);
        Console.Write(" has won the battle against Defender ");
        DisplayNationName(Defender);
        Console.WriteLine();
        Console.ResetColor();
    }

    private void DisplayDefenderWin()
    {
        Console.Write($"Defender ");
        DisplayNationName(Defender);
        Console.Write(" has won the battle against Attacker ");
        DisplayNationName(Attacker);
        Console.WriteLine();
        Console.ResetColor();
    }
}
