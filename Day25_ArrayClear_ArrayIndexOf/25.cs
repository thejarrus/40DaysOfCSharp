
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Örnek Veri Seti: Davetli Listesi
        string[] davetliler = { "Hakan", "Selin", "Burak", "Elif", "Cem" };

        Console.WriteLine("--- 1. Arama İşlemi (IndexOf) ---");
        
        // "Burak" ismini arıyoruz.
        // IndexOf: Bize sıra numarasını (index) verir. Yoksa -1 verir.
        int siraNo = Array.IndexOf(davetliler, "Burak");

        if (siraNo != -1)
        {
            Console.WriteLine($"✅ Bulundu! Burak listenin {siraNo}. sırasında.");
        }
        else
        {
            Console.WriteLine("❌ Kişi listede bulunamadı.");
        }

        Console.WriteLine("\n--- 2. Temizlik İşlemi (Clear) ---");
        
        // İlk 2 davetliyi listeden çıkaralım (Sıfırlayalım).
        // Parametreler: (Dizi, Başlangıç Indexi, Silinecek Adet)
        Array.Clear(davetliler, 0, 2);

        Console.WriteLine("Temizlik sonrası liste durumu:");
        
        // Listeyi yazdıralım
        foreach (string kisi in davetliler)
        {
            // Silinen elemanlar string olduğu için 'null' olur.
            // Görsel olarak 'Boş' yazdıralım.
            if (string.IsNullOrEmpty(kisi))
            {
                Console.WriteLine("- [BOŞ KOLTUK]"); 
            }
            else
            {
                Console.WriteLine($"- {kisi}");
            }
        }
        
        // Bir sonraki günün (Listeler) konusu için ipucu:
        Console.WriteLine("\n(Not: Array.Clear diziyi küçültmez, sadece içini boşaltır!)");

        Console.Read();
    }
}
