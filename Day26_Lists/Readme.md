# 🚀 40 Günde C# Öğreniyorum - Gün 26: Listeler (List<T>)

Merhaba! 👋 **40 Günde C#** serimizin 26. gününe geldik. Bugün dizilerin (Arrays) statik yapısından kurtulup, dinamik ve esnek olan **Generic List** yapısına geçiş yaptık.

---

## 🎯 Bugün Neler Öğrendik?

Dizilerin aksine, **Listeler** oluşturulurken boyut belirtmeyi gerektirmez. Çalışma zamanında (runtime) eleman ekleyip çıkartabiliriz.

- **`List<T>`**: T yerine hangi türü (string, int, double) saklayacağımızı yazarız.
- **`.Add(değer)`**: Listenin sonuna yeni eleman ekler.
- **`.Remove(değer)`**: Listeden belirtilen elemanı siler ve boşluğu kapatır.
- **`.Count`**: Dizilerdeki `.Length` yerine, listelerde eleman sayısını `.Count` ile öğreniriz.

---

## 💻 Kod Örneği

Aşağıdaki örnekte basit bir "Yapılacaklar Listesi" (To-Do List) oluşturduk.

```csharp
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
