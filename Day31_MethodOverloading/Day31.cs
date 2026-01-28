using System;

class SavasMotoru
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- METHOD OVERLOADING SİSTEMİ ---");

        // 1. İmzaya göre otomatik seçim
        Vur(10);                             // Sadece hasar
        Vur(15, "Efsanevi Kılıç");          // Hasar + Silah
        Vur(20, "Ateş Asası", true);        // Hasar + Silah + Kritik

        Console.Read();
    }

    // 1. VARYASYON: Temel Hasar
    static void Vur(int hasar)
    {
        Console.WriteLine($"💥 Düşmana {hasar} birim hasar verildi.");
    }

    // 2. VARYASYON: Silahlı Saldırı
    static void Vur(int hasar, string silah)
    {
        Console.WriteLine($"⚔️ {silah} kullanılarak {hasar} hasar verildi.");
    }

    // 3. VARYASYON: Kritik Vuruş Mekaniği
    static void Vur(int hasar, string silah, bool kritik)
    {
        if (kritik) 
        {
            hasar *= 2;
            Console.WriteLine($"🔥 KRİTİK! {silah} ile {hasar} hasar verildi!");
        }
        else 
        {
            Vur(hasar, silah); // 2. metodu tekrar çağırarak kod tekrarını önlüyoruz
        }
    }
}
