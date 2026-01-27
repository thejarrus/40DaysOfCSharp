using System;
using System.Collections.Generic; // 1. Kütüphaneyi Unutma!

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "RPG Envanter Sistemi"; // (Opsiyonel Havalı Başlık)

        // ADIM 1: SÖZLÜĞÜ TANIMLA
        // <Anahtar: Eşya Adı, Değer: Adet>
        Dictionary<string, int> canta = new Dictionary<string, int>();

        // ADIM 2: VERİ EKLE (.Add)
        canta.Add("Can İksiri", 5);
        canta.Add("Altın", 100);
        canta.Add("Paslı Kılıç", 1);

        Console.WriteLine("--- OYUN BAŞLADI ---\n");

        // ADIM 3: GÜVENLİ ERİŞİM VE KULLANIM
        // "Can İksiri" anahtarı var mı? (Yoksa hata verir!)
        if (canta.ContainsKey("Can İksiri"))
        {
            // Değeri Okuma
            int adet = canta["Can İksiri"]; 
            Console.WriteLine($"🧪 Çantada {adet} iksir var.");

            // Değeri Değiştirme (İçme)
            canta["Can İksiri"] = canta["Can İksiri"] - 1;
            Console.WriteLine("🔻 Gluk gluk... İksir içildi.");
            
            // Güncel Durum
            Console.WriteLine($"🧪 Kalan İksir: {canta["Can İksiri"]}");
        }
        else
        {
            Console.WriteLine("❌ Çantada bu eşya yok!");
        }

        Console.Read();
    }
}
