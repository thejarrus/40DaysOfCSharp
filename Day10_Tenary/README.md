# Day 10: Conditional (Ternary) Operator `?:`

Bu günün konusu:  
**C#’ta tek satırda koşullu ifadeler yazmayı sağlayan Ternary Operator (?:) kullanımı!**

## 🔥 Kısa Bilgi
Ternary operator, bir koşulun doğru veya yanlış olmasına göre iki farklı değeri hızlıca döndürmeni sağlar.  
Yani, if-else’in tek satırlık, pratik hali!

## 🧑‍💻 Örnek Kullanım
```csharp
int puan = 65;
string sonuc = (puan >= 50) ? "Geçti" : "Kaldı";
Console.WriteLine(sonuc); // Çıktı: Geçti
