using System;

namespace Gun32_SiniflarVeNesneler
{
    // 1. SINIF TANIMI (KALIP)
    // Sınıf isimleri genellikle PascalCase (Büyük harfle başlar) yazılır.
    class Oyuncu
    {
        // Alanlar (Fields)
        // public: Bu değişkenlere sınıfın dışından erişilebileceğini belirtir.
        public int can = 100;
        public int hasar = 20;

        // Metotlar (Davranışlar)
        public void Saldir()
        {
            Console.WriteLine("⚔️ Saldırı yapıldı ve " + hasar + " hasar verildi!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 2. NESNE OLUŞTURMA (KOPYA)
            // 'Oyuncu' kalıbından 'oyuncu1' adında gerçek bir nesne yaratıyoruz.
            Oyuncu oyuncu1 = new Oyuncu();
            
            // 'oyuncu2' tamamen bağımsız bir başka nesnedir.
            Oyuncu oyuncu2 = new Oyuncu();

            // Nesne özelliklerini kullanma
            Console.WriteLine("--- OYUNCU İSTATİSTİKLERİ ---");
            Console.WriteLine("Oyuncu 1 Canı: " + oyuncu1.can);
            
            // Nesne metodunu çağırma
            oyuncu1.Saldir();

            // Nesnelerin bağımsız olduğunu kanıtlayalım:
            oyuncu2.can = 80; // Sadece oyuncu2'nin canını değiştirdik.
            
            Console.WriteLine("\nOyuncu 1'in canı hala: " + oyuncu1.can);
            Console.WriteLine("Oyuncu 2'nin yeni canı: " + oyuncu2.can);

            Console.ReadLine();
        }
    }
}
