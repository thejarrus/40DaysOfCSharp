using System;
using System.Collections.Generic; // Dictionary için şart!

class Program
{
    static void Main(string[] args)
    {
        // GÜN 28: DICTIONARY (SÖZLÜK) YAPISI
        // Senaryo: RPG Oyun Envanteri (Eşya Adı -> Adet)
        
        // <Anahtar (Key), Değer (Value)>
        Dictionary<string, int> envanter = new Dictionary<string, int>();

        // 1. Eşyaları Çantaya Ekleme
        envanter.Add("Can İksiri", 5);
        envanter.Add("Mana İksiri", 2);
        envanter.Add("Efsanevi Kılıç", 1);

        Console.WriteLine("\n\t--- ÇANTA İÇERİĞİ ---\n");

        // 2. Bir eşyaya erişmek (İsmiyle Çağırmak)
        // Listelerdeki envanter[0] yerine envanter["Key"] kullanıyoruz.
        if (envanter.ContainsKey("Can İksiri"))
        {
            int adet = envanter["Can İksiri"];
            Console.WriteLine($"🧪 Can İksiri Sayısı: {adet}");
        }

        // 3. Eşya Kullanma (Değeri Değiştirme)
        Console.WriteLine("\n... Bir tane Can İksiri içildi ...\n");
        envanter["Can İksiri"] = envanter["Can İksiri"] - 1; // 5 -> 4 oldu.

        // 4. Tüm Çantayı Listeleme (Foreach)
        // KeyValuePair: Hem anahtarı hem değeri tutan yapı
        foreach (var esya in envanter)
        {
            Console.WriteLine($"📦 Eşya: {esya.Key} \t| Adet: {esya.Value}");
        }

        Console.Read();
    }
}
