using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "апельсин1.54яблоко2.412.31молоко0.99кофе1.231.11";

            decimal TotalPrice = TotalPriceCheck(input);

            Console.WriteLine($"Конечная сумма:{TotalPrice:F2}");
        }

        public static decimal TotalPriceCheck(string input)
        {
            decimal totalDecimal = 0;

            //для поиска цены
            string regularExpression = @"(\d{1,3}(?:\.\d{3})*(?:\.\d{2})?)";

            var matches = Regex.Matches(input, regularExpression);

            foreach (Match match in matches)
            {
                string priceValue = match.Value;

                priceValue = priceValue.Replace(".", "");

                decimal price = decimal.Parse(priceValue) / 100;

                totalDecimal += price;
            }
            return totalDecimal;

        }
    }
}
