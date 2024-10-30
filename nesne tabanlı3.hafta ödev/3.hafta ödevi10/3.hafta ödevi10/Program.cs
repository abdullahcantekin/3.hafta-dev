using System; // System kütüphanesini ekler

class Program
{
    static void Main()
    {
        #region
        // Sayı ve operatörleri saklamak için diziler oluşturur
        double[] sayilar = new double[10]; // Sayılar için dizi
        string[] operatörler = new string[9]; // Operatörler için dizi
        int sayiIndex = 0, operatörIndex = 0; // Dizilerin başlangıç indeksleri

        // Kullanıcıdan giriş alır
        while (true)
        {
            Console.Write("Bir sayı girin (çıkmak için 'exit' yazın): ");
            string input = Console.ReadLine();

            // Çıkış komutu kontrolüdür
            if (input.ToLower() == "exit") break;

            // Sayı girilmişse diziye ekler
            if (double.TryParse(input, out double sayi))
            {
                sayilar[sayiIndex++] = sayi; // Sayıyı dizinin ilgili indeksine ekler
            }
            else
            {
                Console.Write("Bir operatör girin (+, -, *, /): ");
                string operatör = Console.ReadLine(); // Operatör girişini alır

                // Operatör geçerli ve en az bir sayı varsa ekler
                if (IsValidOperator(operatör) && sayiIndex > operatörIndex)
                {
                    operatörler[operatörIndex++] = operatör; // Operatörü dizinin ilgili indeksine ekler
                }
            }

            // Hesaplama yap ve sonucu kontrol eder
            double sonuc = Calculate(sayilar, operatörler, sayiIndex, operatörIndex);
            if (sonuc <= 0) // Sonucun sıfırdan büyük olup olmadığını kontrol eder
            {
                Console.WriteLine("Sonuç sıfırdan büyük olmalı, lütfen yeniden deneyin.");
                sayiIndex--; // Sonucu geçersizse sayıyı geri alır
            }
            else
            {
                Console.WriteLine($"Geçerli Sonuç: {sonuc}"); // Geçerli sonucu yazdır
            }
        }
    }

    // Geçerli bir operatör olup olmadığını kontrol eden fonksiyon
    static bool IsValidOperator(string operatör)
    {
        return operatör == "+" || operatör == "-" || operatör == "*" || operatör == "/"; // Geçerlilik kontrolü
    }

    // Sayılar ve operatörler ile hesaplama yapan fonksiyon
    static double Calculate(double[] sayilar, string[] operatörler, int sayiCount, int operatörCount)
    {
        double sonuc = sayilar[0]; // İlk sayıyı başlangıç sonucu olarak al
        for (int i = 0; i < operatörCount; i++) // Operatörler üzerinden döngü
        {
            switch (operatörler[i])
            {
                case "+":
                    sonuc += sayilar[i + 1]; // Toplama işlemi
                    break;
                case "-":
                    sonuc -= sayilar[i + 1]; // Çıkarma işlemi
                    break;
                case "*":
                    sonuc *= sayilar[i + 1]; // Çarpma işlemi
                    break;
                case "/":
                    if (sayilar[i + 1] != 0) // Sıfıra bölme kontrolü
                        sonuc /= sayilar[i + 1]; // Bölme işlemi
                    break;
            }
        }
        return sonuc; // Hesaplanan sonucu döndür
        #endregion
    }
}

