using System;
using System.Runtime.CompilerServices;

public class Wizert
{
	private int[,] _position;
	private int _health;
	private int _magicka;
	
	public Wizert()
	{
		Random rnd = new Random();
		_position = new int[,] { { rnd.Next(1,6), rnd.Next(1,6) } };
		_health = 100;
		_magicka = 200;
	}

	public void Move(int direction)
	{
		//North - 1
		//East - 2
		//South - 3
		//West - 4
		switch(direction)
		{
			case 1:
				if (_position[0, 1] == 5)
				{
					Console.WriteLine("You have reached the Northern Wall, cannot go further");
				}
				else
				{
                    _position[0, 1]++;
					Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0,1]);
				}
				break;
            case 2:
                if (_position[0, 0] == 5)
                {
                    Console.WriteLine("You have reached the Eastern Wall, cannot go further");
                }
                else
                {
                    _position[0, 0]++;
                   Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
                }
                break;
            case 3:
                if (_position[0, 1] == 1)
                {
                    Console.WriteLine("You have reached the Southern Wall, cannot go further");
                }
                else
                {
                    _position[0, 1]--;
                    Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
                }
                break;
            case 4:
                if (_position[0, 0] == 1)
                {
                    Console.WriteLine("You have reached the Western Wall, cannot go further");
                }
                else
                {
                    _position[0, 0]--;
                    Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
                }
                break;
            default:
                Console.WriteLine("Enter a valid direction");
                break;
        }
    }
	public string GetPosition()
	{
		return "(" + _position[0, 0] + ", " + _position[0, 1] + ")";
	}
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
		
    //Fireball
    //Heal
    //Flee

}
