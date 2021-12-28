using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBrowser.Web
{
    public partial class SellerRegistrationVerificationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] sellerDetails;
            if (Session["SellerDetails"] != null)
            {
                sellerDetails = Convert.ToString(Session["SellerDetails"]).Split('|');
                lblSellerName.Text = sellerDetails[0];
            }
        }
    }
}