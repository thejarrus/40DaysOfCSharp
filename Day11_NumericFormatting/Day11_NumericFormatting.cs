using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Terminalde '₺' gibi özel karakterlerin doğru görüntülenmesi için
        // konsolun çıkış kodlamasını UTF-8 olarak ayarlamak gerekir.
        Console.OutputEncoding = Encoding.UTF8;

        double sayi = 1234.5678;

        // .ToString("C") metodu, parametre verilmezse mevcut sistemin kültür ayarını kullanır.
        // Fiyatı Türk Lirası olarak formatlamak için "tr-TR" kültürünü belirtmelisiniz.
        Console.WriteLine("Para birimi:");
        Console.WriteLine(sayi.ToString("C", new CultureInfo("tr-TR")));  // ₺1.234,57 (veya $1,234.57)
        Console.WriteLine();

        Console.WriteLine("Binlik ayraç:");
        Console.WriteLine(sayi.ToString("N"));
        Console.WriteLine();

        Console.WriteLine("Sabit ondalik:");
        Console.WriteLine(sayi.ToString("F"));
        Console.WriteLine();

        Console.WriteLine("Yüzde:");
        Console.WriteLine(sayi.ToString("P"));
        Console.WriteLine();

        Console.WriteLine("Bilimsel gösterim:");
        Console.WriteLine(sayi.ToString("E"));
        Console.WriteLine();
        
    }
}
 