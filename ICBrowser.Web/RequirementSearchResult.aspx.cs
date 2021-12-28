using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;
using System.Data;


namespace ICBrowser.Web
{
    public partial class RequirementSearchResult : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        string g_searchText;
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SearchClicked += new Search(Master_SearchClicked);
        }

        void Master_SearchClicked(string searchText, bool searchRequirement)
        {
            try
            {
                g_searchText = searchText;
                BindSearchData(searchText);
                Label2.Text = searchText;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                g_searchText = Request.QueryString[Constants.SearchText];
                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrEmpty(g_searchText))
                    {
                        BindSearchData(g_searchText);
                        Label2.Text = g_searchText;
                    }
                    else
                    {
                        BindEmptyGrid();
                        Label2.Text = g_searchText;
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void BindEmptyGrid()
        {
            grdReqSearchResults.DataSource = null;
            grdReqSearchResults.DataBind();
        }

        private void BindSearchData(string searchText)
        {
            try
            {
                grdReqSearchResults.DataSource = Master.PageController.SearchRequirements(searchText);
                grdReqSearchResults.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void grdReqSearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdReqSearchResults.PageIndex = e.NewPageIndex;
                BindSearchData(Request.QueryString[Constants.SearchText]);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void grdReqSearchResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hlCompanyName = e.Row.FindControl("hlCompanyName") as HyperLink;
                Label lblWithPO = ((Label)e.Row.FindControl("lblWithPO"));
                Label LblComponentname = e.Row.FindControl("LblComponentname") as Label;
                LblComponentname.Visible = true;
                LinkButton lnkbtn = e.Row.FindControl("lnkComponentName") as LinkButton;
                lnkbtn.Visible = false;

                if (lblWithPO.Text == "True")
                    lblWithPO.Text = "PO";
                else
                    lblWithPO.Text = "RFQ";

                MembershipUser usertologin = Membership.GetUser();
                if (usertologin != null)
                {
                    Guid UserId = (Guid)usertologin.ProviderUserKey;

                    //chk for Admin.......
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(UserId);

                    if (Admin.IsAdmin)
                    {
                        lnkbtn.Visible = false;
                    }
                    else
                    {
                        lnkbtn.Visible = true;
                        LblComponentname.Visible = false;
                    }
                  
                    hlCompanyName.Visible = true;
                    grdReqSearchResults.Columns[4].Visible = true;
                }
                else
                {
                    LblComponentname.Visible = true;
                    lnkbtn.Visible = false;
                    hlCompanyName.Visible = false;
                    grdReqSearchResults.Columns[4].Visible = false;
                }
            }
        }


        protected void grdReqSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");

                if (userToLogin != null)
                {

                    LinkButton lnkbtn = row.FindControl("lnkComponentName") as LinkButton;
                    string test1 = lnkbtn.Text.Replace("&nbsp;", "");
                    //((LinkButton)row.Cells[2].FindControl("lnk"));

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

                    Session["GetList"] = values;
                    Response.Redirect("UserResponse.aspx?userid=" + lnkSellerId.Text.Trim() + "&RequestType=Requirements" + "&PartNo=" + values[0].ComponentName);
                }
            }
        }

    }
}
