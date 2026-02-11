using System;

class Hesaplama
{
    public static int Topla(int a, int b)
    {
        return a + b;
    }

    public static int Carp(int a, int b)
    {
        return a * b;
    }
}

static class OyunAyarlari
{
    public static int MaxCan = 100;
    public static int MaxHasar = 50;
    public static string OyunAdi = "RPG Game";
}

class Program
{
    static void Main()
    {
        // Static metot kullanımı
        int toplam = Hesaplama.Topla(5, 3);
        int carpim = Hesaplama.Carp(4, 2);

        Console.WriteLine("Toplam: " + toplam);  // 8
        Console.WriteLine("Çarpım: " + carpim);  // 8

        // Static sınıf kullanımı
        Console.WriteLine("Oyun: " + OyunAyarlari.OyunAdi);
        Console.WriteLine("Max Can: " + OyunAyarlari.MaxCan);
    }
}
