using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Kullanıcıdan orijinal mesajı alır
        Console.Write("Orijinal mesajı girin: ");
        string mesaj = Console.ReadLine();

        // Şifreleme işlemini gerçekleştir ve sonuç olarak şifreli mesajı alır
        string sifreliMesaj = SifrelemeYap(mesaj);
        Console.WriteLine($"Şifreli Mesaj: {sifreliMesaj}");
    }

    // Şifreleme işlemini gerçekleştiren fonksiyondur
    static string SifrelemeYap(string mesaj)
    {
        // Mesajın uzunluğu kadar Fibonacci sayıları oluşturur
        var fibonacciSayilari = FibonacciOlustur(mesaj.Length);
        var sifreliMesaj = new List<char>();

        // Mesajdaki her karakter için döngü başlatır
        for (int i = 0; i < mesaj.Length; i++)
        {
            // Karakterin ASCII değeri ile Fibonacci sayısını çarpar
            int asciiDegeri = mesaj[i] * fibonacciSayilari[i];

            // Pozisyon asal ise mod 100, değilse mod 256 işlemi uygular
            int modSonuc = (AsalMi(i + 1)) ? asciiDegeri % 100 : asciiDegeri % 256;
            // Hesaplanan mod sonucunu karakter listesine ekler
            sifreliMesaj.Add((char)modSonuc);
        }

        // Listeyi bir string'e dönüştür ve döndürür
        return string.Concat(sifreliMesaj);
    }

    // Verilen uzunluk kadar Fibonacci dizisi oluşturan fonksiyon
    static List<int> FibonacciOlustur(int uzunluk)
    {
        // Fibonacci dizisini başlatır
        List<int> fibonacci = new List<int> { 1, 1 };

        // Fibonacci dizisini oluşturmak için döngüdür
        for (int i = 2; i < uzunluk; i++)
            fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);

        return fibonacci; // Oluşan Fibonacci dizisini döndür
    }

    // Bir sayının asal olup olmadığını kontrol eden fonksiyon
    static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false; // 0 ve 1 asal değildir
        // 2'den başlayarak sayının kareköküne kadar döngü
        for (int i = 2; i * i <= sayi; i++)
            if (sayi % i == 0) return false; // Eğer tam bölünüyorsa asal değildir
        return true; // Asal
    }
}

