using System;

public class Enemy
{
	private int[,] _position;
	private string _name;
	private string _attack;
	private int _health;
	private int _damage;

	public Enemy(string name, string attack, int health, int damage, int posX, int posY)
	{ 
		_name = name;
		_attack = attack;
        _position = new int[,] { { posX, posY} };
		_health = health;
		_damage = damage;
    }
	public int GetDamage()
	{
		return _damage;
	}
	public int GetHealth()
	{
		return _health;	
	}
    public string GetPosition()
    {
        return "(" + _position[0, 0] + ", " + _position[0, 1] + ")";
    }
	public string GetName()
	{
		return _name; 
	}
	public void TakeDamage()
	{
		int damage = 5;
		if (_health < 5)
		{
			damage = _health;
		}
		_health -= damage;
		Console.WriteLine($"{this._name} took {damage} damage. {this._name} health remaining: {_health}");
	}

}

