using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    /// <summary>
    ///  Только споты, не сложно добавить  и фьчерс,  сделать 2 вложенных класс или структуры
    /// </summary>
    /// <param name="key"></param>
    /// <param name="secret"></param>
    /// <param name="PASSPHRASE"></param>
    public record ApiCredentialsExchange(string? key = null, string? secret = null, string? PASSPHRASE = null);

    //public class Data
    //{
    //    public string Name { get; set; }

        
    //}

}
