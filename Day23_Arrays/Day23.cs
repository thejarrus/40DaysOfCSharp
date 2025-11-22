using System;

class Program
{
    static void Main()
    {
        string[] isimler = { "Yiğit", "Burak", "Sena", "Zeynep", "Melek0" };
        int[] notlar = { 90, 85, 65, 92, 88 };

        for (int i = 0; i < isimler.Length; i++)
        {
            string durum = notlar[i] >= 70 ? "Geçti" : "Kaldı";
            Console.WriteLine($"{isimler[i]}: {notlar[i]} - {durum}");
        }

        int enYuksekNot = notlar[0];
        string enBasariliOgrenci = isimler[0];

        for (int i = 1; i < notlar.Length; i++)
        {
            if (notlar[i] > enYuksekNot)
            {
                enYuksekNot = notlar[i];
                enBasariliOgrenci = isimler[i];
            }
        }
        Console.WriteLine($"\nEn başarılı öğrenci: {enBasariliOgrenci} - Notu: {enYuksekNot}");
    }
}
