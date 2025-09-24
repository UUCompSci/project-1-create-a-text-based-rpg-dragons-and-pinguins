﻿// Authors: Elena Hazard and Kate Steed.
// Purpose: A text based RPG where there are different scenes that you can move between to progress the story.
using static System.Console;
Random r = Random.Shared;

// Game varibles.
bool exit = false;

// input varibles.
const ConsoleKey A = ConsoleKey.A;
const ConsoleKey S = ConsoleKey.S;
const ConsoleKey D = ConsoleKey.D;
const ConsoleKey B = ConsoleKey.B;
const ConsoleKey C = ConsoleKey.C;
const ConsoleKey E = ConsoleKey.E;
const ConsoleKey F = ConsoleKey.F;
const ConsoleKey G = ConsoleKey.G;
const ConsoleKey H = ConsoleKey.H;
const ConsoleKey Esc = ConsoleKey.Escape;

// Location varibles.
const int TOWER = 0;
const int CITY = 1;
const int CAVE = 2;
const int COMBAT = 3;
const int MAGIC_CORE = 4;
const int MENTOR = 5;
const int ENDING1 = 6;
const int ENDING2 = 7;
int? currentLocation = TOWER;

// Starting Gear varibles and arrays.
string[] Inventory = new string[3];
string[] ArmorType = r.GetItems(choices: new[] { "Plate Armor", "Mail Armor", "Leather Armor" }, length: 3);
string[] CoinType = r.GetItems(choices: new[] { "Gold Pieces", "Silver Pieces", "Copper Pieces" }, length: 3);
int Coins = r.Next(minValue: 1, maxValue: 101);
bool IsArmorString = false;
bool IsCoinString = false;
bool IsInt = false;

// Combat varibles
int PlayerHP = r.Next(minValue: 30, maxValue: 51);
int MonsterHP = r.Next(minValue: 45, maxValue: 51);

// Gives starting inventory.
// Check if command line arguments are passed.
if (args.Length == 0)
{
    WriteLine("Generating random starting equipment.");
    Inventory = new string[] { ArmorType[0], CoinType[0], Coins.ToString() };
}
else
{
    WriteLine("Generating custon gear.");
    try
    {
        if (args[0] is string i)
        {
            Inventory[0] = i;
            IsArmorString = true;
        }

        if (args[1] is string ct)
        {
            Inventory[1] = ct;
            IsCoinString = true;
        }

        if (int.Parse(args[2]) is int c)
        {
            Inventory[2] = c.ToString();
            IsInt = true;
        }
    }
    catch (FormatException)
    {
        if (IsArmorString == false)
        {
            Inventory[0] = ArmorType[0];
        }

        if (IsCoinString == false)
        {
            Inventory[1] = CoinType[0];
        }

        if (IsInt == false)
        {
            Inventory[2] = Coins.ToString();
        }
    }

    catch (IndexOutOfRangeException)
    {
        if (IsCoinString == false & args.Length == 1)
        {
            Inventory[1] = CoinType[0];
            Inventory[2] = Coins.ToString();
        }

        if (IsInt == false & args.Length == 2)
        {
            Inventory[2] = Coins.ToString();
        }
    }
}
WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
WriteLine("You wake up to alarms going off and the ground shaking. You fall out of bed and look up to see your mentor, Auren Mageward, come into your room. 'The magic holds this city in the air is unstable and everyone is in danger!' He explains.");

while (!exit)
{
    // Keeps track of the current location and switchs it.
    switch (currentLocation)
    {
        case TOWER:
            TowerMap();
            SeeIfDead();
            break;

        case CITY:
            CityMap();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case CAVE:
            CaveMap();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case MAGIC_CORE:
            MagicCoreMap();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case MENTOR:
            MentorMap();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case COMBAT:
            CombatScene();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case ENDING1:
            DestroyShard();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        case ENDING2:
            ExtractShard();
<<<<<<< HEAD
            SeeIfDead();
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
            break;

        default:
            WriteLine("HP has hit 0. You have died.");
            exit = true;
            break;

    }
    // Opening scene.
    void TowerMap()
    {
        WriteLine($"What would you like to do? Press '{A}' to go investigate the tremors that you felt from below, '{S}' to speak to the other wizards in the tower to find out more information, '{B}' to open your inventory, or hit 'Esc'at any time to exit the game.");

        switch (GetKey())
        {
            case A:
                currentLocation = CAVE;
                break;

            case S:
                currentLocation = CITY;
                break;

            case B:
                WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
                break;

            case Esc:
                WriteLine("Exiting the game.");
                exit = true;
                break;

            default:
                ErrorMessage();
                break;
        }
    }

    void CaveMap()
    {
        WriteLine("You go deeper into the city's forest until you come across the cave with a faint glow sprouting from the entrance, but something seems off. Your mentor told you this cave holds the magical core that keeps the city afloat, but you sense corruption coming from the entrance.");
        WriteLine($"Press '{C}' to follow the path of corruption (enter the cave), '{D}' to look for clues from a safe distance (walk the perimeter), or '{B}' to open your inventory.");

        switch (GetKey())
        {
            case C:
<<<<<<< HEAD
                WriteLine("Suddenly, a monster jumps out from the shadows and attacks you. Press any key to prepare for combat.");
                ReadKey(true);
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
                currentLocation = COMBAT;
                break;

            case D:
<<<<<<< HEAD
                WriteLine("Suddenly, a monster jumps out from the shadows and attacks you. Press any key to prepare for combat.");
                ReadKey(true);
=======
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
                currentLocation = COMBAT;
                break;

            case B:
                WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
                break;

            case Esc:
                WriteLine("Exiting the game.");
                exit = true;
                break;

            default:
                ErrorMessage();
                break;
        }
    }

    void CityMap()
    {
        WriteLine("You speak to the wizards. They inform you that they had felt the tremors too, and speculate that the magical core keeping this city afloat has been corrupted.");
        WriteLine("They request that you check on the core. You briefly wonder if you should inform your mentor of the situation.");
        WriteLine($"Press '{E}' to go directly to the magical core to investigate, '{F}' to go back and warn your mentor and inform him of what is going on, or '{B}' to open your inventory.");

        switch (GetKey())
        {
            case E:
                currentLocation = MAGIC_CORE;
                break;

            case F:
                currentLocation = MENTOR;
                break;

            case B:
                WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
                break;

            case Esc:
                WriteLine("Exiting the game.");
                exit = true;
                break;

            default:
                ErrorMessage();
                break;
        }
    }

    void MagicCoreMap()
    {
        WriteLine("You decide to head straight to the magical core before the situation gets worse.");
        WriteLine("You finally reach the cave where the magical core lies and notice a corrupted shard wedged deep within the core.");
        WriteLine("Suddenly, a monster jumps out from the shadows and attacks you. Press any key to prepare for combat.");
        ReadKey(true);

<<<<<<< HEAD
        currentLocation = COMBAT;
=======
    currentLocation = COMBAT;
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
    }

    void MentorMap()
    {
        WriteLine("You rush back to warn your mentor of the situation. He insists on accompanying you to the magic core.");
        WriteLine("The two of you reach the core and notice a corrupted shard wedged deep within the core.");
<<<<<<< HEAD
        WriteLine("Suddenly, a monster jumps out from the shadows and attacks your mentor. You jump in to help defend him. Press any key to prepare for combat.");
=======
        WriteLine("You jump in to help defend him.");
        WriteLine("Suddenly, a monster jumps out from the shadows and attacks you. Press any key to prepare for combat.");
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
        ReadKey(true);

        currentLocation = COMBAT;
    }

<<<<<<< HEAD
    // The combat mechanic and you select an ending if you win.
    void CombatScene()
    {
        while (MonsterHP >= 0 & PlayerHP >= 0)
        {
            WriteLine($"What would you like to do? Press '{A}' to summon a blade made of magic to attack the monster with, '{S}' to cast a spell, '{H}' to check your HP, or '{B}' to open your inventory.");
            switch (GetKey())
            {
                case A:
                    int MagicBlade = r.Next(minValue: 3, maxValue: 6);
                    int MonsterDamage = r.Next(minValue: 2, maxValue: 5);
                    int ArmorDestroyed = r.Next(minValue: 1, maxValue: 5);
                    WriteLine($"The monster strikes you with its claws! You take {MonsterDamage} HP!");
                    PlayerHP -= MonsterDamage;
                    if (ArmorDestroyed == 1 & Inventory[0] != "")
                    {
                        WriteLine("The monsters claws tore your armor apart!");
                        Inventory[0] = "";
                    }
                    WriteLine("You summon a blade of pure magical energy and stike the monster");
                    WriteLine($"You deal {MagicBlade} damage to it!");
                    MonsterHP -= MagicBlade;
                    if (PlayerHP <= 0)
                    {
                        return;
                    }
                    break;

                case S:
                    string[] MagicSpell = r.GetItems(choices: new[] { "Fireball", "Frozen Spike", "Lightning Bolt" }, length: 3);
                    int MagicSpellDamage = r.Next(minValue: 3, maxValue: 6);
                    int MonsterSpellDamage = r.Next(minValue: 2, maxValue: 5);
                    ArmorDestroyed = r.Next(minValue: 1, maxValue: 5);
                    WriteLine($"The monster strikes you with an orb of darkness! You take {MonsterSpellDamage} HP!");
                    PlayerHP -= MonsterSpellDamage;
                    if (ArmorDestroyed == 1 & Inventory[0] != "")
                    {
                        WriteLine("The orb destroyed your armor!");
                        Inventory[0] = "";
                    }
                    WriteLine($"You cast {MagicSpell[0]}!");
                    WriteLine($"You deal {MagicSpellDamage} damage to it!");
                    MonsterHP -= MagicSpellDamage;
                    if (PlayerHP <= 0)
                    {
                        return;
                    }
                    break;

                case H:
                    WriteLine($"You have {PlayerHP} HP");
                    break;

                case B:
                    if (Inventory[0] == "")
                    {
                        WriteLine($"You have: {Inventory[2]} {Inventory[1]}");
                        break;
                    }
                    else
                    {
                        WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
                        break;
                    }

                case Esc:
                    WriteLine("Exiting the game.");
                    exit = true;
                    return;

                default:
                    ErrorMessage();
                    break;
            }
        }

        WriteLine($"Finally, the monster drops to the ground, dead. Now you think of how to deal with the corrupted shard.");
=======
    void CombatScene()
    {
        // combat code above write lines
        WriteLine("Finally, the monster drops dead. Now you think of how to deal with the corrupted shard.");
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
        WriteLine("Initially, you think of directly destorying the shard to quickly remove the corruption, but part of you wonders if it had been purposely planted. If you can manage to extract it in one piece the elders might be able to find out its orgin.");
        WriteLine($"Press '{G}' destroy the shard directly, '{H}' to try and extract the shard, or '{B}' to open your inventory.");
        switch (GetKey())
        {
            case G:
                currentLocation = ENDING1;
                break;

            case H:
                currentLocation = ENDING2;
                break;
<<<<<<< HEAD

            case B:
                if (Inventory[0] == "")
                {
                    WriteLine($"You have: {Inventory[2]} {Inventory[1]}");
                    break;
                }
                else
                {
                    WriteLine($"You have: {Inventory[0]} and {Inventory[2]} {Inventory[1]}");
                    break;
                }

            case Esc:
                WriteLine("Exiting the game.");
                exit = true;
                break;

            default:
                ErrorMessage();
                break;
        }
    }

=======
        }
    }
    
>>>>>>> 7e61b2224daba7be02a00a678622fcbc2d6149f1
    void DestroyShard()
    {
        WriteLine("You destroy the shard using the magic your mentor taught you. The core glows brighter and the city stabalizes.");
        WriteLine("You return to your room and share a quiet victory over a cozy tea time with your mentor.");
        exit = true;
    }

    void ExtractShard()
    {
        WriteLine("You successfully extract the shard and bring it up to the elder wizards.");
        WriteLine("They examine the shard and determine it was planted one of your fellow students.");
        WriteLine("You are congratulated by the citizens and seen as the hero who caught the criminal and saved whole city.");
        exit = true;
    }

}

// Functions.

// Gets the key that was inputed.
ConsoleKey GetKey()
{
    ConsoleKey getKey = ReadKey(true).Key;
    return getKey;
}

// Prints an error message if the key doesn't match one of the options.
void ErrorMessage()
{
    WriteLine("Input is invalid. Please use one of the listed keys.");
}

int? SeeIfDead()
{
    if (PlayerHP <= 0)
        currentLocation = null;
    return currentLocation;
}