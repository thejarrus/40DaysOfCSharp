# 📌 Day 15 – Verbatim String Literal (@) ile Uzun Metinler

## 🎯 Amaç  
C#’ta `verbatim string literal` özelliğini öğrenmek.  
Bu özellik, **dosya yolları** ve **uzun metinler** ile çalışırken kaçış karakterlerini (`\n`, `\\` vb.) kullanma zorunluluğunu ortadan kaldırır. Ayrıca **çok satırlı stringler** yazmayı da kolaylaştırır.

---

## 📖 Konsept  
Normal bir string içinde `\` gibi karakterleri yazmak için `\\` şeklinde kullanmak gerekir.  
Örneğin:  

```csharp
string yol = "C:\\Users\\Bro";
