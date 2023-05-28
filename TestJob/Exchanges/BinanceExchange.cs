using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects;
using Bybit.Net.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestJob.Interfaces;

namespace TestJob.Exchanges
{
    public class BinanceExchange : ExchangesBase
    {
        public string Name => nameof(BinanceExchange);

        public List<string> symbols { get; set; }

        public string? selectSymbol { get; set; } = "BNBUSDT";

        BinanceClient client;


        public async Task Init(ApiCredentialsExchange? apiCredentials = null)
        {
            if (apiCredentials == null)
            {
                client = new();
            }
            else
            {
                client = new BinanceClient(new BinanceClientOptions
                {
                    ApiCredentials = new BinanceApiCredentials(apiCredentials.key, apiCredentials.secret),
                    SpotApiOptions = new BinanceApiClientOptions
                    {
                        BaseAddress = "https://api.binance.com/",
                        RateLimitingBehaviour = RateLimitingBehaviour.Fail
                    },
                    //UsdFuturesApiOptions = new BinanceApiClientOptions
                    //{
                    //    ApiCredentials = new BinanceApiCredentials("OTHER-API-KEY-FOR-FUTURES", "OTHER-API-SECRET-FOR-FUTURES")
                    //}
                });
            }
            return;
        }  
        public async Task<string> GetPrice()
        {
            if (selectSymbol != null)
            {
                var select = selectSymbol;
                var ticker = await client.SpotApi.ExchangeData.GetTickerAsync(select);
                return ticker.Data.LastPrice.ToString();
            }
            return string.Empty;
          
        }

        public async Task<List<string>> GetSymbols()
        {
            if (symbols == null)
            {
                symbols = client.SpotApi.ExchangeData.GetExchangeInfoAsync().Result.Data.Symbols.Select(x => x.Name).ToList();
            }
            return symbols;
        }

        public void searchSymbol(string symbol)
        {
            selectSymbol = null;
            if (symbols.Any(x => x == symbol))
            {
                selectSymbol = symbol;
            }
        }
    }
}
