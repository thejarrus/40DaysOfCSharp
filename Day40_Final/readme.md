# ⚔️ Gölge Diyarının Kahramanları

### 40 Günde C# Öğreniyorum — Gün 40: Final Proje

Terminal tabanlı bir RPG zindan macerası. 39 günde öğrenilen tüm C# kavramlarını tek bir projede birleştiren final proje.

```
  ╔═══════════════════════════════════════════════════════╗
  ║         D İ Y A R I N I N   K A H R A M A N I         ║
  ╚═══════════════════════════════════════════════════════╝
```

---

## 🎮 Oyun Hakkında

Gölge Diyarının Kahramanları, tamamen terminal üzerinde çalışan bir RPG macera oyunudur. Tavernacı Tahir seni karşılar, sana bir görev verir ve beş odalı bir zindanda Gölge Lordu'nu yenmeye çalışırsın.

Her seçimin sonucu değiştirir. Karakter sınıfın, diyalog cevapların, savaş stratejin ve hazine odalarındaki risklerin oyunun gidişatını belirler.

---

## ✨ Özellikler

**Hikaye & Diyalog**
- Tavernacı Tahir ile etkileşimli diyalog sistemi
- Seçim bazlı dallanma: Cesur, Bilgi İsteyen veya İsteksiz cevaplar
- Her seçimin oyun mekaniğine doğrudan etkisi (oda atlama, bonus iksir vb.)

**Karakter Sistemi**
- 3 oynanabilir sınıf: Savaşçı (yüksek HP/zırh), Okçu (yüksek kritik şansı), Büyücü (yüksek hasar)
- Her sınıfın kendine özgü normal saldırısı, özel gücü ve kritik vuruş oranı
- Özelleştirilebilir karakter ismi

**Savaş Mekanikleri**
- Saldır / Savun / Özel Güç üçlü savaş sistemi
- Savunma: Hasarı %75 azaltır + bir sonraki saldırıya %50 karşı saldırı bonusu
- Özel güçler: Cooldown sistemiyle dengeli (3 tur bekleme)
- Kritik vuruş sistemi: Sınıfa göre %10-%20 şans, hasar x2
- Zırh hesaplaması: Gerçek hasar = max(1, hasar - zırh)

**Zindan Yapısı**
- 5 odalı doğrusal zindan: Savaş → Hazine → Savaş → Hazine → Boss
- Zindan haritası göstergesi: `[#]---[#]---[X]---[ ]---[ ]`
- 4 farklı düşman tipi + 1 boss (Gölge Lordu)

**Boss AI**
- Gölge Lordu: HP %30'un altına düşünce öfkelenir
- Öfke modunda özel saldırı yapar, hasar artar

**Hazine Odaları**
- Risk/ödül seçim sistemi: Dikkatli aç (%70 başarı) / Hızlı aç (%50 başarı, bonus ödül) / Dokunma
- Başarısızlıkta zehirli gaz tuzağı

**Görsel & Arayüz**
- ASCII art karakter ve düşman görselleri
- Renkli HP barları (yeşil → sarı → kırmızı)
- Animasyonlu metin ve yanıp sönen efektler
- Çerçeveli UI sistemi (tutarlı 50 karakter genişlik)
- Savaş logu: Son 3 aksiyonu gösterir

**İstatistikler (LINQ)**
- Macera sonu detaylı istatistik ekranı
- Toplam/ortalama/max/min hasar analizi
- En güçlü 3 saldırı sıralaması
- 40 Günde C# karne listesi

---

## 🚀 Kurulum & Çalıştırma

### Gereksinimler

- [.NET SDK](https://dotnet.microsoft.com/download) (.NET 8.0 veya üstü)

### Çalıştırma

```bash
git clone https://github.com/thejarrus/40DaysOfCSharp.git
cd 40DaysOfCSharp/Day40_GolgeDiyari
dotnet run
```

> **Not:** Terminal'in UTF-8 karakter desteği ve renk desteği olmalıdır. Windows Terminal, macOS Terminal veya modern Linux terminalleri sorunsuz çalışır.

---

## 🎯 Seride Kullanılan C# Kavramları

Bu proje, 40 Günde C# serisinde işlenen tüm konuları tek bir yerde kullanır. Kodda her kavramın kullanıldığı yer yorum satırlarıyla işaretlidir.

| Gün | Konu | Projede Kullanımı |
|:---:|------|-------------------|
| 01-02 | Değişkenler & Veri Tipleri | HP, hasar, zırh değişkenleri |
| 03 | Operatörler | Hasar hesaplamaları |
| 04 | Modülüs | Boss giriş animasyonunda renk döngüsü |
| 05 | Var & Const | `OyunMotoru` sabitleri (`OZEL_BEKLEME_SURE`, `SAVUNMA_AZALTMA`) |
| 06 | if / else | Kritik vuruş kontrolü, HP renk belirleme |
| 08 | Switch Case | Görev cevabı, karakter seçimi, oda tipi yönlendirme |
| 09 | Döngüler | Savaş döngüsü (`while`), oda geçişi (`foreach`), okçu çoklu ok (`for`) |
| 10 | Ternary | `Oldu` property'si, Tahir veda metni |
| 11-12 | ToString & TryParse | Menü input doğrulama, sayısal format |
| 15 | Verbatim String | ASCII art tanımlamaları (`@"..."`) |
| 17 | String Interpolation | `$"{Ad} \| HP: {Can}/{MaxCan}"` |
| 18 | IsNullOrEmpty | Karakter ismi kontrolü |
| 23-25 | Arrays | ASCII art dizileri, sınıf bilgi tablosu |
| 26 | Lists | Düşman havuzu, zindan odaları, savaş logu, hasar geçmişi |
| 27 | 2D Arrays | Karakter sınıf bilgi tablosu `string[3,4]` |
| 28 | Dictionary | Diyalog sistemi, düşman ASCII art kütüphanesi |
| 29 | Entry Point | `static void Main(string[] args)` |
| 30-31 | Return Types & Overloading | `Bilgi()` ve `Bilgi(bool detayli)` metot overloading |
| 32-33 | Class & Constructor | `Karakter`, `Dusman`, `Oda` sınıfları ve constructor'ları |
| 34 | Encapsulation | `private int _can` + `public int Can { get; set; }` |
| 35 | Inheritance | `Savasci : Karakter`, `Okcu : Karakter`, `Buyucu : Karakter` |
| 36 | Polymorphism | `abstract` metotlar + `override` (her sınıfın kendi `Saldir()` implementasyonu) |
| 37 | Abstract & Interface | `abstract class Karakter`, `interface ISaldirabilir` |
| 38 | Static | `static class OyunMotoru` (merkezi Random, sabitler, istatistikler), `static class UI` |
| 39 | LINQ | `Where`, `OrderByDescending`, `First`, `Sum`, `Average`, `Max`, `Min`, `Take` |

---

## 🗺️ Oyun Akışı

```
┌─────────────┐
│ Başlık Ekranı│
└──────┬──────┘
       ▼
┌─────────────┐     ┌──────────────────────────────┐
│   Taverna    │────▶│ Diyalog Seçimi               │
│  (Tahir)    │     │ 1. Cesur → Normal başlangıç   │
└──────┬──────┘     │ 2. Bilgi → 1. odayı atla      │
       │            │ 3. İsteksiz → İlk saldırı +%50│
       │            └──────────────────────────────┘
       ▼
┌─────────────┐
│  Karakter   │
│   Seçimi    │
│ ⚔️🏹🔮    │
└──────┬──────┘
       ▼
┌─────────────┐   ┌─────────────┐   ┌─────────────┐
│  ODA 1      │──▶│  ODA 2      │──▶│  ODA 3      │
│  Savaş      │   │  Hazine     │   │  Savaş      │
│ (Kolay)     │   │ (Seçimli)   │   │ (Orta)      │
└─────────────┘   └─────────────┘   └──────┬──────┘
                                           ▼
                  ┌─────────────┐   ┌─────────────┐
                  │  ODA 5      │◀──│  ODA 4      │
                  │  BOSS       │   │  Hazine     │
                  │ Gölge Lordu │   │ (Son Şans)  │
                  └──────┬──────┘   └─────────────┘
                         ▼
                  ┌──────┴──────┐
                  │             │
              ┌───▼───┐   ┌────▼───┐
              │ ZAFER  │   │YENİLGİ│
              │  🏆   │   │  💀   │
              └───┬───┘   └────┬───┘
                  │            │
                  └─────┬──────┘
                        ▼
                 ┌──────────────┐
                 │  İstatistik  │
                 │   Ekranı    │
                 │   (LINQ)    │
                 └──────────────┘
```

---

## ⚔️ Sınıf Karşılaştırması

| | Savaşçı ⚔️ | Okçu 🏹 | Büyücü 🔮 |
|---|:---:|:---:|:---:|
| **HP** | 140 | 110 | 90 |
| **Saldırı** | 20 | 24 | 30 |
| **Zırh** | 10 | 5 | 3 |
| **Kritik Şansı** | %15 | %20 | %10 |
| **Normal Saldırı** | Kılıç Savurdu | Ok Fırlattı | Büyü Fırlattı |
| **Özel Güç** | Güçlü Darbe (x2.2) | Oklu Yağmur (3x ok) | Ateş Topu (x2.8) |
| **Stil** | Dengeli, dayanıklı | Yüksek kritik, çoklu vuruş | Cam top ama yüksek hasar |

---

## 👾 Düşmanlar

| Düşman | HP | Saldırı | Zırh | Zorluk |
|--------|:---:|:---:|:---:|:---:|
| İskelet Asker ☠️ | 60 | 12 | 3 | Kolay |
| Zehirli Örümcek 🕷️ | 50 | 14 | 2 | Kolay |
| Karanlık Şövalye ⚔️ | 80 | 16 | 6 | Orta |
| Hayalet 👻 | 55 | 18 | 1 | Orta |
| **Gölge Lordu** ☠️ | **130** | **20** | **7** | **Boss** |

> Gölge Lordu HP'si %30'un altına düşünce **öfkelenir** ve özel saldırılar yapmaya başlar.

---

## 📸 Ekran Görüntüleri

### Taverna
```
          ╔══════════════════════════════╗
          ║       E S K İ   M E Ş E      ║
          ╠══════════════════════════════╣
          ║     🍺  T A V E R N A  🍺   ║
          ╚══════════════════════════════╝
```

### Savaş Ekranı
```
  +==================================================+
  | << SAVAS >>                    Tur: 3             |
  |--------------------------------------------------|
  |  Kahraman           [########------]  85/140     |
  |                    - VS -                         |
  |  İskelet Asker      [####----------]  28/60      |
  +==================================================+

    [1] Saldır    [2] Savun    [3] Özel Güç
```

### Boss Savaşı
```
          ╔═══════════╗
          ║ ▓▓▓▓▓▓▓ ║
        ╔═╩═════════╩═╗
        ║ ║ ● ▼ ● ║   ║
        ║ ║   ∩   ║   ║
        ║ ╚═══════╝   ║
      ╔═╩═════════════╩═╗
     ╔╝ ║║ ║║║║║║ ║║ ║║ ╚╗
    ╔╝  ║║ ║║║║║║ ║║ ║║  ╚╗

      ☠️ GÖLGE LORDU ☠️
```

---

## 📁 Proje Yapısı

```
Day40_GolgeDiyari/
├── Program.cs              # Tüm oyun kodu (tek dosya)
├── GolgeDiyari.csproj      # .NET proje dosyası
└── GolgeDiyari.sln         # Solution dosyası
```

### Kod Mimarisi

```
Program.cs
│
├── ISaldirabilir            (Interface — Gün 37)
├── Karakter                 (Abstract Class — Gün 37, 34)
│   ├── Savasci              (Inheritance — Gün 35)
│   ├── Okcu                 (Override — Gün 36)
│   ├── Buyucu               (Polymorphism — Gün 36)
│   └── Dusman               (Inheritance — Gün 35)
├── OyunMotoru               (Static Class — Gün 38)
├── UI                       (Static Class — Gün 38)
├── Oda                      (Class — Gün 32)
├── OdaTipi                  (Enum)
│
└── Program
    ├── Main()               (Entry Point — Gün 29)
    ├── BaslikEkrani()
    ├── TavernaSahnesi()     (Dictionary diyalog — Gün 28)
    ├── KarakterSecimi()     (2D Array, TryParse — Gün 27, 12)
    ├── ZindanOlustur()      (LINQ — Gün 39)
    ├── ZindanMacerasi()     (foreach — Gün 9)
    ├── SavasBaslat()        (while döngüsü, switch — Gün 9, 8)
    ├── OdaHazine()          (Random, seçim sistemi)
    └── SonucEkrani()        (LINQ istatistikler — Gün 39)
```

---

## 🔗 40 Günde C# Serisi

Bu proje, 40 Günde C# Öğreniyorum serisinin final projesidir.

| Bölüm | Günler | Konular |
|-------|--------|---------|
| Temel Kavramlar | 01-06 | Değişkenler, Operatörler, Koşullar |
| Kontrol Yapıları | 07-10 | Switch, Döngüler, Ternary |
| String İşlemleri | 11-22 | Format, Parse, Concatenation, Metotlar |
| Koleksiyonlar | 23-28 | Arrays, Lists, 2D Arrays, Dictionary |
| Metotlar | 29-31 | Entry Point, Return Types, Overloading |
| OOP | 32-40 | Class, Constructor, Encapsulation, Inheritance, Polymorphism, Abstract, Interface, Static, LINQ |

Tüm günlerin kodları: [github.com/thejarrus/40DaysOfCSharp](https://github.com/thejarrus/40DaysOfCSharp)

---

## 📱 Beni Takip Edin

| Platform | Link |
|----------|------|
| YouTube | [@thejarrus](https://www.youtube.com/@thejarrus) |
| TikTok | [@thejarrus_](https://www.tiktok.com/@thejarrus_?lang=tr-TR) |
| Instagram | [@thejarrus](https://www.instagram.com/thejarrus/) |
| GitHub | [thejarrus](https://github.com/thejarrus) |

---

## 📄 Lisans

Bu proje eğitim amaçlı oluşturulmuştur. Serbestçe inceleyebilir, çalıştırabilir ve öğrenmek için kullanabilirsiniz.

---

<p align="center">
  <b>40 Günde C# Öğreniyorum</b><br>
  <i>by @thejarrus</i><br><br>
  <code>C#'ı öğrendik. Şimdi öğrendiklerimize şekil verme zamanı.</code>
</p>
