using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob.Interfaces
{
    public interface ExchangesBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">API-KEY</param>
        /// <param name="secret">API-SECRET</param>
        /// <returns></returns>
        Task Init(ApiCredentialsExchange?  apiCredentials =null);
        string? selectSymbol { get; set; }

        /// <summary>
        /// Имя конторы
        /// </summary>
        string Name { get; }

        Task<string> GetPrice();
        Task<List<string>> GetSymbols();
        void searchSymbol(string symbol);

    }
}
