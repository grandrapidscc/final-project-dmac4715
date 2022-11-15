using System;

public static class Helpers
{
    public static void PrintMenu()
    {
        Console.WriteLine("|^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|");
        Console.WriteLine("|\tThe Wizert --                      |");
        Console.WriteLine("|\tDungeon Escape Text Adventure      |");
        Console.WriteLine("|^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|");
        Console.WriteLine("|^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^|\n");
        Console.WriteLine("\t1 - New Game");
        Console.WriteLine("\t2 - How to Play");
        Console.WriteLine("\t3 - Exit");

    }
    public static void PrintInstructions()
    {
        Console.Clear();
        Console.WriteLine("Most Powerful Wizert:\n");
        Console.WriteLine("Trapped in a dungeon, can you find a way out?");
        Console.WriteLine("This you must do to earn your clout.");
        Console.WriteLine("Choose a direction 1 through 4,");
        Console.WriteLine("And find out what it has in store.");
        Console.WriteLine("Will it be your exit path?");
        Console.WriteLine("Or rather meet the goblins wrath.");
        Console.WriteLine("Fight your enemies or flee,");
        Console.WriteLine("And watch your health points carefully.");
        Console.WriteLine("");

        //FIX ME : Finish instruction verse

        Console.WriteLine("Are you ready?");
        Console.WriteLine("\t1 - Continue to menu");
        Console.WriteLine("\t3 - Exit");
    }
    public static void PrintDirMenu()
    {
        Console.WriteLine("Choose a direction:");
        Console.WriteLine("\t1 - North");
        Console.WriteLine("\t2 - East");
        Console.WriteLine("\t3 - South");
        Console.WriteLine("\t4 - West");
    }
    public static int GetValidInt()
    {
        bool goodValue = false;
        int userInt = 0;
        while (goodValue == false)
        {
            if (int.TryParse(Console.ReadLine(), out userInt))
            {
                goodValue = true;
            }
            else
            {
                Console.WriteLine("Enter a valid numerical choice");
            }
        } 
        return userInt;

    }
}
