using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ICBrowser.Business;
using ICBrowser.Web;
using System.Collections;
using System.Collections.Generic;
using ICBrowser.Common;
using System.Web.Security;
using System.Data.SqlClient;

namespace ICBrowser.Web
{
    /// <summary>
    /// Class MoreDetails.
    /// </summary>
    public partial class MoreDetails : BasePage
    {
        List<Common.Component> values = new List<Common.Component>();
        static string prevPage = String.Empty;
        Hashtable htMoreDetailsInfo = new Hashtable();
        Hashtable htFullPartsListInfo = new Hashtable();
        string type = "";
        MembershipUser userToLogin = Membership.GetUser();
        Guid loggedInUserId;


        /// <summary>
        /// Previouses the page on back button click.
        /// </summary>
        private void PreviousPageOnBackButtonClick()
        {
            // Need to use session for storing previous page value.
            // On Localization Page is Post back Twice so prevPage Lost its previous value stored.
            // hence to remember previous value of 'prevPage', Session["PreviousPageValue"] is used. which is clean after its use.

            try
            {
                prevPage = string.Empty;
                prevPage = Request.UrlReferrer.ToString();
                if (Session["PreviousPageValue"] == null)
                {
                    //Session is Created.
                    Session["PreviousPageValue"] = prevPage;

                }
                else
                {
                    if (prevPage.Equals(Session["PreviousPageValue"].ToString()))
                    {
                        prevPage = Request.UrlReferrer.ToString();
                        Session.Remove("PreviousPageValue");
                        // do nothing
                    }
                    else
                    {
                        prevPage = Request.UrlReferrer.ToString();
                        //prevPage = Session["PreviousPageValue"].ToString();

                        //Session is destroy it of not no use now. It is of no use.,
                        Session.Remove("PreviousPageValue");
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataGrid();
                PreviousPageOnBackButtonClick();
            }
        }

        /// <summary>
        /// Binds the data grid.
        /// </summary>
        public void BindDataGrid()
        {
            loggedInUserId = (Guid)userToLogin.ProviderUserKey;
            try
            {
                htFullPartsListInfo = (Hashtable)Session["FullList"];
                Guid UserId = new Guid(htFullPartsListInfo["UserId"].ToString());
                type = htFullPartsListInfo["type"].ToString();

                if (UserId != null)
                {
                    if (type == "Requirement" || type == "RequirementwithPO")
                    {
                        List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<BuyersRequirements>();
                        UserRequirements UserData = new UserRequirements();
                        btnquote.Text = "Quote";
                        if (type == "Requirement")
                        {
                            lblHeading.Text = "View full list of Requirements by member";
                            buyersDetails = UserData.UserRequirementListingRFQByUserId(UserId);
                        }
                        else
                        {
                            lblHeading.Text = "View full list of Requirements With PO by member";
                            buyersDetails = UserData.UserDetailRequirementsByUserIdwithPO(UserId);
                        }
                        DataTable dtBuyersDetails = new DataTable();
                        dtBuyersDetails.Columns.Add("UserId", typeof(Guid));
                        dtBuyersDetails.Columns.Add("ComponentName", typeof(string));
                        dtBuyersDetails.Columns.Add("Quantity", typeof(int));
                        dtBuyersDetails.Columns.Add("StockStatus", typeof(int));
                        dtBuyersDetails.Columns.Add("BrandName", typeof(string));
                        dtBuyersDetails.Columns.Add("DateCode", typeof(string));
                        dtBuyersDetails.Columns.Add("Package", typeof(string));
                        dtBuyersDetails.Columns.Add("Description", typeof(string));
                        dtBuyersDetails.Columns.Add("PriceInUSD", typeof(decimal));
                        dtBuyersDetails.Columns.Add("RequirementWithPO", typeof(string));
                        dtBuyersDetails.Columns.Add("ModifiedDate", typeof(DateTime));
                        dtBuyersDetails.Columns.Add("ModifiedOn", typeof(DateTime));
                        dtBuyersDetails.Columns.Add("ModifyDate", typeof(DateTime));


                        DataRow dr;

                        foreach (ICBrowser.Common.BuyersRequirements buyerReqEntry in buyersDetails)
                        {
                            dr = dtBuyersDetails.NewRow();
                            dr["UserId"] = buyerReqEntry.userId;
                            dr["ComponentName"] = buyerReqEntry.ComponentName;
                            dr["Quantity"] = buyerReqEntry.Quantity;
                            dr["StockStatus"] = 0;
                            dr["BrandName"] = buyerReqEntry.BrandName;
                            dr["DateCode"] = buyerReqEntry.DateCode;
                            if (buyerReqEntry.PriceInUSD == 0)
                            {
                                dr["PriceInUSD"] = DBNull.Value;
                            }
                            else
                            {
                                dr["PriceInUSD"] = buyerReqEntry.PriceInUSD;
                            }
                            dr["Description"] = buyerReqEntry.Description;
                            dr["Package"] = buyerReqEntry.Package; 
                            if (buyerReqEntry.RequirementwithPO == true)
                                dr["RequirementWithPO"] = "PO";
                            else
                                dr["RequirementWithPO"] = "RFQ";
                            dr["ModifiedDate"] = buyerReqEntry.ModifiedDate.ToString();
                            dr["ModifiedOn"] = DateTime.Now;                            
                            //dr["ModifyDate"] = buyerReqEntry.ModifiedDate; ;

                            dtBuyersDetails.Rows.Add(dr);
                        }
                        hnkCompanyName.Text = buyersDetails[0].CompanyName;
                        gvBuyrListng.DataSource = dtBuyersDetails;
                        gvBuyrListng.DataBind();
                    }
                    else
                    {
                        btnquote.Text = "Request Quote";
                        lblHeading.Text = "View full list of offers by member :";
                        SellerInventoryListing Offer = new SellerInventoryListing();
                        List<ICBrowser.Common.Component> OfferDetails = Offer.UserOfferDetailsForMatch(UserId, loggedInUserId);
                        DataTable dtOfferDetails = new DataTable();
                        dtOfferDetails.Columns.Add("UserId", typeof(Guid));
                        dtOfferDetails.Columns.Add("ComponentName", typeof(string));
                        dtOfferDetails.Columns.Add("Quantity", typeof(int));
                        dtOfferDetails.Columns.Add("StockStatus", typeof(int));
                        dtOfferDetails.Columns.Add("BrandName", typeof(string));
                        dtOfferDetails.Columns.Add("DateCode", typeof(string));
                        dtOfferDetails.Columns.Add("Package", typeof(string));
                        dtOfferDetails.Columns.Add("Description", typeof(string));
                        dtOfferDetails.Columns.Add("PriceInUSD", typeof(decimal));
                        dtOfferDetails.Columns.Add("RequirementWithPO", typeof(string));
                        dtOfferDetails.Columns.Add("ModifiedDate", typeof(DateTime));
                        dtOfferDetails.Columns.Add("ModifiedOn", typeof(DateTime));


                        DataRow dr;

                        foreach (ICBrowser.Common.Component OfferEntry in OfferDetails)
                        {
                            dr = dtOfferDetails.NewRow();
                            dr["UserId"] = OfferEntry.UserId;
                            dr["ComponentName"] = OfferEntry.ComponentName;
                            dr["Quantity"] = OfferEntry.Quantity;
                            dr["StockStatus"] = OfferEntry.stockstatus;
                            dr["BrandName"] = OfferEntry.BrandName;
                            dr["DateCode"] = OfferEntry.datecode;
                            if (OfferEntry.PriceInUSD == 0)
                            {
                                dr["PriceInUSD"] = DBNull.Value;
                            }
                            else
                            {
                                dr["PriceInUSD"] = OfferEntry.PriceInUSD; 
                            }
                            dr["Description"] = OfferEntry.Description;
                            dr["Package"] = OfferEntry.package;                            
                            dr["RequirementWithPO"] = "Requirement";
                            dr["ModifiedDate"] = DateTime.Now;
                            dr["ModifiedOn"] = OfferEntry.ModifiedOn.ToString();
                            dtOfferDetails.Rows.Add(dr);
                        }

                        hnkCompanyName.Text = OfferDetails[0].CompanyName;
                        gvBuyrListng.DataSource = dtOfferDetails;
                        gvBuyrListng.DataBind();
                    }


                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the PageIndexChanging event of the gvBuyrListng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvBuyrListng_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BindDataGrid();
                gvBuyrListng.PageIndex = e.NewPageIndex;
                gvBuyrListng.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvBuyrListng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvBuyrListng_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());
                htFullPartsListInfo = (Hashtable)Session["FullList"];
                type = htFullPartsListInfo["type"].ToString();


                if (e.CommandName == "Select")
                {

                    if (userToLogin != null)
                    {
                        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                        LinkButton lnkSellerId = (LinkButton)row.Cells[0].FindControl("lnkSellerId");


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



                        if (values.Count != 0)
                        {
                            htMoreDetailsInfo.Add("UserId", lnkSellerId.Text.Trim());
                            if (type == "Offer")
                            {
                                htMoreDetailsInfo.Add("RequestType", "Offers");
                            }
                            else
                            {
                                htMoreDetailsInfo.Add("RequestType", "Requirements");
                            }
                            htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                            htMoreDetailsInfo.Add("Page", "MoreDetails");
                            htMoreDetailsInfo.Add("Values", values);


                            Session["GetList"] = htMoreDetailsInfo;
                            Session["FileUpload1"] = "";
                            Response.Redirect("UserResponse.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// Handles the RowDataBound event of the gvBuyrListng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvBuyrListng_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    type = htFullPartsListInfo["type"].ToString();

                    Label lblStockStatus = ((Label)e.Row.FindControl("lblStockStatus"));


                    if (lblStockStatus.Text == "1")
                        lblStockStatus.Text = "Available";
                    else if (lblStockStatus.Text == "2")
                        lblStockStatus.Text = "In House";
                    else
                        lblStockStatus.Text = "OEM Excess";

                    if (type == "Requirement")
                    {
                        HyperLink hlComponentName = ((HyperLink)e.Row.FindControl("hlComponentName"));
                        hlComponentName.Visible = false;
                        gvBuyrListng.Columns[5].Visible = true;
                        gvBuyrListng.Columns[3].Visible = false;
                        gvBuyrListng.Columns[10].Visible = false;
                    }
                    else if (type == "RequirementwithPO")
                    {
                        HyperLink hlComponentName = ((HyperLink)e.Row.FindControl("hlComponentName"));
                        hlComponentName.Visible = false;
                        gvBuyrListng.Columns[5].Visible = true;
                        gvBuyrListng.Columns[3].Visible = false;
                        gvBuyrListng.Columns[10].Visible = false;
                    }
                    else
                    {
                        //gvBuyrListng.Columns[6].Visible = false;
                        //gvBuyrListng.Columns[9].Visible = false;
                        gvBuyrListng.Columns[10].Visible = false;
                    }
                    GridViewRow gvr = e.Row;
                    if (gvr.RowType.Equals(DataControlRowType.DataRow))
                        (gvr.FindControl("hlComponentName") as HyperLink).ToolTip = "Click to view Datasheet";
                }


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the hnkCompanyName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void hnkCompanyName_Click(object sender, EventArgs e)
        {
            htFullPartsListInfo = (Hashtable)Session["FullList"];
            Guid UserId = new Guid(htFullPartsListInfo["UserId"].ToString());
            //Response.Redirect("NewUserProfile.aspx?UserID=" + UserId);
            string redUrl = "NewUserProfile.aspx?UserID=" + UserId;
            ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
        }

        /// <summary>
        /// Handles the Click event of the btnback control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            //Response.Redirect(prevPage);
            ClientScript.RegisterStartupScript(this.GetType(), "ViewDetails", "<script>window.close();</script>");
        }

        protected void btnquote_Click(object sender, EventArgs e)
        {
            htFullPartsListInfo = (Hashtable)Session["FullList"];
            Guid UserId = new Guid(htFullPartsListInfo["UserId"].ToString());
            loggedInUserId = (Guid)userToLogin.ProviderUserKey;
            type = htFullPartsListInfo["type"].ToString();
            if (UserId != null)
            {
                if (type == "Requirement" || type == "RequirementwithPO")
                {
                    UserRequirements UserData = new UserRequirements();
                    List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<BuyersRequirements>();
                    if (type == "Requirement")
                    {
                        buyersDetails = UserData.UserRequirementListingRFQByUserId(UserId);

                        foreach (var i in buyersDetails)
                        {
                            if (i.PriceInUSD == 0)
                            {
                                i.PriceInUSD = null;
                            }
                            values.Add(new Common.Component
                            {

                                ComponentName = i.ComponentName,
                                Quantity = i.Quantity,
                                BrandName = i.BrandName,
                                datecode = i.DateCode,
                                PriceInUSD = i.PriceInUSD,
                                Description = i.Description

                            });
                        }


                        htMoreDetailsInfo.Add("UserId", UserId);
                        htMoreDetailsInfo.Add("RequestType", "Requirements");
                        htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                        htMoreDetailsInfo.Add("Page", "MoreDetails");
                        htMoreDetailsInfo.Add("Values", values);
                        Session["GetList"] = htMoreDetailsInfo;
                        Session["FileUpload1"] = "";
                        //Response.Redirect("MoreDetails.aspx", false);
                        Response.Redirect("UserResponse.aspx", false);
                    }
                    else
                    {
                        buyersDetails = UserData.UserDetailRequirementsByUserIdwithPO(UserId);

                        foreach (var i in buyersDetails)
                        {
                            if (i.PriceInUSD == 0)
                            {
                                i.PriceInUSD = null;
                            }
                            values.Add(new Common.Component
                            {

                                ComponentName = i.ComponentName,
                                Quantity = i.Quantity,
                                BrandName = i.BrandName,
                                datecode = i.DateCode,
                                PriceInUSD = i.PriceInUSD,
                                Description = i.Description

                            });
                        }

                        htMoreDetailsInfo.Add("UserId", UserId);
                        htMoreDetailsInfo.Add("RequestType", "Requirements");
                        htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                        htMoreDetailsInfo.Add("Page", "MoreDetails");
                        htMoreDetailsInfo.Add("Values", values);
                        Session["GetList"] = htMoreDetailsInfo;
                        Session["FileUpload1"] = "";
                        //Response.Redirect("MoreDetails.aspx", false);
                        Response.Redirect("UserResponse.aspx", false);
                    }

                }
                else
                {
                    SellerInventoryListing Offer = new SellerInventoryListing();
                    List<ICBrowser.Common.Component> OfferDetails = new List<ICBrowser.Common.Component>();

                    OfferDetails = Offer.UserOfferDetailsForMatch(UserId, loggedInUserId);

                    foreach (var i in OfferDetails)
                    {
                        if (i.PriceInUSD == 0)
                        {
                            i.PriceInUSD = null;
                        }
                        values.Add(new Common.Component
                        {
                            ComponentName = i.ComponentName,
                            Quantity = i.Quantity,
                            BrandName = i.BrandName,
                            datecode = i.datecode,
                            PriceInUSD = i.PriceInUSD,
                            Description = i.Description

                        });
                    }

                    htMoreDetailsInfo.Add("UserId", UserId);
                    htMoreDetailsInfo.Add("RequestType", "Offers");
                    htMoreDetailsInfo.Add("PartNo", values[0].ComponentName);
                    htMoreDetailsInfo.Add("Page", "MoreDetails");
                    htMoreDetailsInfo.Add("Values", values);
                    Session["GetList"] = htMoreDetailsInfo;
                    Session["FileUpload1"] = "";
                    //Response.Redirect("MoreDetails.aspx", false);
                    Response.Redirect("UserResponse.aspx", false);
                }
            }
        }
    }

}


