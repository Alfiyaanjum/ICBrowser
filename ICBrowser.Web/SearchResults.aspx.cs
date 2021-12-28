using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;
using System.Collections;
using System.Data;

namespace ICBrowser.Web
{
    public partial class SearchResults : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        Hashtable htMoreDetailsInfo = new Hashtable();
        MembershipUser userToLogin = Membership.GetUser();
        public Guid currUserId;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SearchValue"] != null)
                    {
                        string SearchStringValue = Session["SearchValue"].ToString().Trim();
                        lblParttosearch.Text = SearchStringValue;
                        BindSearchData(SearchStringValue);
                    }
                    else
                    {
                        BindEmptyGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Binds the empty grid.
        /// </summary>
        private void BindEmptyGrid()
        {
            grdSearchResults.DataSource = null;
            grdSearchResults.DataBind();
        }

        /// <summary>
        /// Binds the search data.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        private void BindSearchData(string searchText)
        {
            try
            {
                if (userToLogin != null)
                {
                    currUserId = (Guid)userToLogin.ProviderUserKey;
                    IEnumerable<ICBrowser.Common.Component> lst = Master.PageController.SearchComponents(searchText, currUserId);

                    DataTable dtForGrid = new DataTable();
                    dtForGrid.Columns.Add("ComponentName", typeof(string));
                    dtForGrid.Columns.Add("Quantity", typeof(int));
                    dtForGrid.Columns.Add("BrandName", typeof(string));
                    dtForGrid.Columns.Add("CompanyName", typeof(string));
                    dtForGrid.Columns.Add("userId", typeof(Guid));
                    dtForGrid.Columns.Add("ModifiedOn", typeof(string));
                    dtForGrid.Columns.Add("PriceInUSD", typeof(decimal));
                    dtForGrid.Columns.Add("Description", typeof(string));
                    dtForGrid.Columns.Add("Package", typeof(string));
                    dtForGrid.Columns.Add("DateCode", typeof(string));
                    dtForGrid.Columns.Add("StockStatus", typeof(int));
                    dtForGrid.Columns.Add("isOffer", typeof(int));

                    DataRow drForGrid;
                    foreach (ICBrowser.Common.Component drDetails in lst)
                    {
                        drForGrid = dtForGrid.NewRow();
                        drForGrid["ComponentName"] = drDetails.ComponentName;
                        drForGrid["CompanyName"] = drDetails.CompanyName;
                        drForGrid["Quantity"] = drDetails.Quantity;
                        drForGrid["BrandName"] = drDetails.BrandName;
                        drForGrid["userId"] = drDetails.UserId;
                        drForGrid["PriceInUSD"] = drDetails.PriceInUSD;
                        drForGrid["ModifiedOn"] = drDetails.ModifiedOn.ToString("dd-MMM-yyyy");
                        drForGrid["Package"] = drDetails.package;
                        drForGrid["Description"] = drDetails.Description;
                        drForGrid["DateCode"] = drDetails.datecode;
                        drForGrid["StockStatus"] = drDetails.stockstatus;
                        drForGrid["isOffer"] = drDetails.isOffer;
                        dtForGrid.Rows.Add(drForGrid);
                    }
                    grdSearchResults.DataSource = dtForGrid;
                    grdSearchResults.DataBind();
                }
                else
                {
                    IEnumerable<ICBrowser.Common.Component> lst = Master.PageController.SearchComponents(searchText, currUserId);

                    DataTable dtForGrid = new DataTable();
                    dtForGrid.Columns.Add("ComponentName", typeof(string));
                    dtForGrid.Columns.Add("Quantity", typeof(int));
                    dtForGrid.Columns.Add("BrandName", typeof(string));
                    dtForGrid.Columns.Add("CompanyName", typeof(string));
                    dtForGrid.Columns.Add("userId", typeof(Guid));
                    dtForGrid.Columns.Add("ModifiedOn", typeof(string));
                    dtForGrid.Columns.Add("PriceInUSD", typeof(decimal));
                    dtForGrid.Columns.Add("Description", typeof(string));
                    dtForGrid.Columns.Add("Package", typeof(string));
                    dtForGrid.Columns.Add("DateCode", typeof(string));
                    dtForGrid.Columns.Add("StockStatus", typeof(int));
                    dtForGrid.Columns.Add("isOffer", typeof(int));

                    DataRow drForGrid;
                    foreach (ICBrowser.Common.Component drDetails in lst)
                    {
                        drForGrid = dtForGrid.NewRow();
                        drForGrid["ComponentName"] = drDetails.ComponentName;
                        drForGrid["CompanyName"] = drDetails.CompanyName;
                        drForGrid["Quantity"] = drDetails.Quantity;
                        drForGrid["BrandName"] = drDetails.BrandName;
                        drForGrid["userId"] = drDetails.UserId;
                        drForGrid["PriceInUSD"] = drDetails.PriceInUSD;
                        drForGrid["ModifiedOn"] = drDetails.ModifiedOn.ToString("dd-MMM-yyyy");
                        drForGrid["Package"] = drDetails.package;
                        drForGrid["Description"] = drDetails.Description;
                        drForGrid["DateCode"] = drDetails.datecode;
                        drForGrid["StockStatus"] = drDetails.stockstatus;
                        drForGrid["isOffer"] = drDetails.isOffer;
                        dtForGrid.Rows.Add(drForGrid);
                    }
                    grdSearchResults.DataSource = dtForGrid;
                    grdSearchResults.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                grdSearchResults.DataSource = null;
                grdSearchResults.DataBind();
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the grdSearchResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void grdSearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSearchResults.PageIndex = e.NewPageIndex;
                BindSearchData(Session["SearchValue"].ToString().Trim());
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the grdSearchResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdSearchResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hlCompanyName = e.Row.FindControl("hlCompanyName") as HyperLink;
                Label lblStockStatus = ((Label)e.Row.FindControl("lblStockStatus"));
                Label lblCompanyName = ((Label)e.Row.FindControl("lblCompanyName"));

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
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    UserProfileDetails profiledetais = new UserProfileDetails();
                    int memTypeId = 0;
                    objuserpro = profiledetais.GetUserProfileDetails(UserId);
                    memTypeId = objuserpro.TypeOfMembership;
                    //chk for Admin.......
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(UserId);
                    if (Admin.IsAdmin || memTypeId <= 1)
                    {
                        hlCompanyName.Visible = false;
                        lnkComponentName.Visible = false;
                        LblComponentname.Visible = true;
                        lblCompanyName.Visible = true;
                    }
                    else
                    {
                        lnkComponentName.Visible = true;
                        hlCompanyName.Visible = true;
                    }
                    // hlCompanyName.Visible = true;
                    grdSearchResults.Columns[4].Visible = true;
                }
                else
                {
                    LblComponentname.Visible = true;
                    hlCompanyName.Visible = false;
                    grdSearchResults.Columns[4].Visible = false;
                }


                // Display Hot Image For Offer 
                Label lblIsOffer = ((Label)e.Row.FindControl("lblIsOffer"));
                Image imgHot = ((Image)e.Row.FindControl("imgHotOffer"));
                if (imgHot != null)
                {
                    if (lblIsOffer.Text.Trim() == "1") // is Offer
                    {
                        imgHot.Visible = true;
                    }
                    else // is not Offer
                    {
                        imgHot.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the grdSearchResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void grdSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkComponentName = (LinkButton)row.Cells[5].FindControl("lnkComponentName");
                LinkButton lnkUserId = (LinkButton)row.Cells[5].FindControl("lnkUserId");
                Label lblIsOffer = (Label)row.Cells[5].FindControl("lblIsOffer");
                if (lblIsOffer != null && lnkComponentName != null)
                {
                    //if (lblIsOffer.Text.Trim() == "1") // is Offer
                    //{
                    //Response.Redirect("OfferDetails.aspx?ComponentName=" + lnkComponentName.Text);
                    MembershipUser userToLogin = Membership.GetUser();
                    Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());

                    //  GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    // LinkButton lnkBtn = (LinkButton)row.Cells[0].FindControl("lnkUserId");
                    if (e.CommandName == "Select")
                    {

                        if (lnkComponentName != null)
                        {


                            string test1 = lnkComponentName.Text.Replace("&nbsp;", "");

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

                            Label lblPackage = row.FindControl("lblPackage") as Label;

                            if (lnkUserId != null)
                            {

                                values.Add(new Common.Component
                                {
                                    ComponentName = lnkComponentName.Text.Trim(),
                                    Quantity = Convert.ToInt32(test2),
                                    BrandName = test3,
                                    datecode = test4,
                                    PriceInUSD = Convert.ToDecimal(test5),
                                    Description = test6,
                                    package = lblPackage.Text
                                });
                            }

                        }

                        if (values.Count != 0)
                        {
                            htMoreDetailsInfo.Add("UserId", lnkUserId.Text.Trim());
                            htMoreDetailsInfo.Add("RequestType", "Offers");
                            htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                            htMoreDetailsInfo.Add("Page", "MoreDetails");
                            htMoreDetailsInfo.Add("Values", values);
                            Session["GetList"] = htMoreDetailsInfo;
                            Session["FileUpload1"] = "";
                            Response.Redirect("UserResponse.aspx", false);
                        }

                    }

                    else if ((e.CommandName == "SelectCompanyName"))
                    {
                        if (lnkUserId != null)
                        {
                            //Response.Redirect("NewUserProfile.aspx?UserId=" + lnkUserId.Text.Trim(), true);
                            string redUrl = "NewUserProfile.aspx?UserID=" + lnkUserId.Text.Trim();
                            ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
                        }

                    }
                    //  else // is not Offer
                    // {
                    // Response.Redirect("ComponentDetails.aspx?ComponentName=" + lnkComponentName.Text);
                    // }
                }
            }
        }
    }
}