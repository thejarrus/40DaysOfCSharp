# 📌 Day 17 – String Interpolation

## 🎯 Amaç  
C#’ta **String Interpolation** özelliğini öğrenmek.  
`String.Format` veya `+` operatörü yerine `$"..."` sözdizimini kullanarak değişkenleri doğrudan stringlerin içine yerleştirmeyi sağlar.  
Bu yöntem hem **daha okunabilir** hem de **daha kısa** bir yazım sunar.  

---

## 📖 String Interpolation Kullanımı  

```csharp
string ad = "Ali";
string soyad = "Yılmaz";

string mesaj = $"Adı: {ad}, Soyadı: {soyad}";
Console.WriteLine(mesaj);
