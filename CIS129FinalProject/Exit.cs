using System;

public class Exit
{
	private int[,] _position;
    private int exitDir;

    public Exit()
	{
        Random rnd = new Random();
        exitDir = rnd.Next(1, 5);
        int x = 0;
        int y = 0;
        switch (exitDir)
        {
            case 1: // north
                x = rnd.Next(1, 6);
                y = 5;
                break;
            case 2: // east
                x = 5;
                y = rnd.Next(1, 6);
                break;
            case 3: // south
                x = rnd.Next(1, 6);
                y = 1;
                break;
            case 4: // west
                x = 1;
                y = rnd.Next(1, 6);
                break;
            default: // need a break statement but i don't think this will ever be reached
                Console.WriteLine("Impossible error");
                break;
        }
        _position = new int[,] { { x, y} };


    }
    public int[,] GetPosition()
    {
        return _position;
    }
    public string GetPositionS()
    {
        return "(" + _position[0, 0] + ", " + _position[0, 1] + ")";
    }
    public int GetDirection()
    {
        return exitDir;
    }
}
