# 📅 33. Gün - Constructor (Yapıcı Metot)

## 📖 Konu

Constructor, bir nesne oluşturulurken otomatik olarak çalışan özel bir metottur. Sınıf ismiyle aynı isme sahiptir ve nesnenin başlangıç değerlerini ayarlamak için kullanılır.

---

## ❌ Constructorsız (Uzun Yol)

```csharp
Oyuncu oyuncu1 = new Oyuncu();
oyuncu1.can = 150;
oyuncu1.hasar = 25;

Oyuncu oyuncu2 = new Oyuncu();
oyuncu2.can = 80;
oyuncu2.hasar = 40;
```

## ✅ Constructorlı (Kısa Yol)

```csharp
Oyuncu savaşçı = new Oyuncu(150, 25);
Oyuncu okçu = new Oyuncu(80, 40);
```

---

## 💻 Kod

```csharp
using System;

class Oyuncu 
{
    public int can;
    public int hasar;

    // Constructor: Sınıf ismiyle aynı isimde
    public Oyuncu(int _can, int _hasar) 
    {
        can = _can;
        hasar = _hasar;
    }

    public void Bilgi() 
    {
        Console.WriteLine("Can: " + can + ", Hasar: " + hasar);
    }
}

class Program 
{
    static void Main() 
    {
        Oyuncu savaşçı = new Oyuncu(150, 25);
        Oyuncu okçu = new Oyuncu(80, 40);

        savaşçı.Bilgi();  // Can: 150, Hasar: 25
        okçu.Bilgi();     // Can: 80, Hasar: 40
    }
}
```

---

## 🧠 Özet

- Constructor sınıf ismiyle aynı isimdedir.
- Nesne oluşturulurken otomatik çalışır.
- Başlangıç değerlerini parametre olarak alır.
- `new Oyuncu(150, 25)` dediğinde constructor devreye girer.

---

## 📺 Video

[![YouTube](https://img.shields.io/badge/YouTube-İzle-red?style=for-the-badge&logo=youtube)](https://youtube.com/shorts/9j6Shp0T3zU?si=UgmHpa2lsBSqggvT)
