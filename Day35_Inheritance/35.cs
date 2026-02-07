using System;

class Karakter
{
    public int can = 100;
    public int hasar = 10;

    public void Bilgi()
    {
        Console.WriteLine("Can: " + can + ", Hasar: " + hasar);
    }
}

class Savasci : Karakter
{
    public int zirh = 50;
}

class Okcu : Karakter
{
    public int menzil = 100;
}

class Buyucu : Karakter
{
    public int mana = 200;
}

class Program
{
    static void Main()
    {
        Savasci savaşçı = new Savasci();
        savaşçı.Bilgi();  // Can: 100, Hasar: 10
        Console.WriteLine("Zırh: " + savaşçı.zirh);  // 50

        Okcu okçu = new Okcu();
        okçu.Bilgi();  // Can: 100, Hasar: 10
        Console.WriteLine("Menzil: " + okçu.menzil);  // 100

        Buyucu büyücü = new Buyucu();
        büyücü.Bilgi();  // Can: 100, Hasar: 10
        Console.WriteLine("Mana: " + büyücü.mana);  // 200
    }
}
