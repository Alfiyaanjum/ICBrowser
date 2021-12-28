using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Web.Controls;
using System.Security;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class UploadBulkRequest : BasePage
    {
        #region paramaters
        public int rptr_AddUploadRequestCount;
        #endregion

        #region Events
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
                AddInventoryControl(10);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //  List<ICBrowser.Common.Component> lst = GetData();
            Business.UserRequirements BuyerRequirementObj = new Business.UserRequirements();
            List<ICBrowser.Common.BuyersRequirements> lst = new List<ICBrowser.Common.BuyersRequirements>();
            ICBrowser.Common.BuyersRequirements dir = new ICBrowser.Common.BuyersRequirements();
            int savecount = 0;
            bool status = false;
            try
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    SellerInventories itemctrl1 = item.FindControl("SellerInventories1") as SellerInventories;
                    dir = itemctrl1 != null ? itemctrl1.BuyerRequirementData : null;
                    dir.userId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemctrl1 != null && dir != null && dir.Quantity != 0 && dir.ComponentName != "")
                        {
                            savecount += 1;
                            //status = BuyerRequirementObj.AddUserRequirements(dir);
                            lst.Add(dir);
                        }
                    }
                }

                status = BuyerRequirementObj.InsertUserRequirementsManually(lst);

                if (status == true && savecount > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('" + savecount + " Records has been saved successfully.');document.location.href='/BuyersRequirment.aspx'", true);
                    //lblSuccess.Visible = true;
                    //lblError.Visible = false;
                    //lblSuccess.Text = savecount + " records has been saved successfully.";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Records saved. Please fill Part Number and Quantity field.');", true);
                    //lblError.Visible = true;
                    //lblSuccess.Visible = false;
                    //lblError.Text = "No Records saved. Please fill Part Number and Quantity field.";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Add Bulk Requirements"
        /// <summary>
        /// Adds the inventory control.
        /// </summary>
        /// <param name="ctrlCount">The control count.</param>
        private void AddInventoryControl(int ctrlCount)
        {
            try
            {
                rptr_AddUploadRequestCount = ctrlCount;
                List<ICBrowser.Common.BuyersRequirements> lstDir = new List<ICBrowser.Common.BuyersRequirements>(ctrlCount);

                for (int i = 0; i < ctrlCount; i++)
                {
                    lstDir.Add(new ICBrowser.Common.BuyersRequirements());
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
        private void rptAddInventory_Bind(List<Common.BuyersRequirements> lstDir)
        {
            try
            {
                Repeater1.DataSource = lstDir;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the OnItemDataBound event of the Repeater1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            List<string> lst = new List<string>();
            lst.Add("RFQ");
            lst.Add("PO");
            try
            {
                RepeaterItem item = e.Item;
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    SellerInventories ctrlDirectorDtls = (SellerInventories)e.Item.FindControl("SellerInventories1");
                    if (ctrlDirectorDtls != null)
                    {
                        //hidding td
                        //System.Web.UI.HtmlControls.HtmlTableCell td1 = (System.Web.UI.HtmlControls.HtmlTableCell)ctrlDirectorDtls.FindControl("tdStockInHand");
                        //td1.Visible = false;
                        //System.Web.UI.HtmlControls.HtmlTableCell td2 = (System.Web.UI.HtmlControls.HtmlTableCell)ctrlDirectorDtls.FindControl("tdPriceINR");
                        //td2.Visible = false;
                        System.Web.UI.HtmlControls.HtmlTableCell td3 = (System.Web.UI.HtmlControls.HtmlTableCell)ctrlDirectorDtls.FindControl("tdPriceUSD");
                        td3.Visible = true;
                        //System.Web.UI.HtmlControls.HtmlTableCell td4 = (System.Web.UI.HtmlControls.HtmlTableCell)ctrlDirectorDtls.FindControl("tdPriceCNY");
                        //td4.Visible = false;

                        //hiding countrols
                        //TextBox txtPriceinINR = (TextBox)ctrlDirectorDtls.FindControl("txtPriceinINR");
                        //txtPriceinINR.Visible = false;
                        TextBox txtPriceInUSD = (TextBox)ctrlDirectorDtls.FindControl("txtPriceInUSD");
                        txtPriceInUSD.Visible = true;
                        //TextBox txtPriceInCNY = (TextBox)ctrlDirectorDtls.FindControl("txtPriceInCNY");
                        //txtPriceInCNY.Visible = false;
                        //TextBox txtStockInhand = (TextBox)ctrlDirectorDtls.FindControl("txtStockInhand");
                        //txtStockInhand.Visible = false;

                        DropDownList ddlWithPO = (DropDownList)ctrlDirectorDtls.FindControl("ddlStockStatus");
                        ddlWithPO.DataSource = lst;
                        ddlWithPO.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>List&lt;ICBrowser.Common.BuyersRequirements&gt;.</returns>
        protected List<ICBrowser.Common.BuyersRequirements> GetData()
        {
            List<ICBrowser.Common.BuyersRequirements> lst = new List<ICBrowser.Common.BuyersRequirements>();
            try
            {
                foreach (RepeaterItem row in this.Repeater1.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        // This is common web control 
                        SellerInventories ctrlDirectorDtls = (SellerInventories)row.FindControl("SellerInventories1");
                        lst.Add(ctrlDirectorDtls.BuyerRequirementData);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btnback control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BuyersRequirment.aspx");
        }
    }
}