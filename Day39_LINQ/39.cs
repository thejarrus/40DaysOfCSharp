using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> hasarlar = new List<int> { 30, 60, 45, 80, 20 };

        // Where - Filtreleme
        var gucluler = hasarlar.Where(h => h > 50).ToList();
        Console.WriteLine("50'den büyükler:");
        foreach (var h in gucluler)
            Console.WriteLine(h);  // 60, 80

        // OrderBy - Sıralama
        var sirali = hasarlar.OrderBy(h => h).ToList();
        Console.WriteLine("\nKüçükten büyüğe:");
        foreach (var h in sirali)
            Console.WriteLine(h);  // 20, 30, 45, 60, 80

        // Select - Dönüştürme
        var ikiKat = hasarlar.Select(h => h * 2).ToList();
        Console.WriteLine("\n2 katı:");
        foreach (var h in ikiKat)
            Console.WriteLine(h);  // 60, 120, 90, 160, 40

        // Zincirleme kullanım
        var sonuc = hasarlar
            .Where(h => h > 30)
            .OrderBy(h => h)
            .Select(h => h * 2)
            .ToList();
        Console.WriteLine("\nZincirleme (>30, sıralı, 2 katı):");
        foreach (var h in sonuc)
            Console.WriteLine(h);  // 90, 120, 160
    }
}
