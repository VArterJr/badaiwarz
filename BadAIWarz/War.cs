public class War
{
    public Nation Attacker { get; set; }
    public Nation Defender { get; set; }
    public int WarNum, TotalWars;

    public War(Nation attacker, Nation defender, int warnum, int totalwars)
    {
        Attacker = attacker;
        Defender = defender;
        WarNum = warnum;
        TotalWars = totalwars;
    }

    public void Simulate()
    {
        DisplayBattleHeader();
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
        // This is a horrible way to do this, but it's just an experiment and I wanted to start somewhere.

        int attackerPoints = 0, defenderPoints = 0;

        if (Attacker.MilitaryStrength > Defender.MilitaryStrength) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.TerritorySize > Defender.TerritorySize) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.EconomyWorth > Defender.EconomyWorth) { attackerPoints++; }
        else { defenderPoints++; }

        if (Attacker.SocialTemperature < 0.5 && attackerPoints > 0) { attackerPoints--; }
        if (Defender.SocialTemperature < 0.5 && defenderPoints > 0) { defenderPoints--; }

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

    private void DisplayBattleHeader()
    {
        Console.WriteLine("------------------------------------");
        Console.Write("Battle #" + WarNum + "/" + TotalWars + " ");
        DisplayNationName(Attacker, 'u');
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" ATTACKS ");
        Console.ResetColor();
        DisplayNationName(Defender, 'u');
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    private void DisplayPreBattleInfo()
    {
        Console.WriteLine("PRE-BATTLE INFO");
        DisplayNationsInfo();
    }

    private void DisplayPostBattleInfo()
    {
        Console.WriteLine("POST-BATTLE INFO");
        DisplayNationsInfo();
        Console.WriteLine("------------------------------------\n");
    }

    private void DisplayNationsInfo()
    {
        Console.WriteLine($"Attacker: " +
            $"MS:{Attacker.MilitaryStrength} " +
            $"TS:{Attacker.TerritorySize} " + 
            $"EW:{Attacker.EconomyWorth} " +
            $"ST:{Attacker.SocialTemperature}: " +
            $"PSA:{Attacker.PopulationSizeAdult}");
        Console.WriteLine($"Defender: " +
            $"MS:{Defender.MilitaryStrength} " +
            $"TS:{Defender.TerritorySize} " +
            $"EW:{Defender.EconomyWorth} " +
            $"ST:{Defender.SocialTemperature}: " +
            $"PSA:{Defender.PopulationSizeAdult}");
    }

    private void DisplayNationName(Nation n)
    {
        Console.ForegroundColor = n.ForeColor;
        Console.BackgroundColor = n.BackColor;
        Console.Write($"{n.Name}");
        Console.ResetColor();
    }

    private void DisplayNationName(Nation n, Char c)
    {
        Console.ForegroundColor = n.ForeColor;
        Console.BackgroundColor = n.BackColor;

        if(c == 'u') { Console.Write($"{n.Name}".ToUpper()); }
        else { Console.Write($"{n.Name}"); }

        Console.ResetColor();
    }

    private void DisplayAttackerWin()
    {
        Console.Write($"\nAttacker ");
        DisplayNationName(Attacker);
        Console.Write(" has won the battle against Defender ");
        DisplayNationName(Defender);
        Console.WriteLine("\n");
        Console.ResetColor();
    }

    private void DisplayDefenderWin()
    {
        Console.Write($"\nDefender ");
        DisplayNationName(Defender);
        Console.Write(" has won the battle against Attacker ");
        DisplayNationName(Attacker);
        Console.WriteLine("\n");
        Console.ResetColor();
    }
}
