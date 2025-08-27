# 📌 Day 16 – String Formatting

## 🎯 Amaç  
C#’ta **String Formatting** konusunu öğrenmek.  
Bu özellik sayesinde stringlere değişkenleri yerleştirebilir, sayı ve tarihleri istediğimiz formatta gösterebiliriz.  

---

## 📖 String.Format Kullanımı  
`String.Format`, stringler içinde `{0}`, `{1}` gibi placeholder’lar kullanmamıza izin verir.  

```csharp
int yas = 21;
string ad = "Yiğit";

Console.WriteLine("Benim adım {0} ve {1} yaşındayım.", ad, yas);
