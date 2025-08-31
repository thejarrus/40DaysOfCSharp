# 📌 Day 18 – Empty String & String.Equals

## 🎯 Amaç  
C#’ta **Empty String** (boş string) ve **String.Equals** metodunu öğrenmek.  
Bu konular string işlemlerinde hem doğru kontrol yapmamızı hem de güvenli karşılaştırmalar yapmamızı sağlar.  

---

## 📖 Empty String (`""` & `String.Empty`)  

```csharp
string bos1 = "";
string bos2 = String.Empty;

Console.WriteLine(bos1 == bos2); // True
