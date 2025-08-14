Day 14: FizzBuzz Challenge

Bu klasörde C# dilinde klasik bir programlama mülakat sorusu olan FizzBuzz problemini çözme örneğini bulabilirsiniz. Kod, hem sabit limitli hem de kullanıcının belirlediği limite göre çalışabilecek şekilde tasarlanmıştır.

📌 Konular

for döngüsü ile sayılar üzerinde iterasyon

if, else if ve else koşullarıyla kontrol yapıları

Mod alma (%) operatörünün kullanımı

Birden fazla koşulun birlikte kontrol edilmesi (mantıksal operatörler)

Kullanıcıdan veri alma (Console.ReadLine()) ve tip dönüşümü (int.Parse())

Kodun esnek hale getirilmesi (kullanıcı limit girişi)

💻 Örnek Kod
Console.Write("Limiti girin: ");
int limit = int.Parse(Console.ReadLine());

for (int i = 1; i <= limit; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
        Console.WriteLine("FizzBuzz");
    else if (i % 3 == 0)
        Console.WriteLine("Fizz");
    else if (i % 5 == 0)
        Console.WriteLine("Buzz");
    else
        Console.WriteLine(i);
}

📖 Açıklama

i % 3 == 0 ifadesi, sayının 3’e tam bölünüp bölünmediğini kontrol eder.

i % 5 == 0 ifadesi, sayının 5’e tam bölünüp bölünmediğini kontrol eder.

Öncelikle hem 3’e hem 5’e bölünenler (i % 3 == 0 && i % 5 == 0) kontrol edilir, çünkü aksi halde bu sayılar tek tek Fizz veya Buzz olarak yazdırılır.

Kullanıcı istediği limiti girerek programı farklı aralıklarla çalıştırabilir.
