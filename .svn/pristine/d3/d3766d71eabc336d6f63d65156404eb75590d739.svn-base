using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;

namespace ICBrowser.Web
{
    public partial class SellerCompanyDetailsPage: BasePage
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack && Request.QueryString[Constants.ID] != null && int.TryParse(Convert.ToString(Request.QueryString[Constants.ID]), out id))
            {
                //if (!string.IsNullOrEmpty(id))
                //{
                //    if (string.Compare(id, "Send Message") !=0)
                //    {
                //        pnlCompDet.Visible = true;
                BindCompanyDetails(id);
                //}
                //else
                //{
                //    pnlCompDet.Visible = false;
                //}
                // }
            }
        }

        private void BindCompanyDetails(int id)
        {
            CompanyDetails objCompDetails = new CompanyDetails();
            //objCompDetails = Master.PageController.GetSellerCompanyDetails(id);
            if (string.IsNullOrEmpty(objCompDetails.CompanyName))
                lblCompanyName.Text = "This Company is not Registered with us, you can send message instead.";
            else
                lblCompanyName.Text = objCompDetails.CompanyName;
            lblContactName.Text = objCompDetails.ContactName;
            lblPhoneNumber.Text = objCompDetails.PhoneNumber;
            lblFax.Text = objCompDetails.FaxNumber;
            lblEmail.Text = objCompDetails.Email;
            lblWebsite.Text = objCompDetails.Website;
            lblAddress.Text = objCompDetails.PrimaryAddress + ", " + objCompDetails.PrimaryCity + ", " + objCompDetails.PrimaryState;
            lblZip.Text = objCompDetails.PrimaryZip;
            lblCountry.Text = objCompDetails.PrimaryCountry;
            lblCompanyInfo.Text = objCompDetails.Description;
        }
    }
}