using System;

class Program
{
    static void Main()
    {
        // Normal string (kaçış karakteri gerekiyor)
        string yol1 = "C:\\Users\\Bro\\Desktop";

        // Verbatim string (kaçış gerekmez)
        string yol2 = @"C:\Users\Bro\Desktop";

        Console.WriteLine("Normal string: " + yol1);
        Console.WriteLine("Verbatim string: " + yol2);

        // Çok satırlı metin
        string metin = @"Merhaba!
Bu C# verbatim string örneğidir.
Uzun metinleri daha okunabilir yapar.";

        Console.WriteLine(metin);
    }
}
