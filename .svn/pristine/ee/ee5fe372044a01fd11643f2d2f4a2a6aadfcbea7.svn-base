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
    public partial class ContactUs : BasePage
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

            Common.ContactUs cu = new Common.ContactUs();

            cu = asd.GetStaticContactUsData();

            Img.ImageUrl = cu.ImagePath;

            if (rdlLanguagePreference.SelectedValue != null)
            {

                if (rdlLanguagePreference.SelectedValue == "zh-CN")
                {
                    lblInfo.Text = Server.HtmlDecode(cu.StaticZhCN);

                    LnkCustServcEmailId.Text = cu.CustServiceEmail;
                    lblCustServcPno.Text = cu.CustServicePhNo;

                    lnkbtnAddEmailId.Text = cu.AdvertisementEmail;
                    lblAddPno.Text = cu.AdvertisementPhNo;

                    lnkbtnSalesofcEmail.Text = cu.SalesOfficeEmail;
                    lblSalesofcPno.Text = cu.SalesOfficePhNo;
                }
                else
                {
                    lblInfo.Text = Server.HtmlDecode(cu.StaticEnIN);
                    LnkCustServcEmailId.Text = cu.CustServiceEmail;
                    lblCustServcPno.Text = cu.CustServicePhNo;

                    lnkbtnAddEmailId.Text = cu.AdvertisementEmail;
                    lblAddPno.Text = cu.AdvertisementPhNo;

                    lnkbtnSalesofcEmail.Text = cu.SalesOfficeEmail;
                    lblSalesofcPno.Text = cu.SalesOfficePhNo;
                }

            }
        }


        /// <summary>
        /// Handles the Click event of the LnkCustServcEmailId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void LnkCustServcEmailId_Click(object sender, EventArgs e)
        {
            //Do some work
            AdminStaticData asd = new AdminStaticData();

            Common.ContactUs cu = new Common.ContactUs();

            cu = asd.GetStaticContactUsData();            
            LnkCustServcEmailId.Text = cu.CustServiceEmail;
            string email = LnkCustServcEmailId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto",
                "<script type = 'text/javascript'>parent.location='mailto:" + email + "?subject=Inquiry for Customer Service'</script>");
        }


        /// <summary>
        /// Handles the Click event of the lnkbtnAddEmailId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkbtnAddEmailId_Click(object sender, EventArgs e)
        {
            //Do some work
            AdminStaticData asd = new AdminStaticData();

            Common.ContactUs cu = new Common.ContactUs();

            cu = asd.GetStaticContactUsData();
            lnkbtnAddEmailId.Text = cu.AdvertisementEmail;
            string email = lnkbtnAddEmailId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto",
                "<script type = 'text/javascript'>parent.location='mailto:" + email + "?subject=Inquiry for Advertisement'</script>");
        }


        /// <summary>
        /// Handles the Click event of the lnkbtnSalesofcEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkbtnSalesofcEmail_Click(object sender, EventArgs e)
        {
            //Do some work
            AdminStaticData asd = new AdminStaticData();

            Common.ContactUs cu = new Common.ContactUs();

            cu = asd.GetStaticContactUsData();
            lnkbtnSalesofcEmail.Text = cu.SalesOfficeEmail;
            string email = lnkbtnSalesofcEmail.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto",
                "<script type = 'text/javascript'>parent.location='mailto:" + email + "?subject=Inquiry for Sales Office'</script>");
        }

    }
}