using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Dungeon
{
	public Wizert hero;
	public Exit exit;
	private ArrayList EnemyList = new ArrayList();
	private ArrayList PowerUps = new ArrayList();

	private bool GameOver;
	private bool isSuccess;

	public Dungeon()
	{
		hero = new Wizert();
		exit = new Exit();
        //instantiate Enemies and create enemies list
        Enemy goblin = new Enemy("goblin", "body slam", 3,2);
        Enemy orc = new Enemy("orc", "cleave",5,3);
        Enemy banshee = new Enemy("banshee", "screech",8,5);
        EnemyList.Add(goblin);
		EnemyList.Add(orc);
		EnemyList.Add(banshee);

		//instantiate PowerUps and Create PowerUps List

		GameOver = false;
		isSuccess = false;
		
	}

	public void Start()
	{
		//Fix me: remove in final
		Console.WriteLine("Wizert : " + hero.GetPosition());
		Console.WriteLine("Exit: " + exit.GetPositionS() + " " + exit.GetDirection());
		foreach (Enemy enemy in EnemyList)
		{
			Console.WriteLine(enemy.GetName() + ": " + enemy.GetPosition());
		}
		//
		Helpers.PrintDirMenu();
		int userInt = Helpers.GetValidInt();
		while (GameOver == false)
		{
			hero.Move(userInt);
			CheckInteractions();
			if (GameOver == false)
			{
				Helpers.PrintDirMenu();
				userInt = Helpers.GetValidInt();
				CheckForWin(userInt);
			}
		}
		if (isSuccess == true)
		{
			Console.WriteLine("There's a crack in the wall...");
			Console.WriteLine("IT'S A DOORWAY!!!");
			Console.WriteLine("\t1 - Continue");
            userInt = Helpers.GetValidInt();
            Console.WriteLine("Congratulations -- you have escaped the dungeon!!\n\n");

		}
		else
		{
			Console.WriteLine("You died - Game Over\n\n");
		}
		Console.WriteLine("\t1 - Continue");
		userInt = Helpers.GetValidInt();
		
	}
	public void CheckInteractions()
	{
		foreach(Enemy enemy in EnemyList)
		{
			if (enemy.GetPosition() == hero.GetPosition() && enemy.GetHealth() > 0)
			{
                Console.WriteLine($"{enemy.GetName()} is attacking");
				Battle(enemy);
			}
		}
		//Check for powerUPs
	}
	public void Battle(Enemy enemy)
	{
        bool endAttack = false;
        int choice;
        while (endAttack == false)
        {
            //enemy attacks
            hero.TakeDamage(enemy.GetDamage());
            if (hero.GetHealth() <= 0)
            {
                GameOver = true;
                endAttack = true;
				break;
            }
            //Wizert Attacks
            Helpers.PrintActionMenu();
            choice = Helpers.GetValidInt();
            if (choice == 1)
            {
                enemy.TakeDamage();
				hero.UseMagicka(3);
                if (enemy.GetHealth() <= 0)
                {
                    endAttack = true;
					Console.WriteLine(enemy.GetName() + " has been defeated!!");
                }
            }
            else if (choice == 2)
            {
				
				hero.UseMagicka(5);
                hero.Heal();
            }
            else if (choice == 3)
            {
				Random rnd = new Random();
				if (rnd.Next(0, 5) == 1)
				{
					endAttack = true;
					Console.WriteLine(enemy.GetName() + " seems distracted, now is your chance to escape");
				}
				else
				{
					Console.WriteLine("Can't get away!!");
				}
				
            }
            else
            {
                Console.WriteLine("Enter a valid numerical choice");
            }
            
        }
    }
	public void CheckForWin(int direction)
	{
		if (exit.GetPositionS() == hero.GetPosition() && direction == exit.GetDirection())
		{
			isSuccess = true;
			GameOver = true;
		}
		
	}

}
