using System;

public static class Helpers
{
    public static void PrintMenu()
    {
        Console.WriteLine("The Wizert --");
        Console.WriteLine("\tDungeon Escape Text Adventure");
        Console.WriteLine("\n");
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
        Console.WriteLine("And watch your health points carefully.\n");
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
    public static void PrintActionMenu()
    {
        Console.WriteLine("Choose an Action:");
        Console.WriteLine("\t1 - Attack");
        Console.WriteLine("\t2 - Heal");
        Console.WriteLine("\t3 - Flee");
    }
    public static int GetValidInt(int max)
    {
        bool goodValue = false;
        int userInt = 0;
        while (goodValue == false)
        {
            if (int.TryParse(Console.ReadLine(), out userInt) && userInt <= max && userInt != 0)
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
