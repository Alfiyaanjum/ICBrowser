using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public class CurrencyExchangeRate
    {
        public int ExchangeID { get; set; }
        public string ForeignCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
