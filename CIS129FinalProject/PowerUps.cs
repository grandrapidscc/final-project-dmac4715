using System;

public class PowerUp
{
	private int[,] _position;
	private int _type;
	private bool _unused;

	public PowerUp(int posX, int posY, int type)
	{
		_position = new int[,] { { posX, posY } };
		_type = type;
		_unused = true;
	}
    public string GetPosition()
    {
        return "(" + _position[0, 0] + ", " + _position[0, 1] + ")";
    }
	public int GetPUType()
	{
		return _type;
	}
	public bool GetUnused()
	{
		return _unused;
	}
	public void Use()
	{
		_unused = false;
	}
}

