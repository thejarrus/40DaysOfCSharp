using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true) // Kullanıcıyı programda tutar
        {
            Console.WriteLine("===Çarpım Tablosu Uygulaması===");
            Console.WriteLine("1- Tek bir sayının çarpım tablosu");
            Console.WriteLine("2- 1'den x'e kadar çarpım tablosu");
            Console.WriteLine("3- Çıkış Yap");
            Console.WriteLine("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                TekSayiTablosu();
            }

            else if (secim == "2")
            {
                TumTablolar();
            }

            else if (secim == "3")
            {
                Console.WriteLine("Programdan çıkılıyor...");
                break;
            }

            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            }

            Console.WriteLine(); // Boş satır bırakmak için
        }
    }

    static void TekSayiTablosu()
    {
        Console.WriteLine("Hangi sayının çarpım tablosu olsun? (1-100): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number) && number >= 1 && number <= 100)
        {                                       
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }
        }

        else {
            Console.WriteLine("Lütfen 1 ile 100 arasında bir sayı giriniz.");
        }
    }

    static void TumTablolar()
    {
        Console.WriteLine("x değeri kaç olsun? (1-100): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int maxNumber) && maxNumber >= 1 && maxNumber <= 100)
        {
            for (int number = 1; number <= maxNumber; number++)
            {
                Console.WriteLine($"\n--- {number} Çarpım Tablosu ---");
                for (int i = 1; i <= 20; i++)
                {
                    Console.WriteLine($"{number} x {i} = {number * i}");
                }
            }
        }
        else
        {
            Console.WriteLine("Lütfen 1 ile 100 arasında bir sayı giriniz.");
        }
    }
}