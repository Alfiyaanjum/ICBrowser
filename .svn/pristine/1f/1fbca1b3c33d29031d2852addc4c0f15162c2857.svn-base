using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using ICBrowser.Web.Controls;
using ICBrowser.DAL;
using System.Data;

namespace ICBrowser.Web
{
    public partial class AddBuyersRequirements : System.Web.UI.Page
    {
        public int rptr_AddBuyerRequirementCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AddRequirementsControl(10);
                //ClearContent();
            }
        }

        private void AddRequirementsControl(int ctrlCount)
        {
            try
            {
                rptr_AddBuyerRequirementCount = ctrlCount;
                hidden_rptr_ControlCount.Value = ctrlCount.ToString();
                List<ICBrowser.Common.BuyersRequirements> lstDir = new List<ICBrowser.Common.BuyersRequirements>(ctrlCount);
                for (int i = 0; i < ctrlCount; i++)
                {
                    lstDir.Add(new ICBrowser.Common.BuyersRequirements());
                }
                rptAddRequirements_Bind(lstDir);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void rptAddRequirements_Bind(List<ICBrowser.Common.BuyersRequirements> arr)
        {
            try
            {

                rptr_AddBuyerRequirementCount = arr.Count;
                hidden_rptr_ControlCount.Value = arr.Count.ToString();
                rptAddBuyerRequirements.DataSource = arr;
                rptAddBuyerRequirements.DataBind();

                int rowIndex = 0;

                foreach (RepeaterItem row in rptAddBuyerRequirements.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        AddRequirement ctrlDirectorDtls = (AddRequirement)row.FindControl("ctrlAddRequirements");
                        rowIndex++;
                        Label lblHeaderTextCounter = (Label)ctrlDirectorDtls.FindControl("lblReqPopupHeader");
                        lblHeaderTextCounter.Text = "Add Requirement " + rowIndex;
                        ctrlDirectorDtls.ShowRemove = arr.Count > 1;
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BuyersDataRequirement bdr = new BuyersDataRequirement();
            List<ICBrowser.Common.BuyersRequirements> data = new List<Common.BuyersRequirements>();
            ICBrowser.Common.BuyersRequirements dir = new ICBrowser.Common.BuyersRequirements();
            try
            {
                foreach (RepeaterItem item in rptAddBuyerRequirements.Items)
                {
                    AddRequirement itemCtrl = item.FindControl("ctrlAddRequirements") as AddRequirement;
                    dir = itemCtrl != null ? itemCtrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemCtrl != null && dir != null)
                        {
                            bdr.AddBuyersRequirementsDetails(dir);
                            ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('Record has been updated successfully.');", true);
                        }
                    }
                }
                ClearContent();
            }
            catch (Exception ex)
            {
                lblStatusmsg.Visible = true;
                IClogger.LogError(ex.ToString());
            }
        }

        private void ClearContent()
        {
            ICBrowser.Common.BuyersRequirements dir = new ICBrowser.Common.BuyersRequirements();
            try
            {
                foreach (RepeaterItem item in rptAddBuyerRequirements.Items)
                {
                    AddRequirement itemCtrl = item.FindControl("ctrlAddRequirements") as AddRequirement;
                    //dir = itemCtrl != null ? itemCtrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemCtrl != null)
                        {
                            TextBox txtComponentName = (TextBox)itemCtrl.FindControl("tbxPartNumber");
                            TextBox txtQuantity = (TextBox)itemCtrl.FindControl("tbxReqPopupQuantity");
                            TextBox txtDescription = (TextBox)itemCtrl.FindControl("tbxReqPopupDescription");
                            TextBox txtBrandName = (TextBox)itemCtrl.FindControl("tbxMake");
                            TextBox txtRequiredBefore = (TextBox)itemCtrl.FindControl("txtRequiredBefore");
                            txtComponentName.Text = "";
                            txtQuantity.Text = "";
                            txtDescription.Text = "";
                            txtBrandName.Text = "";
                            txtRequiredBefore.Text = "";
                        }
                    }
                }
                lblStatusmsg.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void rptAddRequirements_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            BuyersDataRequirement bdr = new BuyersDataRequirement();
            List<ICBrowser.Common.BuyersRequirements> lst = new List<Common.BuyersRequirements>();
            //ICBrowser.Common.BuyersRequirements dir = new ICBrowser.Common.BuyersRequirements();
            int savecount = 0;
            try
            {
                Button btnText = (Button)e.CommandSource;
                if (btnText.Text.Equals("Remove"))
                {
                    // Do nothing and remove control from the list
                    ClearContent();
                    lst = GetData();
                }
                else if (btnText.Text.Equals("Save"))
                {
                    // Get Data
                    lst = GetData();
                }

                //Button btnText = (Button)e.CommandSource;
                switch (btnText.Text)
                {
                    case "Remove":
                        //RemoveFromTupleTaxonomyForDetailsofDirectors(e.Item.ItemIndex);
                        ClearContent();
                        lst.RemoveAt(e.Item.ItemIndex);
                        break;
                    case "Save":
                        // Chech wheather textbox value is empty or not
                        foreach (ICBrowser.Common.BuyersRequirements dir in lst)
                        {
                            if (dir != null && dir.BrandName != "" && dir.BuyerName != "" && dir.ComponentName != "" && dir.Description != "" && dir.RequiredBefore != null && dir.Quantity != null)
                            {
                                bdr.AddBuyersRequirementsDetails(dir);
                                savecount += 1;
                            }
                        }
                        DisplayMessage(savecount, lst.Count);
                        ClearContent();
                        break;
                    case "Show"://no need to wite any code as its already written in the usercontrols button click event
                        break;
                }
                rptAddRequirements_Bind(lst);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void DisplayMessage(int SaveCount, int FromCount)
        {
            try
            {
                if (SaveCount == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No Records Updated.');", true);
                }
                else if (SaveCount > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + SaveCount + " out of " + FromCount + " Records Updated.');", true);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected List<ICBrowser.Common.BuyersRequirements> GetData()
        {
            List<ICBrowser.Common.BuyersRequirements> lst = new List<ICBrowser.Common.BuyersRequirements>();
            try
            {
                foreach (RepeaterItem row in this.rptAddBuyerRequirements.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        AddRequirement ctrlDirectorDtls = (AddRequirement)row.FindControl("ctrlAddRequirements");
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

        //private void RemoveFromTupleTaxonomyForDetailsofDirectors(int itemIndex)
        //{
        //    try
        //    {
        //        if (rptAddBuyerRequirements.Items.Count > 0)
        //        {
        //            BuyersDataRequirement bdr = new BuyersDataRequirement();
        //            AddRequirement controlToDelete = rptAddBuyerRequirements.Items[itemIndex].FindControl("ctrlAddRequirements") as DirectorDetails;
        //            if (controlToDelete != null && controlToDelete.Data != null)
        //            {
        //                //bdr.DeleteBuyerRequirementControlValue();
        //                //repo.Delete(controlToDelete.Data.ParentId.Value);
        //                //repo.DeleteChildren(controlToDelete.Data.ParentId.Value);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }
        //}
    }
}