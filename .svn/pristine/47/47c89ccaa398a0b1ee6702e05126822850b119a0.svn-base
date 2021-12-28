using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Globalization;
using AjaxControlToolkit;

namespace ICBrowser.Web
{
    public partial class FAQ : System.Web.UI.Page
    {
        List<Common.FAQ> faq = new List<Common.FAQ>();

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
            faq = asd.GetFaqData();


            if (rdlLanguagePreference.SelectedValue == "zh-CN")
            {
                for (int i = 0; i < faq.Count; i++)
                {
                    AccordionPane ap1 = new AccordionPane();
                    ap1.ID = "abc" + i.ToString();

                    LiteralControl ltrl = new LiteralControl();
                    ltrl.Text = Server.HtmlDecode(faq[i].QuestionCny);
                    ap1.HeaderContainer.Controls.Add(ltrl);

                    LiteralControl ltrl1 = new LiteralControl();
                    ltrl1.Text = Server.HtmlDecode(faq[i].AnswerCny);
                    ap1.ContentContainer.Controls.Add(ltrl1);
                    UserAccordion.Panes.Add(ap1);
                }
            }

            else
            {
                for (int i = 0; i < faq.Count; i++)
                {
                    AccordionPane ap1 = new AccordionPane();
                    ap1.ID = "abc" + i.ToString();

                    LiteralControl ltrl = new LiteralControl();
                    ltrl.Text = Server.HtmlDecode(faq[i].QuestionEng);
                    ap1.HeaderContainer.Controls.Add(ltrl);

                    LiteralControl ltrl1 = new LiteralControl();
                    ltrl1.Text = Server.HtmlDecode(faq[i].AnswerEng);
                    ap1.ContentContainer.Controls.Add(ltrl1);
                    UserAccordion.Panes.Add(ap1);
                }
            }

            

        }
        
    }
}