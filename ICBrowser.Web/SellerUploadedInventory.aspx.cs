
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using ICBrowser.Web.Controls;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Data;

namespace ICBrowser.Web
{
    /// <summary>
    /// Class SellerUploadedInventory.
    /// </summary>
    public partial class SellerUploadedInventory : BasePage
    {
        #region "public Parameters"
        Business.InventoryGridDetails objInventoryGridDetails = new Business.InventoryGridDetails();
        Common.Component objComponent = new Common.Component();
        Common.UserProfile UserPrfl = new Common.UserProfile();
        List<Component> lstfound = new List<Component>();
        public int typeOfMembershipId = 0;

        #endregion

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                if (userToLogin != null)
                {
                    Guid userId = (Guid)userToLogin.ProviderUserKey;
                    lblmsg.Visible = false;

                    if (Request.QueryString["UserId"] != null)
                    {
                        Guid queryStrUserId = new Guid(Request.QueryString["UserId"]);
                        UserPrfl = objInventoryGridDetails.GetUserCountByUserId(queryStrUserId);
                    }
                    else
                    {
                        UserPrfl = (Common.UserProfile)Session["UserProfile"];
                    }

                    typeOfMembershipId = UserPrfl.TypeOfMembership;

                    //chk for admin...
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(userId);
                    if (Admin.IsAdmin == true)
                    {
                        
                        img1.Visible = false;
                        img2.Visible = false;

                        grdInventoryDetails.Columns[10].Visible = false; // Edit Button
                        grdInventoryDetails.Columns[11].Visible = false; // Delete Button
                      
                        lnkBulkAddInventory.Visible = false;
                        lnkAddInventory.Visible = false;

                        lblExcessMessage.Visible = false;
                        lblUploadMessage.Visible = false;
                    }

                    // ********At this stage also check if membership is Trial cause Trial member cannot Upload Inventories except offers ************//
                    if (typeOfMembershipId > 1 || Admin.IsAdmin == true)  //if true means member is Paid OR Trial member (not free member i.e Buyer)
                    {
                        lblExcessMessage.Visible = false;
                        lblUploadMessage.Visible = false;

                        if (!IsPostBack)
                        {
                            txtSearchFromGrid.Text = "";
                            ddlstockstatus.ClearSelection();
                            ddlstatus.ClearSelection();
                            bindgrid(UserPrfl.UserID);
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", true);
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

        #region "Inventory grid Operation(Edit/delete)"

        /// <summary>
        /// method for Binding grid with search result
        /// </summary>
        protected void bindSearchFromGrid()
        {
            try
            {
                //bind the grid according to text entered          
                DataTable dtableForGrid = new DataTable();
                dtableForGrid.Columns.Add("Status", typeof(string));
                dtableForGrid.Columns.Add("ComponentId", typeof(int));
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

                foreach (ICBrowser.Common.Component inventorydata in lstfound)
                {
                    drow = dtableForGrid.NewRow();
                    drow["ComponentId"] = inventorydata.Componentid;
                    if (inventorydata.Status == 1)
                        drow["Status"] = "Open";

                    else
                        drow["Status"] = "Closed";
                    drow["ComponentName"] = inventorydata.ComponentName;
                    drow["Quantity"] = inventorydata.Quantity;

                    //if (!inventorydata.StockInHand.ToString().Equals(""))
                    //{
                    //    drow["StockInHand"] = inventorydata.StockInHand;
                    //}
                    //else
                    //{
                    //    drow["StockInHand"] = 0;
                    //}

                    drow["BrandName"] = inventorydata.BrandName;

                    //if (!inventorydata.PriceInINR.ToString().Equals(""))
                    //{
                    //    drow["PriceInINR"] = inventorydata.PriceInINR;
                    //}
                    //else
                    //{
                    //    drow["PriceInINR"] = 0.00;
                    //}

                    drow["Package"] = inventorydata.package;
                    drow["DateCode"] = inventorydata.datecode;

                    if (!inventorydata.PriceInUSD.ToString().Equals(""))
                    {
                        drow["PriceInUSD"] = inventorydata.PriceInUSD;
                    }
                    else
                    {
                        drow["PriceInUSD"] = 0.00;
                    }

                    //if (!inventorydata.PriceInCNY.ToString().Equals(""))
                    //{
                    //    drow["PriceInCNY"] = inventorydata.PriceInCNY;
                    //}
                    //else
                    //{
                    //    drow["PriceInCNY"] = 0.00;
                    //}

                    if (inventorydata.stockstatus == 1)
                    {
                        drow["StockStatus"] = "Available";
                    }
                    else
                    {
                        if (inventorydata.stockstatus == 2)
                        {
                            drow["StockStatus"] = "In House";
                        }
                        else
                        {
                            if (inventorydata.stockstatus == 3)
                            {
                                drow["StockStatus"] = "OEM Excess";
                            }
                            else
                            {
                                // dr["StockStatus"] = "---";
                            }
                        }
                    }
                    drow["Description"] = inventorydata.Description;
                    //drow["Country"] = inventorydata.country;
                    dtableForGrid.Rows.Add(drow);
                }
                grdInventoryDetails.DataSource = dtableForGrid;
                grdInventoryDetails.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// method to bind the default grid Details of all Components uploaded by logged In Member (paid Seller only) 
        /// </summary>
        public void bindgrid(Guid usrId)
        {
            try
            {
                DataTable dtableInventoryDetails = objInventoryGridDetails.GetAllComponentDetails(usrId);
                DataTable dtableForGrid = new DataTable();
                dtableForGrid.Columns.Add("Status", typeof(string));
                dtableForGrid.Columns.Add("ComponentId", typeof(int));
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
                    drowForGrid["ComponentId"] = drDetails["ComponentId"];
                    drowForGrid["ComponentName"] = drDetails["ComponentName"];
                    drowForGrid["Quantity"] = drDetails["Quantity"];

                    //if (!drDetails["StockInHand"].ToString().Equals(""))
                    //{
                    //    drowForGrid["StockInHand"] = drDetails["StockInHand"];
                    //}
                    //else
                    //{
                    //    drowForGrid["StockInHand"] = 0;
                    //}
                    drowForGrid["Brandname"] = drDetails["Brandname"];
                    drowForGrid["DateCode"] = drDetails["DateCode"];
                    drowForGrid["Package"] = drDetails["Package"];
                    drowForGrid["Description"] = drDetails["Description"];


                    //drowForGrid["PriceInINR"] = drDetails["PriceInINR"];
                    drowForGrid["PriceInUSD"] = drDetails["PriceInUSD"];
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
                    //drowForGrid["Country"] = drDetails["Country"];
                    dtableForGrid.Rows.Add(drowForGrid);
                }

                grdInventoryDetails.DataSource = dtableForGrid;
                grdInventoryDetails.DataBind();
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// binds the grid depending on the search condition
        /// </summary>
        private void setGrdPosition()
        {
            try
            {
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlstockstatus.SelectedValue) > 0)
                    {
                        lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstockstatus.SelectedValue);
                        bindSearchFromGrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                            {
                                bindgrid(UserPrfl.UserID);
                            }
                            else
                            {
                                bindgrid(UserPrfl.UserID);
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

        /// <summary>
        /// Handles the RowEditing event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdInventoryDetails.EditIndex = e.NewEditIndex;  //code that Edits the current row       
                setGrdPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowUpdating event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                objComponent.Componentid = Convert.ToInt32(((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId")).Text);
                //objComponent.Status = Convert.ToInt32(((DropDownList)grdInventoryDetails.Rows[e.RowIndex].FindControl("ddlStatus")).Text);
                //  objComponent.ComponentName = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtComponentName")).Text;                
                objComponent.ComponentName = ((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentname")).Text;
                objComponent.Quantity = Convert.ToInt32(((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtQuantity")).Text);

                //int stockinhand = 0;
                //if (!stockinhand.ToString().Equals(""))
                //{
                //    objComponent.StockInHand = Convert.ToInt32(((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtStockInHand")).Text);
                //}
                //else
                //{
                //    objComponent.StockInHand = 0;
                //}
                objComponent.BrandName = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtBrandName")).Text;
                objComponent.datecode = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtdateCode")).Text;
                objComponent.package = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtpackage")).Text;
                objComponent.Description = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtDescription")).Text;
                //string prinINR = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinINR")).Text;
                //if (!prinINR.ToString().Equals(""))
                //{
                //    objComponent.PriceInINR = Convert.ToDecimal(((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinINR")).Text);
                //}
                //else
                //{
                //    objComponent.PriceInINR = 0;
                //}

                string prinUSD = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinUSD")).Text;
                if (!prinUSD.ToString().Equals(""))
                {
                    objComponent.PriceInUSD = Convert.ToDecimal(((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinUSD")).Text);
                }
                else
                {
                    objComponent.PriceInUSD = 0;
                }

                //string prinCNY = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinCNY")).Text;
                //if (!prinCNY.ToString().Equals(""))
                //{
                //    objComponent.PriceInCNY = Convert.ToDecimal(((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtprinCNY")).Text);
                //}
                //else
                //{
                //    objComponent.PriceInCNY = 0;
                //}
                //objComponent.Status=nul
                objComponent.PriceInCNY = null;
                objComponent.PriceInINR = null;
                //objComponent.stockstatus = Convert.ToInt32(((DropDownList)grdInventoryDetails.Rows[e.RowIndex].FindControl("ddlStockStatus")).Text);
                string stkstatus = ((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("lblStkstatus")).Text;
                if (stkstatus.Equals("Available"))
                {
                    objComponent.stockstatus = 1;
                }
                else if (stkstatus.Equals("In House"))
                {
                    objComponent.stockstatus = 2;
                }
                else if (stkstatus.Equals("OEM Excess"))
                {
                    objComponent.stockstatus = 3;
                }
                //Textbox txtcategory=(TextBox)GvCategory.Rows[e.RowIndex].Cells[0].Controls[0].


                //DropDownList ddlcontry = (DropDownList)grdInventoryDetails.Rows[e.RowIndex].FindControl("ddlCountry");
                //if (ddlcontry.SelectedIndex > 0)
                //{
                //    objComponent.country = ((DropDownList)grdInventoryDetails.Rows[e.RowIndex].FindControl("ddlCountry")).SelectedItem.Text;
                //}
                //else
                //{
                //    // string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[8].ToString();  
                //    //objComponent.country = ((Label)grdInventoryDetails.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
                //    //  objComponent.country = ((Label)grdInventoryDetails.Rows[e.RowIndex].Cells[0].Controls[0].FindControl("lblcounty")).Text;

                //    objComponent.country = ((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("lblcountry")).Text;
                //}

                objInventoryGridDetails.UpdateInventories(objComponent);
                grdInventoryDetails.EditIndex = -1; //reset the edit index and then bind the grid

                setGrdPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdInventoryDetails.EditIndex = -1;
                setGrdPosition();

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowUpdated event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
        }

        /// <summary>
        /// Handles the RowDeleting event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objComponent.Componentid = Convert.ToInt32(((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId")).Text);
                objInventoryGridDetails.deleteSelectedComponent(objComponent.Componentid); //deleted the selected Row  oR Component

                setGrdPosition();
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdInventoryDetails.PageIndex = e.NewPageIndex; //code for new page index 

                setGrdPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// method for selected index changed of Filter with Columns drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlInventoryGridColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchFromGrid.Text = String.Empty;

                if (ddlInventoryGridColumns.SelectedValue == "4")  //check for status
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
                else
                {
                    txtSearchFromGrid.Visible = true;
                    imgSearchFromGrid.Visible = true;
                    ddlstatus.Visible = false;
                    ddlstatus.ClearSelection();
                    ddlstockstatus.Visible = false;
                    ddlstockstatus.ClearSelection();
                }
                setGrdPosition();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// method for selected index changed of  Status drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlstockstatus.ClearSelection();
                lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                bindSearchFromGrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// method for selected index changed of  Stock Status drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstockstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlstatus.ClearSelection();
                lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstockstatus.SelectedValue);
                bindSearchFromGrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// method of Search button in grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgSearchFromGrid_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) >= 0) && (txtSearchFromGrid.Text == ""))
                {
                    bindgrid(UserPrfl.UserID);
                }
                else
                {
                    lstfound = objInventoryGridDetails.GetRequestedSearchGridData(UserPrfl.UserID, Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                    bindSearchFromGrid();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        /// <summary>
        /// method to clear all selection of dropdown and textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgClearSearchSelection_Click(object sender, ImageClickEventArgs e)
        {
            ddlInventoryGridColumns.ClearSelection();
            ddlstatus.Visible = false;
            ddlstatus.ClearSelection();
            ddlstockstatus.Visible = false;
            ddlstockstatus.ClearSelection();

            txtSearchFromGrid.Text = "";
            imgSearchFromGrid.Visible = true;
            txtSearchFromGrid.Visible = true;

            bindgrid(UserPrfl.UserID);
        }

        /// <summary>
        /// deleted the multiple selected Inventories 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelInventories_Click(object sender, EventArgs e)
        {
            bool flag = false;

            foreach (GridViewRow gv in grdInventoryDetails.Rows)
            {
                CheckBox chkBx = (CheckBox)gv.FindControl("chkbx");
                if (chkBx != null && chkBx.Checked)
                {
                    flag = true;
                    Label LblComponentId = (Label)gv.FindControl("LblComponentId");
                    objComponent.Componentid = Convert.ToInt32(LblComponentId.Text);
                    objInventoryGridDetails.deleteSelectedComponent(objComponent.Componentid); //deleted the selected Row  oR Component                    
                    lblmsg.Text = "Inventories deleted succesfully.";
                }
            }
            bindgrid(UserPrfl.UserID);
            if (flag == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please select Inventories to delete";
            }
            else
            {
                lblmsg.Text = "Inventories deleted succesfully.";
            }


        }

        /// <summary>
        /// Handles the RowDataBound event of the grdInventoryDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void grdInventoryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && this.grdInventoryDetails.EditIndex > -1 && e.Row.RowIndex == this.grdInventoryDetails.EditIndex)
            {
                try
                {
                    DropDownList drpStat = (DropDownList)e.Row.FindControl("ddlStatus");
                    string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[0].ToString();
                    int value = 0;
                    if (status.Equals("Open"))
                    {
                        value = 1;
                    }
                    else
                    {
                        value = 0;
                    }
                    drpStat.SelectedIndex = value;

                    //----------------------------------country-----------------------------------------------
                    //DropDownList drpCountry = (DropDownList)e.Row.FindControl("ddlCountry");
                    //string lblcountry = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[11].ToString();
                    //string cntryVal = lblcountry;

                    //if (lblcountry.ToUpper().Equals("INDIA"))
                    //{
                    //    drpCountry.SelectedIndex = 1;
                    //}
                    //else if (lblcountry.ToUpper().Equals("CHINA"))
                    //{
                    //    drpCountry.SelectedIndex = 2;
                    //}
                    //else if (lblcountry.ToUpper().Equals("USA"))
                    //{
                    //    drpCountry.SelectedIndex = 3;
                    //}
                    //else
                    //{
                    //    drpCountry.SelectedIndex = 0;
                    //}
                }
                catch (Exception ex)
                {
                    IClogger.LogMessage(ex.Message);
                }
            }
        }
        #endregion


    }
}