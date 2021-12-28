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
    public partial class WhyUsData : BasePage
    {
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

            AdminStaticData asd = new AdminStaticData();

            WhyUs whyus = new WhyUs();

            whyus = asd.GetWhyUsData();

           // Img.ImageUrl = escrow.ImagePath;

            if (rdlLanguagePreference.SelectedValue != null)
            {
                if (rdlLanguagePreference.SelectedValue == "zh-CN")
                {

                    lblWhyus.Text = Server.HtmlDecode(whyus.QuestionCny);
                }
                else
                {
                    lblWhyus.Text = Server.HtmlDecode(whyus.QuestionEng);
                }

            }

        }
    }
}