using System;

class Oyuncu 
{
    public int can;
    public int hasar;

    public Oyuncu(int _can, int _hasar) 
    {
        can = _can;
        hasar = _hasar;
    }

    public void Bilgi() 
    {
        Console.WriteLine("Can: " + can + ", Hasar: " + hasar);
    }
}

class Program 
{
    static void Main() 
    {
        Oyuncu savaşçı = new Oyuncu(150, 25);
        Oyuncu okçu = new Oyuncu(80, 40);

        savaşçı.Bilgi();
        okçu.Bilgi();
    }
}
