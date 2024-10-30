using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = GetNumbersFromUser(); // Kullanıcıdan sayıları al
        List<string> ranges = FindConsecutiveRanges(numbers); // Ardışık grupları bul

        // Ardışık sayı gruplarını ekrana yazdır
        Console.WriteLine("Ardışık gruplar:");
        foreach (string range in ranges)
        {
            Console.WriteLine(range);
        }
    }

    // Kullanıcıdan pozitif tam sayıları alır ve liste olarak döndürür
    static List<int> GetNumbersFromUser()
    {
        List<int> numbers = new List<int>();
        int input;

        // Kullanıcıdan sayıları almaya devam eder; 0 girildiğinde durur
        do
        {
            Console.Write("Pozitif bir tam sayı girin (Çıkmak için 0): ");
            input = int.Parse(Console.ReadLine());
            if (input > 0) numbers.Add(input); // Pozitif girişleri listeye ekle
        } while (input != 0);

        numbers.Sort(); // Sayıları sıralar
        return numbers;
    }

    // Ardışık sayı gruplarını bulan ve bir liste olarak döndüren fonksiyon
    static List<string> FindConsecutiveRanges(List<int> numbers)
    {
        List<string> ranges = new List<string>(); // Sonuçları saklamak için liste
        int i = 0;

        // Listedeki tüm elemanları kontrol eder
        while (i < numbers.Count)
        {
            int start = numbers[i]; // Grubun başlangıç sayısını al
            while (i < numbers.Count - 1 && numbers[i] + 1 == numbers[i + 1]) // Ardışık sayıları bul
            {
                i++; // Ardışık olan bir sonraki sayıya geç
            }
            int end = numbers[i]; // Grubun bitiş sayısını al

            // Tek sayılık grupsa sadece sayıyı ekle; değilse başlangıç ve bitişi ekle
            ranges.Add(start == end ? $"{start}" : $"{start}-{end}");
            i++; // Sonraki sayıya geç
        }

        return ranges;
    }
}
