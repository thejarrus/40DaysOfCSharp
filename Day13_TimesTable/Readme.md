# Day 13: Kullanıcıdan Veri Alma ve Tip Dönüşümü

Bu klasörde C# dilinde **kullanıcıdan konsol üzerinden veri alma** ve alınan veriyi farklı veri tiplerine dönüştürme örneklerini bulabilirsiniz.  
Örnekler, temel giriş/çıkış işlemlerinin nasıl yapılacağını ve `string` tipindeki verilerin `int`, `double` gibi sayısal tiplere nasıl dönüştürüleceğini gösterir.

---

## 📌 Konular

- `Console.ReadLine()` ile kullanıcıdan veri alma
- `int.Parse()` ve `double.Parse()` ile tip dönüşümü
- `Convert.ToInt32()` ve `Convert.ToDouble()` alternatifleri
- Kullanıcıdan birden fazla veri alma
- Basit aritmetik işlemler ile giriş verilerini kullanma
- Hatalı girişlerde programın çökmesini önlemek için `TryParse` kullanımı

---

## 💻 Örnek Kod

```csharp
Console.Write("Adınızı girin: ");
string ad = Console.ReadLine();

Console.Write("Yaşınızı girin: ");
int yas = int.Parse(Console.ReadLine());

Console.Write("Boyunuzu girin (metre cinsinden): ");
double boy = double.Parse(Console.ReadLine());

Console.WriteLine($"\nMerhaba {ad}, {yas} yaşındasın ve boyun {boy} metre.");
