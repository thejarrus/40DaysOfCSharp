using System;

class Program
{
    static void Main()
    {
        int yas = 21;
        string ad = "Yiğit";
        Console.WriteLine("Benim adım {0} ve {1} yaşındayım.", ad, yas);

        double fiyat = 1234.5678;

        Console.WriteLine("{0:F2}", fiyat); // 1234.57
        Console.WriteLine("{0:N}", fiyat);  // 1,234.57
        Console.WriteLine("{0:C}", fiyat);  // ₺1.234,57
        Console.WriteLine("{0:P}", 0.85);   // %85,00

        DateTime simdi = DateTime.Now;

        Console.WriteLine("{0:dd.MM.yyyy}", simdi); // 27.08.2025
        Console.WriteLine("{0:dddd}", simdi);       // Çarşamba
        Console.WriteLine("{0:HH:mm}", simdi);      // 14:35

    }
}




















