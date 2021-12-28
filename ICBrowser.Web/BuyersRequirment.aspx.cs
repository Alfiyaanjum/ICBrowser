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
using System.Collections.Generic;
using ICBrowser.Common;
//using ICBrowser.DAL;
using System.Web.Security;
using System.Data.SqlClient;

namespace ICBrowser.Web
{
    public partial class BuyReq : BasePage
    {
        #region "Private Parameters"
        //private DataSet _finalData;
        private static bool flag = false;
        #endregion

        InventoryGridDetails objInventoryGridDetails = new InventoryGridDetails(); //class Object
        Common.UserProfile objUserProfile = new Common.UserProfile(); //class Object
        #region "Events"

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = (Guid)userToLogin.ProviderUserKey;
            if (userToLogin != null)
            {
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(userid);
                if (Admin.IsAdmin == true)
                {

                    img2.Visible = false;
                    img3.Visible = false;
                    lnkBulkAddRequirements.Visible = false;
                    buyersreq.Visible = false;

                    // lblOperations.Visible = false;
                    gdvBuyersReqDetails.Columns[10].Visible = false;
                    gdvBuyersReqDetails.Columns[11].Visible = false;
                }
                if (Request.QueryString["UserId"] != null)
                {
                    Guid queryStrUserId = new Guid(Request.QueryString["UserId"]);
                    objUserProfile = objInventoryGridDetails.GetUserCountByUserId(queryStrUserId);
                }
                else
                {
                    objUserProfile = objInventoryGridDetails.GetUserCountByUserId(userid);
                }


                if (!Page.IsPostBack && flag == false)
                {
                    Guid userId = objUserProfile.UserID;
                    BindRequirementGridview(userId);
                    ViewState["SearchFlag"] = flag;
                    txtSearchContent.Text = "";
                }
                lblmsg.Visible = false;
            }
            else
            {
                Response.Redirect("Default.aspx", true);
            }
        }

        /// <summary>
        /// Binds the requirement gridview.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void BindRequirementGridview(Guid userId)
        {
            // MembershipUser userToLogin = Membership.GetUser();
            UserRequirements UserData = new UserRequirements();

            List<ICBrowser.Common.BuyersRequirements> buyersDetails = UserData.UserRequirementListingByUserId(userId);
            DataTable dtBuyersDetails = new DataTable();
            dtBuyersDetails.Columns.Add("BuyerRequirementId", typeof(int));
            dtBuyersDetails.Columns.Add("UserId", typeof(Guid));
            dtBuyersDetails.Columns.Add("ComponentName", typeof(string));
            dtBuyersDetails.Columns.Add("Quantity", typeof(int));
            dtBuyersDetails.Columns.Add("BrandName", typeof(string));
            dtBuyersDetails.Columns.Add("DateCode", typeof(string));
            dtBuyersDetails.Columns.Add("Package", typeof(string));
            dtBuyersDetails.Columns.Add("Description", typeof(string));
            dtBuyersDetails.Columns.Add("PriceInUSD", typeof(decimal));
            dtBuyersDetails.Columns.Add("RequirementWithPO", typeof(string));

            dtBuyersDetails.Columns.Add("ModifiedDate", typeof(string));


            DataRow dr;

            foreach (ICBrowser.Common.BuyersRequirements buyerReqEntry in buyersDetails)
            {
                dr = dtBuyersDetails.NewRow();
                dr["BuyerRequirementId"] = buyerReqEntry.BuyerRequirementId;
                dr["UserId"] = buyerReqEntry.userId;
                dr["ComponentName"] = buyerReqEntry.ComponentName;
                dr["Quantity"] = buyerReqEntry.Quantity;
                dr["BrandName"] = buyerReqEntry.BrandName;
                dr["DateCode"] = buyerReqEntry.DateCode;
                dr["Package"] = buyerReqEntry.Package;
                dr["Description"] = buyerReqEntry.Description;
                if (buyerReqEntry.PriceInUSD == 0)
                {
                    dr["PriceInUSD"] = DBNull.Value;
                }
                else
                {
                    dr["PriceInUSD"] = buyerReqEntry.PriceInUSD;
                }
                if (buyerReqEntry.RequirementwithPO == true)
                    dr["RequirementWithPO"] = "PO";
                else
                    dr["RequirementWithPO"] = "RFQ";

                dr["ModifiedDate"] = buyerReqEntry.ModifiedDate.ToString("dd-MMM-yyyy");
                dtBuyersDetails.Rows.Add(dr);
            }

            gdvBuyersReqDetails.DataSource = dtBuyersDetails;
            gdvBuyersReqDetails.DataBind();
        }

        /// <summary>
        /// Sortings the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="sortname">The sortname.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>IEnumerable&lt;Common.BuyersRequirements&gt;.</returns>
        private IEnumerable<Common.BuyersRequirements> Sorting(IEnumerable<Common.BuyersRequirements> data, string sortname, string sortDirection)
        {
            if (sortname == "BuyerRequirementId" && sortDirection == "Ascending")
            {
                return data.OrderBy(aa => aa.BuyerRequirementId);
            }

            else
            {
                return data.OrderByDescending(aa => aa.BuyerRequirementId);
            }
        }


        /// <summary>
        /// Handles the RowEditing event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvBuyersReqDetails.EditIndex = e.NewEditIndex;

            bool searchmodestatus = Convert.ToBoolean(ViewState["SearchFlag"].ToString());
            if (searchmodestatus == false)
            {
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
            else
            {
                if (txtSearchContent.Visible == true)
                {
                    BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                }
                else if (ddlStatusSearch.Visible == true)
                {
                    BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
                }
            }
        }

        /// <summary>
        /// Handles the RowUpdating event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            UserRequirements buydata = new UserRequirements();
            Guid userId = objUserProfile.UserID;
            try
            {
                int buyerreqid = Convert.ToInt32(((Label)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("lblBuyerRequirementId")).Text);

                string componentname = (((Label)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("lblComponentName")).Text);
                int quantity = Convert.ToInt32(((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtQuantity")).Text);
                string brandname = (((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtBrandName")).Text);
                string datecode = (((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtDateCode")).Text);
                string package = (((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtPackage")).Text);
                string description = (((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtDescription")).Text);
                string price_in_usd = (((TextBox)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("txtPriceInUSD")).Text);
                decimal? priceinusd;
                if (!string.IsNullOrEmpty(price_in_usd))
                {
                    priceinusd = Convert.ToDecimal(price_in_usd);
                }
                else
                {
                    priceinusd = null;
                }
                int withpo = Convert.ToInt32(((DropDownList)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("ddlWithPO")).Text);

                int NotificationStatus = 0;
                buydata.rowUpdatebuyrsreq(buyerreqid, userId, withpo, quantity, componentname, description, brandname, NotificationStatus, package, datecode, priceinusd);
                gdvBuyersReqDetails.EditIndex = -1;
                bool searchmodestatus = Convert.ToBoolean(ViewState["SearchFlag"].ToString());
                if (searchmodestatus == false)
                {

                    BindRequirementGridview(userId);
                }
                else
                {
                    if (txtSearchContent.Visible == true)
                    {
                        BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                    }
                    else if (ddlStatusSearch.Visible == true)
                    {
                        BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowDeleting event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label lblbuyerreqid = (Label)gdvBuyersReqDetails.Rows[e.RowIndex].FindControl("LblBuyerRequirementId");
                int buyerreqid = Convert.ToInt32(lblbuyerreqid.Text);
                UserRequirements buydatreq = new UserRequirements();
                buydatreq.rowDeletebuyrsreq(buyerreqid);

                bool searchmodestatus = Convert.ToBoolean(ViewState["SearchFlag"].ToString());
                if (searchmodestatus == false)
                {
                    Guid userId = objUserProfile.UserID;
                    BindRequirementGridview(userId);
                }
                else
                {
                    if (txtSearchContent.Visible == true)
                    {
                        BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                    }
                    else if (ddlStatusSearch.Visible == true)
                    {
                        BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvBuyersReqDetails.EditIndex = -1;

            bool searchmodestatus = Convert.ToBoolean(ViewState["SearchFlag"].ToString());
            if (searchmodestatus == false)
            {
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
            else
            {
                if (txtSearchContent.Visible == true)
                {
                    BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                }
                else if (ddlStatusSearch.Visible == true)
                {
                    BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
                }
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && this.gdvBuyersReqDetails.EditIndex > -1 && e.Row.RowIndex == this.gdvBuyersReqDetails.EditIndex)
            {
                DropDownList ddlnotes = e.Row.FindControl("ddlWithPO") as DropDownList;
                string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[9].ToString();

                if (status.Equals("PO"))
                {
                    ddlnotes.SelectedValue = "1";
                }
                else
                {
                    ddlnotes.SelectedValue = "0";
                }
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging1 event of the gdvBuyersReqDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gdvBuyersReqDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gdvBuyersReqDetails.PageIndex = e.NewPageIndex;

            bool searchmodestatus = Convert.ToBoolean(ViewState["SearchFlag"].ToString());
            if (searchmodestatus == false)
            {
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
            else
            {
                if (txtSearchContent.Visible == true)
                {
                    BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                }
                else if (ddlStatusSearch.Visible == true)
                {
                    BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the buyersreq control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void buyersreq_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadRequest.aspx?RequestType=Requirement", false);
        }

        #endregion

        #region "Search"
        /// <summary>
        /// Binds the requirement gridview for search.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="type">The type.</param>
        private void BindRequirementGridviewForSearch(string text, string type) // binding grid for search functionality
        {
            if (text != "") // if search string is not empty bind data
            {
                UserRequirements buyersdata = new UserRequirements();
                List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<ICBrowser.Common.BuyersRequirements>();
                buyersDetails = buyersdata.getSearchContent(text, type, objUserProfile.UserID);
                DataTable dtBuyersDetails = new DataTable();
                if (buyersDetails != null)
                {
                    dtBuyersDetails.Columns.Add("BuyerRequirementId", typeof(int));
                    dtBuyersDetails.Columns.Add("userId", typeof(Guid));
                    dtBuyersDetails.Columns.Add("ComponentName", typeof(string));
                    dtBuyersDetails.Columns.Add("Quantity", typeof(int));
                    dtBuyersDetails.Columns.Add("BrandName", typeof(string));
                    dtBuyersDetails.Columns.Add("DateCode", typeof(string));
                    dtBuyersDetails.Columns.Add("Package", typeof(string));
                    dtBuyersDetails.Columns.Add("Description", typeof(string));
                    dtBuyersDetails.Columns.Add("RequirementWithPO", typeof(string));
                    dtBuyersDetails.Columns.Add("PriceInUSD", typeof(string));
                    dtBuyersDetails.Columns.Add("ModifiedDate", typeof(string));
                    DataRow dr;
                    foreach (ICBrowser.Common.BuyersRequirements buyerReqEntry in buyersDetails)
                    {
                        dr = dtBuyersDetails.NewRow();
                        dr["BuyerRequirementId"] = buyerReqEntry.BuyerRequirementId;
                        dr["userId"] = buyerReqEntry.userId;
                        dr["ComponentName"] = buyerReqEntry.ComponentName;
                        dr["Quantity"] = buyerReqEntry.Quantity;
                        dr["BrandName"] = buyerReqEntry.BrandName;
                        dr["DateCode"] = buyerReqEntry.DateCode;
                        dr["Package"] = buyerReqEntry.Package;
                        dr["Description"] = buyerReqEntry.Description;
                        if (buyerReqEntry.RequirementwithPO == true)
                            dr["RequirementWithPO"] = "PO";
                        else
                            dr["RequirementWithPO"] = "RFQ";
                        dr["PriceInUSD"] = buyerReqEntry.PriceInUSD;
                        dr["ModifiedDate"] = buyerReqEntry.ModifiedDate.ToString("dd-MMM-yyyy");
                        dtBuyersDetails.Rows.Add(dr);
                    }
                }
                gdvBuyersReqDetails.DataSource = dtBuyersDetails;
                gdvBuyersReqDetails.DataBind();
            }
            else // else bind gird with old method
            {
                ViewState["SearchFlag"] = flag;
                //flag = false;
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
        }

        /// <summary>
        /// Binds the requirement gridview for search drop down.
        /// </summary>
        /// <param name="txtSearch">The text search.</param>
        /// <param name="ddlType">Type of the DDL.</param>
        /// <param name="UserId">The user identifier.</param>
        private void BindRequirementGridviewForSearchDropDown(string txtSearch, string ddlType, Guid UserId) // binding grid for status dropdown controls
        {
            try
            {
                UserRequirements buyersdata = new UserRequirements();
                List<ICBrowser.Common.BuyersRequirements> buyersDetails = new List<ICBrowser.Common.BuyersRequirements>();
                buyersDetails = buyersdata.getSearchContent(txtSearch, ddlType, UserId);
                DataTable dtBuyersDetails = new DataTable();
                if (buyersDetails != null)
                {
                    dtBuyersDetails.Columns.Add("BuyerRequirementId", typeof(int));
                    dtBuyersDetails.Columns.Add("userId", typeof(Guid));
                    dtBuyersDetails.Columns.Add("ComponentName", typeof(string));
                    dtBuyersDetails.Columns.Add("Quantity", typeof(int));
                    dtBuyersDetails.Columns.Add("BrandName", typeof(string));
                    dtBuyersDetails.Columns.Add("DateCode", typeof(string));
                    dtBuyersDetails.Columns.Add("Package", typeof(string));
                    dtBuyersDetails.Columns.Add("Description", typeof(string));
                    dtBuyersDetails.Columns.Add("RequirementWithPO", typeof(string));
                    dtBuyersDetails.Columns.Add("PriceInUSD", typeof(string));
                    dtBuyersDetails.Columns.Add("ModifiedDate", typeof(string));

                    DataRow dr;
                    foreach (ICBrowser.Common.BuyersRequirements buyerReqEntry in buyersDetails)
                    {
                        dr = dtBuyersDetails.NewRow();
                        dr["BuyerRequirementId"] = buyerReqEntry.BuyerRequirementId;
                        dr["userId"] = buyerReqEntry.userId;
                        dr["ComponentName"] = buyerReqEntry.ComponentName;
                        dr["Quantity"] = buyerReqEntry.Quantity;
                        dr["BrandName"] = buyerReqEntry.BrandName;
                        dr["DateCode"] = buyerReqEntry.DateCode;
                        dr["Package"] = buyerReqEntry.Package;
                        dr["Description"] = buyerReqEntry.Description;
                        if (buyerReqEntry.RequirementwithPO == true)
                            dr["RequirementWithPO"] = "PO";
                        else
                            dr["RequirementWithPO"] = "RFQ";
                        dr["PriceInUSD"] = buyerReqEntry.PriceInUSD;
                        dr["ModifiedDate"] = buyerReqEntry.ModifiedDate.ToString("dd-MMM-yyyy");
                        dtBuyersDetails.Rows.Add(dr);
                    }
                }
                gdvBuyersReqDetails.DataSource = dtBuyersDetails;
                gdvBuyersReqDetails.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlSearchType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchType.SelectedValue.Equals("Status_with_po")) // if status appears in dropdown filter make textbox and button visibilty false
            {

                ddlStatusSearch.Visible = true;
                txtSearchContent.Visible = false;
                txtSearchContent.Text = "";
                btnSearch.Visible = false;
                //   btnClearSearch.Visible = false;
                ViewState["SearchFlag"] = false;
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
            else // else make dropdown for status visible false and search button visible true
            {
                ddlStatusSearch.Visible = false;
                txtSearchContent.Visible = true;
                txtSearchContent.Text = "";
                btnSearch.Visible = true;
                btnClearSearch.Visible = true;
                if (txtSearchContent.Text != null)
                {
                    ViewState["SearchFlag"] = true;
                    BindRequirementGridviewForSearch(txtSearchContent.Text, ddlSearchType.SelectedValue);
                }
                else
                {
                    ViewState["SearchFlag"] = false;
                    Guid userId = objUserProfile.UserID;
                    BindRequirementGridview(userId);
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlStatusSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlStatusSearch_SelectedIndexChanged(object sender, EventArgs e) // for status dropdown binding of grid on the basis of opened and close status of data
        {
            if (!ddlStatusSearch.SelectedValue.Equals("Select")) // for open and closed dropdown selection binding of grid on basis of selected dropdown
            {
                //flag = true;
                ViewState["SearchFlag"] = true;
                BindRequirementGridviewForSearchDropDown(ddlStatusSearch.SelectedValue, ddlSearchType.SelectedValue, objUserProfile.UserID);
            }
            else // default select option appears
            {
                //flag = false;
                ViewState["SearchFlag"] = false;
                Guid userId = objUserProfile.UserID;
                BindRequirementGridview(userId);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearchContent.Visible == true) // if search textbox or dropdown control is visible
                {
                    if (txtSearchContent.Text != null) // if textbox is visible than it checks for textbox is empty bind with new grid method
                    {
                        //flag = true;
                        ViewState["SearchFlag"] = true;
                        string txtSearch = txtSearchContent.Text.Trim();
                        string ddlType = ddlSearchType.SelectedValue.ToString();
                        if (!ddlType.Equals("0"))
                            BindRequirementGridviewForSearch(txtSearch, ddlType);
                    }
                    else // if textbox is empty than bind with old grid method
                    {
                        //flag = false;
                        ViewState["SearchFlag"] = false;
                        Guid userId = objUserProfile.UserID;
                        BindRequirementGridview(userId);
                    }

                }
                else if (ddlStatusSearch.Visible == true) // if status drop down is visible than make textbox and button search visible false 
                {

                    ViewState["SearchFlag"] = true;
                    string txtSearch = ddlStatusSearch.SelectedValue.ToString();
                    string ddlType = ddlSearchType.SelectedValue.ToString();
                    BindRequirementGridviewForSearchDropDown(txtSearch, ddlType, objUserProfile.UserID); // binding data 
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClearSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void btnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            ddlSearchType.ClearSelection();
            ddlStatusSearch.Visible = false;
            ddlStatusSearch.ClearSelection();
            txtSearchContent.Text = "";
            btnSearch.Visible = true;
            txtSearchContent.Visible = true;
            ViewState["SearchFlag"] = false;
            Guid userId = objUserProfile.UserID;
            BindRequirementGridview(userId);
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the btnDelInventories control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDelInventories_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Guid userId = objUserProfile.UserID;
            foreach (GridViewRow gv in gdvBuyersReqDetails.Rows)
            {
                CheckBox chkBx = (CheckBox)gv.FindControl("chkbx");
                if (chkBx != null && chkBx.Checked)
                {
                    flag = true;

                    Label lblbuyerreqid = (Label)gv.FindControl("LblBuyerRequirementId");
                    int buyerreqid = Convert.ToInt32(lblbuyerreqid.Text);
                    UserRequirements buydatreq = new UserRequirements();
                    buydatreq.rowDeletebuyrsreq(buyerreqid);
                    lblmsg.Text = "Requirement deleted succesfully.";
                }
            }
            BindRequirementGridview(userId);

            if (flag == false)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please select Requirement to delete";
            }
            else
            {
                lblmsg.Text = "Requirement deleted succesfully.";
            }

        }
    }
}