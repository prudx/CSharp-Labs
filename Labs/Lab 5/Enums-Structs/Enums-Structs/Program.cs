using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CurrencyUnit { EUR, USD, CNY }

namespace Enums_Structs
{
    public struct Money
    {
        public double Amount { get; set; }
        public CurrencyUnit Currency { get; set; }

        private const double USDtoEUR = 0.87;
        private const double USDtoCNY = 1 / CNYtoUSD;

        private const double EURtoUSD = 1 / USDtoEUR;
        private const double EURtoCNY = 8.00;

        private const double CNYtoUSD = 0.14;
        private const double CNYtoEUR = 0.125;

        public Money(double amt, CurrencyUnit c)
        {
            Currency = c;
            Amount = amt;
        }

        //half the amount of const by /the inverse amount
        //

        public double Conversion(CurrencyUnit currencyNew)
        {
            switch (Currency)
            {
                case CurrencyUnit.USD:
                    switch (currencyNew)
                    {
                        case CurrencyUnit.EUR:
                            return Amount * USDtoEUR;
                        case CurrencyUnit.CNY:
                            return Amount * USDtoCNY;
                        default:
                            return 0.0;
                    }
                case CurrencyUnit.EUR:
                    switch (currencyNew)
                    {
                        case CurrencyUnit.USD:
                            return Amount * EURtoUSD;
                        case CurrencyUnit.CNY:
                            return Amount * EURtoCNY;
                        default:
                            return 0.0;
                    }
                case CurrencyUnit.CNY:
                    switch (currencyNew)
                    {
                        case CurrencyUnit.EUR:
                            return Amount * CNYtoEUR;
                        case CurrencyUnit.USD:
                            return Amount * CNYtoUSD;
                        default:
                            return 1.0;
                    }
            }
            return 99;
        }

    }
    public class Test
    {
        static void Main()
        {
            Money m1 = new Money(1, CurrencyUnit.CNY);

            Money m2 = new Money(1, CurrencyUnit.USD);

            Money m3 = new Money(1, CurrencyUnit.EUR);

            Console.WriteLine("Convert from " + m1.Amount + " " + m1.Currency + " to USD: ");
            Console.WriteLine(m1.Conversion(CurrencyUnit.USD));
            Console.WriteLine("Convert from " + m2.Amount + " " + m2.Currency + " to EUR: ");
            Console.WriteLine(m2.Conversion(CurrencyUnit.EUR));
            Console.WriteLine("Convert from " + m3.Amount + " " + m3.Currency + " to CNY: ");
            Console.WriteLine(m3.Conversion(CurrencyUnit.USD));



        }
    }
}
