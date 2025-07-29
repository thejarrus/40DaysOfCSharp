# 📅 Haftanın Günü Bulma Programı / Day of the Week Finder

Bu C# konsol uygulaması, kullanıcıdan bir gün ismi alır (örneğin: "pazartesi", "salı")  
ve haftanın kaçıncı günü olduğunu switch-case yapısıyla belirtir.  
Geçersiz bir gün girildiğinde kullanıcıyı bilgilendirir.

This C# console app asks the user to enter a day (e.g., "monday", "tuesday")  
and shows the corresponding day number of the week using a switch-case structure.  
It also warns the user if the entered value is invalid.

---

## 💻 Nasıl Çalışır? / How It Works

Kullanıcıdan bir gün ismi alınır → Küçük harfe çevrilir → `switch-case` ile eşleştirilir → Gerekli mesaj yazdırılır.

The user enters a day → Input is converted to lowercase → Matched via `switch-case` → Corresponding message is displayed.

---

## 🧪 Örnek Kullanım / Example Output

Bir gün girin:
salı
Haftanın 2. günü

Enter a day:
tuesday
Day 2 of the week


---

## 📌 Notlar / Notes

- C# `switch` ifadeleri büyük/küçük harf duyarlıdır.
- Bu yüzden `ToLower()` kullanılarak giriş normalize edilir.
- `default` bloğu sayesinde geçersiz girdilere karşı kullanıcı bilgilendirilir.

---

## 🧠 Öğrenilen Konular / Concepts Covered

- `switch-case` yapısı / switch-case structure  
- `Console.ReadLine()` ile veri alma / Taking input from user  
- `ToLower()` ile büyük-küçük harf kontrolü / Case normalization  
- `default` kullanımı / Default case handling

---

## 📅 Proje / Project

Bu proje [40 Günde C# Öğreniyorum](#) serisinin 8. gün videosuna aittir.  
This project is from **Day 8** of the [Learning C# in 40 Days](#) video series.

