# 🧩 32. Gün: Sınıflar ve Nesneler (Classes & Objects)

Yazılım dünyasının en büyük dönüm noktasına hoş geldiniz: **Nesne Yönelimli Programlama (OOP)**. 

Bugün, kod kalabalığından kurtulup nasıl kendi "kalıplarımızı" (Sınıflar) oluşturacağımızı ve bu kalıplardan nasıl "kopyalar" (Nesneler) üreteceğimizi öğrendik.

### 🚀 Temel Kavramlar

1. **Sınıf (Class):** Bir nesnenin özelliklerini ve davranışlarını tanımlayan bir şablondur. Oyun dünyasındaki bir karakterin "mimari planı" gibidir.
2. **Nesne (Object):** Sınıftan türetilen somut örnektir. Plandan inşa edilen gerçek bir ev veya karakterdir.
3. **public Erişilebilirliği:** Bir sınıfın içindeki değişkenlere dışarıdan erişebilmemiz için `public` anahtar kelimesini kullanmamız gerekir.
4. **new Anahtar Kelimesi:** Bellekte yeni bir nesne örneği (instance) oluşturmak için kullanılır.



### 🎮 Örnek Senaryo
Bir savaş oyununda yüzlerce karakter için ayrı ayrı `can` ve `hasar` değişkeni tanımlamak yerine, bir `Oyuncu` sınıfı tanımlayıp tüm karakterleri bu tek kalıptan türetiyoruz.
