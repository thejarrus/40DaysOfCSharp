using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your message: ");
        string message = Console.ReadLine() ?? "";

        for (int i = message.Length - 1; i >= 0; i--)
        {
            Console.Write(message[i]);
        }
        Console.WriteLine();
    }
}
