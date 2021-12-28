using ICBrowser.Business;
using ICBrowser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class ComponentDetails : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SellerInventoryListing sil = new SellerInventoryListing();
                string componentName = Request.QueryString["ComponentName"];
                lbl_componentName.Text = componentName;
                gvComponentDetails.DataSource = sil.ComponentDetailsByComponentName(componentName);
                gvComponentDetails.DataBind();
            }
            //lblmsg.Visible = false;
        }

        /// <summary>
        /// Handles the RowCommand event of the gvComponentDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvComponentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            var lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");

            if (e.CommandName == "SelectPartNumber")
            {
               
                LinkButton lnkbtn = row.FindControl("lnkPartNumber") as LinkButton;
                string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                //((LinkButton)row.Cells[2].FindControl("lnk"));

                Label lblQty = row.FindControl("lblQuantity") as Label;
                string test2 = lblQty.Text.Replace("&nbsp;", "");

                Label lblBrandName = row.FindControl("lblBrandName") as Label;
                string test3 = lblBrandName.Text.Replace("&nbsp;", "");

                Label lblDateCode = row.FindControl("lblDateCode") as Label;
                string test4 = lblDateCode.Text.Replace("&nbsp;", "");

                Label lblUnitPrice = row.FindControl("lblUnitPriceUSD") as Label;
                decimal test5 =Convert.ToDecimal(lblUnitPrice.Text.Replace("&nbsp;", ""));

                Label lblDescription = row.FindControl("lbldescription") as Label;
                string test6 = lblDescription.Text.Replace("&nbsp;", "");
                
                //if (userid == senduserid)
                //{

                if (lnkbtn != null)
                {

                    values.Add(new Common.Component
                    {

                        ComponentName = lnkbtn.Text.Trim(),
                        Quantity = Convert.ToInt32(test2),
                        BrandName = test3,
                        datecode = test4,
                        PriceInUSD = Convert.ToDecimal(test5),
                        Description=test6
                        
                    });
                }

            }

            if (values.Count != 0)
            {
                htMoreDetailsInfo.Add("UserId", lnkSellerId.Text.Trim());
                htMoreDetailsInfo.Add("RequestType", "Offers");
                htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                htMoreDetailsInfo.Add("Page", "MoreDetails");
                htMoreDetailsInfo.Add("Values", values);

                Session["GetList"] = htMoreDetailsInfo;
                Response.Redirect("UserResponse.aspx",false);
            }

            else if (e.CommandName == "SelectCompanyName")
            {
                // do something on select company name
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                var lnkBtn = (LinkButton)row.Cells[0].FindControl("lnkSellerId");
                string id = lnkBtn.Text;
                int rowindex = row.RowIndex;

                if (Membership.GetUser() == null)
                {
                    Response.Redirect("Register.aspx?UserId=" + id, true);
                }
                else
                {
                    //Response.Redirect(, true);
                    string redUrl = "NewUserProfile.aspx?UserId=" + id;
                    ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
                }
            }

        }

        /// <summary>
        /// Handles the RowDataBound event of the gvComponentDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvComponentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStkStatus = ((Label)e.Row.FindControl("lblStkStatus"));

                LinkButton lnkpartNo = ((LinkButton)e.Row.FindControl("lnkPartNumber"));
                lnkpartNo.Text = Request.QueryString["ComponentName"];


                if (lblStkStatus.Text == "1")
                    lblStkStatus.Text = "Available";
                else if (lblStkStatus.Text == "2")
                    lblStkStatus.Text = "In House";
                else
                    lblStkStatus.Text = "OEM Excess";
            }
        }
    }
}