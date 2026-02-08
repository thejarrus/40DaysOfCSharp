using System;

abstract class Karakter
{
    protected int can = 100;
    protected int hasar = 10;

    public abstract void Saldir();
}

interface IHareketEdebilir
{
    void Hareket();
}

class Savasci : Karakter, IHareketEdebilir
{
    public override void Saldir()
    {
        Console.WriteLine("Kılıçla " + hasar + " hasar vurdu!");
    }

    public void Hareket()
    {
        Console.WriteLine("Savaşçı koşuyor!");
    }
}

class Okcu : Karakter, IHareketEdebilir
{
    public override void Saldir()
    {
        Console.WriteLine("Okla " + hasar + " hasar vurdu!");
    }

    public void Hareket()
    {
        Console.WriteLine("Okçu yürüyor!");
    }
}

class Program
{
    static void Main()
    {
        Savasci savasci = new Savasci();
        Okcu okcu = new Okcu();

        savasci.Saldir();
        savasci.Hareket();

        okcu.Saldir();
        okcu.Hareket();
    }
}
