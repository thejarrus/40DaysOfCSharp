using System;

class Program
{
    // Global bir değişken (Karakterin canı)
    static int playerHealth = 100;

    static void Main(string[] args)
    {
        Console.WriteLine("--- SAVAS BASLADI ---");

        // Metodu sadece ismini söyleyerek çağırıyoruz
        ApplyDamage(20); 
        ApplyDamage(15);
        
        HealPlayer(); // Parametresiz kullanım

        Console.WriteLine($"\nFinal Can Durumu: {playerHealth}");
        Console.Read();
    }

    // VOID METOT: Geriye bir şey döndürmez (sadece iş yapar)
    // PARAMETRELİ: Dışarıdan 'damageAmount' verisi alır
    static void ApplyDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Console.WriteLine($"💥 Hasar Alındı: {damageAmount} | Kalan Can: {playerHealth}");
    }

    // VOID METOT: Parametresiz kullanım
    static void HealPlayer()
    {
        playerHealth += 10;
        Console.WriteLine("💚 İksir İçildi! +10 Can eklendi.");
    }
}
