using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        #region
        // Kullanıcıdan pozitif tam sayıları alır
        List<int> numbers = GetNumbersFromUser();

        // Eğer liste boş değilse ortalama ve medyanı hesaplayıp yazdırır
        if (numbers.Count > 0)
        {
            Console.WriteLine($"Ortalama: {CalculateAverage(numbers)}"); // Ortalama hesapla ve göster
            Console.WriteLine($"Medyan: {CalculateMedian(numbers)}");   // Medyan hesapla ve göster
        }
        else
        {
            Console.WriteLine("Hiç pozitif sayı girilmedi."); // Hiç sayı girilmezse uyarı verir
        }
    }

    // Kullanıcıdan pozitif tam sayıları alır ve bir liste olarak döndürür
    static List<int> GetNumbersFromUser()
    {
        List<int> numbers = new List<int>(); // Sayıları saklamak için liste oluştur
        int input;

        // Kullanıcıdan sayıları almaya devam eder; 0 girildiğinde durur
        do
        {
            Console.Write("Pozitif bir tam sayı girin (Çıkmak için 0): "); // Kullanıcıdan giriş iste

            // Girişi doğrula ve tam sayıya çevir; yalnızca pozitifse listeye ekle
            if (int.TryParse(Console.ReadLine(), out input) && input > 0)
            {
                numbers.Add(input); // Pozitif giriş listeye eklenir
            }
            else if (input < 0 || !int.TryParse(Console.ReadLine(), out _)) // Negatif veya geçersiz girişte uyarı ver
            {
                Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
            }

        } while (input != 0); // 0 girildiğinde döngü sona erer

        return numbers; // Sayıların olduğu listeyi döndür
    }

    // Listenin ortalamasını hesaplar ve döndürür
    static double CalculateAverage(List<int> numbers)
    {
        return numbers.Average(); // Ortalama hesapla
    }

    // Listenin medyanını hesaplar ve döndürür
    static double CalculateMedian(List<int> numbers)
    {
        numbers.Sort(); // Listeyi küçükten büyüğe sıralar
        int count = numbers.Count; // Listenin eleman sayısını alır

        // Eleman sayısı tekse ortadaki elemanı döndürür, çiftse ortadaki iki elemanın ortalamasını alır
        return count % 2 != 0
            ? numbers[count / 2]
            : (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
        #endregion
    }
}





