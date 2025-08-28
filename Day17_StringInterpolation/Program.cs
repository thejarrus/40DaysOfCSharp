using System;

class Program
{
    static void Main()
    {
        string ad = "Ali";
        string soyad = "Yılmaz";

        string mesaj = $"Adı: {ad}, Soyadı: {soyad}";
        Console.WriteLine(mesaj);

        int a = 5, b = 10;
        Console.WriteLine($"Toplam: {a + b}");

        double fiyat = 1234.5678;
        Console.WriteLine($"Fiyat: {fiyat:F2}");
        Console.WriteLine($"Para Birimi: {fiyat:C}");
    }
}




















