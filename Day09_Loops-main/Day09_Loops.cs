using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Basit for döngüsü: 1'den 10'a kadar sayıları yazdır
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("--------------------");

        // 2. for döngüsü ile 5 kez "Merhaba!" yazdır
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Merhaba!");
        }

        Console.WriteLine("--------------------");

        // 3. while döngüsü örneği
        int j = 0;
        while (j < 3)
        {
            Console.WriteLine("while döngüsü: " + j);
            j++;
        }

        Console.WriteLine("--------------------");

        // 4. do-while döngüsü örneği
        int k = 0;
        do
        {
            Console.WriteLine("do-while döngüsü: " + k);
            k++;
        } while (k < 3);

        Console.WriteLine("--------------------");

        // 5. 1’den 100’e kadar olan sayıların toplamı
        int toplam = 0;
        for (int i = 1; i <= 100; i++)
        {
            toplam += i;
        }
        Console.WriteLine("1'den 100'e kadar sayıların toplamı: " + toplam);

        Console.WriteLine("--------------------");

        // 6. Sonsuz döngü hatasına örnek (yorumlu)
        /*
        int a = 0;
        while (a < 5)
        {
            Console.WriteLine(a);
            // a++; // Yorum satırına alınırsa sonsuz döngü olur
        }
        */

        // 7. Kullanıcıdan giriş alarak yıldız bastırma
        Console.Write("Kaç yıldız bastırmak istersin?: ");
        string giris = Console.ReadLine();
        if (int.TryParse(giris, out int yildizSayisi))
        {
            for (int i = 0; i < yildizSayisi; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
        }
    }
}
