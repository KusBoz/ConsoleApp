int monsterhp = 100;
int herohp = 100;

const int Game_Delay = 1000;
const int Crit_Multiplier = 2;

const int Hero_Damage_MIN = 1;
const int Hero_Damage_MAX = 20;
const int Hero_Defense_MIN = 5;
const int Hero_Defense_MAX = 10;
const int Hero_CritRoll_MIN = 1;
const int Hero_CritRoll_MAX = 4;
const int Hero_CritRoll_Jackpot = 4;

const int Monster_Damage_MIN = 1;
const int Monster_Damage_MAX = 20;
const int Monster_Defense_MIN = 5;
const int Monster_Defense_MAX = 10;

const int heroDef = dice.Next(Hero_Defense_MIN, Hero_Defense_MAX + 1);
const int monsterDef = dice.Next(Monster_Defense_MIN, Monster_Defense_MAX + 1);

Random dice = new();

while(monsterhp > 0 && herohp > 0)
{
    Thread.Sleep(Game_Delay);
    int heroCritRoll = dice.Next(Hero_CritRoll_MIN, Hero_CritRoll_MAX + 1);
    int herodmg = dice.Next(Hero_Damage_MIN, Hero_Damage_MAX + 1);
    if (heroCritRoll == Hero_CritRoll_Jackpot)
    {
        herodmg *= Crit_Multiplier;
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

    int monsterdmg = dice.Next(Monster_Damage_MIN, Monster_Damage_MAX + 1);
    int monsterTD = Math.Max(monsterdmg - heroDef, 0);
    herohp -= monsterTD;
    Console.WriteLine($"Monster hit {monsterdmg} but Hero resisted {heroDef}. \n Hero: {herohp}");

    if (herohp <= 0)
    {
        Console.WriteLine("hero ded");
    }
}

Console.WriteLine("oyun biti");
