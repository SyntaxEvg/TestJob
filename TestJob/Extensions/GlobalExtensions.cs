using CryptoExchange.Net.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJob.Interfaces;

namespace TestJob.Extensions
{
    public static class GlobalExtensions
    {
        public static IEnumerable<(string, string)> GetExchangeRates(this ICollection<ExchangesBase> exchangesBases)
        {
            foreach (var exchange in exchangesBases)
            {
                yield return (exchange.Name, exchange.GetPrice().GetAwaiter().GetResult());
            }
        }
        public static void SearchSymbol(this ICollection<ExchangesBase> exchangesBases,string symbol)
        {
            foreach (var item in exchangesBases)
            {
                item.searchSymbol(symbol);
            }
        }
        public static void Intit(this ICollection<ExchangesBase> exchangesBases)
        {
            foreach (var item in exchangesBases)
            {
                item.Init();
            }
        }
    }
}
