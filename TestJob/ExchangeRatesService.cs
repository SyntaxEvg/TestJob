
using Binance.Net.Clients;
using Binance.Net.Objects;
using Bybit.Net.Clients;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;
using Kucoin.Net.Clients;
using Kucoin.Net.Objects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJob.Interfaces;
using TestJob.Exchanges;
using System.Diagnostics;
using System.Collections;
using TestJob.Extensions;
using TestJob.Enums;

namespace ExchangeRates
{
    public class ExchangeRatesService
    {
       //private readonly BinanceApiClient _binanceApiClient;
       //private readonly BybitApiClient _bybitApiClient;
       //private readonly KucoinApiClient _kucoinApiClient;

        private readonly List<string> _NameExhange;
        private readonly Func<Operation, List<string>, string> combox;
        ICollection<ExchangesBase> Exchanges;



        //  public ExchangeRatesService(string binanceApiKey, string binanceSecretKey, string bybitApiKey, string bybitSecretKey, string kucoinApiKey, string kucoinSecretKey)
        public ExchangeRatesService(Func<Operation,List<string>, string> Combox = null)
        {
            combox = Combox;
            Exchanges = new List<ExchangesBase>
            {
               new TestJob.Exchanges.BinanceExchange(),
               new TestJob.Exchanges.BybitExchange(), 
               new TestJob.Exchanges.KucoinExchange()
            };
            Exchanges.Intit();

            GetSymbols().GetAwaiter().GetResult();

        }

        private async Task GetSymbols()
        {

            combox.Invoke(Operation.add,await Exchanges.First(x => x.Name == nameof(BinanceExchange)).GetSymbols());//берем за основу тикеры бинанс и помещаем их в комбо
            await Exchanges.First(x => x.Name == nameof(BybitExchange)).GetSymbols();
            await Exchanges.First(x => x.Name == nameof(KucoinExchange)).GetSymbols();


            var symbol = combox.Invoke(Operation.get,null);
            Exchanges.SearchSymbol(symbol);


        }

        public IEnumerable<(string, string)> GetExchangeRates()
        {
            return Exchanges?.GetExchangeRates();
            
        }
        public void SetSymbol(string symbolBinance)
        {
            Exchanges.SearchSymbol(symbolBinance);
        }


    }
}


