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
    public partial class SearchOffers : BasePage
    {
        string g_searchText;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    g_searchText = Request.QueryString[Constants.SearchText];
                    if (!string.IsNullOrEmpty(g_searchText))
                    {
                        BindSearchData(g_searchText);
                        lblSearchText.Text = g_searchText;
                    }
                    else
                    {
                        BindEmptyGrid();
                        lblSearchText.Text = g_searchText;
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
            grvOfferSearch.DataSource = null;
            grvOfferSearch.DataBind();
        }

        private void BindSearchData(string searchText)
        {
            try
            {
                IEnumerable<ICBrowser.Common.Component> lst = Master.PageController.SearchOffers(searchText);

                DataTable dtForGrid = new DataTable();
                dtForGrid.Columns.Add("ComponentName", typeof(string));
                dtForGrid.Columns.Add("Quantity", typeof(int));
                dtForGrid.Columns.Add("BrandName", typeof(string));
                dtForGrid.Columns.Add("CompanyName", typeof(string));
                dtForGrid.Columns.Add("userId", typeof(Guid));
                dtForGrid.Columns.Add("ModifiedOn", typeof(string));
                dtForGrid.Columns.Add("DataSheetURL", typeof(string));
                //dtForGrid.Columns.Add("StockInHand", typeof(int));
                dtForGrid.Columns.Add("Description", typeof(string));
                //dtForGrid.Columns.Add("PriceInINR", typeof(decimal));
                dtForGrid.Columns.Add("PriceInUSD", typeof(decimal));
                //dtForGrid.Columns.Add("PriceInCNY", typeof(decimal));
                //dtForGrid.Columns.Add("Country", typeof(string));
                dtForGrid.Columns.Add("Package", typeof(string));
                dtForGrid.Columns.Add("DateCode", typeof(string));
                dtForGrid.Columns.Add("StockStatus", typeof(int));

                DataRow drForGrid;
                foreach (ICBrowser.Common.Component drDetails in lst)
                {
                    drForGrid = dtForGrid.NewRow();
                    drForGrid["ComponentName"] = drDetails.ComponentName;
                    drForGrid["CompanyName"] = drDetails.CompanyName;
                    drForGrid["Quantity"] = drDetails.Quantity;
                    drForGrid["BrandName"] = drDetails.BrandName;
                    drForGrid["userId"] = drDetails.UserId;
                    //drForGrid["StockInHand"] = drDetails.StockInHand;
                    drForGrid["Description"] = drDetails.Description;
                    //drForGrid["PriceInINR"] = drDetails.PriceInINR;
                    drForGrid["PriceInUSD"] = drDetails.PriceInUSD;
                    //drForGrid["PriceInCNY"] = drDetails.PriceInCNY;
                    drForGrid["ModifiedOn"] = drDetails.ModifiedOn.ToString("dd-MMM-yyyy");
                    drForGrid["DataSheetURL"] = drDetails.DataSheetURL;
                    //drForGrid["Country"] = drDetails.country;
                    drForGrid["Package"] = drDetails.package;
                    drForGrid["DateCode"] = drDetails.datecode;
                    drForGrid["StockStatus"] = drDetails.stockstatus;
                    dtForGrid.Rows.Add(drForGrid);
                }
                grvOfferSearch.DataSource = dtForGrid;
                grvOfferSearch.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void grvOfferSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                HyperLink hlCompanyName = e.Row.FindControl("hlCompanyName") as HyperLink;
                Label lblStockStatus = ((Label)e.Row.FindControl("lblStockStatus"));

                LinkButton lnkComponentName = e.Row.FindControl("lnkComponentName") as LinkButton;
                Label LblComponentname = e.Row.FindControl("LblComponentname") as Label;

                if (lblStockStatus.Text == "1")
                    lblStockStatus.Text = "Available";
                else if (lblStockStatus.Text == "2")
                    lblStockStatus.Text = "In House";
                else
                    lblStockStatus.Text = "OEM Excess";

                MembershipUser usertologin = Membership.GetUser();
                if (usertologin != null)
                {
                    Guid UserId = (Guid)usertologin.ProviderUserKey;

                    //chk for Admin.......
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(UserId);
                 

                    if (Admin.IsAdmin)
                    {
                        lnkComponentName.Visible = false;
                        LblComponentname.Visible = true;
                    }
                    else
                    {
                        lnkComponentName.Visible = true;
                    }
                    hlCompanyName.Visible = true;
                    grvOfferSearch.Columns[6].Visible = true;
                }
                else
                {
                 
                    LblComponentname.Visible = true;
                    hlCompanyName.Visible = false;
                    grvOfferSearch.Columns[6].Visible = false;
                }

            }

        }

        protected void grvOfferSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvOfferSearch.PageIndex = e.NewPageIndex;
            BindSearchData(Request.QueryString[Constants.SearchText]);
        }

        protected void grvOfferSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                LinkButton lnkComponentName = (LinkButton)grvOfferSearch.Rows[row.RowIndex].FindControl("lnkComponentName");
                if (lnkComponentName != null)
                {
                    Response.Redirect("OfferDetails.aspx?ComponentName=" + lnkComponentName.Text.Trim(), false);
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }
    }
}