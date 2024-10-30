using System; // Temel işlevler için System kütüphanesini ekler
using System.Collections.Generic; // Liste yapıları için gerekli kütüphaneyi ekler

class Program
{
    // Yönler dizisi: yukarı, aşağı, sola, sağa alır
    static readonly int[,] yönler = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

    static void Main()
    {
        #region
        int M = 5; // Labirentin satır sayısı
        int N = 5; // Labirentin sütun sayısı
        List<string> yol = new List<string>(); // Yol adımlarını saklamak için listeler

        // Başlangıç noktasından hedef noktaya yol bulur
        if (FindPath(0, 0, M - 1, N - 1, yol))
        {
            Console.WriteLine("Şehre ulaşan yol:");
            Console.WriteLine(string.Join(" -> ", yol)); // Yol adımlarını birleştirip yazdırır
        }
        else
        {
            Console.WriteLine("Şehir kayboldu!"); // Yol bulunamazsa mesaj
        }
    }

    // Koordinatlarda yol bulma fonksiyonu
    static bool FindPath(int x, int y, int hedefX, int hedefY, List<string> yol)
    {
        // Hedefe ulaşıldığında
        if (x == hedefX && y == hedefY)
        {
            yol.Add($"({x}, {y})"); // Hedef noktasını ekle
            return true; // Başarıyla hedefe ulaşıldı
        }

        // Geçerli hücre kontrolü
        if (!IsValidCell(x, y)) return false; // Geçerli değilse false döndür

        yol.Add($"({x}, {y})"); // Mevcut hücreyi yol adımlarına ekle

        // Her yönü kontrol et
        foreach (var yön in yönler)
        {
            // Yeni X ve Y koordinatlarını hesapla
            int yeniX = x + yön[0];
            int yeniY = y + yön[1];

            // Yeni koordinatta yol bul
            if (FindPath(yeniX, yeniY, hedefX, hedefY, yol)) return true; // Hedefe ulaşıldıysa
        }

        yol.RemoveAt(yol.Count - 1); // Hedefe ulaşılamazsa son adımı kaldır
        return false; // Yol bulunamadı
    }

    // Geçerli hücre kontrolü
    static bool IsValidCell(int x, int y)
    {
        // Labirentin sınırları
        if (x < 0 || y < 0 || x >= 5 || y >= 5) return false;
        // Hem x hem de y asal mı?
        if (!IsPrime(x) || !IsPrime(y)) return false;
        // Toplam çarpıma bölünebilir mi?
        return (x + y) % (x * y) == 0;
    }

    // Asal sayı kontrol fonksiyonu
    static bool IsPrime(int sayi)
    {
        if (sayi < 2) return false; // 2'den küçük sayılar asal değil
        for (int i = 2; i * i <= sayi; i++)
        {
            if (sayi % i == 0) return false; // Eğer bölen varsa asal değil
        }
        return true; // Sayı asaldır
#endregion
    }
}
