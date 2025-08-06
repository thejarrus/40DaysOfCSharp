# Day 11: Numeric Formatting & ToString

Bu klasörde C#'ta sayıların ekrana veya metne nasıl istenilen formatta yazdırılabileceğini gösteren örnekler ve notlar bulabilirsin.

## 📌 Konular
- `.ToString()` fonksiyonunun temelleri
- Sayı formatlama kodları ("N", "F", "C", "P", "E")
- Ondalık basamak belirleme
- Para birimi, yüzde, bilimsel gösterim
- Farklı kültürlerde (en-US, tr-TR) format farkları
- Terminalde sembol sorunları ve çözüm önerileri

## 💻 Örnek Kod
```csharp
double sayi = 1234.5678;

Console.WriteLine(sayi.ToString("N2")); // 1.234,57
Console.WriteLine(sayi.ToString("C", new System.Globalization.CultureInfo("tr-TR"))); // ₺1.234,57
Console.WriteLine(sayi.ToString("F1")); // 1234,6
Console.WriteLine(sayi.ToString("P1")); // 123.5 %
Console.WriteLine(sayi.ToString("E2")); // 1,23E+003
