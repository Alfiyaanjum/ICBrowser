using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Web.Security;
using System.Collections;

namespace ICBrowser.Web
{
    public partial class OfferDetails : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();

        #region "Event"
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserOffersData objUserOffer = new UserOffersData();
            string queryString = Request.QueryString["ComponentName"].Replace('@', '#');
            if (!Page.IsPostBack)
            {
                if ((queryString != "" || queryString != null))
                {
                    lbl_offerName.Text = queryString;
                    gvOfferDetails.DataSource = objUserOffer.getOfferDetailsByOfferName(queryString);
                    gvOfferDetails.DataBind();
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            lblmsg.Visible = false;
        }

        /// <summary>
        /// Handles the RowCommand event of the gvOfferDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvOfferDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            LinkButton lnkBtn = (LinkButton)row.Cells[0].FindControl("lnkUserId");
            if (e.CommandName == "SelectPartNumber")
            {

                if (lnkBtn != null)
                {

                    LinkButton lnkbtn = row.FindControl("lnkPartNumber") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");

                    Label lblQty = row.FindControl("lblQuantity") as Label;
                    string test2 = lblQty.Text.Replace("&nbsp;", "");

                    Label lblBrandName = row.FindControl("lblBrandName") as Label;
                    string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                    Label lblDateCode = row.FindControl("lblDateCode") as Label;
                    string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                    Label lblUnitPrice = row.FindControl("lblPriceInUSD") as Label;
                    decimal test5 = Convert.ToDecimal(lblUnitPrice.Text.Replace("&nbsp;", ""));

                    Label lblDescription = row.FindControl("lbldescription") as Label;
                    string test6 = lblDescription.Text.Replace("&nbsp;", "");

                    if (lnkbtn != null)
                    {

                        values.Add(new Common.Component
                        {
                            ComponentName = lnkbtn.Text.Trim(),
                            Quantity = Convert.ToInt32(test2),
                            BrandName = test3,
                            datecode = test4,
                            PriceInUSD = Convert.ToDecimal(test5),
                            Description = test6
                        });
                    }

                }

                if (values.Count != 0)
                {
                    htMoreDetailsInfo.Add("UserId", lnkBtn.Text.Trim());
                    htMoreDetailsInfo.Add("RequestType", "Offers");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Response.Redirect("UserResponse.aspx",false);
                }

            }

            else if ((e.CommandName == "SelectCompanyName"))
            {
                if (lnkBtn != null)
                {
                    //Response.Redirect("NewUserProfile.aspx?UserId=" + lnkBtn.Text.Trim(), true);
                    string redUrl = "NewUserProfile.aspx?UserID=" + lnkBtn.Text.Trim();
                    ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
                }

            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvOfferDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvOfferDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStkStatus = ((Label)e.Row.FindControl("lblStkStatus"));
                //LinkButton lnkpartNo = ((LinkButton)e.Row.FindControl("lnkPartNumber"));
                //lnkpartNo.Text = Request.QueryString["ComponentName"];

                if (lblStkStatus.Text == "1")
                    lblStkStatus.Text = "Available";
                else if (lblStkStatus.Text == "2")
                    lblStkStatus.Text = "In House";
                else
                    lblStkStatus.Text = "OEM Excess";
            }
        }
        #endregion
    }
}