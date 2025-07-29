# MiniGradingCalculator

# Not Hesaplama Uygulaması

Bu, kullanıcıdan 0-100 arası bir not alıp harf notu olarak (A, B, C, D, F) çıktısını veren basit bir C# konsol uygulamasıdır.

## Özellikler
- Kullanıcıdan sayı alır.
- Geçersiz girişleri kontrol eder.
- Not aralığına göre harf notunu ekrana yazdırır.

## Kullanım
1. Projeyi derle ve çalıştır.
2. Konsola bir not (0-100) gir.
3. Sonucu ekranda gör.

[YOUTUBE SHORTS - Not Hesaplama Uygulaması](https://youtube.com/shorts/5HHEEBlS-qw?si=Nopz2ZDZxLOmGvW9)

## Koddan Kısa Bir Parça
```csharp
Console.WriteLine("Notunu gir (0-100): ");
string girilenDeger = Console.ReadLine() ?? "";

bool dogruMu = int.TryParse(girilenDeger, out int not);

if (!dogruMu)
{
    Console.WriteLine("Geçersiz not girdiniz!");
}
else if (not < 0 || not > 100)
{
    Console.WriteLine("Geçersiz not girdiniz!");
}
else if (not >= 90)
    Console.WriteLine("Harf notun A");
else if (not >= 80)
    Console.WriteLine("Harf notun B");
else if (not >= 70)
    Console.WriteLine("Harf notun C");
else if (not >= 60)
    Console.WriteLine("Harf notun D");
else
    Console.WriteLine("Harf notun F (Kaldiniz!)");
