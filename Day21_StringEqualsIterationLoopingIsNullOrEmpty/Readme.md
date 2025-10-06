# 40 Days of C# — Gün 21

## Konular
- `string.Equals`
- String üzerinde döngüleme (indeks ve `foreach`)
- `string.IsNullOrEmpty`

## Örnek 1 — Eşitlik: `string.Equals`
using System;

class Program
{
    static void Main()
    {
        Console.Write("İlk metin: ");
        string a = Console.ReadLine() ?? "";

        Console.Write("İkinci metin: ");
        string b = Console.ReadLine() ?? "";

        if (string.Equals(a, b, StringComparison.Ordinal))
            Console.WriteLine("Eşit");
        else
            Console.WriteLine("Eşit değil");
    }
}

## Örnek 2 — String üzerinde döngüleme
string s = Console.ReadLine() ?? "";

// indeks ile
for (int i = 0; i < s.Length; i++)
{
    char c = s[i];
    Console.Write(c);
}
Console.WriteLine();

// foreach ile
foreach (char c in s)
{
    Console.Write(c);
}
Console.WriteLine();

## Örnek 3 — Boş kontrolü: `string.IsNullOrEmpty`
Console.Write("Kullanıcı adı: ");
string user = Console.ReadLine();

if (string.IsNullOrEmpty(user))
{
    Console.WriteLine("Kullanıcı adı boş olamaz.");
    return;
}
Console.WriteLine($"Merhaba, {user}");

## Notlar
- `StringComparison.Ordinal` kültürden bağımsız karşılaştırma yapar.
- `x.Equals(string.Empty)` null olduğunda hata verir; `string.IsNullOrEmpty(x)` güvenlidir.
