using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Web.Controls;
using ICBrowser.Business;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class UploadBulkOffers : BasePage
    {
        public int rptr_AddOffersCount;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                lblSuccess.Visible = false;
                lblError.Visible = false;
                if (Session["UserProfile"] != null)
                {
                    int MembershipTypeOfUser = ((ICBrowser.Common.UserProfile)(Session["UserProfile"])).TypeOfMembership;
                    if ((MembershipTypeOfUser != 0 || MembershipTypeOfUser != 1))
                    {
                        AddInventoryControl(10);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();
            ICBrowser.Business.UserOffersData objUserOfferData = new ICBrowser.Business.UserOffersData();
            List<ICBrowser.Common.Component> lst = new List<ICBrowser.Common.Component>();
            int savecount = 0;
            int noOfRowsSaveAffected = 0;
            MembershipUser userToLogin = Membership.GetUser();
            try
            {
                int MembershipType = ((ICBrowser.Common.UserProfile)(Session["UserProfile"])).TypeOfMembership;
                int AvailableOfferLimit = CheckAvalaibileUploadOffersAsPerMembershipType(MembershipType);
                List<Component> dirList = new List<Component>();
                foreach (RepeaterItem item in rptOffers.Items)
                {
                    SellerInventories itemctrl = item.FindControl("SellerInventories1") as SellerInventories;
                    dir = itemctrl != null ? itemctrl.Data : null;
                    dir.UserId = new Guid(userToLogin.ProviderUserKey.ToString());
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (dir != null && dir.ComponentName != "" && dir.Quantity != 0 && dir.stockstatus > 0)
                        {
                            dirList.Add(dir);
                            savecount += 1;
                        }
                    }
                }
                noOfRowsSaveAffected = objUserOfferData.SaveOffersByUserManually(dirList);
                if (noOfRowsSaveAffected > AvailableOfferLimit)
                {
                    DeleteUploadedOfferByModifiedDate(AvailableOfferLimit, dir.UserId);
                }
                DisplayMessage(savecount);
                //ClearContent();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Adds the inventory control.
        /// </summary>
        /// <param name="ctrlCount">The control count.</param>
        private void AddInventoryControl(int ctrlCount)
        {
            try
            {
                rptr_AddOffersCount = ctrlCount;
                List<ICBrowser.Common.Component> lstDir = new List<ICBrowser.Common.Component>(ctrlCount);

                for (int i = 0; i < ctrlCount; i++)
                {
                    lstDir.Add(new ICBrowser.Common.Component());
                }
                rptAddInventory_Bind(lstDir);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// RPTs the add inventory_ bind.
        /// </summary>
        /// <param name="lstDir">The LST dir.</param>
        private void rptAddInventory_Bind(List<Common.Component> lstDir)
        {
            try
            {
                rptOffers.DataSource = lstDir;
                rptOffers.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>List&lt;ICBrowser.Common.Component&gt;.</returns>
        protected List<ICBrowser.Common.Component> GetData()
        {
            List<ICBrowser.Common.Component> lst = new List<ICBrowser.Common.Component>();
            try
            {
                foreach (RepeaterItem row in this.rptOffers.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        SellerInventories ctrlDirectorDtls = (SellerInventories)row.FindControl("SellerInventories1");
                        lst.Add(ctrlDirectorDtls.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }

        /// <summary>
        /// Clears the content.
        /// </summary>
        private void ClearContent()
        {
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();
            try
            {
                foreach (RepeaterItem item in rptOffers.Items)
                {
                    SellerInventories itemCtrl = item.FindControl("SellerInventories1") as SellerInventories;
                    dir = itemCtrl != null ? itemCtrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemCtrl != null && dir != null)
                        {
                            TextBox txtComponentName = (TextBox)itemCtrl.FindControl("txtPartNumber");
                            TextBox txtBrandName = (TextBox)itemCtrl.FindControl("txtBrandname");
                            TextBox txtDescription = (TextBox)itemCtrl.FindControl("txtDescription");
                            TextBox txtdateCode = (TextBox)itemCtrl.FindControl("txtDateCode");
                            //TextBox txtStockInHand = (TextBox)itemCtrl.FindControl("txtStockInhand");

                            // TextBox txtAvailalbleFrom = (TextBox)itemCtrl.FindControl("txtAvailfrom");

                            TextBox txtQuantity = (TextBox)itemCtrl.FindControl("txtQuantity");
                            TextBox txtpackage = (TextBox)itemCtrl.FindControl("txtPackage");
                            //TextBox txtprceinINR = (TextBox)itemCtrl.FindControl("txtPriceinINR");
                            TextBox txtprceinUSD = (TextBox)itemCtrl.FindControl("txtPriceInUSD");
                            //TextBox txtprceinCNY = (TextBox)itemCtrl.FindControl("txtPriceInCNY");
                            // TextBox txtCountry = (TextBox)itemCtrl.FindControl("txtCountry");
                            //DropDownList ddlCountry = (DropDownList)itemCtrl.FindControl("ddlCountry");

                            DropDownList ddlStockstatus = (DropDownList)itemCtrl.FindControl("ddlStockStatus");
                            //  TextBox txtdatasheetlink = (TextBox)itemCtrl.FindControl("txtDatasheetlink");


                            txtComponentName.Text = "";
                            txtBrandName.Text = "";
                            txtDescription.Text = "";
                            txtdateCode.Text = "";

                            //   txtAvailalbleFrom.Text = "";
                            //txtStockInHand.Text = "";
                            txtQuantity.Text = "";
                            //txtprceinINR.Text = "";
                            txtprceinUSD.Text = "";
                            //txtprceinCNY.Text = "";
                            //  txtCountry.Text = "";
                            //ddlCountry.ClearSelection();
                            txtpackage.Text = "";
                            ddlStockstatus.ClearSelection();
                            // txtdatasheetlink.Text = "";
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
        /// Displays the message.
        /// </summary>
        /// <param name="SaveCount">The save count.</param>
        private void DisplayMessage(int SaveCount)
        {
            try
            {
                if (SaveCount == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Records saved. Please fill Part Number,Quantity and Stock Status.');", true);
                    //lblSuccess.Visible = false;
                    //lblError.Visible = true;
                    //lblError.Text = "No Records saved. Please fill Part #, Quantity & Stock Status field.";
                }
                else if (SaveCount > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "MessagePopUp", "alert('" + SaveCount + " Records has been saved successfully.');document.location.href='/UserOffers.aspx';", true);
                    //lblError.Visible = false;
                    //lblSuccess.Visible = true;
                    //lblSuccess.Text = SaveCount + " records has been saved successfully.";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Checks the type of the avalaibile upload offers as per membership.
        /// </summary>
        /// <param name="membershipType">Type of the membership.</param>
        /// <returns>System.Int32.</returns>
        private int CheckAvalaibileUploadOffersAsPerMembershipType(int membershipType)
        {
            UserOffersData objUserOfferData = new UserOffersData();
            int limit = objUserOfferData.GetOfferUploadingLimitAsPerMembershipType(membershipType);
            if (limit != 0)
            {
                return limit;
            }
            return 0;
        }

        /// <summary>
        /// Deletes the uploaded offer by modified date.
        /// </summary>
        /// <param name="noOfRowsToBeSave">The no of rows to be save.</param>
        /// <param name="UserId">The user identifier.</param>
        private void DeleteUploadedOfferByModifiedDate(int noOfRowsToBeSave, Guid UserId)
        {
            UserOffersData objUserOfferData = new UserOffersData();
            try
            {
                objUserOfferData.DeleteExtraUploadedOfferAsPerMofiedDate(noOfRowsToBeSave, UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnback control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserOffers.aspx");
        }
    }
}