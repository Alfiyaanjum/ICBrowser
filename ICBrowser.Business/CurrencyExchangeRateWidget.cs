using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ICBrowser.Business;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class CurrencyExchangeRateWidget
    {
        /// <summary>
        /// Method to access DAL to retrieve Today's Currency Exchange Rate
        /// </summary>
        /// <returns></returns>
        public List<CurrencyExchangeRate> GetCurrExRate()
        {
            List<CurrencyExchangeRate> lstCurrExRate = new List<CurrencyExchangeRate>();
            try
            {
                // Access DAL to retrieve current exchange rate
                ExchangeRateRepository objExRateRepo = new ExchangeRateRepository();
                lstCurrExRate = objExRateRepo.GetCurrencyExchangeRate();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return lstCurrExRate;
        }
    }
}
