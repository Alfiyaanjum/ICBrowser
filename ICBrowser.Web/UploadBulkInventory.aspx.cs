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
    public partial class UploadBulkInventory : BasePage
    {
        #region "Public Parameters"
        InventoryGridDetails objInventoryGridDetails = new InventoryGridDetails();
        Common.UserProfile objUserProf = new Common.UserProfile();
        public int rptr_AddSellerInventoryCount;
        public Guid UserId;
        public int membershipTypeId = 0;
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
                objUserProf = (Common.UserProfile)Session["UserProfile"];
                UserId = objUserProf.UserID;

                if (userToLogin != null)
                {
                    membershipTypeId = objUserProf.TypeOfMembership;
                    lblUploadMessage.Visible = false;
                    lblExcessMessage.Visible = false;

                    //create a function to get the expirydate of Seller who has Logged in
                    if (membershipTypeId > 1)
                    {
                        if (!IsPostBack)
                        {
                            AddInventoryControl(10);
                            lblUploadMessage.Visible = false;
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

        #region "Add Bulk Inventories"

        /// <summary>
        /// Adds the inventory control.
        /// </summary>
        /// <param name="ctrlCount">The control count.</param>
        public void AddInventoryControl(int ctrlCount)
        {
            try
            {
                rptr_AddSellerInventoryCount = ctrlCount;
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
        /// <param name="arr">The arr.</param>
        public void rptAddInventory_Bind(List<ICBrowser.Common.Component> arr)
        {
            try
            {
                rptInventory.DataSource = arr;
                rptInventory.DataBind();
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
                foreach (RepeaterItem row in this.rptInventory.Items)
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
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int permittedcount = 0;
            int savedComponentCount = 0;
            int leftspace = 0;
            int savecount = 0;
            List<ICBrowser.Common.Component> data = new List<Common.Component>();
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();
            List<Component> dirList = new List<Component>();
            bool limitstatus = false;
            try
            {
                int MembershipType = ((ICBrowser.Common.UserProfile)(Session["UserProfile"])).TypeOfMembership;
              
                List<ICBrowser.Common.Component> lst = GetData();
                foreach (RepeaterItem item in rptInventory.Items)
                {
                    SellerInventories itemctrl = item.FindControl("SellerInventories1") as SellerInventories;
                    dir = itemctrl != null ? itemctrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemctrl != null && dir != null && dir.ComponentName != "" && dir.Quantity != 0 && dir.stockstatus > 0)
                        {
                            permittedcount = objInventoryGridDetails.getComponentListingCount(membershipTypeId);  //gets the permitted count
                            savedComponentCount = objInventoryGridDetails.getComponentCount(UserId);  //gets the total saved component count    ///  0 
                            leftspace = permittedcount - savedComponentCount;

                            //if (savedComponentCount == permittedcount) //excess data
                            //{
                            //    lblExcessMessage.Visible = true;
                            //    lblExcessMessage.Text = "You have exceeded the Inventory Upload Limit.";
                            //    limitstatus = true;
                            //    //ClearContent();
                            //}
                            //else
                            //{
                            dir.Status = 1; //status =open by default
                            dir.UserId = UserId;
                            savecount += 1;
                            dirList.Add(dir);
                            //}
                        }
                    }
                }

                if (savecount == 0 && limitstatus != true)
                {
                    DisplayMessage(savecount);
                    //ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Records saved. Please fill Part Number, Quantity and Stock Status field.');", true);
                }

                //if (leftspace != 0)
                //{
                //call insert code here
                if (dirList.Count <= leftspace)
                {
                    savedComponentCount = objInventoryGridDetails.AddBulkInventoriesManually(dirList);
                    DisplayMessage(savedComponentCount);
                    //ClearContent();
                }
                else if (dirList.Count > leftspace)
                {
                    int deleteExcessComponent = dirList.Count - leftspace;
                    //final.RemoveRange(0, deleteExcessComponent);
                    //dirList.RemoveRange(leftspace, deleteExcessComponent);
                    int ComponentCount = objInventoryGridDetails.AddBulkInventoriesManually(dirList);
                    int Totalcount=savedComponentCount+ComponentCount;
                    //ClearContent();
                   
                    if (Totalcount > permittedcount)
                    {
                        DeleteUploadedInventoryByModifiedDate(permittedcount, dirList[0].UserId);
                    }
                    //lblExcessMessage.Visible = true;
                    //lblExcessMessage.Text = "'"+ savedComponentCount +" Inventories uploaded sucessfully.";
                    DisplayMessage(ComponentCount);
                }
                
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }


        /// <summary>
        /// Deletes the uploaded inventory by modified date.
        /// </summary>
        /// <param name="noOfRowsToBeSave">The no of rows to be save.</param>
        /// <param name="UserId">The user identifier.</param>
        private void DeleteUploadedInventoryByModifiedDate(int noOfRowsToBeSave, Guid UserId)
        {
            UserOffersData objUserOfferData = new UserOffersData();
            try
            {
                objUserOfferData.DeleteExtraUploadedInventoryAsPerMofiedDate(noOfRowsToBeSave, UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }
        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="dirlistcount">The dirlistcount.</param>
        private void DisplayMessage(int dirlistcount)
        {
            try
            {
                if (dirlistcount == 0) //if no data in list
                {
                    // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No Records Saved.');", true);                   
                    ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Records saved. Please fill Part Number,Quantity and Stock Status.');", true);
                    //lblUploadMessage.Visible = false;
                    //lblExcessMessage.Visible = true;
                    //lblExcessMessage.Text = "No Records saved. Please fill Part#, Quantity & Stock Status field.";
                }
                else if (dirlistcount > 0) //data present in list
                {
                    // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + SaveCount + " out of " + FromCount + "  records has been saved successfully.');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('" + dirlistcount + "  Records has been saved successfully.');document.location.href='/SellerUploadedInventory.aspx'", true);
                    //lblExcessMessage.Visible = false;
                    //lblUploadMessage.Visible = true;
                    //lblUploadMessage.Text = dirlistcount + " records has been saved successfully.";
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No records saved. As you have exceeded the Inventory Upload Limit.');", true);
                    lblUploadMessage.Visible = true;
                    lblUploadMessage.Text = "No records saved. As you have exceeded the Inventory Upload Limit.";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Clears the content.
        /// </summary>
        private void ClearContent()
        {
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();
            try
            {
                foreach (RepeaterItem item in rptInventory.Items)
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
                            //  TextBox txtprceinINR = (TextBox)itemCtrl.FindControl("txtPriceinINR");
                            TextBox txtprceinUSD = (TextBox)itemCtrl.FindControl("txtPriceInUSD");
                            // TextBox txtprceinCNY = (TextBox)itemCtrl.FindControl("txtPriceInCNY");
                            //  TextBox txtCountry = (TextBox)itemCtrl.FindControl("txtCountry");
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
                            //  txtprceinINR.Text = "";
                            txtprceinUSD.Text = "";
                            // txtprceinCNY.Text = "";
                            // txtCountry.Text = "";
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
        #endregion

        /// <summary>
        /// Handles the Click event of the btnback control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SellerUploadedInventory.aspx");
        }
    }
}