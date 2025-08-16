📌 Day 15 – Verbatim String Literal (@) ile Uzun Metinler
🎯 Amaç

C#’ta verbatim string literal özelliğini öğrenmek.
Bu özellik, dosya yolları ve uzun metinler ile çalışırken kaçış karakterlerini (\n, \\ vb.) kullanma zorunluluğunu ortadan kaldırır. Ayrıca çok satırlı stringler yazmayı da kolaylaştırır.

📖 Konsept

Normal bir string içinde \ gibi karakterleri yazmak için \\ şeklinde kullanmak gerekir.
Örneğin:

string yol = "C:\\Users\\Bro";


Ama @ işaretini kullanırsak, bu karakterler olduğu gibi kabul edilir:

string yol = @"C:\Users\Bro";


Ayrıca çok satırlı metinleri de direkt olarak yazabiliriz:

string metin = @"Merhaba!
Bu birden fazla satırlı
verbatim string örneği.";


Çıktı:

Merhaba!
Bu birden fazla satırlı
verbatim string örneği.

🛠️ Kod Örneği
using System;

class Program
{
    static void Main()
    {
        // Normal string (kaçış karakteri gerekiyor)
        string yol1 = "C:\\Users\\Bro\\Desktop";

        // Verbatim string (kaçış gerekmez)
        string yol2 = @"C:\Users\Bro\Desktop";

        Console.WriteLine("Normal string: " + yol1);
        Console.WriteLine("Verbatim string: " + yol2);

        // Çok satırlı metin
        string metin = @"Merhaba!
Bu C# verbatim string örneğidir.
Uzun metinleri daha okunabilir yapar.";

        Console.WriteLine(metin);
    }
}

💡 Çıktı
Normal string: C:\Users\Bro\Desktop
Verbatim string: C:\Users\Bro\Desktop
Merhaba!
Bu C# verbatim string örneğidir.
Uzun metinleri daha okunabilir yapar.

✅ Kazanımlar

@ ile stringlerde kaçış karakteri kullanımına gerek kalmadığını öğrendim.

Çok satırlı metinlerin daha okunabilir yazılabileceğini gördüm.

Dosya yolları ile çalışırken verbatim string literal özelliğinin pratikliği fark edildi.
