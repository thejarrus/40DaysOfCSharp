using System;

class Program
{
    static void Main()
    {
        string bos1 = "";
        string bos2 = String.Empty;

        Console.WriteLine(bos1 == bos2); // True

        string a = "Merhaba";
        string b = "merhaba";

        // == operatörü
        Console.WriteLine(a == b); // False

        // String.Equals
        Console.WriteLine(a.Equals(b)); // False
    Console.WriteLine(a.Equals(b, StringComparison.OrdinalIgnoreCase)); // True

    }
}




















