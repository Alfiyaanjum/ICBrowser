using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ICBrowser.DAL
{
    public class ExchangeRateRepository : Repository
    {
        /// <summary>
        /// Method to retrieve Today's Currency Exchnage Rate from database
        /// </summary>
        /// <returns></returns>
        public List<CurrencyExchangeRate> GetCurrencyExchangeRate()
        {
            List<CurrencyExchangeRate> lstExRate = new List<CurrencyExchangeRate>();

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("GetExchangeRate");

                // Execute stored proc with reader
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                // Update list of exchange rates retrieved from database
                while (reader.Read())
                {
                    lstExRate.Add(new CurrencyExchangeRate()
                    {
                        ExchangeID = reader.GetValue<int>("ExchangeID"),
                        ForeignCurrency = reader.GetValue<string>("ForeignCurrency"),
                        ExchangeRate = reader.GetValue<decimal>("ExchangeRate"),
                    });
                }
                reader.Close();
                lstExRate.TrimExcess();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return lstExRate;
        }
    }
}
