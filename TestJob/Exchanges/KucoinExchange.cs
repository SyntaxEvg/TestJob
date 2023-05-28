using Bybit.Net.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using Kucoin.Net.Objects;
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
    public class KucoinExchange : ExchangesBase
    {
        public string? selectSymbol { get; set; } = "BNB-USDT";
        public List<string> symbols { get; set; } 
        public string Name => nameof(KucoinExchange);

        KucoinClient client;


        public async Task Init(ApiCredentialsExchange? apiCredentials = null)
        {
            if (apiCredentials == null)
            {
                client = new();
            }
            else
            {
                client = new KucoinClient(new KucoinClientOptions
                {
                    ApiCredentials = new KucoinApiCredentials(apiCredentials.key, apiCredentials.secret, apiCredentials.PASSPHRASE),
                    //LogLevel = LogLevel.Trace,
                    //FuturesApiOptions = new KucoinRestApiClientOptions
                    //{
                    //    ApiCredentials = new KucoinApiCredentials("FUTURES-API-KEY", "FUTURES-API-SECRET", "FUTURES-API-PASSPHRASE"),
                    //    AutoTimestamp = false
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
                symbols = client.SpotApi.ExchangeData.GetSymbolsAsync().Result.Data.Select(x => x.Name).ToList();
            }
            return symbols;
        }

        public void searchSymbol(string symbol)
        {
            selectSymbol = null;
            //к сожалению  не очень понял как искать  одинаковый выбранный тикер ,так как он содержит  дефис
            //попробовал сделал так.. 
            //так как символ  имеет  часто  3 символа, потом 4 и потом 2 ,  проведем несколько сравнений для поиска соответствия
            var Length = symbol.Length;
            try
            {
                var strspan = symbol.AsSpan();
                //case 3
                var str = SplitCountSymbol(strspan, 3);
                if (str == null)
                {
                    //goto step
                    str = SplitCountSymbol(strspan, 4);
                    if (str == null)
                    {
                        str = SplitCountSymbol(strspan, 2);
                    }
                }
                if (str != null && symbols.Any(x => x == str))
                {
                    selectSymbol = str;
                }
            }
            catch (Exception)
            {
            }
        }
        private string SplitCountSymbol(ReadOnlySpan<char> strspan, int switch_on)
        {
            string res = null;
            try
            {
                switch (switch_on)
                {
                    case 3: return SliceCountSymbol(strspan, 3);
                    case 4: return SliceCountSymbol(strspan, 4);

                    case 2: return SliceCountSymbol(strspan, 2);

                    default:
                        return res;
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return res;

        }
        private string SliceCountSymbol(ReadOnlySpan<char> strspan, int switch_on)
        {
            var twosymbolpart1 = strspan.Slice(0, switch_on);
            var twosymbolpart2 = strspan.Slice(switch_on, strspan.Length - switch_on);
            return string.Concat(twosymbolpart1, "-", twosymbolpart2);
        }
    }
}
