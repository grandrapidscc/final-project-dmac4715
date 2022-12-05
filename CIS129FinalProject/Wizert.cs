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
        switch (direction)
        {
            case 1:
                if (_position[0, 1] == 5)
                {
                    Console.WriteLine("You have reached the Northern Wall, cannot go further");
                }
                else
                {
                    _position[0, 1]++;
                    //Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
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
                    //Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
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
                    //Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
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
                    //Console.WriteLine("Wizert: " + _position[0, 0] + ", " + _position[0, 1]);
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
    public int GetHealth()
    {
        return _health;
    }
    public void TakeDamage(int damage)
    {
        if (_health < damage)
        {
            damage = _health;

        }
        _health -= damage;
        Console.WriteLine($"Wizert took {damage} damage, current health: {_health}");


    }
    public bool UseMagicka(int amount)
    {
        if (_magicka > 0)
        {
            _magicka -= amount;
            Console.WriteLine("Magicka Remaining: " + _magicka);
            return true;
        }
        else
        {
            Console.WriteLine("Not enough Magicka power to use that spell.");
            return false;
        }
    }

    public void Heal()
    {
        _health += 3;
        Console.WriteLine("You have gained 3 health points, current health: " + _health);
    }

    public void UsePU(int type)
    {
        if (type == 0)
        {
            _health += 10;
            Console.WriteLine("PowerUp has raised your health 10 points, current health: " + _health);
        }

        else if (type == 1)
        {
            _magicka += 20;
            Console.WriteLine("PowerUp has raised your Magicka 20 points, current Magicka: " + _magicka);
        }
    }
}

        //Fireball
        //Heal
        //Flee