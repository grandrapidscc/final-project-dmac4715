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
			Helpers.PrintDirMenu();
			userInt = Helpers.GetValidInt();
			CheckForWin(userInt);
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
			if (enemy.GetPosition() == hero.GetPosition())
			{
				Console.WriteLine($"{enemy.GetName()} is attacking");
				enemy.Attack();
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
