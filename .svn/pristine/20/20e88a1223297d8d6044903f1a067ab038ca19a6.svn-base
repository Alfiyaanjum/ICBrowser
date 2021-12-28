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
using System.IO;
using System.Configuration;


namespace ICBrowser.Web
{
    public partial class Add10Inventory : System.Web.UI.Page
    {
        public int rptr_AddSellerInventoryCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AddInventoryControl(10);

            }
        }

        public void AddInventoryControl(int ctrlCount)
        {
            try
            {
                rptr_AddSellerInventoryCount = ctrlCount;
                hidden_rptr_ControlCount.Value = ctrlCount.ToString();
                List<ICBrowser.Common.Component> lstDir = new List<ICBrowser.Common.Component>(ctrlCount);
                for (int i = 0; i < ctrlCount; i++)
                {
                    lstDir.Add(new ICBrowser.Common.Component());
                }
                rptAddInventory_Bind(lstDir);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }


        public void rptAddInventory_Bind(List<ICBrowser.Common.Component> arr)
        {
            try
            {
                rptr_AddSellerInventoryCount = arr.Count;
                hidden_rptr_ControlCount.Value = arr.Count.ToString();
                rptAddInventory.DataSource = arr;
                rptAddInventory.DataBind();

                int rowIndex = 0;

                //foreach (ICBrowser.Common.Component dr in arr)
                //{
                //    RepeaterItem row = rptAddInventory.Items[rowIndex];
                //    rowIndex++;
                //}

                foreach (RepeaterItem row in rptAddInventory.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        AddInventory ctrlDirectorDtls = (AddInventory)row.FindControl("ctrlAddInventory");
                        rowIndex++;
                        Label lblHeaderTextCounter = (Label)ctrlDirectorDtls.FindControl("lblReqPopupHeader");
                        lblHeaderTextCounter.Text = "Add Inventory " + rowIndex;
                        ctrlDirectorDtls.ShowRemove = arr.Count > 1;
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) //Save all button
        {
            InventoryGridDetails igd = new InventoryGridDetails();
            List<ICBrowser.Common.Component> data = new List<Common.Component>();
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();

            try
            {
                foreach (RepeaterItem item in rptAddInventory.Items)
                {
                    AddInventory itemCtrl = item.FindControl("ctrlAddInventory") as AddInventory;
                    dir = itemCtrl != null ? itemCtrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemCtrl != null && dir != null)
                        {
                            int Compid = igd.AddSellerInventoryDetails(dir);  //code to save all data except file and function returns compid

                            //  Code to save the Uploaded file 
                            FileUpload fuploader = (FileUpload)itemCtrl.FindControl("FuploadAdd");
                            if (fuploader.HasFile)
                            {
                                string uploadfilename = fuploader.FileName;
                                string extnsion = Path.GetExtension(uploadfilename);
                                double filesize = Convert.ToDouble(Web.Properties.Settings.Default.FileSize);

                                if (extnsion == ".pdf" || extnsion == ".doc")
                                {
                                    if (fuploader.PostedFile.ContentLength > filesize)
                                    {
                                        // lblUploadMessage.Visible = true;
                                        // lblUploadMessage.Text = "Your file was not uploaded because it exceeds the 4MB size limit.";
                                    }
                                    else
                                    {
                                        if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid)))
                                        {
                                            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid));
                                        }
                                        else
                                        {
                                            if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "\\" + uploadfilename)))
                                            {
                                                File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "\\" + uploadfilename));
                                            }
                                        }
                                        //code for Saving the file
                                        string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid) + "\\" + uploadfilename;
                                        fuploader.SaveAs(savedFilePath);

                                        igd.insertuploadfile(Compid, ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "/" + uploadfilename);

                                        //  Directory.Delete(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid), true);
                                    }

                                }
                                else
                                {
                                    //onl pdf or doc file allowed
                                    //lblError

                                    Label lblshowError = (Label)itemCtrl.FindControl("lblError");
                                    lblshowError.Visible = true;
                                    lblshowError.Text = "Only .pdf or .doc files allowed.";

                                }
                            }

                            else
                            {
                                TextBox txtgetlink = (TextBox)itemCtrl.FindControl("txtDatasheetlink");
                                if (txtgetlink.Text != "")
                                {
                                    string savedlink = "";

                                    if (txtgetlink.Text.StartsWith("http://"))
                                    {
                                        savedlink = txtgetlink.Text;
                                    }
                                    else
                                    {
                                        savedlink = "http://" + txtgetlink.Text;
                                    }

                                    igd.insertuploadfile(Compid, savedlink);
                                }
                            }
                            ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('Record has been Saved successfully.');", true);
                        }
                    }
                }
                ClearContent();
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }


        private void ClearContent()
        {
            ICBrowser.Common.Component dir = new ICBrowser.Common.Component();
            try
            {
                foreach (RepeaterItem item in rptAddInventory.Items)
                {
                    AddInventory itemCtrl = item.FindControl("ctrlAddInventory") as AddInventory;
                    dir = itemCtrl != null ? itemCtrl.Data : null;
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        if (itemCtrl != null && dir != null)
                        {
                            TextBox txtComponentName = (TextBox)itemCtrl.FindControl("TxtComponentName");
                            TextBox txtBrandName = (TextBox)itemCtrl.FindControl("TxtBrandName");
                            TextBox txtDescription = (TextBox)itemCtrl.FindControl("TxtDescription");
                            TextBox txtAvailalbleFrom = (TextBox)itemCtrl.FindControl("txtAvailfrom");
                            TextBox txtStockInHand = (TextBox)itemCtrl.FindControl("TxtStockInHand");
                            TextBox txtQuantity = (TextBox)itemCtrl.FindControl("TxtQuantity");
                            TextBox txtprceinINR = (TextBox)itemCtrl.FindControl("TxtPriceInINR");
                            TextBox txtprceinUSD = (TextBox)itemCtrl.FindControl("TxtPriceInUSD");
                            TextBox txtdatasheetlink = (TextBox)itemCtrl.FindControl("txtDatasheetlink");


                            txtComponentName.Text = "";
                            txtBrandName.Text = "";
                            txtDescription.Text = "";
                            txtAvailalbleFrom.Text = "";
                            txtStockInHand.Text = "";
                            txtQuantity.Text = "";
                            txtprceinINR.Text = "";
                            txtprceinUSD.Text = "";
                            txtdatasheetlink.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void rptAddInventory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            InventoryGridDetails igd = new InventoryGridDetails();
            List<ICBrowser.Common.Component> data = new List<Common.Component>();
            //ICBrowser.Common.Component dir = new ICBrowser.Common.Component();

            int savecount = 0;
            try
            {
                List<ICBrowser.Common.Component> lst = GetData();
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


                switch (btnText.Text)
                {
                    case "Remove":
                        //RemoveFromTupleTaxonomyForDetailsofDirectors(e.Item.ItemIndex);
                        lst.RemoveAt(e.Item.ItemIndex);
                        break;
                    case "Save":
                        foreach (ICBrowser.Common.Component dir in lst)
                        {
                            AddInventory itemCtrl = e.Item.FindControl("ctrlAddInventory") as AddInventory;
                            //dir = itemCtrl != null ? itemCtrl.Data : null;

                            if (itemCtrl != null && dir != null && dir.BrandName != "" && dir.AvailableFrom != null && dir.ComponentName != "" && dir.Description != "" && dir.StockInHand != null && dir.Quantity != null && dir.PriceInINR != null && dir.PriceInUSD != null && dir.PriceInCNY != null)
                            {
                                int Compid = igd.AddSellerInventoryDetails(dir);  //code to save all data except file and function returns compid
                                savecount += 1;
                                //  Code to save the Uploaded file 
                                FileUpload fuploader = (FileUpload)itemCtrl.FindControl("FuploadAdd");
                                if (fuploader.HasFile)
                                {
                                    string uploadfilename = fuploader.FileName;
                                    string extnsion = Path.GetExtension(uploadfilename);
                                    double filesize = Convert.ToDouble(Web.Properties.Settings.Default.FileSize);

                                    if (extnsion == ".pdf" || extnsion == ".doc")
                                    {
                                        if (fuploader.PostedFile.ContentLength > filesize)
                                        {
                                            // lblUploadMessage.Visible = true;
                                            // lblUploadMessage.Text = "Your file was not uploaded because it exceeds the 4MB size limit.";
                                        }
                                        else
                                        {
                                            if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid)))
                                            {
                                                Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid));
                                            }
                                            else
                                            {
                                                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "\\" + uploadfilename)))
                                                {
                                                    File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "\\" + uploadfilename));
                                                }
                                            }
                                            //code for Saving the file
                                            string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid) + "\\" + uploadfilename;
                                            fuploader.SaveAs(savedFilePath);

                                            igd.insertuploadfile(Compid, ConfigurationManager.AppSettings["RequirementsSheetPath"] + Compid + "/" + uploadfilename);

                                            //  Directory.Delete(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid), true);
                                        }

                                    }
                                    else
                                    {
                                        //onl pdf or doc file allowed
                                        //lblError

                                        Label lblshowError = (Label)itemCtrl.FindControl("lblError");
                                        lblshowError.Visible = true;
                                        lblshowError.Text = "Only .pdf or .doc files allowed.";

                                    }
                                }

                                else
                                {
                                    TextBox txtgetlink = (TextBox)itemCtrl.FindControl("txtDatasheetlink");
                                    if (txtgetlink.Text != "")
                                    {
                                        string savedlink = "";

                                        if (txtgetlink.Text.StartsWith("http://"))
                                        {
                                            savedlink = txtgetlink.Text;
                                        }
                                        else
                                        {
                                            savedlink = "http://" + txtgetlink.Text;
                                        }

                                        igd.insertuploadfile(Compid, savedlink);
                                    }
                                }

                                // ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('Record has been Saved successfully.');", true);
                            }

                        }
                        DisplayMessage(savecount, lst.Count);
                        ClearContent();
                        break;
                    case "Show"://no need to wite any code as its already written in the usercontrols button click event
                        break;
                }
                rptAddInventory_Bind(lst);
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

        protected List<ICBrowser.Common.Component> GetData()
        {
            List<ICBrowser.Common.Component> lst = new List<ICBrowser.Common.Component>();
            try
            {
                foreach (RepeaterItem row in this.rptAddInventory.Items)
                {
                    if (row.ItemType == ListItemType.AlternatingItem || row.ItemType == ListItemType.Item)
                    {
                        AddInventory ctrlDirectorDtls = (AddInventory)row.FindControl("ctrlAddInventory");
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

    }
}