using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bir gün girin:");
        string gun = Console.ReadLine();
        gun = gun.ToLower();

        switch (gun)
        {
            case "pazartesi":
                Console.WriteLine("Haftanın 1. günü");
                break;

            case "salı":
                Console.WriteLine("Haftanın 2. günü");
                break;

            case "çarşamba":
                Console.WriteLine("Haftanın 3. günü");
                break;

            case "perşembe":
                Console.WriteLine("Haftanın 4. günü");
                break;

            case "cuma":
                Console.WriteLine("Haftanın 5. günü");
                break;

            case "cumartesi":
                Console.WriteLine("Haftanın 6. günü");
                break;

            case "pazar":
                Console.WriteLine("Haftanın 7. günü");
                break;

            default:
                Console.WriteLine("Geçersiz gün girdiniz.");
                break;    
        }
    }
}

