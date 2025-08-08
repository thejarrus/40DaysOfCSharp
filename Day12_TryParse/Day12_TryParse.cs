using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Güvenli veri alma örneği
        Console.WriteLine("Lütfen bir sayı giriniz: ");
        string girilenDeger = Console.ReadLine();

        if (int.TryParse(girilenDeger, out int yas))
        {
            //Dönüşüm Başarılıysa
            Console.WriteLine($"Yaşınız: {yas}");
        }

        else
        {
            //Dönüşüm Başarısızsa
            Console.WriteLine("Hatalı giriş!");
        }
        
    }
}
 