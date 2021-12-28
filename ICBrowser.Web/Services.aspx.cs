using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Globalization;
using System.Threading;

namespace ICBrowser.Web
{
    public partial class Services : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList rdlLanguagePreference = (RadioButtonList)Master.FindControl("rdllanguagepreference");

            string s = rdlLanguagePreference.SelectedValue;

            if (!Page.IsPostBack)
            {
                HttpCookie cookie = Request.Cookies[Constants.CultureInfoCookieName];

                if (cookie != null && cookie.Value != null)
                {
                    rdlLanguagePreference.SelectedValue = cookie.Value;

                }
                else if (CultureInfo.CurrentUICulture.Name == "zh-CN")
                {
                    rdlLanguagePreference.SelectedValue = "zh-CN";
                }
            }

            AdminStaticData buyerdata = new AdminStaticData();

            EscrowDetails escrow = new EscrowDetails();

            escrow = buyerdata.GetStaicServiceData();

            Img.ImageUrl = escrow.ImagePath;

            if (rdlLanguagePreference.SelectedValue != null)
            {

                if (rdlLanguagePreference.SelectedValue == "zh-CN")
                {

                    lblServices.Text = Server.HtmlDecode(escrow.StaticZhCN);
                }

                else
                {

                    lblServices.Text = Server.HtmlDecode(escrow.StaticEnIN);
                }

            }
        }
    }
}