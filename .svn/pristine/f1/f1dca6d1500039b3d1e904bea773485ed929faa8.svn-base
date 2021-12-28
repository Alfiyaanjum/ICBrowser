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
    public partial class About : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList rdlLanguagePreference = (RadioButtonList)Master.FindControl("rdllanguagepreference");

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


            AdminStaticData asd = new AdminStaticData();

            EscrowDetails escrow = new EscrowDetails();

            escrow = asd.GetStaticAboutUsData();

            Img.ImageUrl = escrow.ImagePath;

            {

                if (rdlLanguagePreference.SelectedValue == "zh-CN")
                {
                    lblInfo.Text = Server.HtmlDecode(escrow.StaticZhCN);
                }

                else
                {
                    lblInfo.Text = Server.HtmlDecode(escrow.StaticEnIN);
                }

            }

        }
    }
}
