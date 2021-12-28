using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Globalization;

namespace ICBrowser.Web
{
    public partial class TermsAndConditions : BasePage
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


            EscrowDetails ed = GetData();
            if (rdlLanguagePreference.SelectedValue == "zh-CN")
            {
                lblData.Text = Server.HtmlDecode(ed.StaticZhCN);
            }

            else
            {
                lblData.Text = Server.HtmlDecode(ed.StaticEnIN);
            }


        }


        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>EscrowDetails.</returns>
        public EscrowDetails GetData()
        {
            AdminStaticData asd = new AdminStaticData();
            Common.EscrowDetails ed = new Common.EscrowDetails();
            ed = asd.GetStaticLegalAgreementData();
            return ed;
        }
    }
}