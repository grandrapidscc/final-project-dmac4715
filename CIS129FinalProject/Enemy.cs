using System;

public class Enemy
{
	private int[,] _position;
	private string _name;
	private string _attack;
	private int _health;
	private int _damage;

	public Enemy(string name, string attack, int health, int damage)
	{
		Random rnd = new Random();
		_name = name;
		_attack = attack;
        _position = new int[,] { { rnd.Next(1,6), rnd.Next(1,6) } };
		_health = health;
		_damage = damage;
    }

	public void Attack()
	{
		bool endAttack = false;
		//while(endAttack == false)
		//{
			Console.WriteLine($"{_name} used {_attack}");
			if (_health <= 0)
			{
                endAttack = true;
            }
			
		//}
	}
    public string GetPosition()
    {
        return "(" + _position[0, 0] + ", " + _position[0, 1] + ")";
    }
	public string GetName()
	{
		return _name; 
	}

}

