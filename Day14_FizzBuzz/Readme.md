# Day 14: FizzBuzz Challenge

Bu klasörde C# dilinde klasik bir programlama mülakat sorusu olan **FizzBuzz** problemini çözme örneğini bulabilirsiniz.  
Kod, hem sabit limitli hem de kullanıcının belirlediği limite göre çalışabilecek şekilde tasarlanmıştır.

---

## 📌 Konular

- `for` döngüsü ile sayılar üzerinde iterasyon
- `if`, `else if`, `else` koşulları ile kontrol yapıları
- Mod alma (`%`) operatörünün kullanımı
- Birden fazla koşulun birlikte kontrol edilmesi (mantıksal operatörler)
- Kullanıcıdan veri alma (`Console.ReadLine()`) ve tip dönüşümü (`int.Parse()`)
- Kodun esnek hale getirilmesi (kullanıcı limit girişi)

---

## 💻 Örnek Kod

```csharp
Console.Write("Limiti girin: ");
int limit = int.Parse(Console.ReadLine());

for (int i = 1; i <= limit; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
        Console.WriteLine("FizzBuzz");
    else if (i % 3 == 0)
        Console.WriteLine("Fizz");
    else if (i % 5 == 0)
        Console.WriteLine("Buzz");
    else
        Console.WriteLine(i);
}
