static int dusmanCani = 100;

static void Main(string[] args)
{
    // 1. ADIM: Veriyi metottan çekip bir değişkene hapsediyoruz.
    int hamHasar = HasarHesapla(); 

    // 2. ADIM: Veriyi elimize aldığımız için artık ona hükmedebiliriz.
    if (hamHasar > 15)
    {
        Console.WriteLine($"🎲 Zar: {hamHasar} | 🔥 MÜKEMMEL VURUŞ!");
        hamHasar *= 2; // Kritik vuruşsa veriyi modifiye et
        Console.WriteLine($"Hasar ikiye katlandı! Yeni Hasar: {hamHasar}");
    }

    dusmanCani -= hamHasar;
    Console.WriteLine($"❤️ Kalan Can: {dusmanCani}");
}

static int HasarHesapla()
{
    Random rnd = new Random();
    return rnd.Next(1, 21); // Raporu dışarı fırlat
}
