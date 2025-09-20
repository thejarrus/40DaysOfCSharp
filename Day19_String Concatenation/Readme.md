# Day 19: String Concatenation (Birleştirme)

Bu gün C# dilinde **String Concatenation** (birleştirme) konusunu işledik.  
Metinleri `+` operatörü ile nasıl yan yana getirebileceğimizi öğrendik.  

---

## 📌 Konular
- String Concatenation (metin birleştirme)
- `+` operatörünün temel kullanımı
- Birden fazla stringin yan yana getirilmesi
- Küçük bir performans notu (`StringBuilder` ile farklar)

---

## 💻 Örnek Kodlar

### Basit Birleştirme
```csharp
string ad = "Ali";
string soyad = "Yılmaz";

string tamIsim = ad + " " + soyad;
Console.WriteLine(tamIsim);  // Ali Yılmaz
