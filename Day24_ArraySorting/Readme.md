# 🚀 40 Günde C# Öğreniyorum - Gün 24: Dizileri Sıralama (Array Sorting)

Merhaba! 👋 **40 Günde C#** serimizin 24. gününe hoş geldin. Bu seride sıfırdan başlayarak C# programlama dilini adım adım öğreniyoruz. 

Bugünün konusu: **Dizilerdeki verileri sıraya dizmek (Sorting) ve ters çevirmek (Reversing).**

---

## 🎯 Bugün Neler Öğrendik?

Veriler her zaman düzenli gelmez. Özellikle e-ticaret, veri analizi veya listeleme işlemlerinde verileri belirli bir kurala göre sıralamamız gerekir. Bugün `Array` sınıfının hazır güçlerini kullandık:

- **`Array.Sort()`**: Diziyi küçükten büyüğe (A-Z veya 0-9) sıralar.
- **`Array.Reverse()`**: Diziyi mevcut sırasının tam tersine çevirir (Sıraladıktan sonra kullanırsak Büyükten Küçüğe elde ederiz).
- **`Numeric Formatting (N2)`**: Fiyatları para birimi formatında (virgülden sonra 2 basamak) gösterme pratiği yaptık.

---

## 💻 Kod Örneği

Aşağıdaki kod, bir mağazadaki karışık fiyat listesini önce **Ucuzdan Pahalıya**, sonra **Pahalıdan Ucuza** sıralayan bir senaryoyu içerir.

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Karışık fiyat listesi (double türünde)
        double[] fiyatlar = { 120.50, 45.00, 1250.99, 19.90, 500.00 };

        Console.WriteLine("--- Rastgele Liste (Kaos) ---");
        foreach (var f in fiyatlar)
        {
            Console.Write($"{f} ");
        }

        // 2. Küçükten Büyüğe Sıralama (Ascending)
        Array.Sort(fiyatlar);

        Console.WriteLine("\n\n--- Ucuzdan Pahalıya (Sort) ---");
        for (int i = 0; i < fiyatlar.Length; i++)
        {
            // "N2" formatı: Binlik ayıracı ve virgülden sonra 2 basamak
            Console.WriteLine($"{i + 1}. Ürün: {fiyatlar[i].ToString("N2")} TL");
        }

        // 3. Büyükten Küçüğe Sıralama (Descending)
        // Not: Önce sıraladık, şimdi ters çeviriyoruz.
        Array.Reverse(fiyatlar);

        Console.WriteLine("\n--- Pahalıdan Ucuza (Reverse) ---");
        foreach (var f in fiyatlar)
        {
            Console.WriteLine($"- {f.ToString("N2")} TL");
        }

        Console.Read();
    }
}
```
## 📺 Konsol Çıktısı
Kodu çalıştırdığında göreceğin ekran çıktısı şöyledir:
```
--- Rastgele Liste (Kaos) ---
120.5 45 1250.99 19.9 500 

--- Ucuzdan Pahalıya (Sort) ---
1. Ürün: 19,90 TL
2. Ürün: 45,00 TL
3. Ürün: 120,50 TL
4. Ürün: 500,00 TL
5. Ürün: 1.250,99 TL

--- Pahalıdan Ucuza (Reverse) ---
- 1.250,99 TL
- 500,00 TL
- 120,50 TL
- 45,00 TL
- 19,90 TL
```
