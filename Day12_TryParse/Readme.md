# Day 12: TryParse Fonksiyonu

Bu klasörde, C#’ta kullanıcıdan veya dış kaynaklardan alınan metin verilerini **güvenli bir şekilde** sayısal, mantıksal veya tarih tiplerine dönüştürmek için kullanılan `TryParse` metodunun örneklerini bulabilirsin.

## 📌 Konular
- `Parse` ve `TryParse` arasındaki farklar
- `int.TryParse` kullanımı
- `double`, `bool` ve `DateTime` tiplerinde TryParse örnekleri
- Geçersiz veri geldiğinde hata almadan program akışına devam etme
- Kültür (CultureInfo) farklarında TryParse kullanımı

## 💻 Örnek Kod
```csharp
Console.Write("Bir sayı gir: ");
string girdi = Console.ReadLine();

if (int.TryParse(girdi, out int sayi))
    Console.WriteLine($"Tebrikler! Sayı: {sayi}");
else
    Console.WriteLine("Geçersiz giriş, lütfen bir sayı girin.");
