using System;

class Oyuncu
{
    private int can;
    private int hasar;

    public int Can
    {
        get { return can; }
        set
        {
            if (value < 0) can = 0;
            else can = value;
        }
    }

    public int Hasar
    {
        get { return hasar; }
        set
        {
            if (value < 0) hasar = 0;
            else hasar = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Oyuncu oyuncu = new Oyuncu();

        oyuncu.Can = 100;
        Console.WriteLine("Can: " + oyuncu.Can);  // 100

        oyuncu.Can = -50;
        Console.WriteLine("Can: " + oyuncu.Can);  // 0

        oyuncu.Hasar = 25;
        Console.WriteLine("Hasar: " + oyuncu.Hasar);  // 25
    }
}
