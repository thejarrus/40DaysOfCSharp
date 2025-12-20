using System;
using System.Collections.Generic; // ⚠️ Listeler için bu kütüphane şart!

class Program
{
    static void Main(string[] args)
    {
        // 1. Liste Oluşturma
        List<string> gorevler = new List<string>();

        // 2. Ekleme
        gorevler.Add("Videoyu Hazırla");
        gorevler.Add("Github'a Yükle");
        gorevler.Add("Spor Yap");

        // 3. Silme
        gorevler.Remove("Spor Yap"); // Sporu iptal ettik :)

        // 4. Listeleme
        Console.WriteLine("--- Kalan Görevler ---");
        foreach (var gorev in gorevler)
        {
            Console.WriteLine(gorev);
        }
        
        Console.WriteLine($"Toplam Görev: {gorevler.Count}");
        
        Console.Read();
    }
}
