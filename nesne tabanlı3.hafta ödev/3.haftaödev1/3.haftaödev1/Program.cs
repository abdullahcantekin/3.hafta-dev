using System;
using System.Linq;

class Program
{
    static void Main()
    {
        #region
        // Kullanıcıdan tam sayıları girmesini ister (virgülle ayırarak)
        Console.Write("Tam sayıları girin (virgülle ayırarak): ");

        // Girilen sayıları virgüle göre ayırarak diziye dönüştür ve tam sayıya çevir
        int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        // Diziyi küçükten büyüğe sıralar
        Array.Sort(numbers);

        // Kullanıcıdan aranacak sayıyı girmesini ister
        Console.Write("Aranacak sayıyı girin: ");
        int target;

        // Kullanıcı girişini kontrol eder, eğer sayı değilse tekrar girmesini ister
        while (!int.TryParse(Console.ReadLine(), out target))
        {
            Console.WriteLine("Geçersiz giriş. Lütfen bir tam sayı girin: ");
        }

        // İkili arama fonksiyonu ile sayının dizide olup olmadığını kontrol eder
        bool found = BinarySearch(numbers, target);

        // Sonucu ekrana yazar; sayı bulunduysa "mevcut", bulunamadıysa "bulunamadı" yazdırır
        Console.WriteLine(found ? "Sayı dizide mevcut." : "Sayı dizide bulunamadı.");
    }

    // İkili arama fonksiyonu: Dizide hedef sayıyı arar
    static bool BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1; // Başlangıç ve bitiş indekslerini ayarla

        // Başlangıç indeks soldan sağa doğru, bitiş indeks ise sağdan sola doğru ilerler
        while (left <= right)
        {
            // Orta elemanı hesapla
            int mid = left + (right - left) / 2;

            // Eğer orta eleman hedef sayıya eşitse, bulundu
            if (arr[mid] == target) return true;

            // Eğer hedef sayı ortadakinden büyükse, sol kısmı atla
            if (arr[mid] < target) left = mid + 1;

            // Hedef sayı ortadakinden küçükse, sağ kısmı atla
            else right = mid - 1;
        }

        // Sayı bulunamazsa false döndür
        return false;
        #endregion
    }
}
