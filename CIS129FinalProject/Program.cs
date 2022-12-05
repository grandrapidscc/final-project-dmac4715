/* 
 * Name: David McMahon
 * Class: CIS 129.2103
 * Description: Final Project - Wizert Text Adventure
 */

int selection;
do
{
    Helpers.PrintMenu();

    selection = Helpers.GetValidInt(3);
    if (selection == 1)
    {
        Dungeon game = new Dungeon();
        game.Start();
    }
    else if (selection == 2)
    {
        Helpers.PrintInstructions();
        selection = Helpers.GetValidInt(3);
    }
    Console.Clear();

} while (selection != 3);