using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class UserOffers : BasePage
    {
        ICBrowser.Business.UserOffersData objOfferSData = new Business.UserOffersData();
        Common.UserProfile objUserProfile = new Common.UserProfile(); //class Object
        List<Component> lstfound = new List<Component>();
        public Guid currUserId;
        string UserId = "";
        public bool SearchFlag;
        InventoryGridDetails objInventoryGridDetails = new InventoryGridDetails(); //class Object   


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //UserId = Request.QueryString["UserId"];
                MembershipUser userToLogin = Membership.GetUser();
                if (userToLogin != null)
                {
                    currUserId = (Guid)userToLogin.ProviderUserKey;

                    if (currUserId != null)
                    {
                        //Guid queryStrUserId = new Guid(Request.QueryString["UserId"]);
                        objUserProfile = objInventoryGridDetails.GetUserCountByUserId(currUserId);
                    }
                    else
                    {
                        objUserProfile = (Common.UserProfile)Session["UserProfile"];
                        // userprfl = objinventorygriddetails.getusercountbyuserid(userprfl.userid);
                    }

                    lblmsg.Visible = false;
                    if (!Page.IsPostBack)
                    {
                        lblmsg.Visible = false;
                        Controller controlIsAdmin = new Controller();
                        Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                        if (Admin.IsAdmin == true)
                        {
                            //  lblOperations.Visible = false;
                            string userid = Request.QueryString["UserID"].ToString();
                            grvOffer.Columns[10].Visible = false; // Edit Button
                            grvOffer.Columns[11].Visible = false; // Delete Button

                            img2.Visible = false;
                            img3.Visible = false;

                            lnbAddOffers.Visible = false;
                            lblBulkOfferUpload.Visible = false;
                            objUserProfile.UserID = new Guid(userid);
                        }

                        if (Session["UserProfile"] != null)
                        {
                            // objUserProfile = (ICBrowser.Common.UserProfile)Session["UserProfile"];
                            int MembershipTypeOfUser = objUserProfile.TypeOfMembership;
                            if (MembershipTypeOfUser != 0 || MembershipTypeOfUser != 1)
                            {
                                BindGrid(objUserProfile.UserID.ToString());
                            }
                            else
                            {
                                Response.Redirect("Default.aspx", false);
                            }
                        }
                        else
                        {
                            Response.Redirect("Default.aspx", false);
                        }


                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }



            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        private void BindGrid(string UserID)
        {
            ICBrowser.Business.UserOffersData objUserOffer = new Business.UserOffersData();
            try
            {
                if (UserID != null)
                {
                    Guid UserId = new Guid(UserID);
                    DataTable dtableInventoryDetails = objUserOffer.GetAllOfferDetailsByUserID(UserId);
                    DataTable dtableForGrid = new DataTable();
                    dtableForGrid.Columns.Add("Status", typeof(string));
                    dtableForGrid.Columns.Add("OfferId", typeof(int));
                    dtableForGrid.Columns.Add("ComponentName", typeof(string));
                    dtableForGrid.Columns.Add("Quantity", typeof(int));
                    //dtableForGrid.Columns.Add("StockInHand", typeof(int));
                    dtableForGrid.Columns.Add("Brandname", typeof(string));
                    dtableForGrid.Columns.Add("DateCode", typeof(string));
                    dtableForGrid.Columns.Add("Package", typeof(string));
                    dtableForGrid.Columns.Add("Description", typeof(string));
                    //dtableForGrid.Columns.Add("PriceInINR", typeof(decimal));
                    dtableForGrid.Columns.Add("PriceInUSD", typeof(decimal));
                    //dtableForGrid.Columns.Add("PriceInCNY", typeof(decimal));
                    dtableForGrid.Columns.Add("StockStatus", typeof(string));
                    //dtableForGrid.Columns.Add("Country", typeof(string));

                    DataRow drowForGrid;
                    foreach (DataRow drDetails in dtableInventoryDetails.Rows)
                    {
                        drowForGrid = dtableForGrid.NewRow();
                        if (drDetails["Status"].ToString().Equals("1"))
                        {
                            drowForGrid["Status"] = "Open";
                        }
                        else
                        {
                            drowForGrid["Status"] = "Closed";
                        }
                        drowForGrid["OfferId"] = drDetails["OfferId"];
                        drowForGrid["ComponentName"] = drDetails["ComponentName"];
                        drowForGrid["Quantity"] = drDetails["Quantity"];
                        drowForGrid["Brandname"] = drDetails["Brandname"];
                        drowForGrid["DateCode"] = drDetails["DateCode"];
                        drowForGrid["Package"] = drDetails["Package"];
                        drowForGrid["Description"] = drDetails["Description"];
                        //drowForGrid["PriceInINR"] = drDetails["PriceInINR"];
                        if (drDetails["PriceInUSD"].ToString().Equals("0.000")) 
                        {
                            drowForGrid["PriceInUSD"] = DBNull.Value;
                        } 
                        else                        
                        {
                            drowForGrid["PriceInUSD"] = drDetails["PriceInUSD"];
                        }
                       
                        //drowForGrid["PriceInCNY"] = drDetails["PriceInCNY"];

                        if (drDetails["StockStatus"].ToString().Equals("1"))
                        {
                            drowForGrid["StockStatus"] = "Available";
                        }
                        else
                        {
                            if (drDetails["StockStatus"].ToString().Equals("2"))
                            {
                                drowForGrid["StockStatus"] = "In House";
                            }
                            else
                            {
                                if (drDetails["StockStatus"].ToString().Equals("3"))
                                {
                                    drowForGrid["StockStatus"] = "OEM Excess";
                                }
                            }
                        }
                        dtableForGrid.Rows.Add(drowForGrid);
                    }
                    grvOffer.DataSource = dtableForGrid;
                    grvOffer.DataBind();
                }
                else
                {
                    grvOffer.DataSource = null;
                    grvOffer.DataBind();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        #region "Grid"
        protected void grvOffer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && this.grvOffer.EditIndex > -1 && e.Row.RowIndex == this.grvOffer.EditIndex)
            {
                DropDownList ddlnotes = e.Row.FindControl("ddlStatus") as DropDownList;
                //DropDownList ddlCountry = e.Row.FindControl("ddlCountry") as DropDownList;
                string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[0].ToString();
                // string country = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[13].ToString();

                if (ddlnotes != null)
                {
                    if (status.Equals("Closed"))
                    {
                        ddlnotes.SelectedValue = "0";
                    }
                    else
                    {
                        ddlnotes.SelectedValue = "1";
                    }
                }
            }
        }

        protected void grvOffer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ICBrowser.Common.Component objUserOffer = new ICBrowser.Common.Component();
            MembershipUser userToLogin = Membership.GetUser();
            string UserId = userToLogin.ProviderUserKey.ToString();

            try
            {

                if (UserId != null)
                {
                    objUserOffer.Componentid = Convert.ToInt32(((Label)grvOffer.Rows[e.RowIndex].FindControl("LblOfferId")).Text);
                    objOfferSData.DeleteOfferOnRowDeleting(objUserOffer.Componentid, UserId);
                    setGridPosition();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        private void setGridPosition()
        {
            ICBrowser.Business.UserOffersData objOfferSData = new Business.UserOffersData();
            try
            {
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = objOfferSData.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue, currUserId);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlstockstatus.SelectedValue) > 0)
                    {
                        lstfound = objOfferSData.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstockstatus.SelectedValue, currUserId);
                        bindSearchFromGrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = objOfferSData.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text, currUserId);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            Controller controlIsAdmin = new Controller();
                            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                            if (Admin.IsAdmin == true)
                            {
                                UserId = Request.QueryString["UserID"].ToString();
                            }
                            else
                            {
                                UserId = Convert.ToString(objUserProfile.UserID);
                            }

                            if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                            {
                                BindGrid(UserId);
                            }
                            else
                            {
                                BindGrid(UserId);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void grvOffer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<ICBrowser.Common.Component> lstUserOffer = new List<ICBrowser.Common.Component>();
            ICBrowser.Common.Component objUserOffer = new ICBrowser.Common.Component();

            ICBrowser.Business.UserOffersData objOfferSData = new Business.UserOffersData();
            MembershipUser userToLogin = Membership.GetUser();
            string UserId = userToLogin.ProviderUserKey.ToString();
            try
            {
                if (UserId != null)
                {
                    objUserOffer.OfferId = Convert.ToInt32(((Label)grvOffer.Rows[e.RowIndex].FindControl("LblOfferId")).Text); // this is actually OfferId   
                    //objUserOffer.Status = Convert.ToInt32(((DropDownList)grvOffer.Rows[e.RowIndex].FindControl("ddlStatus")).Text);
                    objUserOffer.ComponentName = ((Label)grvOffer.Rows[e.RowIndex].FindControl("LblComponentname")).Text;
                    objUserOffer.Quantity = Convert.ToInt32(((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtQuantity")).Text);
                    objUserOffer.BrandName = ((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtBrandName")).Text;
                    objUserOffer.datecode = ((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtdateCode")).Text;
                    objUserOffer.package = ((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtpackage")).Text;
                    objUserOffer.Description = ((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtDescription")).Text;
                    objUserOffer.PriceInINR = null;
                    string prinUSD = ((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtprinUSD")).Text;
                    if (!prinUSD.ToString().Equals(""))
                    {
                        objUserOffer.PriceInUSD = Convert.ToDecimal(((TextBox)grvOffer.Rows[e.RowIndex].FindControl("txtprinUSD")).Text);
                    }
                    else
                    {
                        objUserOffer.PriceInUSD = 0;
                    }
                    objUserOffer.PriceInCNY = null;
                    string stkstatus = ((Label)grvOffer.Rows[e.RowIndex].FindControl("lblStkstatus")).Text;
                    if (stkstatus == "Available")
                    {
                        objUserOffer.stockstatus = 1;
                    }
                    else if (stkstatus == "In House")
                    {
                        objUserOffer.stockstatus = 2;
                    }
                    else if (stkstatus == "OEM Excess")
                    {
                        objUserOffer.stockstatus = 3;
                    }
                    objUserOffer.country = null;
                    objUserOffer.UserId = new Guid(UserId);
                    objOfferSData.UpdateOffers(objUserOffer);
                    grvOffer.EditIndex = -1;
                    setGridPosition();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        protected void grvOffer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UserOffersData ObjUserOffer = new UserOffersData();
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                string UserId = userToLogin.ProviderUserKey.ToString();
                grvOffer.EditIndex = e.NewEditIndex;
                BindGrid(UserId);

                setGridPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);

            }
        }

        protected void grvOffer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UserOffersData objUserOffer = new UserOffersData();
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                string UserId = userToLogin.ProviderUserKey.ToString();
                grvOffer.EditIndex = -1;
                setGridPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grvOffer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string UserId = "";
            UserOffersData objUserOffer = new UserOffersData();
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                UserId = userToLogin.ProviderUserKey.ToString();
                grvOffer.PageIndex = e.NewPageIndex;
                //BindGrid(UserId);

                setGridPosition();

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
        #endregion

        protected void lnbAddOffers_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadOffers.aspx?RequestType=Offers", false);
        }

        protected void lblBulkOfferUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadBulkOffers.aspx", false);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string UserId;
            if (Request.QueryString["UserID"] != null)
            {
                UserId = Request.QueryString["UserID"].ToString();
            }
            else
            {
                MembershipUser userToLogin = Membership.GetUser();
                UserId = userToLogin.ProviderUserKey.ToString();
            }


            ICBrowser.Common.Component objUserOffer = new ICBrowser.Common.Component();
            ICBrowser.Business.UserOffersData objOfferSData = new Business.UserOffersData();
            foreach (GridViewRow gv in grvOffer.Rows)
            {
                CheckBox chkBx = (CheckBox)gv.FindControl("chkbx");
                if (chkBx != null && chkBx.Checked)
                {
                    flag = true;
                    Label LblComponentId = (Label)gv.FindControl("LblOfferId");
                    objUserOffer.Componentid = Convert.ToInt32(LblComponentId.Text);
                    objOfferSData.DeleteOfferOnRowDeleting(objUserOffer.Componentid, UserId);
                    lblmsg.Text = "Offers deleted succesfully.";
                }
            }
            if (flag == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please select Offers to delete";
            }
            else
            {
                lblmsg.Text = "Offers deleted succesfully.";
            }
            BindGrid(UserId);

        }

        protected void ddlInventoryGridColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchFromGrid.Text = String.Empty;
            if (ddlInventoryGridColumns.SelectedItem.Value == "4") //check for Status
            {
                ddlstatus.Visible = true;
                ddlstatus.SelectedValue = "-1";

                ddlstockstatus.Visible = false;
                txtSearchFromGrid.Visible = false;
                imgSearchFromGrid.Visible = false;
            }
            else if (ddlInventoryGridColumns.SelectedValue == "5")   //check for stock status
            {
                ddlstockstatus.Visible = true;
                ddlstockstatus.SelectedValue = "0";

                ddlstatus.Visible = false;
                txtSearchFromGrid.Visible = false;
                imgSearchFromGrid.Visible = false;
            }
            else //its a normal text search 
            {
                txtSearchFromGrid.Visible = true;
                imgSearchFromGrid.Visible = true;
                ddlstatus.Visible = false;
                ddlstatus.ClearSelection();
                ddlstockstatus.Visible = false;
                ddlstockstatus.ClearSelection();
            }
            setGridPosition();
        }

        protected void imgClearSearchSelection_Click(object sender, ImageClickEventArgs e)
        {
            string UserId = "";
            MembershipUser userToLogin = Membership.GetUser();
            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                UserId = Request.QueryString["UserID"].ToString();
            }
            else
            {
                UserId = userToLogin.ProviderUserKey.ToString();
            }      
          
            ddlInventoryGridColumns.ClearSelection();
            ddlstatus.Visible = false;
            ddlstatus.ClearSelection();
            ddlstockstatus.Visible = false;
            ddlstockstatus.ClearSelection();

            txtSearchFromGrid.Text = "";
            imgSearchFromGrid.Visible = true;
            txtSearchFromGrid.Visible = true;

            BindGrid(UserId);
        }

        protected void imgSearchFromGrid_Click(object sender, ImageClickEventArgs e)
        {
            SearchFlag = true;
            ICBrowser.Business.UserOffersData objUserOffer = new Business.UserOffersData();

            try
            {
                string UserID = "";
                Guid newUserId = new Guid();
                //objUserProfile = (ICBrowser.Common.UserProfile)Session["UserProfile"];
                //UserId = objUserProfile.UserID.ToString();
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    UserId = Request.QueryString["UserID"].ToString();
                    newUserId = new Guid(Request.QueryString["UserID"].ToString());
                }
                else
                {
                    UserId = Convert.ToString(objUserProfile.UserID);
                    newUserId = objUserProfile.UserID;
                }
                if ((Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) >= 0) && (txtSearchFromGrid.Text == ""))
                {
                    BindGrid(UserId);
                }
                else
                {

                    ddlstockstatus.ClearSelection();
                    lstfound = objUserOffer.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text, newUserId);
                    bindSearchFromGrid();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// method that binds grid with Searched data
        /// </summary>
        protected void bindSearchFromGrid()
        {
            try
            {
                //bind the grid according to text entered          
                DataTable dtableForGrid = new DataTable();
                dtableForGrid.Columns.Add("Status", typeof(string));
                dtableForGrid.Columns.Add("OfferId", typeof(int));
                dtableForGrid.Columns.Add("ComponentName", typeof(string));
                dtableForGrid.Columns.Add("Quantity", typeof(int));
                //dtableForGrid.Columns.Add("StockInHand", typeof(int));
                dtableForGrid.Columns.Add("Brandname", typeof(string));
                dtableForGrid.Columns.Add("DateCode", typeof(string));
                dtableForGrid.Columns.Add("Package", typeof(string));
                dtableForGrid.Columns.Add("Description", typeof(string));
                //dtableForGrid.Columns.Add("PriceInINR", typeof(decimal));
                dtableForGrid.Columns.Add("PriceInUSD", typeof(decimal));
                //dtableForGrid.Columns.Add("PriceInCNY", typeof(decimal));
                dtableForGrid.Columns.Add("StockStatus", typeof(string));
                //dtableForGrid.Columns.Add("Country", typeof(string));
                DataRow drow;

                foreach (ICBrowser.Common.Component Offerdata in lstfound)
                {
                    drow = dtableForGrid.NewRow();
                    drow["OfferId"] = Offerdata.OfferId;
                    if (Offerdata.Status == 1)
                        drow["Status"] = "Open";

                    else
                        drow["Status"] = "Closed";
                    drow["ComponentName"] = Offerdata.ComponentName;
                    drow["Quantity"] = Offerdata.Quantity;

                    //if (!Offerdata.StockInHand.ToString().Equals(""))
                    //{
                    //    drow["StockInHand"] = Offerdata.StockInHand;
                    //}
                    //else
                    //{
                    //    drow["StockInHand"] = 0;
                    //}

                    drow["BrandName"] = Offerdata.BrandName;

                    //if (!Offerdata.PriceInINR.ToString().Equals(""))
                    //{
                    //    drow["PriceInINR"] = Offerdata.PriceInINR;
                    //}
                    //else
                    //{
                    //    drow["PriceInINR"] = 0.00;
                    //}

                    drow["Package"] = Offerdata.package;
                    drow["DateCode"] = Offerdata.datecode;

                    if (!Offerdata.PriceInUSD.ToString().Equals(""))
                    {
                        drow["PriceInUSD"] = Offerdata.PriceInUSD;
                    }
                    else
                    {
                        drow["PriceInUSD"] = 0.00;
                    }

                    //if (!Offerdata.PriceInCNY.ToString().Equals(""))
                    //{
                    //    drow["PriceInCNY"] = Offerdata.PriceInCNY;
                    //}
                    //else
                    //{
                    //    drow["PriceInCNY"] = 0.00;
                    //}

                    if (Offerdata.stockstatus == 1)
                    {
                        drow["StockStatus"] = "Available";
                    }
                    else
                    {
                        if (Offerdata.stockstatus == 2)
                        {
                            drow["StockStatus"] = "In House";
                        }
                        else
                        {
                            if (Offerdata.stockstatus == 3)
                            {
                                drow["StockStatus"] = "OEM Excess";
                            }
                            else
                            {
                                // dr["StockStatus"] = "---";
                            }
                        }
                    }
                    drow["Description"] = Offerdata.Description;
                    //drow["Country"] = Offerdata.country;
                    dtableForGrid.Rows.Add(drow);
                }
                grvOffer.DataSource = dtableForGrid;
                grvOffer.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFlag = false;
            ICBrowser.Business.UserOffersData objUserOffer = new Business.UserOffersData();
            try
            {
                ddlstockstatus.ClearSelection();
                txtSearchFromGrid.Text = "";
                lstfound = objUserOffer.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue, currUserId);
                bindSearchFromGrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void ddlstockstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFlag = false;
            ICBrowser.Business.UserOffersData objUserOffer = new Business.UserOffersData();
            try
            {
                ddlstatus.ClearSelection();
                txtSearchFromGrid.Text = "";
                lstfound = objUserOffer.getOfferDetailsOnSearch(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstockstatus.SelectedValue, currUserId);
                bindSearchFromGrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
    }
}