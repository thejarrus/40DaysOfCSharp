using System;

class Karakter
{
    protected int can = 100;
    protected int hasar = 10;

    public virtual void Saldir()
    {
        Console.WriteLine("Saldırı!");
    }
}

class Savasci : Karakter
{
    public override void Saldir()
    {
        Console.WriteLine("Kılıçla " + hasar + " hasar vurdu!");
    }
}

class Okcu : Karakter
{
    public override void Saldir()
    {
        Console.WriteLine("Okla " + hasar + " hasar vurdu!");
    }
}

class Buyucu : Karakter
{
    public override void Saldir()
    {
        Console.WriteLine("Büyüyle " + hasar + " hasar vurdu!");
    }
}

class Program
{
    static void Main()
    {
        Karakter k1 = new Savasci();
        Karakter k2 = new Okcu();
        Karakter k3 = new Buyucu();

        k1.Saldir();  // Kılıçla 10 hasar vurdu!
        k2.Saldir();  // Okla 10 hasar vurdu!
        k3.Saldir();  // Büyüyle 10 hasar vurdu!
    }
}
