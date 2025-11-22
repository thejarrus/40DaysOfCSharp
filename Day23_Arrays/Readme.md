# 🎯 Gün 23 – Diziler (Arrays)

Bu derste C#’ta **dizi (array)** kavramını öğreniyoruz.  
Birden fazla veriyi tek bir değişkende nasıl saklayabileceğimizi,  
döngülerle dizi elemanlarını nasıl gezebileceğimizi ve koşullarla nasıl işlem yapabileceğimizi adım adım gösteriyoruz.

---

## 🧠 Konu Özeti

- **Array Tanımı:** Aynı türden birden fazla veriyi tek bir değişkende tutmamızı sağlar.  
- **Dizi Elemanlarına Erişim:** `isimler[0]`, `notlar[2]` gibi indeks numarasıyla erişim yapılır.  
- **Dizi Uzunluğu:** `isimler.Length` dizideki eleman sayısını verir.  
- **for Döngüsü ile Gezinme:** Dizi elemanları üzerinde işlem yapmak için kullanılır.  
- **Koşullar & Ternary Operatör:** Dizi içindeki değerlere göre durum belirlenebilir.

---

## 💻 Kod

```csharp
using System;

class Program
{
    static void Main()
    {
        string[] isimler = { "Yiğit", "Ahmet", "Zeynep", "Ali", "Ece" };
        int[] notlar = { 85, 92, 67, 74, 100 };

        Console.WriteLine("----- Not Listesi -----");

        for (int i = 0; i < isimler.Length; i++)
        {
            string durum = notlar[i] >= 70 ? "Geçti" : "Kaldı";
            Console.WriteLine($"{isimler[i]}: {notlar[i].ToString("D3")} - {durum}");
        }

        Console.WriteLine("\nEn yüksek notu bulalım:");

        int enYuksek = notlar[0];
        string enBasarili = isimler[0];

        for (int i = 1; i < notlar.Length; i++)
        {
            if (notlar[i] > enYuksek)
            {
                enYuksek = notlar[i];
                enBasarili = isimler[i];
            }
        }

        Console.WriteLine($"En yüksek not {enYuksek} - {enBasarili}");
    }
}
