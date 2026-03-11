// ═══════════════════════════════════════════════════════════════
// 40 GÜNDE C# - GÜN 40: FİNAL PROJE
// "Gölge Diyarının Kahramanları" - RPG Zindan Macerası
// by Jarrus
// ═══════════════════════════════════════════════════════════════

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// ─────────────────────────────────────────────────────────────
// GÜN 37: Interface
// ─────────────────────────────────────────────────────────────
public interface ISaldirabilir
{
    int Saldir();
    string SaldiriAdi();
}

// ─────────────────────────────────────────────────────────────
// GÜN 37: Abstract Class + GÜN 34: Encapsulation
// ─────────────────────────────────────────────────────────────
public abstract class Karakter : ISaldirabilir
{
    // GÜN 34: private field + public property
    private int _can;

    public string Ad { get; protected set; }
    public int MaxCan { get; protected set; }
    public int Hasar { get; protected set; }
    public int Zirh { get; protected set; }

    public int Can
    {
        get => _can;
        set => _can = Math.Max(0, Math.Min(value, MaxCan));
    }

    // GÜN 33: Constructor
    protected Karakter(string ad, int can, int hasar, int zirh)
    {
        Ad = ad;
        MaxCan = can;
        _can = can;
        Hasar = hasar;
        Zirh = zirh;
    }

    // GÜN 36: Polymorphism - abstract metotlar
    public abstract int Saldir();
    public abstract string SaldiriAdi();
    public abstract string OzelSaldiriAdi();
    public abstract int OzelSaldir();
    public abstract ConsoleColor Renk();
    public abstract int KritikSans(); // %0-100 arası kritik vuruş şansı

    // GÜN 36: virtual metot
    public virtual void HasarAl(int miktar)
    {
        int gercekHasar = Math.Max(1, miktar - Zirh);
        Can -= gercekHasar;
    }

    public bool Oldu => Can <= 0; // Gün 10

    // GÜN 31: Method Overloading
    public string Bilgi()
    {
        return $"{Ad} | HP: {Can}/{MaxCan} | ATK: {Hasar} | DEF: {Zirh}";
    }

    public string Bilgi(bool detayli)
    {
        return detayli
            ? $"[{GetType().Name}] {Ad} | HP: {Can}/{MaxCan} | ATK: {Hasar} | DEF: {Zirh}"
            : Bilgi();
    }
}

// ─────────────────────────────────────────────────────────────
// GÜN 35: Inheritance + GÜN 36: override
// ─────────────────────────────────────────────────────────────
public class Savasci : Karakter
{
    public Savasci(string ad) : base(ad, 140, 20, 10) { }

    public override int Saldir() => Hasar + OyunMotoru.Rng.Next(-3, 8);
    public override string SaldiriAdi() => "Kılıç Savurdu!";
    public override int OzelSaldir() => (int)(Hasar * 2.2) + OyunMotoru.Rng.Next(0, 12);
    public override string OzelSaldiriAdi() => "GÜÇLÜ DARBE!";
    public override ConsoleColor Renk() => ConsoleColor.Red;
    public override int KritikSans() => 15; // %15 kritik şansı
}

public class Okcu : Karakter
{
    public Okcu(string ad) : base(ad, 110, 24, 5) { }

    public override int Saldir() => Hasar + OyunMotoru.Rng.Next(-2, 10);
    public override string SaldiriAdi() => "Ok Fırlattı!";

    public override int OzelSaldir()
    {
        int toplam = 0;
        for (int i = 0; i < 3; i++)
            toplam += Hasar / 2 + OyunMotoru.Rng.Next(0, 8);
        return toplam;
    }

    public override string OzelSaldiriAdi() => "OKLU YAĞMUR! (x3)";
    public override ConsoleColor Renk() => ConsoleColor.Green;
    public override int KritikSans() => 20; // %20 kritik şansı - En yüksek
}

public class Buyucu : Karakter
{
    public Buyucu(string ad) : base(ad, 90, 30, 3) { }

    public override int Saldir() => Hasar + OyunMotoru.Rng.Next(-5, 12);
    public override string SaldiriAdi() => "Büyü Fırlattı!";
    public override int OzelSaldir() => (int)(Hasar * 2.8) + OyunMotoru.Rng.Next(5, 15);
    public override string OzelSaldiriAdi() => "ATEŞ TOPU!";
    public override ConsoleColor Renk() => ConsoleColor.Cyan;
    public override int KritikSans() => 10; // %10 kritik şansı - En düşük
}

// ─────────────────────────────────────────────────────────────
// GÜN 35: Inheritance - Düşman
// ─────────────────────────────────────────────────────────────
public class Dusman : Karakter
{
    public int ZorlukSeviyesi { get; private set; }
    public string Ikon { get; private set; }

    public Dusman(string ad, int can, int hasar, int zirh, int zorluk, string ikon)
        : base(ad, can, hasar, zirh)
    {
        ZorlukSeviyesi = zorluk;
        Ikon = ikon;
    }

    public override int Saldir() => Hasar + OyunMotoru.Rng.Next(-4, 9);
    public override string SaldiriAdi() => "Saldırdı!";
    public override int OzelSaldir() => (int)(Hasar * 1.8) + OyunMotoru.Rng.Next(0, 10);
    public override string OzelSaldiriAdi() => "GÜÇLÜ SALDIRI!";
    public override ConsoleColor Renk() => ConsoleColor.DarkMagenta;
    public override int KritikSans() => 5; // %5 kritik şansı - Düşman için düşük
}

// ─────────────────────────────────────────────────────────────
// GÜN 38: Static Sınıf - Oyun Motoru
// ─────────────────────────────────────────────────────────────
public static class OyunMotoru
{
    // Merkezi Random instance - tüm sınıflar için
    public static readonly Random Rng = new Random();

    // Oyun dengesi sabitleri
    public const int OZEL_BEKLEME_SURE = 3;
    public const double SAVUNMA_AZALTMA = 0.75;  // %75 hasar azaltma
    public const double KARSI_SALDIRI_BONUS = 1.5;  // %50 bonus
    public const int MIN_HASAR = 1;

    // Hazine sabitleri
    public const int HAZINE_MIN_DEGERLI = 15;
    public const int HAZINE_MAX_DEGERLI = 36;
    public const int HAZINE_MIN_BOSS_ONCESI = 20;
    public const int HAZINE_MAX_BOSS_ONCESI = 41;
    public const int DIKKATLI_ACMA_BASARI_ORANI = 70;  // %70
    public const int HIZLI_ACMA_BASARI_ORANI = 50;  // %50
    public const double HIZLI_ACMA_BONUS = 1.5;

    public static int OzelBekleme => OZEL_BEKLEME_SURE;
    public static int ToplamTur { get; set; } = 0;
    public static int OdaSayisi { get; set; } = 0;
    public static int YenilenDusman { get; set; } = 0;
    public static int BulunanHazine { get; set; } = 0;

    // GÜN 26: List
    public static List<int> HasarGecmisi { get; set; } = new List<int>();

    public static void HasarKaydet(int hasar)
    {
        HasarGecmisi.Add(hasar);
    }

    // Fisher-Yates shuffle - LINQ OrderBy(rng.Next()) yerine optimize edilmiş
    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Rng.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}

// ─────────────────────────────────────────────────────────────
// GÜN 38: Static Sınıf - Tutarlı Arayüz Sistemi
// ─────────────────────────────────────────────────────────────
public static class UI
{
    // Sabit genişlik - tüm çerçeveler bu genişlikte
    public const int GENISLIK = 50;

    // ── Renk Paleti ──
    public static readonly ConsoleColor CERCEVE    = ConsoleColor.DarkYellow;
    public static readonly ConsoleColor BASLIK     = ConsoleColor.Yellow;
    public static readonly ConsoleColor ACIKLAMA   = ConsoleColor.White;
    public static readonly ConsoleColor SOLUK      = ConsoleColor.DarkGray;
    public static readonly ConsoleColor UYARI      = ConsoleColor.Red;
    public static readonly ConsoleColor BASARI     = ConsoleColor.Green;
    public static readonly ConsoleColor OZEL       = ConsoleColor.Magenta;
    public static readonly ConsoleColor SAVUNMA    = ConsoleColor.Blue;
    public static readonly ConsoleColor BOSS_RENK  = ConsoleColor.DarkRed;

    // ── Temel Yazdırma ──
    public static void Yaz(string metin, ConsoleColor renk)
    {
        Console.ForegroundColor = renk;
        Console.Write(metin);
        Console.ResetColor();
    }

    public static void Satir(string metin, ConsoleColor renk)
    {
        Console.ForegroundColor = renk;
        Console.WriteLine(metin);
        Console.ResetColor();
    }

    public static void AnimasyonluYaz(string metin, ConsoleColor renk, int hiz = 22)
    {
        Console.ForegroundColor = renk;
        foreach (char c in metin)
        {
            Console.Write(c);
            Thread.Sleep(hiz);
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    // ── Çerçeve Sistemi (cache edilmiş stringler) ──
    private static readonly string cerceveCizgi = "  +" + new string('=', GENISLIK) + "+";
    private static readonly string cerceveBoslukIc = new string(' ', GENISLIK);
    private static readonly string cerceveTirIc = new string('-', GENISLIK);

    public static void CerceveUst(ConsoleColor renk)
    {
        Satir(cerceveCizgi, renk);
    }

    public static void CerceveAlt(ConsoleColor renk)
    {
        Satir(cerceveCizgi, renk);
    }

    // Optimize edilmiş - gereksiz substring oluşturmaz
    private static readonly char[] paddingBuffer = new char[GENISLIK];

    public static void CerceveSatir(string metin, ConsoleColor cerceve, ConsoleColor icerik)
    {
        int maxMetinUzunluk = GENISLIK - 4;
        int metinUzunluk = Math.Min(metin.Length, maxMetinUzunluk);
        int bosluk = GENISLIK - 2 - metinUzunluk;

        Yaz("  | ", cerceve);

        if (metin.Length > maxMetinUzunluk)
        {
            Console.ForegroundColor = icerik;
            Console.Write(metin.AsSpan(0, maxMetinUzunluk));
            Console.ResetColor();
        }
        else
        {
            Yaz(metin, icerik);
        }

        if (bosluk > 0)
        {
            Array.Fill(paddingBuffer, ' ', 0, bosluk);
            Console.ForegroundColor = cerceve;
            Console.Write(paddingBuffer, 0, bosluk);
            Console.ResetColor();
        }

        Satir(" |", cerceve);
    }

    public static void CerceveBos(ConsoleColor renk)
    {
        Satir("  |" + cerceveBoslukIc + "|", renk);
    }

    public static void CerceveCizgi(ConsoleColor renk)
    {
        Satir("  |" + cerceveTirIc + "|", renk);
    }

    // ── HP Barı (optimize edilmiş) ──
    private static readonly char[] hpBarBuffer = new char[20];

    public static string CanBari(int can, int maxCan, int uzunluk = 20)
    {
        if (maxCan <= 0)
        {
            Array.Fill(hpBarBuffer, '-', 0, Math.Min(uzunluk, hpBarBuffer.Length));
            return new string(hpBarBuffer, 0, Math.Min(uzunluk, hpBarBuffer.Length));
        }

        double oran = (double)can / maxCan;
        int dolu = (int)(oran * uzunluk);
        int bos = uzunluk - dolu;

        if (uzunluk <= hpBarBuffer.Length)
        {
            Array.Fill(hpBarBuffer, '#', 0, dolu);
            Array.Fill(hpBarBuffer, '-', dolu, bos);
            return new string(hpBarBuffer, 0, uzunluk);
        }

        return new string('#', dolu) + new string('-', bos);
    }

    public static ConsoleColor CanRengi(int can, int maxCan)
    {
        if (maxCan <= 0) return UYARI;
        double oran = (double)can / maxCan;
        if (oran > 0.6) return BASARI;
        else if (oran > 0.3) return ConsoleColor.Yellow;
        else return UYARI;
    }

    // ── HP Barı Çizimi (Çerçeve içinde) ──
    public static void CanBariCiz(string ad, int can, int maxCan, ConsoleColor adRenk, ConsoleColor cerceve)
    {
        // Uzun isimleri kısalt (max 18 karakter)
        int maxIsimUzunluk = 18;
        string kisaAd = ad.Length > maxIsimUzunluk ? string.Concat(ad.AsSpan(0, maxIsimUzunluk - 2), "..") : ad;

        string bar = CanBari(can, maxCan, 14);
        ConsoleColor barRenk = CanRengi(can, maxCan);

        Yaz("  | ", cerceve);
        Yaz($" {kisaAd,-18}", adRenk);
        Yaz(" [", SOLUK);
        Yaz(bar, barRenk);
        Yaz("]", SOLUK);
        string hpText = $" {can,3}/{maxCan,-3}";
        Yaz(hpText, ACIKLAMA);
        int kalan = GENISLIK - 18 - 14 - hpText.Length - 5;
        if (kalan > 0) Yaz(new string(' ', kalan), cerceve);
        Satir(" |", cerceve);
    }

    // ── Zindan Haritası ──
    public static void HaritaCiz(int toplamOda, int mevcutOda)
    {
        Console.Write("    ");
        for (int i = 1; i <= toplamOda; i++)
        {
            if (i < mevcutOda)
                Yaz("[#]", BASARI);
            else if (i == mevcutOda)
                Yaz("[X]", ConsoleColor.Yellow);
            else
                Yaz("[ ]", SOLUK);

            if (i < toplamOda)
                Yaz("---", SOLUK);
        }
        Console.WriteLine();
    }

    // ── Seçim Menüsü ──
    public static int SecimSor(string[] secenekler, ConsoleColor[]? renkler = null)
    {
        Console.WriteLine();
        for (int i = 0; i < secenekler.Length; i++)
        {
            ConsoleColor renk = (renkler != null && i < renkler.Length) ? renkler[i] : ACIKLAMA;
            Yaz($"    [{i + 1}] ", ConsoleColor.White);
            Satir(secenekler[i], renk);
        }
        Console.WriteLine();

        int secim = 0;
        while (secim < 1 || secim > secenekler.Length)
        {
            Console.Write("    Secimin: ");
            string girdi = Console.ReadLine();
            if (!int.TryParse(girdi, out secim) || secim < 1 || secim > secenekler.Length)
            {
                Satir($"    Gecersiz! 1-{secenekler.Length} arasi sec.", UYARI);
                secim = 0;
            }
        }
        return secim;
    }

    // ── Yardımcılar ──
    public static void Bekle(int ms = 800) => Thread.Sleep(ms);

    public static void EnterBekle()
    {
        Console.WriteLine();
        Yaz("    [ENTER'a bas]", SOLUK);
        Console.ReadLine();
    }

    public static void Temizle()
    {
        try { Console.Clear(); } catch { }
    }

    // ASCII art'ı ortalı yazdır
    public static void ArtCiz(string[] art, ConsoleColor renk, int solBosluk = 6, int gecikme = 40)
    {
        string pad = new string(' ', solBosluk);
        foreach (string satir in art)
        {
            Satir(pad + satir, renk);
            Thread.Sleep(gecikme);
        }
    }

    // Çok renkli ASCII art desteği
    public static void ArtCizRenkli(string[] art, ConsoleColor[] renkler, int solBosluk = 6, int gecikme = 40)
    {
        string pad = new string(' ', solBosluk);
        for (int i = 0; i < art.Length; i++)
        {
            ConsoleColor satırRenk = (i < renkler.Length) ? renkler[i] : ACIKLAMA;
            Satir(pad + art[i], satırRenk);
            Thread.Sleep(gecikme);
        }
    }

    // Yanıp sönen metin efekti
    public static void YanipSonenMesaj(string mesaj, ConsoleColor renk, int tekrar = 3, int parlakMs = 150, int sonukMs = 100)
    {
        for (int i = 0; i < tekrar; i++)
        {
            Console.Write($"\r    >>> ");
            Yaz(mesaj, renk);
            Console.Write("     ");
            Thread.Sleep(parlakMs);
            Console.Write($"\r    >>>                        ");
            Thread.Sleep(sonukMs);
        }
        Console.Write($"\r    >>> ");
        Satir(mesaj, renk);
    }
}

// ─────────────────────────────────────────────────────────────
// ODA SİSTEMİ
// ─────────────────────────────────────────────────────────────
public enum OdaTipi { Savas, Hazine, Tuzak, Boss }

public class Oda
{
    public int Numara { get; set; }
    public OdaTipi Tip { get; set; }
    public string Aciklama { get; set; }
    public Dusman? DusmanVar { get; set; }
    public int HazineDegeri { get; set; }

    public Oda(int numara, OdaTipi tip, string aciklama)
    {
        Numara = numara;
        Tip = tip;
        Aciklama = aciklama;
    }
}

// ═══════════════════════════════════════════════════════════════
// ANA PROGRAM
// ═══════════════════════════════════════════════════════════════
class Program
{
    static Karakter oyuncu = null!;
    static int ozelBekleme = 0;
    static bool karsiSaldiri = false; // Savunma sonrası bonus
    static int baslangicOda = 0;     // Diyalog seçimine göre

    // GÜN 28: Dictionary - Diyalog sistemi
    static Dictionary<string, string[]> diyaloglar = new Dictionary<string, string[]>
    {
        { "karsilama", new string[] {
            "Hoş geldin yolcu...",
            "Ben Tahir, bu tavernanın sahibiyim.",
            "Dışarıda fırtına var, içeri gel de bir nefes al."
        }},
        { "gorev", new string[] {
            "Dinle... Köyün yakınındaki eski zindanda karanlık bir güç uyanmış.",
            "Gölge Lordu diyorlar ona.",
            "Oraya giren cesur yolcular... geri dönmedi.",
            "Birinin onu durdurması gerekiyor."
        }},
        { "secim", new string[] {
            "Peki kahraman, nasıl bir savaşçısın sen?"
        }}
    };

    // GÜN 26: List - Düşman havuzu
    static List<Dusman> dusmanHavuzu = new List<Dusman>
    {
        new Dusman("İskelet Asker",    60, 12, 3, 1, "ISKELET"),
        new Dusman("Zehirli Örümcek",  50, 14, 2, 1, "ORUMCEK"),
        new Dusman("Karanlık Şövalye", 80, 16, 6, 2, "SOVALYE"),
        new Dusman("Hayalet",          55, 18, 1, 2, "HAYALET"),
        new Dusman("Gölge Lordu",     130, 20, 7, 3, "BOSS")
    };

    static List<Oda> zindanOdalari = new List<Oda>();

    // ── ASCII Art Kütüphanesi ──

    static string[] ART_BASLIK = new string[]
    {
        @"  ╔═══════════════════════════════════════════════════════╗",
        @"  ║ ▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄   ▄            ▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄  ║",
        @"  ║ ██        ██       ██ ██           ██       ████      ║",
        @"  ║ ██   ▄▄▄▄ ██   ▄   ██ ██     ▄▄▄▄ ██   ▄▄▄▄ ██        ║",
        @"  ║ ██  ██  ██ ██  ███  ██ ██    ██  ████  ██  ████       ║",
        @"  ║ ██  ██████ ██       ██ ██    ███████   ██████  ▀▀▀▀▀  ║",
        @"  ║  ▀▀▀▀  ▀▀  ▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀  ║",
        @"  ║                                                       ║",
        @"  ║         D İ Y A R I N I N   K A H R A M A N I         ║",
        @"  ╚═══════════════════════════════════════════════════════╝"
    };

    static string[] ART_TAVERNA = new string[]
    {
        @"          ╔══════════════════════════════╗",
        @"          ║       E S K İ   M E Ş E      ║",
        @"          ╠══════════════════════════════╣",
        @"         /║  ╔═══╗    ╔═══╗    ╔═══╗     ║\",
        @"        / ║  ║ ◊ ║    ║ ● ║    ║ ◊ ║     ║ \",
        @"       /  ║  ║___║    ║___║    ║___║     ║  \",
        @"      /   ║  │   │    │   │    │   │     ║   \",
        @"     /    ╠══════════════════════════════╣    \",
        @"    ║     ║     🍺  T A V E R N A  🍺   ║     ║",
        @"    ╚═════╩══════════════════════════════╩═════╝",
        @"   ═══════════════════════════════════════════════"
    };

    static string[] ART_ZINDAN_KAPISI = new string[]
    {
        @"       ╔═════════════════════════╗",
        @"       ║ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ ║",
        @"       ║ ▓╔═══════════════════╗▓ ║",
        @"       ║ ▓║                   ║▓ ║",
        @"       ║ ▓║  GÖLGE ZİNDANI    ║▓ ║",
        @"       ║ ▓║                   ║▓ ║",
        @"       ║ ▓║    ⚠️  ☠️  ⚠️    ║▓ ║",
        @"       ║ ▓║                   ║▓ ║",
        @"       ║ ▓║   ╔═════════╗    ║▓  ║",
        @"       ║ ▓║   ║  ⊕   ⊕  ║    ║▓║",
        @"       ║ ▓║   ║    ═    ║    ║▓  ║",
        @"       ║ ▓║   ╚═════════╝    ║▓  ║",
        @"       ║ ▓╚═══════════════════╝▓ ║",
        @"       ║ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ ║",
        @"       ╚═══════════════════════════╝"
    };

    static string[] ART_SANDIK = new string[]
    {
        @"         ╔═══════════════════╗",
        @"         ║   ┌───────────┐   ║",
        @"         ║   │ ★💎 ★ 💰│   ║",
        @"         ║   │ 💰 ★💎 ★│   ║",
        @"         ║   │ ★ 💎 ★💰│   ║",
        @"         ║   └───────────┘   ║",
        @"         ╠═══════════════════╣",
        @"         ║▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓║",
        @"         ║▓╔═══════════════╗▓║",
        @"         ║▓║  H A Z İ N E  ║▓║",
        @"         ╚═╩═══════════════╩═╝"
    };

    static string[] ART_TUZAK = new string[]
    {
        @"      /!\  /!\  /!\  /!\",
        @"     / ! \/ ! \/ ! \/ ! \",
        @"    /  !  /\  !  /\  !  \",
        @"   /___!_/  \_!_/  \_!___\"
    };

    static string[] ART_ZAFER = new string[]
    {
        @"      ★ ･ﾟ✧*:･ﾟ✧ ･ﾟ✧*:･ﾟ✧ ･ﾟ✧*:･ﾟ✧ ★",
        @"         ╔═══════════════════════════╗",
        @"         ║   👑 Z A F E R ! ! ! 👑  ║",
        @"         ╠═══════════════════════════╣",
        @"         ║                           ║",
        @"         ║  🏆 Zindan Temizlendi 🏆 ║",
        @"         ║                           ║",
        @"         ║  Karanlık Sona Erdi!      ║",
        @"         ║                           ║",
        @"         ║     ⚔️  KAHRAMAN  ⚔️     ║",
        @"         ║                           ║",
        @"         ╚═══════════════════════════╝",
        @"      ★ ･ﾟ✧*:･ﾟ✧ ･ﾟ✧*:･ﾟ✧ ･ﾟ✧*:･ﾟ✧ ★",
        @"        ✨  ✨  ✨  ✨  ✨  ✨  ✨"
    };

    static string[] ART_YENILGI = new string[]
    {
        @"         ╔═══════════════════════════╗",
        @"         ║                           ║",
        @"         ║   💀 Y E N İ L D İ N 💀  ║",
        @"         ║                           ║",
        @"         ╠═══════════════════════════╣",
        @"         ║                           ║",
        @"         ║  Karanlık Galip Geldi...  ║",
        @"         ║                           ║",
        @"         ║   Ama Pes Etme Kahraman!  ║",
        @"         ║                           ║",
        @"         ╚═══════════════════════════╝",
        @"             ☠️  ☠️  ☠️  ☠️  ☠️"
    };

    // GÜN 28: Dictionary - Düşman ASCII art
    static Dictionary<string, string[]> dusmanArtlar = new Dictionary<string, string[]>
    {
        { "ISKELET", new string[] {
            @"        _____ ",
            @"       /     \",
            @"      | O   O |",
            @"      |   ^   |",
            @"       \_____/",
            @"        |═|═|",
            @"       /|   |\",
            @"      / |   | \",
            @"       _|   |_",
            @"              ",
            @"    ☠ İSKELET ☠"
        }},
        { "ORUMCEK", new string[] {
            @"      /\____/\",
            @"     /        \",
            @"     | (●)(●) |",
            @"     \   ∇∇  /",
            @"       |___|",
            @"    /| /   \ |\",
            @"   / |/     \| \",
            @"  |  ||     ||  |",
            @"     ||     ||",
            @"               ",
            @"    🕷️ ÖRÜMCEK 🕷️"
        }},
        { "SOVALYE", new string[] {
            @"       ╔═══╗",
            @"       ║▓▓▓║",
            @"      ╔╩═══╩╗",
            @"      ║ ● ● ║",
            @"      ║  =  ║",
            @"      ╚═════╝",
            @"     ╔═╩═══╩═╗",
            @"    ╔╝ ║   ║ ╚╗",
            @"    ║  ║   ║  ║",
            @"       ║   ║",
            @"      _║   ║_",
            @"               ",
            @"   ⚔️ ŞÖVALYE ⚔️"
        }},
        { "HAYALET", new string[] {
            @"        _____ ",
            @"      .'     '.",
            @"     /  O   O  \",
            @"    |     ∩     |",
            @"    |           |",
            @"     \  ╰───╯  /",
            @"      '.     .'",
            @"        '─┬─'",
            @"       ∿∿∿│∿∿∿",
            @"               ",
            @"    👻 HAYALET 👻"
        }},
        { "BOSS", new string[] {
            @"          ╔═══════════╗",
            @"          ║ ▓▓▓▓▓▓▓ ║",
            @"        ╔═╩═════════╩═╗",
            @"        ║ ╔═══════╗   ║",
            @"        ║ ║ ● ▼ ● ║   ║",
            @"        ║ ║   ∩   ║   ║",
            @"        ║ ╚═══════╝   ║",
            @"      ╔═╩═════════════╩═╗",
            @"     ╔╝ ║║ ║║║║║║ ║║ ║║ ╚╗",
            @"    ╔╝  ║║ ║║║║║║ ║║ ║║  ╚╗",
            @"    ║   ║║ ║║║║║║ ║║ ║║   ║",
            @"    ║   ║║ ║║║║║║ ║║ ║║   ║",
            @"    ║   ║║═║║║║║║═║║═║║   ║",
            @"        ║║ ║║║║║║ ║║ ║║",
            @"        ║║═║║║║║║═║║═║║",
            @"                      ",
            @"      ☠️ GÖLGE LORDU ☠️"
        }}
    };

    // ═══════════════════════════════════════════════════════
    // MAIN - GÜN 29: Entry Point
    // ═══════════════════════════════════════════════════════
    static void Main(string[] args)
    {
        // Türkçe karakter desteği
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Title = "Gölge Diyarının Kahramanları - 40 Günde C# Final";

        BaslikEkrani();
        TavernaSahnesi();
        KarakterSecimi();
        TahirVedasi();
        ZindanOlustur();
        ZindanMacerasi();
        SonucEkrani();
    }

    // ═══════════════════════════════════════════════════════
    // BAŞLIK EKRANI
    // ═══════════════════════════════════════════════════════
    static void BaslikEkrani()
    {
        UI.Temizle();
        Console.WriteLine();
        UI.ArtCiz(ART_BASLIK, UI.CERCEVE, 4, 70);
        Console.WriteLine();
        UI.Satir("        GÖLGE DIYARININ KAHRAMANLARI", UI.BASLIK);
        UI.Satir("          ~ Zindan Macerası ~", UI.CERCEVE);
        Console.WriteLine();

        UI.CerceveUst(UI.SOLUK);
        UI.CerceveSatir("40 Günde C# - Final Proje", UI.SOLUK, UI.SOLUK);
        UI.CerceveSatir("by Novament Games  |  @thejarrus", UI.SOLUK, UI.SOLUK);
        UI.CerceveAlt(UI.SOLUK);

        UI.EnterBekle();
    }

    // ═══════════════════════════════════════════════════════
    // TAVERNA SAHNESİ + DİYALOG SEÇENEKLERİ
    // ═══════════════════════════════════════════════════════
    static void TavernaSahnesi()
    {
        UI.Temizle();
        Console.WriteLine();
        UI.ArtCiz(ART_TAVERNA, UI.CERCEVE, 8, 50);
        Console.WriteLine();
        UI.Bekle(400);

        DiyalogGoster("Tahir", diyaloglar["karsilama"], UI.BASLIK);
        UI.EnterBekle();

        // ── GÖREV ANLATIMI ──
        UI.Temizle();
        Console.WriteLine();
        UI.Satir("    [Tahir sana doğru eğilir, sesi alçalır...]", UI.SOLUK);
        Console.WriteLine();
        UI.Bekle(400);
        DiyalogGoster("Tahir", diyaloglar["gorev"], UI.BASLIK);
        Console.WriteLine();

        // ── İLK DİYALOG SEÇİMİ: Görevi kabul et ──
        DiyalogGoster("Tahir", new string[] { "Ne dersin, bu görevi üstlenir misin?" }, UI.BASLIK);

        Console.WriteLine();
        UI.Satir("    [Her seçimin farklı bir sonucu var...]", UI.SOLUK);
        Console.WriteLine();
        UI.Satir("    • Cesur → Normal başlangıç, tüm odaları geç", UI.ACIKLAMA);
        UI.Satir("    • Bilgi İsteyen → 1. odayı atla, direkt 2. odaya git", UI.ACIKLAMA);
        UI.Satir("    • İsteksiz → İlk saldırın %50 daha güçlü (Tahir'in iksiri)", UI.ACIKLAMA);
        Console.WriteLine();

        int gorevCevap = UI.SecimSor(
            new string[] {
                "\"Tabii ki! Hemen yola çıkarım.\" (Cesur)",
                "\"Kabul ederim ama bilgi lazım. Zindan hakkında ne biliyorsun?\" (Bilgi)",
                "\"Bu iş benim için değil... ama başka seçeneğim yok.\" (İsteksiz)"
            },
            new ConsoleColor[] { UI.BASARI, UI.BASLIK, UI.SOLUK }
        );

        // Gün 8: Switch - Seçime göre farklı sonuçlar
        switch (gorevCevap)
        {
            case 1:
                // Cesur cevap: Normal başlangıç
                baslangicOda = 0;
                Console.WriteLine();
                DiyalogGoster("Tahir", new string[] {
                    "Hah! Cesaretini sevdim!",
                    "Bu ruh zindanın derinliklerinde işine yarayacak."
                }, UI.BASLIK);
                break;

            case 2:
                // Bilgi isteyen cevap: 1. odayı atla (Tahir haritayı verdi)
                baslangicOda = 1;
                Console.WriteLine();
                DiyalogGoster("Tahir", new string[] {
                    "Akıllı bir yaklaşım...",
                    "Zindanın ilk odası zaten zayıf iskeletlerle dolu.",
                    "Sana arka kapının anahtarını vereyim, direkt 2. odaya girersin.",
                    "Ama dikkat et, gerisini kendi başına halletmen gerekecek."
                }, UI.BASLIK);
                break;

            case 3:
                // İsteksiz cevap: Normal başlangıç ama moral düşük
                baslangicOda = 0;
                Console.WriteLine();
                DiyalogGoster("Tahir", new string[] {
                    "Hmmm... İsteksiz bir kahraman.",
                    "Ama bazen en büyük kahramanlar böyle başlar.",
                    "Sana tavernamın özel iksirinden vereyim, belki moral verir."
                }, UI.BASLIK);

                // Bonus: İlk saldırı güçlü (karakter seçiminde uygulanacak)
                baslangicOda = -1; // Özel durum: iksir bonusu
                break;
        }

        UI.EnterBekle();
    }

    // ═══════════════════════════════════════════════════════
    // KARAKTER SEÇİMİ
    // ═══════════════════════════════════════════════════════
    static void KarakterSecimi()
    {
        UI.Temizle();
        Console.WriteLine();
        DiyalogGoster("Tahir", diyaloglar["secim"], UI.BASLIK);
        Console.WriteLine();

        // GÜN 27: 2D Array
        string[,] sinifBilgi = new string[3, 4]
        {
            { "SAVASCI",  "HP:140", "ATK:20", "DEF:10" },
            { "OKCU",     "HP:110", "ATK:24", "DEF:5"  },
            { "BUYUCU",   "HP:90",  "ATK:30", "DEF:3"  }
        };

        ConsoleColor[] renkler = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan };

        // Gün 15: Verbatim String - Karakter ASCII art
        string[][] karakterArt = new string[][]
        {
            new string[] {
                @"      ╔═══╗  ",
                @"      ║ ● ║  ",
                @"      ╚═╦═╝  ",
                @"     ╔══╩══╗ ",
                @"    ╔╝ ║║║ ╚╗",
                @"    ║  ║║║  ║",
                @"       ║ ║   ",
                @"      _║ ║_  ",
                @"             ",
                @"  ⚔️ SAVAŞÇI ⚔️"
            },
            new string[] {
                @"       _O_   ",
                @"      / | \  ",
                @"     /  |  \ ",
                @"       /|\   ",
                @"      / | \)═>",
                @"        |    ",
                @"       / \   ",
                @"      /   \  ",
                @"             ",
                @"   🏹 OKÇU 🏹"
            },
            new string[] {
                @"      ★ ✦ ★ ",
                @"       _O_  ",
                @"      /~|~\ ",
                @"    *~ /|\  ",
                @"      / | \ ",
                @"    ✦   |  ★",
                @"       / \  ",
                @"      /   \ ",
                @"            ",
                @"  🔮 BÜYÜCÜ 🔮"
            }
        };

        UI.CerceveUst(UI.CERCEVE);
        UI.CerceveSatir("SINIFINI SEÇ", UI.CERCEVE, UI.BASLIK);
        UI.CerceveAlt(UI.CERCEVE);
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            UI.Yaz($"    [{i + 1}] ", ConsoleColor.White);
            UI.Yaz($"{sinifBilgi[i, 0],-10}", renkler[i]);
            UI.Satir($" {sinifBilgi[i, 1]}  {sinifBilgi[i, 2]}  {sinifBilgi[i, 3]}", UI.SOLUK);

            foreach (string satir in karakterArt[i])
            {
                Console.Write("        ");
                UI.Satir(satir, renkler[i]);
            }
        }

        // Gün 12: TryParse + Gün 9: while
        int secim = 0;
        Console.WriteLine();
        while (secim < 1 || secim > 3)
        {
            Console.Write("    Secimin (1-3): ");
            string girdi = Console.ReadLine();
            if (!int.TryParse(girdi, out secim) || secim < 1 || secim > 3)
            {
                UI.Satir("    Gecersiz! 1, 2 veya 3 gir.", UI.UYARI);
                secim = 0;
            }
        }

        Console.Write("\n    Kahramanın adı: ");
        string ad = Console.ReadLine();
        if (string.IsNullOrEmpty(ad)) ad = "Adsız Kahraman";

        // GÜN 8: Switch + GÜN 32: Object
        switch (secim)
        {
            case 1: oyuncu = new Savasci(ad); break;
            case 2: oyuncu = new Okcu(ad); break;
            case 3: oyuncu = new Buyucu(ad); break;
        }

        // İsteksiz cevap bonusu: ilk saldırı +%50 güçlü
        if (baslangicOda == -1)
        {
            baslangicOda = 0;
            karsiSaldiri = true; // İlk saldırı bonusu
            Console.WriteLine();
            UI.CerceveUst(UI.BASARI);
            UI.CerceveSatir("Tahir'in Moral İksiri!", UI.BASARI, UI.BASARI);
            UI.CerceveSatir("İlk saldırın %50 daha güçlü olacak!", UI.BASARI, UI.ACIKLAMA);
            UI.CerceveAlt(UI.BASARI);
        }

        Console.WriteLine();
        UI.CerceveUst(UI.CERCEVE);
        UI.CerceveSatir($"  {oyuncu.Ad} [{oyuncu.GetType().Name}]", UI.CERCEVE, oyuncu.Renk());
        UI.CerceveSatir($"  {oyuncu.Bilgi()}", UI.CERCEVE, UI.ACIKLAMA);
        UI.CerceveAlt(UI.CERCEVE);
    }

    // ═══════════════════════════════════════════════════════
    // TAHİR VEDASI
    // ═══════════════════════════════════════════════════════
    static void TahirVedasi()
    {
        Console.WriteLine();

        // Gün 10: Ternary
        string odaBilgi = baslangicOda > 0
            ? $"Arka kapıyı kullan, direkt {baslangicOda + 1}. odaya gir."
            : "Zindan 5 oda derinliğinde. Her odada bir sürpriz var.";

        DiyalogGoster("Tahir", new string[] {
            odaBilgi,
            "Dikkatli ol... ve geri dön.",
            "Yolun açık olsun, kahraman!"
        }, UI.BASLIK);

        UI.EnterBekle();
    }

    // ═══════════════════════════════════════════════════════
    // ZİNDAN OLUŞTURMA - GÜN 39: LINQ
    // ═══════════════════════════════════════════════════════
    static void ZindanOlustur()
    {
        // GÜN 39: LINQ - Optimize edilmiş
        var kolaylar = dusmanHavuzu
            .Where(d => d.ZorlukSeviyesi == 1)
            .ToList();
        OyunMotoru.Shuffle(kolaylar);

        var ortalar = dusmanHavuzu
            .Where(d => d.ZorlukSeviyesi == 2)
            .ToList();
        OyunMotoru.Shuffle(ortalar);

        var boss = dusmanHavuzu
            .Where(d => d.ZorlukSeviyesi == 3)
            .OrderByDescending(d => d.MaxCan)
            .First();

        // Oda 1: Savaş (kolay)
        var d1 = kolaylar.First();
        var oda1 = new Oda(1, OdaTipi.Savas, "Karanlık bir koridor... Duvarlarda tırnak izleri.");
        oda1.DusmanVar = new Dusman(d1.Ad, d1.MaxCan, d1.Hasar, d1.Zirh, d1.ZorlukSeviyesi, d1.Ikon);

        // Oda 2: Hazine (seçimli)
        var oda2 = new Oda(2, OdaTipi.Hazine, "Loşluğu yaran bir parıltı... Köşede eski bir sandık.");
        oda2.HazineDegeri = OyunMotoru.Rng.Next(OyunMotoru.HAZINE_MIN_DEGERLI, OyunMotoru.HAZINE_MAX_DEGERLI);

        // Oda 3: Savaş (orta)
        var d3 = ortalar.First();
        var oda3 = new Oda(3, OdaTipi.Savas, "Geniş bir salon. Duvarlarda paslı zırhlar asılı.");
        oda3.DusmanVar = new Dusman(d3.Ad, d3.MaxCan, d3.Hasar, d3.Zirh, d3.ZorlukSeviyesi, d3.Ikon);

        // Oda 4: Hazine (boss öncesi son şans)
        var oda4 = new Oda(4, OdaTipi.Hazine, "Küçük bir oda. Duvardan su sızıyor, yanında bir sandık.");
        oda4.HazineDegeri = OyunMotoru.Rng.Next(OyunMotoru.HAZINE_MIN_BOSS_ONCESI, OyunMotoru.HAZINE_MAX_BOSS_ONCESI);

        // Oda 5: BOSS
        var oda5 = new Oda(5, OdaTipi.Boss, "Devasa bir salon... Tahtta karanlık bir figür oturuyor...");
        oda5.DusmanVar = new Dusman(boss.Ad, boss.MaxCan, boss.Hasar, boss.Zirh, boss.ZorlukSeviyesi, boss.Ikon);

        zindanOdalari.Add(oda1);
        zindanOdalari.Add(oda2);
        zindanOdalari.Add(oda3);
        zindanOdalari.Add(oda4);
        zindanOdalari.Add(oda5);
    }

    // ═══════════════════════════════════════════════════════
    // ZİNDAN MACERASI
    // ═══════════════════════════════════════════════════════
    static void ZindanMacerasi()
    {
        UI.Temizle();
        Console.WriteLine();
        UI.ArtCiz(ART_ZINDAN_KAPISI, UI.SOLUK, 8, 50);
        Console.WriteLine();
        UI.AnimasyonluYaz("    Zindanın kapısını açıyorsun...", UI.SOLUK, 25);
        UI.Bekle(400);
        UI.AnimasyonluYaz("    Soğuk bir hava yüzünü çarpıyor.", UI.SOLUK, 25);
        UI.EnterBekle();

        // Gün 9: foreach + baslangicOda ile atlama
        foreach (Oda oda in zindanOdalari)
        {
            // Başlangıç odası atlaması (Tahir'in arka kapı anahtarı)
            if (oda.Numara <= baslangicOda) continue;

            OyunMotoru.OdaSayisi = oda.Numara;

            if (oyuncu.Oldu) break;

            UI.Temizle();
            Console.WriteLine();

            // Harita
            UI.HaritaCiz(zindanOdalari.Count, oda.Numara);
            Console.WriteLine();

            // Oyuncu durum çerçevesi
            UI.CerceveUst(UI.SOLUK);
            UI.CanBariCiz(oyuncu.Ad, oyuncu.Can, oyuncu.MaxCan, oyuncu.Renk(), UI.SOLUK);
            UI.CerceveAlt(UI.SOLUK);
            Console.WriteLine();

            // Oda başlığı
            UI.CerceveUst(UI.CERCEVE);
            UI.CerceveSatir($"ODA {oda.Numara}", UI.CERCEVE, UI.BASLIK);
            UI.CerceveAlt(UI.CERCEVE);
            Console.WriteLine();
            UI.AnimasyonluYaz($"    {oda.Aciklama}", UI.ACIKLAMA, 18);
            UI.Bekle(400);

            switch (oda.Tip)
            {
                case OdaTipi.Savas: OdaSavas(oda); break;
                case OdaTipi.Hazine: OdaHazine(oda); break;
                case OdaTipi.Boss: OdaBoss(oda); break;
            }

            if (!oyuncu.Oldu && oda.Numara < zindanOdalari.Count)
            {
                Console.WriteLine();
                UI.Satir("    Sonraki odaya ilerliyorsun...", UI.SOLUK);
                UI.EnterBekle();
            }
        }
    }

    // ═══════════════════════════════════════════════════════
    // ODA: SAVAŞ
    // ═══════════════════════════════════════════════════════
    static void OdaSavas(Oda oda)
    {
        if (oda.DusmanVar == null) return;

        Dusman dusman = oda.DusmanVar;
        Console.WriteLine();

        UI.ArtCiz(dusmanArtlar[dusman.Ikon], UI.OZEL, 10, 40);
        Console.WriteLine();
        Console.WriteLine();

        UI.Yaz($"    {dusman.Ad}", UI.OZEL);
        UI.Satir(" belirdi!", UI.ACIKLAMA);
        UI.Satir($"    {dusman.Bilgi()}", UI.SOLUK);
        UI.Bekle(500);

        SavasBaslat(dusman, false);
    }

    // ═══════════════════════════════════════════════════════
    // ODA: BOSS
    // ═══════════════════════════════════════════════════════
    static void OdaBoss(Oda oda)
    {
        if (oda.DusmanVar == null) return;

        Dusman boss = oda.DusmanVar;
        Console.WriteLine();

        // Yanıp sönen giriş - Gün 4: Modülüs
        ConsoleColor[] renkler = { ConsoleColor.DarkMagenta, ConsoleColor.Magenta, UI.BOSS_RENK };

        for (int flash = 0; flash < 3; flash++)
        {
            UI.Temizle();
            Console.WriteLine();
            UI.HaritaCiz(zindanOdalari.Count, oda.Numara);
            Console.WriteLine();
            UI.ArtCiz(dusmanArtlar["BOSS"], renkler[flash % renkler.Length], 8, 30);
            Thread.Sleep(300);
        }

        UI.Temizle();
        Console.WriteLine();
        UI.HaritaCiz(zindanOdalari.Count, oda.Numara);
        Console.WriteLine();
        UI.ArtCiz(dusmanArtlar["BOSS"], UI.BOSS_RENK, 8, 35);
        Console.WriteLine();
        Console.WriteLine();

        UI.CerceveUst(UI.BOSS_RENK);
        UI.CerceveSatir($"BOSS: {boss.Ad}", UI.BOSS_RENK, UI.UYARI);
        UI.CerceveSatir(boss.Bilgi(), UI.BOSS_RENK, UI.ACIKLAMA);
        UI.CerceveAlt(UI.BOSS_RENK);
        Console.WriteLine();

        UI.AnimasyonluYaz("    \"Bir ölümlü daha... Koleksiyonuma ekleneceksin.\"", UI.OZEL, 25);
        UI.Bekle(400);

        SavasBaslat(boss, true);
    }

    // ═══════════════════════════════════════════════════════
    // ODA: HAZİNE (Seçimli + Rastgele Sonuç)
    // ═══════════════════════════════════════════════════════
    static void OdaHazine(Oda oda)
    {
        Console.WriteLine();
        UI.ArtCiz(ART_SANDIK, UI.BASLIK, 8, 50);
        Console.WriteLine();

        UI.AnimasyonluYaz("    Köşede eski bir sandık duruyor...", UI.BASLIK, 22);
        UI.Bekle(300);

        // ── SEÇİM: Sandığı aç mı? ──
        DiyalogGoster("", new string[] { "Sandığı açacak mısın? İçinde ne var bilinmez..." }, UI.SOLUK);

        Console.WriteLine();
        UI.Satir("    [Her seçimin farklı bir riski var...]", UI.SOLUK);
        Console.WriteLine();
        UI.Satir("    • Dikkatli → %70 başarı, normal iyileşme", UI.ACIKLAMA);
        UI.Satir("    • Hızlı → %50 başarı, başarırsa %50 bonus, başarısızsa tam hasar", UI.ACIKLAMA);
        UI.Satir("    • Dokunma → Güvenli ama hiçbir şey kazanmazsın", UI.ACIKLAMA);
        Console.WriteLine();

        int secim = UI.SecimSor(
            new string[] {
                "Sandığı dikkatlice aç (Güvenli)",
                "Sandığı hızlıca aç, ne çıkarsa! (Riskli)",
                "Dokunma, geçip git (Güvenli)"
            },
            new ConsoleColor[] { UI.BASLIK, UI.UYARI, UI.SOLUK }
        );

        Console.WriteLine();

        switch (secim)
        {
            case 1: // Dikkatli açma
                UI.AnimasyonluYaz("    Sandığa yavaş yavaş yaklaşıyorsun...", UI.BASLIK, 25);
                UI.Bekle(300);
                UI.AnimasyonluYaz("    Kapağı dikkatlice açıyorsun...", UI.BASLIK, 25);
                UI.Bekle(400);

                if (OyunMotoru.Rng.Next(100) < OyunMotoru.DIKKATLI_ACMA_BASARI_ORANI)
                {
                    HazineBul(oda.HazineDegeri);
                }
                else
                {
                    HazineTuzak(oda.HazineDegeri / 2);
                }
                break;

            case 2: // Hızlı açma
                UI.AnimasyonluYaz("    Sandığa koşuyorsun ve kapağı açıyorsun!", UI.UYARI, 18);
                UI.Bekle(300);

                if (OyunMotoru.Rng.Next(100) < OyunMotoru.HIZLI_ACMA_BASARI_ORANI)
                {
                    int bonusIyilesme = (int)(oda.HazineDegeri * OyunMotoru.HIZLI_ACMA_BONUS);
                    HazineBul(bonusIyilesme);
                }
                else
                {
                    HazineTuzak(oda.HazineDegeri);
                }
                break;

            case 3: // Dokunma
                UI.Satir("    Sandığa dokunmadan yanından geçtin.", UI.SOLUK);
                UI.Satir("    Bazen en iyi hamle hamle yapmamaktır.", UI.SOLUK);
                break;
        }
    }

    static void HazineBul(int miktar)
    {
        int eskiCan = oyuncu.Can;
        oyuncu.Can += miktar;
        int gercek = oyuncu.Can - eskiCan;

        OyunMotoru.BulunanHazine++;

        UI.YanipSonenMesaj($"+{gercek} HP  İyileşme İksiri!", UI.BASARI);
        UI.Satir($"    HP: {eskiCan} -> {oyuncu.Can}/{oyuncu.MaxCan}", UI.ACIKLAMA);
    }

    static void HazineTuzak(int miktar)
    {
        UI.Satir("    TUZAK! Sandıktan zehirli gaz çıktı!", UI.UYARI);
        UI.Bekle(200);

        int eskiCan = oyuncu.Can;
        oyuncu.Can -= miktar;

        UI.YanipSonenMesaj($"-{miktar} HP  Zehirli Gaz!", UI.UYARI);
        UI.Satir($"    HP: {eskiCan} -> {oyuncu.Can}/{oyuncu.MaxCan}", UI.ACIKLAMA);
    }

    // ═══════════════════════════════════════════════════════
    // SAVAŞ SİSTEMİ (Savunma düzeltilmiş)
    // ═══════════════════════════════════════════════════════
    static void SavasBaslat(Dusman dusman, bool isBoss)
    {
        int tur = 0;
        bool savunma = false;
        // karsiSaldiri'yi burada sıfırlama - Tahir'in iksir bonusu kaybolur!

        // Savaş logu - son 3 aksiyonu göster
        List<string> savasLogu = new List<string>();

        UI.EnterBekle();

        while (!oyuncu.Oldu && !dusman.Oldu)
        {
            tur++;
            OyunMotoru.ToplamTur++;
            savunma = false;

            SavasEkraniCiz(dusman, tur, isBoss, savasLogu);

            int secim = SaldiriSec();

            int oyuncuHasar = 0;
            string saldiriAdi = "";

            switch (secim)
            {
                case 1: // Normal saldırı
                    oyuncuHasar = oyuncu.Saldir();
                    if (karsiSaldiri)
                    {
                        oyuncuHasar = (int)(oyuncuHasar * OyunMotoru.KARSI_SALDIRI_BONUS);
                        saldiriAdi = oyuncu.SaldiriAdi() + " (KARSI SALDIRI!)";
                        karsiSaldiri = false;
                    }
                    else
                    {
                        saldiriAdi = oyuncu.SaldiriAdi();
                    }
                    break;

                case 2: // Savunma
                    savunma = true;
                    karsiSaldiri = true;
                    saldiriAdi = "Savunma + Karşı Saldırı Hazırlıyor!";
                    break;

                case 3: // Özel saldırı
                    oyuncuHasar = oyuncu.OzelSaldir();
                    if (karsiSaldiri)
                    {
                        oyuncuHasar = (int)(oyuncuHasar * OyunMotoru.KARSI_SALDIRI_BONUS);
                        saldiriAdi = oyuncu.OzelSaldiriAdi() + " (KARSI!)";
                        karsiSaldiri = false;
                    }
                    else
                    {
                        saldiriAdi = oyuncu.OzelSaldiriAdi();
                    }
                    ozelBekleme = OyunMotoru.OzelBekleme;
                    break;
            }

            // Oyuncu aksiyonu
            if (secim != 2)
            {
                // Kritik vuruş kontrolü
                bool kritikVurus = OyunMotoru.Rng.Next(100) < oyuncu.KritikSans();
                if (kritikVurus)
                {
                    oyuncuHasar *= 2;
                    saldiriAdi += " ★ KRİTİK! ★";
                }

                SaldiriAnimasyonu(oyuncu.Ad, saldiriAdi, oyuncuHasar, oyuncu.Renk());
                dusman.HasarAl(oyuncuHasar);
                OyunMotoru.HasarKaydet(oyuncuHasar);
                savasLogu.Add($"Tur {tur}: {oyuncu.Ad} → {saldiriAdi} (-{oyuncuHasar} HP)");
            }
            else
            {
                Console.WriteLine();
                UI.CerceveUst(UI.SAVUNMA);
                UI.CerceveSatir($"{oyuncu.Ad} savunma pozisyonu aldı!", UI.SAVUNMA, UI.SAVUNMA);
                UI.CerceveSatir("Hasar -%75 | Sonraki saldırı +%50!", UI.SAVUNMA, UI.ACIKLAMA);
                UI.CerceveAlt(UI.SAVUNMA);
                UI.Bekle(600);
                savasLogu.Add($"Tur {tur}: {oyuncu.Ad} → Savunma pozisyonu");
            }

            if (dusman.Oldu)
            {
                UI.Bekle(400);
                break;
            }

            UI.Bekle(500);

            // Düşman saldırısı - Boss AI
            int dusmanHasar;
            string dusmanSaldiri;

            // Boss HP %30 altındaysa özel saldırı yap
            if (isBoss && dusman.Can <= (dusman.MaxCan * 0.3))
            {
                dusmanHasar = dusman.OzelSaldir();
                dusmanSaldiri = dusman.OzelSaldiriAdi() + " (ÖFKELENDİ!)";
            }
            else
            {
                dusmanHasar = dusman.Saldir();
                dusmanSaldiri = dusman.SaldiriAdi();
            }

            // Kritik vuruş kontrolü (düşman için)
            bool dusmanKritik = OyunMotoru.Rng.Next(100) < dusman.KritikSans();
            if (dusmanKritik)
            {
                dusmanHasar *= 2;
                dusmanSaldiri += " ★ KRİTİK! ★";
            }

            // Savunma varsa ham hasarı azalt, sonra zırh devreye girecek
            if (savunma)
            {
                dusmanHasar = (int)(dusmanHasar * (1 - OyunMotoru.SAVUNMA_AZALTMA));
            }

            // Oyuncunun zırhı da devreye girer (HasarAl metodu)
            int oncekiCan = oyuncu.Can;
            oyuncu.HasarAl(dusmanHasar);
            int gercekHasar = oncekiCan - oyuncu.Can;

            SaldiriAnimasyonu(dusman.Ad, dusmanSaldiri, gercekHasar, dusman.Renk());
            savasLogu.Add($"Tur {tur}: {dusman.Ad} → {dusmanSaldiri} (-{gercekHasar} HP)");

            if (savunma)
            {
                UI.Satir("    >> Savunma hasarı %75 azalttı!", UI.SAVUNMA);
                UI.Satir("    >> Sonraki saldırın %50 daha güçlü!", UI.BASLIK);
            }

            if (ozelBekleme > 0) ozelBekleme--;

            UI.Bekle(600);
        }

        // Savaş sonu
        if (!oyuncu.Oldu)
        {
            OyunMotoru.YenilenDusman++;
            Console.WriteLine();
            UI.CerceveUst(UI.BASARI);
            UI.CerceveSatir($"{dusman.Ad} yenildi!", UI.BASARI, UI.BASARI);
            UI.CerceveAlt(UI.BASARI);
            UI.Bekle(400);
        }
    }

    // ═══════════════════════════════════════════════════════
    // SAVAŞ EKRANI
    // ═══════════════════════════════════════════════════════
    static void SavasEkraniCiz(Dusman dusman, int tur, bool isBoss, List<string>? log = null)
    {
        UI.Temizle();
        Console.WriteLine();

        UI.HaritaCiz(zindanOdalari.Count, OyunMotoru.OdaSayisi);
        Console.WriteLine();

        ConsoleColor cerceve = isBoss ? UI.BOSS_RENK : UI.CERCEVE;
        string baslikText = isBoss ? "BOSS SAVASI" : "SAVAS";

        UI.CerceveUst(cerceve);
        UI.CerceveSatir($"<< {baslikText} >>                    Tur: {tur}", cerceve, UI.BASLIK);
        UI.CerceveCizgi(cerceve);

        // Oyuncu HP
        UI.CanBariCiz(oyuncu.Ad, oyuncu.Can, oyuncu.MaxCan, oyuncu.Renk(), cerceve);

        UI.CerceveSatir("                   - VS -", cerceve, UI.CERCEVE);

        // Düşman HP
        string dusmanLabel = isBoss ? $"{dusman.Ad} [BOSS]" : dusman.Ad;
        UI.CanBariCiz(dusmanLabel, dusman.Can, dusman.MaxCan, dusman.Renk(), cerceve);

        UI.CerceveAlt(cerceve);

        // Karşı saldırı aktif bildirimi
        if (karsiSaldiri)
        {
            Console.WriteLine();
            UI.Satir("    >> KARŞI SALDIRI AKTİF! Sonraki saldırın +%50!", UI.BASLIK);
        }

        // Savaş logu - son 3 aksiyonu göster
        if (log != null && log.Count > 0)
        {
            Console.WriteLine();
            UI.Satir("    ── Son Aksiyonlar ──", UI.SOLUK);
            int baslangic = Math.Max(0, log.Count - 3);
            for (int i = baslangic; i < log.Count; i++)
            {
                UI.Satir($"    {log[i]}", UI.SOLUK);
            }
        }
    }

    // ═══════════════════════════════════════════════════════
    // SALDIRI SEÇİMİ
    // ═══════════════════════════════════════════════════════
    static int SaldiriSec()
    {
        Console.WriteLine();
        UI.Yaz("    [1]", ConsoleColor.White);
        Console.Write(" Saldır    ");
        UI.Yaz("[2]", UI.SAVUNMA);
        Console.Write(" Savun    ");

        bool ozelHazir = ozelBekleme <= 0;
        if (ozelHazir)
        {
            UI.Yaz("[3]", UI.OZEL);
            Console.WriteLine(" Özel Güç");
        }
        else
        {
            UI.Satir($"[3] Özel Güç ({ozelBekleme} tur)", UI.SOLUK);
        }

        Console.WriteLine();

        int secim = 0;
        while (true)
        {
            Console.Write("    Secimin: ");
            string girdi = Console.ReadLine();

            if (int.TryParse(girdi, out secim))
            {
                if (secim >= 1 && secim <= 2) break;
                if (secim == 3 && ozelHazir) break;
                if (secim == 3 && !ozelHazir)
                    UI.Satir($"    Özel güç {ozelBekleme} tur sonra!", UI.SOLUK);
            }
            else
            {
                UI.Satir("    Geçersiz! 1, 2 veya 3 seç.", UI.UYARI);
            }
        }
        return secim;
    }

    // ═══════════════════════════════════════════════════════
    // SALDIRI ANİMASYONU
    // ═══════════════════════════════════════════════════════
    static void SaldiriAnimasyonu(string saldiran, string saldiriAdi, int hasar, ConsoleColor renk)
    {
        Console.WriteLine();
        Console.Write("    ");
        UI.Yaz(saldiran, renk);
        Console.Write(" >> ");
        UI.AnimasyonluYaz(saldiriAdi, renk, 12);

        Thread.Sleep(200);
        UI.YanipSonenMesaj($"-{hasar} HASAR!", UI.UYARI);
    }

    // ═══════════════════════════════════════════════════════
    // DİYALOG GÖSTERİCİ
    // ═══════════════════════════════════════════════════════
    static void DiyalogGoster(string konusmaci, string[] cumleler, ConsoleColor renk)
    {
        foreach (string cumle in cumleler)
        {
            if (!string.IsNullOrEmpty(konusmaci))
            {
                Console.Write("    ");
                UI.Yaz($"[{konusmaci}]: ", renk);
            }
            else
            {
                Console.Write("    ");
            }
            UI.AnimasyonluYaz(cumle, UI.ACIKLAMA, 18);
            UI.Bekle(200);
        }
    }

    // ═══════════════════════════════════════════════════════
    // SONUÇ EKRANI
    // ═══════════════════════════════════════════════════════
    static void SonucEkrani()
    {
        UI.Temizle();
        Console.WriteLine();

        if (!oyuncu.Oldu)
            ZaferAnimasyonu();
        else
            YenilgiAnimasyonu();

        // ── MACERA İSTATİSTİKLERİ (LINQ) ──
        Console.WriteLine();
        UI.CerceveUst(ConsoleColor.Cyan);
        UI.CerceveSatir("MACERA İSTATİSTİKLERİ", ConsoleColor.Cyan, ConsoleColor.Cyan);
        UI.CerceveCizgi(ConsoleColor.Cyan);

        var g = OyunMotoru.HasarGecmisi;

        UI.CerceveSatir($"Geçilen Oda:      {OyunMotoru.OdaSayisi}/{zindanOdalari.Count}", ConsoleColor.Cyan, UI.ACIKLAMA);
        UI.CerceveSatir($"Yenilen Düşman:   {OyunMotoru.YenilenDusman}", ConsoleColor.Cyan, UI.ACIKLAMA);
        UI.CerceveSatir($"Bulunan Hazine:   {OyunMotoru.BulunanHazine}", ConsoleColor.Cyan, UI.ACIKLAMA);
        UI.CerceveSatir($"Toplam Tur:       {OyunMotoru.ToplamTur}", ConsoleColor.Cyan, UI.ACIKLAMA);

        if (g.Count > 0)
        {
            UI.CerceveCizgi(ConsoleColor.Cyan);

            // GÜN 39: LINQ
            int toplam = g.Sum();
            double ort = g.Average();
            int max = g.Max();
            int min = g.Min();

            UI.CerceveSatir($"Toplam Hasar:     {toplam}", ConsoleColor.Cyan, UI.ACIKLAMA);
            UI.CerceveSatir($"Ortalama Hasar:   {ort:F1}", ConsoleColor.Cyan, UI.ACIKLAMA);
            UI.CerceveSatir($"En Güçlü Saldırı: {max}", ConsoleColor.Cyan, UI.ACIKLAMA);
            UI.CerceveSatir($"En Zayıf Saldırı: {min}", ConsoleColor.Cyan, UI.ACIKLAMA);

            var top3 = g.OrderByDescending(h => h).Take(3).ToList();
            UI.CerceveSatir($"En Güçlü 3:       {string.Join(", ", top3)}", ConsoleColor.Cyan, UI.BASLIK);
        }

        UI.CerceveAlt(ConsoleColor.Cyan);

        // ── KARNE ──
        Console.WriteLine();
        UI.CerceveUst(UI.BASLIK);
        UI.CerceveSatir("40 GUNDE C# - KARNE", UI.BASLIK, UI.BASLIK);
        UI.CerceveCizgi(UI.BASLIK);

        string[] konular = new string[]
        {
            "Gün 01-02: Değişkenler & Veri Tipleri",
            "Gün 03:    Operatörler",
            "Gün 04:    Modülüs",
            "Gün 05:    Var & Const",
            "Gün 06:    if / else / else if",
            "Gün 07:    Logical Operators (&&, ||, !)",
            "Gün 08:    Switch Case",
            "Gün 09:    Döngüler (for, while, foreach)",
            "Gün 10:    Ternary Operatörü",
            "Gün 11-12: ToString & TryParse",
            "Gün 13:    Math Kütüphanesi",
            "Gün 14:    Null & Nullable Types",
            "Gün 15-17: String İşlemleri",
            "Gün 18-21: String Metotları",
            "Gün 22:    Escape Sequences & Verbatim",
            "Gün 23-25: Arrays",
            "Gün 26:    Lists",
            "Gün 27:    2D Arrays",
            "Gün 28:    Dictionary",
            "Gün 29:    Entry Point",
            "Gün 30-31: Return Types & Overloading",
            "Gün 32-33: Class, Object, Constructor",
            "Gün 34:    Encapsulation",
            "Gün 35:    Inheritance",
            "Gün 36:    Polymorphism",
            "Gün 37:    Abstract & Interface",
            "Gün 38:    Static",
            "Gün 39:    LINQ"
        };

        foreach (string konu in konular)
        {
            UI.CerceveSatir($"[+] {konu}", UI.BASLIK, UI.BASARI);
            Thread.Sleep(50);
        }

        UI.CerceveCizgi(UI.BASLIK);
        UI.CerceveSatir("40 günde C# öğrendik ve bir RPG yaptık!", UI.BASLIK, UI.BASLIK);
        UI.CerceveSatir("Seriyi takip ettiğin için teşekkürler!", UI.BASLIK, UI.BASLIK);
        UI.CerceveCizgi(UI.BASLIK);
        UI.CerceveSatir("@thejarrus  |  Novament Games", UI.BASLIK, UI.SOLUK);
        UI.CerceveSatir("github.com/thejarrus/40DaysOfCSharp", UI.BASLIK, UI.SOLUK);
        UI.CerceveAlt(UI.BASLIK);

        UI.EnterBekle();
    }

    // ═══════════════════════════════════════════════════════
    // ZAFER
    // ═══════════════════════════════════════════════════════
    static void ZaferAnimasyonu()
    {
        ConsoleColor[] renkler = { UI.BASLIK, UI.UYARI, ConsoleColor.Cyan };

        for (int t = 0; t < 3; t++)
        {
            UI.Temizle();
            Console.WriteLine();
            ConsoleColor renk = renkler[t % renkler.Length];
            UI.ArtCiz(ART_ZAFER, renk, 6, 0);
            Thread.Sleep(350);
        }

        UI.Temizle();
        Console.WriteLine();
        UI.ArtCiz(ART_ZAFER, UI.BASLIK, 6, 0);
        Console.WriteLine();

        // Tamamlanmış harita
        UI.HaritaCiz(zindanOdalari.Count, zindanOdalari.Count + 1);
        Console.WriteLine();

        UI.Yaz($"    {oyuncu.Ad}", oyuncu.Renk());
        Console.Write(" zindanı temizledi! ");
        UI.Satir("Karanlık sona erdi!", UI.BASARI);
        UI.Satir($"    Kalan HP: {oyuncu.Can}/{oyuncu.MaxCan}", UI.ACIKLAMA);
    }

    // ═══════════════════════════════════════════════════════
    // YENİLGİ
    // ═══════════════════════════════════════════════════════
    static void YenilgiAnimasyonu()
    {
        UI.ArtCiz(ART_YENILGI, UI.BOSS_RENK, 6, 80);
        Console.WriteLine();

        UI.HaritaCiz(zindanOdalari.Count, OyunMotoru.OdaSayisi);
        Console.WriteLine();

        UI.Yaz($"    {oyuncu.Ad}", oyuncu.Renk());
        UI.Satir($" zindanın {OyunMotoru.OdaSayisi}. odasında düştü...", UI.ACIKLAMA);
        UI.Satir("    Ama her yenilgi, yeni bir başlangıçtır.", UI.SOLUK);
    }
}
