# 🚀 40 Günde C# Öğreniyorum - Gün 25: Dizide Arama ve Silme (Array IndexOf & Clear)

Merhaba! 👋 **40 Günde C#** serimizin 25. gününe hoş geldin. Bugün dizilerin (Arrays) içinde dedektiflik yapmayı ve belirli verileri temizlemeyi öğrendik.

---

## 🎯 Bugün Neler Öğrendik?

Dizilerle çalışırken "Bu veri dizide var mı, varsa kaçıncı sırada?" sorusunu sıkça sorarız. Ayrıca bazen belirli verileri sıfırlamamız gerekir. İşte bugünün kahramanları:

- **`Array.IndexOf()`**: Dizide belirli bir elemanı arar. Bulursa **index numarasını**, bulamazsa **-1** değerini döndürür.
- **`Array.Clear()`**: Dizinin belirli bir aralığındaki elemanları varsayılan değerlerine (string için `null`, int için `0`) döndürür.
- **⚠️ Kritik Detay**: `Array.Clear` dizinin boyutunu **küçültmez**, sadece içini boşaltır. (Koltukları silmez, oturan kişiyi kaldırır).

---

## 💻 Kod Örneği

Aşağıdaki kodda, bir davetli listesinde belirli bir kişiyi arıyor ve ardından listenin başındaki kişileri siliyoruz.

```csharp
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
