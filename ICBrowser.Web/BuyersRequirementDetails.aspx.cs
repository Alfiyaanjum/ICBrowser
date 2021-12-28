using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBrowser.Web
{
    public partial class RequirementDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRequirementGridview();
        }

        public void BindRequirementGridview()
        {
            BuyersDataRequirement buyersdata = new BuyersDataRequirement();
            gdvBuyersReqDetails.DataSource=buyersdata.BuyersRequirements();
            gdvBuyersReqDetails.DataBind();
        }
    }
}