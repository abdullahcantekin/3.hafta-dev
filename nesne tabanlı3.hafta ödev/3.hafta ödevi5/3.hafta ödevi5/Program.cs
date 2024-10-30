using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        #region
        Console.WriteLine("Polinom işlemleri için iki polinom girin (örneğin, 2x^2 + 3x - 5 ve x^2 - 4). Çıkmak için 'exit' yazın.");

        while (true)
        {
            // Kullanıcıdan birinci polinomu alır
            Console.Write("Birinci polinom: ");
            string input1 = Console.ReadLine();
            if (input1.ToLower() == "exit") break; // Eğer kullanıcı 'exit' yazarsa döngüden çıkar

            // Kullanıcıdan ikinci polinomu alır
            Console.Write("İkinci polinom: ");
            string input2 = Console.ReadLine();
            if (input2.ToLower() == "exit") break; // Eğer kullanıcı 'exit' yazarsa döngüden çıkar

            // Polinomları ayrıştır ve sözlük yapısına kaydeder
            var poly1 = ParsePolynomial(input1);
            var poly2 = ParsePolynomial(input2);

            // Polinomları topla ve sonucu gösterir
            Console.WriteLine("Toplama Sonucu: " + FormatPolynomial(CombinePolynomials(poly1, poly2, 1)));
            // Polinomları çıkar ve sonucu gösterir
            Console.WriteLine("Çıkarma Sonucu: " + FormatPolynomial(CombinePolynomials(poly1, poly2, -1)));
        }
    }

    // Polinomu parçalara ayırarak üs ve katsayıları saklayan bir dictionary döndürürür
    static Dictionary<int, int> ParsePolynomial(string poly)
    {
        var result = new Dictionary<int, int>();
        // Polinomdaki her terimi tanımlayan bir regex ifadesi
        foreach (Match m in Regex.Matches(poly.Replace(" ", ""), @"([+-]?\d*)x\^?(\d*)|([+-]?\d+)"))
        {
            // Katsayıyı belirle (boşsa varsayılan olarak 1)
            int coef = m.Groups[1].Value == "" && m.Groups[3].Value == "" ? 1 : int.Parse(m.Groups[1].Value + "1");
            // Üssü belirle (boşsa varsayılan olarak 1 veya 0)
            int exp = m.Groups[2].Value == "" ? (m.Groups[3].Value == "" ? 1 : 0) : int.Parse(m.Groups[2].Value);

            // Aynı üs varsa katsayıları topla, yoksa ekler
            if (result.ContainsKey(exp)) result[exp] += coef;
            else result[exp] = coef;
        }
        return result;
    }

    // İki polinomu toplama veya çıkarma işlemi (işlem için 'sign' parametresi kullanılır: +1 = toplama, -1 = çıkarma)
    static Dictionary<int, int> CombinePolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2, int sign)
    {
        var result = new Dictionary<int, int>(poly1); // poly1'i başlangıç olarak ekle
        foreach (var term in poly2)
            // Aynı üs varsa katsayıları işlemle güncelle, yoksa ekle
            result[term.Key] = result.ContainsKey(term.Key) ? result[term.Key] + sign * term.Value : sign * term.Value;
        return result;
    }

    // Polinomu string formatında yazdırmak için düzenler
    static string FormatPolynomial(Dictionary<int, int> poly)
    {
        var terms = new List<string>();
        foreach (var term in poly)
        {
            if (term.Value == 0) continue; // Katsayı 0 ise terimi atla
            // İşaret ve katsayıyı belirle
            string sign = term.Value > 0 && terms.Count > 0 ? "+" : "";
            string coef = term.Value == 1 && term.Key != 0 ? "" : term.Value.ToString();
            // Üs değerini ayarla
            string exp = term.Key == 0 ? "" : term.Key == 1 ? "x" : $"x^{term.Key}";
            terms.Add($"{sign}{coef}{exp}");
        }
        return terms.Count > 0 ? string.Join(" ", terms) : "0"; // Terimleri birleştir ve döndürür
        #endregion
    }
}

