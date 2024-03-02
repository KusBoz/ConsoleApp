int monsterhp = 100;
int herohp = 100;

Random dice = new();

int monsterDef = dice.Next(5,10);
int heroDef = dice.Next(5,10);

while(monsterhp > 0 && herohp > 0)
{
    Thread.Sleep(1000);
    int heroCritRoll = dice.Next(1,5);
    int herodmg = dice.Next(1,21);
    if (heroCritRoll == 4)
    {
        herodmg *= 2;
        Console.WriteLine($"OMG hero hit critical!! {herodmg}");
    }
    int heroTD = Math.Max(herodmg - monsterDef, 0);
    monsterhp -= heroTD;
    Console.WriteLine($"Hero hit {herodmg} but monster resisted {monsterDef}. \n Monster: {monsterhp}");

    if (monsterhp <= 0) 
    {
        Console.WriteLine("monster has been slain");
        break;
    }

    int monsterdmg = dice.Next(1,21);
    int monsterTD = Math.Max(monsterdmg - heroDef, 0);
    herohp -= monsterTD;
    Console.WriteLine($"Monster hit {monsterdmg} but Hero resisted {heroDef}. \n Hero: {herohp}");

    if (herohp <= 0)
    {
        Console.WriteLine("hero ded");
    }
}

Console.WriteLine("oyun biti");