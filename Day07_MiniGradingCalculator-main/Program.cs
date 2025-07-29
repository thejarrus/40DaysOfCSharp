using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Notunu gir (0-100): ");
        string girilenDeger = Console.ReadLine() ?? "";

        bool dogruMu = int.TryParse(girilenDeger, out int not);

        if (!dogruMu)
        {
            Console.WriteLine("Geçersiz not girdiniz!");
        }

        else if (not < 0 || not > 100)
        {
            Console.WriteLine("Geçersiz not girdiniz!");
        }

        else if (not >= 90)
            Console.WriteLine("Harf notun A");

        else if (not >= 80)
            Console.WriteLine("Harf notun B");

        else if (not >= 70)
            Console.WriteLine("Harf notun C");

        else if (not >= 60)
            Console.WriteLine("Harf notun D");

        else
            Console.WriteLine("Harf notun F (Kaldiniz!)");
            
    }
}
