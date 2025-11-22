using System;

class Program
{
    static void Main()
    {
        // Karışık fiyat listesi (double türünde)
        double[] fiyatlar = { 120.50, 45.00, 1250.99, 19.90, 500.00 };

        Console.WriteLine("--- Rastgele Liste ---");
        foreach (var f in fiyatlar)
        {
            Console.Write($"{f} ");
        }

        // Küçükten Büyüğe Sıralama
        Array.Sort(fiyatlar);

        Console.WriteLine("\n\n--- Ucuzdan Pahalıya (Sort) ---");
        for (int i = 0; i < fiyatlar.Length; i++)
        {
            // "N2" formatı: Binlik ayıracı ve virgülden sonra 2 basamak
            Console.WriteLine($"{i + 1}. Ürün: {fiyatlar[i].ToString("N2")} TL");
        }

        // Büyükten Küçüğe Sıralama (Ters Çevirme)
        Array.Reverse(fiyatlar);

        Console.WriteLine("\n--- Pahalıdan Ucuza (Reverse) ---");
        foreach (var f in fiyatlar)
        {
            Console.WriteLine($"- {f.ToString("N2")} TL");
        }
    }
}
