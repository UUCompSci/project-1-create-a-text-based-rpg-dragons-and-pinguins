// Authors: Elena Hazard and Kate Steed.
// Purpose: A text based RPG where there are different scenes that you can move between to progress the story.
using static System.Console;
Random r = Random.Shared;

// Game varibles.
bool exit = false;
// Make input varibles.
const ConsoleKey W = ConsoleKey.W;
const ConsoleKey A = ConsoleKey.A;
const ConsoleKey S = ConsoleKey.S;
const ConsoleKey D = ConsoleKey.D;
const ConsoleKey B = ConsoleKey.B;
const ConsoleKey Esc = ConsoleKey.Escape;

// Location varibles.
const int TOWER = 0;
const int CITY = 1;
const int CAVE = 2;
const int COMBAT = 3;
int? currentLocation = TOWER;

// Starting Gear varibles.
string[] Inventory = new string[3];
string[] ArmorType = r.GetItems(choices: new[] { "Plate Armor", "Mail Armor", "Leather Armor" }, length: 3);
string[] CoinType = r.GetItems(choices: new[] { "Gold Pieces", "Silver Pieces", "Copper Pieces" }, length: 3);
int Coins = r.Next(minValue: 1, maxValue: 101);
bool IsArmorString = false;
bool IsCoinString = false;
bool IsInt = false;

// Combat varibles
int HP = r.Next(minValue: 20, maxValue: 51);


// Give starting inventory.
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
    switch (currentLocation)
    {
        case TOWER:
            TowerMap();
            break;

        case CITY:
            break;

        case CAVE:
            break;

        case COMBAT:
            break;

        default:
            WriteLine("HP has hit 0. You have died");
            exit = true;
            break;

    }
    // First scene.
    void TowerMap()
    {
        WriteLine($"What would you like to do? Press '{A}' to go investigate the tremors that you felt from below, '{S}' to speak to the other wizards in the tower to find out more information, '{B}' to open your inventory, or hit 'Esc' to exit the game.");

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