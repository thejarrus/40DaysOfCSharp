# 40 Days of C# — Gün 22

## Alıştırma 1 — String’i tersten yazdırma
Kısıt: Gün 22’ye kadar öğretilenler; dizi ve `Array.Reverse` yok.

using System;

class Program
{
    static void Main()
    {
        Console.Write("Metin: ");
        string message = Console.ReadLine() ?? "";

        // Üretim notu: boş girişi reddetmek için ileride şu kontrol eklenebilir:
        // if (string.IsNullOrWhiteSpace(message)) { Console.WriteLine("Metin boş olamaz."); return; }

        for (int i = message.Length - 1; i >= 0; i--)
            Console.Write(message[i]);

        Console.WriteLine();
    }
}

## Alıştırma 2 — Şifre denetleyici (eşleşme + boş kontrolü)

using System;

class Program
{
    static void Main()
    {
        Console.Write("Şifrenizi giriniz: ");
        string p1 = Console.ReadLine() ?? "";

        Console.Write("Şifrenizi tekrar giriniz: ");
        string p2 = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2))
        {
            Console.WriteLine("Lütfen şifre alanlarını boş bırakmayınız.");
            return;
        }

        if (string.Equals(p1, p2, StringComparison.Ordinal))
            Console.WriteLine("Şifreler eşleşti");
        else
            Console.WriteLine("Şifreler eşleşmedi");
    }
}

## İsteğe bağlı genişletme — Kurallı denetim (LINQ yok)
Kurallar: `>= 8` uzunluk, en az bir büyük harf, en az bir rakam.

Console.Write("Şifre: ");
string pwd = Console.ReadLine() ?? "";

if (string.IsNullOrEmpty(pwd))
{
    Console.WriteLine("Geçersiz: boş");
    return;
}

bool enoughLen = pwd.Length >= 8;
bool hasUpper  = false;
bool hasDigit  = false;

for (int i = 0; i < pwd.Length; i++)
{
    char c = pwd[i];
    if (c >= 'A' && c <= 'Z') hasUpper = true;
    if (c >= '0' && c <= '9') hasDigit = true;
}

if (enoughLen && hasUpper && hasDigit)
    Console.WriteLine("Geçerli şifre");
else
{
    Console.Write("Geçersiz: ");
    if (!enoughLen) Console.Write(">=8 ");
    if (!hasUpper)  Console.Write("BÜYÜK ");
    if (!hasDigit)  Console.Write("RAKAM ");
    Console.WriteLine();
}

## Test Senaryoları
- Ters yazdırma: `merhaba` → `abahrem`
- Şifre eşleşme: `Abc12345` + `Abc12345` → “Şifreler eşleşti”
- Şifre kuralları: `merhaba` → “Geçersiz: >=8 BÜYÜK RAKAM”
