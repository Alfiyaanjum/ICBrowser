using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;

namespace ICBrowser.Web.Controls
{
    public partial class ucCurrencyExchangeRate : System.Web.UI.UserControl
    {
        /// <summary>
        /// Page Load event to show current exchange rate in gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Retrieve Currency Exchange Rate from database
                CurrencyExchangeRateWidget objCurrExRateWidget = new CurrencyExchangeRateWidget();
                List<CurrencyExchangeRate> lstCurrExRate = objCurrExRateWidget.GetCurrExRate();

                // Show exchange rates in gridview
                gvExchangeRate.DataSource = lstCurrExRate;
                gvExchangeRate.DataBind();
                gvExchangeRate.Visible = true;
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
        }
    }
}