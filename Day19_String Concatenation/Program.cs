class Program {

    static void Main(string[] args)
    {
        string ad = "Ali";
        string soyad = "Yılmaz";

        string tamIsim = ad + " " + soyad;

        Console.WriteLine(tamIsim);

        string mesaj = "Hoş geldin " + ad + "! Bugün günlerden " + DateTime.Now.DayOfWeek;
        Console.WriteLine(mesaj);

    }
}