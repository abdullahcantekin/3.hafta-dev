using System;
using System.Data;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        #region
        // İşlem yapılacak matematiksel ifadeeder
        string expression = "3 + 4 * 2 / (1 - 5) ^ 2 ^ 3";

        Console.WriteLine("İfadenin çözüm süreci:");

        // Üs işlemlerini sırayla çözmek için ifadeyi dönüştürür
        expression = SolvePowerOperations(expression);

        // Çarpma, bölme, toplama ve çıkarma işlemlerini çözer
        var result = SolveExpression(expression);

        // Sonucu ekrana yazdırır
        Console.WriteLine($"Sonuç: {result}");
    }

    // Üs işlemlerini çözmek için bir fonksiyon tanımlar
    static string SolvePowerOperations(string expression)
    {
        // Regex, üs alma işlemlerini (örneğin 3 ^ 2) bulmak için kullanılır
        Regex powerRegex = new Regex(@"\d+(\.\d+)? \^ \d+(\.\d+)?");

        // İfade içinde üs işlemi olduğu sürece döngü devam edecek
        while (powerRegex.IsMatch(expression))
        {
            // Eşleşen ilk üs işlemini bulur
            Match match = powerRegex.Match(expression);
            if (match.Success)
            {
                // Üs işleminin taban ve üs değerlerini ayırır
                string[] parts = match.Value.Split('^');
                double baseNum = Convert.ToDouble(parts[0]);  // Taban sayısı
                double exponent = Convert.ToDouble(parts[1]); // Üs sayısı
                double powerResult = Math.Pow(baseNum, exponent); // Üs işlemi yap

                // Üs işleminin sonucunu ekrana yazdır
                Console.WriteLine($"Üs işlemi: {match.Value} = {powerResult}");

                // İfade içinde hesaplanan üs işlemini sonuçla değiştirir
                expression = expression.Replace(match.Value, powerResult.ToString());
            }
        }
        return expression; // İşlem görmüş ifade döndürülür
    }

    // Üs işlemleri çözümledikten sonra diğer işlemleri çözmek için fonksiyon
    static double SolveExpression(string expression)
    {
        // DataTable ile temel aritmetik işlemleri çözmek için
        var dataTable = new DataTable();

        // DataTable kullanarak ifadeyi çözer ve sonucu döndür
        double result = Convert.ToDouble(dataTable.Compute(expression, ""));

        // Kalan işlemin sonucunu ekrana yazdırır
        Console.WriteLine($"Çarpma/bölme ve toplama/çıkarma işlemi: {expression} = {result}");

        return result;
        #endregion
    }
}
