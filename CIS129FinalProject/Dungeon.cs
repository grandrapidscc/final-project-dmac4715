using System;
using System.Collections;
using System.Diagnostics;
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
	private Stopwatch _time;

	public Dungeon()
	{
		
		hero = new Wizert();
		exit = new Exit();
        //instantiate Enemies and create enemies list
        Enemy goblin1 = new Enemy("goblin", "body slam", 3, 2, 1, 2);
        Enemy goblin2 = new Enemy("goblin", "body slam", 3, 2, 1, 4);
        Enemy goblin3 = new Enemy("goblin", "body slam", 3, 2, 2, 1);
        Enemy goblin4 = new Enemy("goblin", "body slam", 3, 2, 2, 5);
        Enemy goblin5 = new Enemy("goblin", "body slam", 3, 2, 4, 1);
        Enemy goblin6 = new Enemy("goblin", "body slam", 3, 2, 4, 5);
        Enemy goblin7 = new Enemy("goblin", "body slam", 3, 2, 5, 2);
        Enemy goblin8 = new Enemy("goblin", "body slam", 3, 2, 5, 4);
        Enemy orc1 = new Enemy("orc", "cleave", 5, 3, 2, 3);
        Enemy orc2 = new Enemy("orc", "cleave", 5, 3, 3, 2);
        Enemy orc3 = new Enemy("orc", "cleave", 5, 3, 3, 4);
        Enemy orc4 = new Enemy("orc", "cleave", 5, 3, 4, 3);
        Enemy banshee1 = new Enemy("banshee", "screech", 8, 5, 1, 1);
        Enemy banshee2 = new Enemy("banshee", "screech", 8, 5, 1, 5);
        Enemy banshee3 = new Enemy("banshee", "screech", 8, 5, 5, 1);
        Enemy banshee4 = new Enemy("banshee", "screech", 8, 5, 5, 5);
        EnemyList.Add(goblin1);
		EnemyList.Add(goblin2);
		EnemyList.Add(goblin3);
		EnemyList.Add(goblin4);
		EnemyList.Add(goblin5);
        EnemyList.Add(goblin3);
        EnemyList.Add(goblin4);
        EnemyList.Add(goblin5);
        EnemyList.Add(goblin6);
        EnemyList.Add(goblin7);
        EnemyList.Add(goblin8);
        EnemyList.Add(orc1);
		EnemyList.Add(orc2);
		EnemyList.Add(orc3);
		EnemyList.Add(orc4);
		EnemyList.Add(banshee1);
		EnemyList.Add(banshee2);
		EnemyList.Add(banshee3);
		EnemyList.Add(banshee4);

		//instantiate PowerUps and Create PowerUps List
		PowerUp h1 = new PowerUp(1, 1, 0);
        PowerUp h2 = new PowerUp(1, 5, 0);
        PowerUp h3 = new PowerUp(5, 1, 0);
		PowerUp h4 = new PowerUp(5, 5, 0);
		PowerUp m1 = new PowerUp(2, 2, 1);
        PowerUp m2 = new PowerUp(2, 4, 1);
        PowerUp m3 = new PowerUp(4, 2, 1);
        PowerUp m4 = new PowerUp(4, 4, 1);
        PowerUps.Add(h1);
        PowerUps.Add(h2);
        PowerUps.Add(h3);
		PowerUps.Add(h4);
        PowerUps.Add(m1);
        PowerUps.Add(m2);
        PowerUps.Add(m3);
        PowerUps.Add(m4);

        GameOver = false;
		isSuccess = false;
		
	}

	public void Start()
	{
        //Fix me: remove in final
        /*Console.WriteLine("Wizert : " + hero.GetPosition());
		Console.WriteLine("Exit: " + exit.GetPositionS() + " " + exit.GetDirection());
		foreach (Enemy enemy in EnemyList)
		{
			Console.WriteLine(enemy.GetName() + ": " + enemy.GetPosition());
		}*/
        //
        _time = new Stopwatch();
        _time.Start();
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
		_time.Stop();
        TimeSpan ts = _time.Elapsed;
        string elapsedTime = String.Format("{0:00}min:{1:00}sec", ts.Minutes, ts.Seconds);

        if (isSuccess == true)
		{
			
			Console.WriteLine("There's a crack in the wall...");
			Console.WriteLine("IT'S A DOORWAY!!!");
			Console.WriteLine("\t1 - Continue");
            userInt = Helpers.GetValidInt();
            Console.WriteLine("Congratulations -- you have escaped the dungeon!!\n");
			Console.WriteLine($"Elapsed Time: {elapsedTime}\n");

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
		bool empty = true;
		foreach(Enemy enemy in EnemyList)
		{
			if (enemy.GetPosition() == hero.GetPosition() && enemy.GetHealth() > 0)
			{
                Console.WriteLine($"{enemy.GetName()} is attacking: {enemy.GetName()} health: {enemy.GetHealth()}");
				Battle(enemy);
				empty = false;
			}
		}
		foreach(PowerUp PU in PowerUps)
		{
			if(PU.GetPosition() == hero.GetPosition() && PU.GetUnused())
			{
				Console.WriteLine("You found a PowerUp in this chamber!");
				hero.UsePU(PU.GetPUType());
				PU.Use();
				empty = false;
			}
		}
		if (empty == true)
		{
			Console.WriteLine("This chamber appears to be empty");
		}

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
                //maybe add chance to miss here??
				if (hero.UseMagicka(3))
				{
					Console.WriteLine($"Your magic fireball blast strikes the {enemy.GetName()}");
                    enemy.TakeDamage();
                }
                if (enemy.GetHealth() <= 0)
                {
                    endAttack = true;
					Console.WriteLine(enemy.GetName() + " has been defeated!!");
                }
            }
            else if (choice == 2)
            {

				if (hero.UseMagicka(5))
				{
                    hero.Heal();
                }
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
