using Binance.Net.Clients;
using Binance.Net.Objects;
using Bybit.Net.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
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
    public class BybitExchange : ExchangesBase
    {
        public List<string> symbols { get; set; }
        public string? selectSymbol { get; set; } = "BNBUSDT";

        public string Name => nameof(BybitExchange);

        private BybitClient client;

        public async Task<string> GetPrice()
        {
            if (selectSymbol != null)
            {
                var select = selectSymbol;
                var ticker = await client.SpotApiV3.ExchangeData.GetTickerAsync(select);
                return ticker.Data.LastPrice.ToString();
            }
            return string.Empty;

           
        }

        public async Task Init(ApiCredentialsExchange? apiCredentials = null)
        {
            if (apiCredentials == null)
            {
                client = new();
            }
            else
            {
                client = new BybitClient(new BybitClientOptions
                {
                    ApiCredentials = new ApiCredentials(apiCredentials.key, apiCredentials.secret),
                    //InverseFuturesApiOptions = new RestApiClientOptions
                    //{
                    //    ApiCredentials = new ApiCredentials("FUTURES-API-KEY", "FUTURES-API-SECRET"),
                    //    AutoTimestamp = false,
                    //    RequestTimeout = TimeSpan.FromSeconds(60)
                    //}
                });
            }
            return;
        }


        public async Task<List<string>> GetSymbols()
        {
            if (symbols == null)
            {
                symbols = client.SpotApiV3.ExchangeData.GetSymbolsAsync().Result.Data.Select(x => x.Name).ToList();
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
