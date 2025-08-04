using System;

class Program
{
    static void Main(string[] args)
    {
        // 7. Kullanıcıdan giriş alarak yıldız bastırma
        Console.Write("Kaç yıldız bastırmak istersin?: ");
        string giris = Console.ReadLine();
        if (int.TryParse(giris, out int yildizSayisi))

        {
            for (int i = 0; i < yildizSayisi; i++)

            {
                Console.WriteLine("*");
            }
            Console.WriteLine();

        }

        else
        {
            Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
        }
    }
}
