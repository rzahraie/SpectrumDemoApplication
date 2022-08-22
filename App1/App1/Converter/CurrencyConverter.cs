using System;
using System.Globalization;
using Xamarin.Forms;

namespace App1.Converter
{
    public class CurrencyConverterSingle : IValueConverter
    {
        private string GetCurrencySymbol(string twoCharSmbol)
        {
            RegionInfo myRI1 = new RegionInfo(twoCharSmbol);
            return (myRI1.CurrencySymbol);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;

            if (string.IsNullOrEmpty(str)) return str;

            if (!str.Contains("|")) return str;

            string[] lst = str.Split('|');

            string currency = lst[0];
            string coin = lst[1];

            decimal converstionFactor = 0.0m;
            string symbol = "";

            //C# 9.0
            //static decimal ConversionFactor(string currency, string crypto)
            //{
            //    return (currency, crypto) switch
            //    {
            //        ("USD", "BTC") => 20000m,
            //        ("USD", "ETH") => 1700m,
            //        ("USD", "ADA") => 2.21m,
            //        ("USD", "XRP") => 0.3815m,
            //        ("JPY", "BTC") => 2480480m,
            //        ("JPY", "ETH") => 248048m,
            //        ("JPY", "ADA") => 0.0m,
            //        ("JPY", "XRP") => 0.0m,
            //        ("CHF", "BTC") => 0.0m,
            //        ("CHF", "ETH") => 0.0m,
            //        ("CHF", "ADA") => 0.0m,
            //        ("CHF", "XRP") => 0.0m,
            //        ("GBP", "BTC") => 0.0m,
            //        ("GBP", "ETH") => 0.0m,
            //        ("GBP", "ADA") => 0.0m,
            //        ("GBP", "XRP") => 0.0m,
            //        ("CNY", "BTC") => 0.0m,
            //        ("CNY", "ETH") => 0.0m,
            //        ("CNY", "ADA") => 0.0m,
            //        ("CNY", "XRP") => 0.0m,
            //        (_, _) => 0.0m
            //    };
            //}

            switch (currency)
            {
                case "USD":
                    converstionFactor = 20000m;
                    symbol = GetCurrencySymbol("US");
                    break;

                case "EUR":
                    converstionFactor = 21364.83m;
                    symbol = GetCurrencySymbol("DE");
                    break;
                case "JPY":
                    converstionFactor = (decimal)(Math.Pow(10, 9) * 3);
                    symbol = GetCurrencySymbol("JP");
                    break;

                case "CHF":
                    converstionFactor = 20374.37m;
                    symbol = GetCurrencySymbol("CH");
                    break;

                case "GBP":
                    converstionFactor = 17967.45m;
                    symbol = GetCurrencySymbol("GB");
                    break;

                case "CNY":
                    converstionFactor = 144894.73m;
                    symbol = GetCurrencySymbol("CN");
                    break;

                default:
                    converstionFactor = 0.0m;
                    break;


            }

            return (symbol + (System.Convert.ToDecimal(coin) * converstionFactor).ToString("#,###.##"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
    public class CurrencyConverter : IMultiValueConverter
    {
        private string GetCurrencySymbol(string twoCharSmbol)
        {
            RegionInfo myRI1 = new RegionInfo(twoCharSmbol);
            return(myRI1.CurrencySymbol);
        }


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string currency = (string)values[0];
            string coin = (string)values[1];

            decimal converstionFactor = 0.0m;
            string symbol = "";

            switch(currency)
            {
                case "USD":
                    converstionFactor = 20000m;
                    symbol = GetCurrencySymbol("US");
                    break;

                case "JPY":
                    converstionFactor = (decimal)(Math.Pow(10, 9) * 3);
                    symbol = GetCurrencySymbol("JP");
                    break;

                case "CHF":
                    converstionFactor = 20374.37m;
                    symbol = GetCurrencySymbol("CH");
                    break;

                case "GBP":
                    converstionFactor = 17967.45m;
                    symbol = GetCurrencySymbol("GB");
                    break;

                case "CNY":
                    converstionFactor = 144894.73m;
                    symbol = GetCurrencySymbol("CN");
                    break;

                default:
                    converstionFactor = 0.0m;
                    break;


            }

            return (symbol + (System.Convert.ToDecimal(coin)*converstionFactor).ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
