using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Reflection;
using Microsoft.CSharp;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using ICBrowser.Business;
using ICBrowser.Web;
using ICBrowser.Common;
using System.Data.OleDb;
using Microsoft.Office.Interop.Access;
using System.Web.Security;
using ICBrowser.DAL;



namespace ICBrowser.Web
{
    public partial class UploadInventory : BasePage
    {
        #region "public Parameters"
        List<Component> lstfound = new List<Component>();
        public DataSet finalData;
        public DataTable dtgetSellid = new DataTable();
        public int sellid = 0;
        public string companyname = "";
        public int membershiptype = 0;
        public string typeofmembership = "";
        InventoryGridDetails invengrddetails = new InventoryGridDetails();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;

                if (userToLogin != null)
                {
                    InventoryGridDetails sellersObj = new InventoryGridDetails();
                    int sellersCount = sellersObj.GetSellersCountByUserId(userid); //validates if the current user logged in is a seller or not

                    //create a function to get the expirydate of Seller who has Logged in
                    if (sellersCount > 0)
                    {

                        lblUploadMessage.Text = "";
                        lblExcessMessage.Text = "";


                        if (!IsPostBack)
                        {
                            Session["UploadedLink"] = "";
                            ViewState["Mode"] = "";
                            ViewState["FileName"] = "";
                            ViewState["Link"] = "";
                            loadInventorygrid();
                            lblUploadMessage.Visible = false;
                            lblExcessMessage.Visible = false;
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

        protected void loadInventorygrid() //normal binding of grid without search
        {
            try
            {
                //dtInventoryDetails = igd.getinventorylist();
                DataTable dtInventoryDetails = invengrddetails.GetAllComponentDetails();
                DataTable dtForGrid = new DataTable();
                dtForGrid.Columns.Add("Status", typeof(string));
                dtForGrid.Columns.Add("ComponentId", typeof(int));
                dtForGrid.Columns.Add("ComponentName", typeof(string));
                dtForGrid.Columns.Add("Quantity", typeof(int));
                dtForGrid.Columns.Add("StockInHand", typeof(int));
                dtForGrid.Columns.Add("Brandname", typeof(string));
                dtForGrid.Columns.Add("DataSheetFileName", typeof(string));
                dtForGrid.Columns.Add("DataSheetURL", typeof(string));


                DataRow drForGrid;
                foreach (DataRow drDetails in dtInventoryDetails.Rows)
                {
                    drForGrid = dtForGrid.NewRow();
                    if (drDetails["Status"].ToString().Equals("1"))
                    {
                        drForGrid["Status"] = "Open";
                    }
                    else
                    {
                        drForGrid["Status"] = "Closed";
                    }
                    drForGrid["ComponentId"] = drDetails["ComponentId"];
                    drForGrid["ComponentName"] = drDetails["ComponentName"];
                    drForGrid["Quantity"] = drDetails["Quantity"];
                    drForGrid["StockInHand"] = drDetails["StockInHand"];
                    drForGrid["Brandname"] = drDetails["Brandname"];
                    drForGrid["DataSheetURL"] = drDetails["DataSheetURL"];

                    string dataSheetURL = drDetails["DataSheetURL"].ToString();

                    if (dataSheetURL == "")
                    {
                        drForGrid["DataSheetFileName"] = drDetails["DataSheetURL"];
                    }
                    else
                    {
                        string dataSheetFileName = "";
                        if (!dataSheetURL.StartsWith("http://") && !dataSheetURL.Equals(""))
                        {
                            string[] subDataSheetURL = dataSheetURL.Split('/');
                            dataSheetFileName = subDataSheetURL.Last();


                            if (dataSheetFileName.EndsWith("..."))
                            {
                                if (dataSheetFileName.Length > 18)
                                    drForGrid["DataSheetFileName"] = dataSheetFileName.Substring(0, 15) + "...";
                                else
                                    drForGrid["DataSheetFileName"] = dataSheetFileName;

                            }
                            else
                            {
                                if (dataSheetFileName.Length > 18)
                                    drForGrid["DataSheetFileName"] = dataSheetFileName.Substring(0, 15) + "...";
                                else
                                    drForGrid["DataSheetFileName"] = dataSheetFileName + "...";
                            }

                        }
                        else
                        {
                            if (dataSheetFileName.EndsWith("..."))
                            {

                                if (dataSheetURL.Length > 18)
                                    drForGrid["DataSheetFileName"] = dataSheetURL.Substring(0, 15) + "...";
                                else
                                    drForGrid["DataSheetFileName"] = drDetails["DataSheetURL"];
                            }
                            else
                            {
                                if (dataSheetURL.Length > 18)
                                    drForGrid["DataSheetFileName"] = dataSheetURL.Substring(0, 15) + "...";
                                else
                                    drForGrid["DataSheetFileName"] = drDetails["DataSheetURL"];
                            }

                        }
                    }
                    dtForGrid.Rows.Add(drForGrid);
                }
                grdInventoryDetails.DataSource = dtForGrid;
                grdInventoryDetails.DataBind();
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);

            }

        }

        protected void grdInventoryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && this.grdInventoryDetails.EditIndex > -1 && e.Row.RowIndex == this.grdInventoryDetails.EditIndex)
                {
                    DropDownList ddlnotes;

                    System.Web.UI.WebControls.Label lblCompStatus = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblStatus");
                    ddlnotes = e.Row.FindControl("ddlStatus") as DropDownList;
                    string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[1].ToString();

                    int value = 1;
                    if (status.Equals("Closed"))
                        value = 0;
                    ddlnotes.SelectedIndex = value;
                }

                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        //string Datasheeturl = (string)DataBinder.Eval(e.Row.DataItem, "DataSheetURL");
                        if (DataBinder.Eval(e.Row.DataItem, "DataSheetURL").ToString() == "" || DataBinder.Eval(e.Row.DataItem, "DataSheetURL") == null)
                        {
                            ImageButton imgbtn = (ImageButton)e.Row.FindControl("imgupload");
                            imgbtn.Visible = true;
                            //imgbtn.Enabled = false;
                        }
                        else
                        {
                            ImageButton imgbtn = (ImageButton)e.Row.FindControl("imgupload");
                            imgbtn.Visible = false;

                        }
                    }
                }
                //if (this.grdInventoryDetails.EditIndex > -1 && e.Row.RowIndex == this.grdInventoryDetails.EditIndex)
                //{
                //    System.Web.UI.WebControls.Label lblCompStatus = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblStatus");
                //    DropDownList ddlnotes = e.Row.FindControl("ddlStatus") as DropDownList;
                //    string status = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[1].ToString();

                //    int value = 1;
                //    if (status.Equals("Closed"))
                //        value = 0;
                //    ddlnotes.SelectedIndex = value;

                //}
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdInventoryDetails.PageIndex = e.NewPageIndex;
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                    grdInventoryDetails.PageIndex = e.NewPageIndex;
                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        clearsearchselection();
                        loadInventorygrid();
                        grdInventoryDetails.PageIndex = 0;
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                            grdInventoryDetails.PageIndex = e.NewPageIndex;
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }






        }

        private void LogData(string data, Boolean isValidData)
        {
            IClogger.LogMessage(data);
        }

        protected void ClearAll()
        {
            try
            {
                TxtBrandName.Text = string.Empty;
                TxtComponentName.Text = string.Empty;
                // TxtDatasheetURL.Text = string.Empty;
                TxtDescription.Text = string.Empty;
                TxtPriceInINR.Text = string.Empty;
                TxtPriceInUSD.Text = string.Empty;
                TxtQuantity.Text = string.Empty;
                TxtStockInHand.Text = string.Empty;
                txtDatasheetlink.Text = string.Empty;
                //datepicker.Value = "";
                txtAvailfrom.Text = string.Empty;
                txtpriceinCNY.Text = string.Empty;
                //txtAvaildate.Text = string.Empty;
                //CalendarExtender.Clear();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void btnAddInventoryDetails_Click(object sender, EventArgs e)
        {

            try
            {
                ddlInventoryGridColumns.ClearSelection();
                txtSearchFromGrid.Text = "";
                ddlstatus.ClearSelection();
                string CompName = TxtComponentName.Text;
                int Qntity = Convert.ToInt32(TxtQuantity.Text);
                string brndname = TxtBrandName.Text;
                string descption = TxtDescription.Text;
                int StkInHnd = Convert.ToInt32(TxtStockInHand.Text);
                decimal prcInINR = Convert.ToDecimal(TxtPriceInINR.Text);

                string RequiredBefore = txtAvailfrom.Text + " " + DateTime.Now.ToLongTimeString();//txtRequiredBefore.PostedDate;
                DateTime Availfrom = Convert.ToDateTime(RequiredBefore);

                //string RequiredBefore = datepicker.Text;//txtRequiredBefore.PostedDate;
                //DateTime reqBefore = Convert.ToDateTime(RequiredBefore);
                //string Availfrom = reqBefore.ToString("dd-MM-yyyy");
                //DateTime Availfrom = Convert.ToDateTime(CalendarExtender.PostedDate);
                // string Availfrom = formattedDate.ToString("dd-MM-yyyy");


                decimal prcInUSD = Convert.ToDecimal(TxtPriceInUSD.Text);

                //new field addded CNY
                decimal prceInCNY = Convert.ToDecimal(txtpriceinCNY.Text);

                int status = 1;
                string datasheetlink = "";
                dtgetSellid = invengrddetails.getinventorylist();

                if (dtgetSellid.Rows.Count > 0)
                {
                    bool notiifcationsent = false;
                    sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
                    companyname = dtgetSellid.Rows[0]["CompanyName"].ToString();
                    membershiptype = Convert.ToInt32(dtgetSellid.Rows[0]["TypeOfMembership"]);

                    //here call a stored procedure to save data according to membership
                    //List<TypeOfMembership> lst = new List<TypeOfMembership>();
                    //lst = igd.GetMembershipDetails(membershiptype);
                    //int permittedcount = Convert.ToInt32(lst[0].ListingCount);  //number of Components Allowed to Save depending on Membership

                    int permittedcount = invengrddetails.getSellerListingCount(membershiptype);

                    //call stored procedure to count the number of data saved by Seller pass sellerid to this proc
                    int savedComponentCount = invengrddetails.getComponentCount(sellid);
                    int leftspace = permittedcount - savedComponentCount;

                    if (savedComponentCount >= permittedcount)
                    {
                        lblExcessMessage.Visible = true;
                        lblExcessMessage.Text = "You have exceeded the Limit. Please upgrade your Membership !!!";
                        //  lblExcessMessage.Text = " * No. of Rows that can be added : " + leftspace;
                        ClearAll();
                    }
                    else
                    {
                        // User uploads a file
                        if (FuploadAdd.HasFile)
                        {
                            string filetype = Path.GetExtension(FuploadAdd.FileName);
                            if (filetype == ".pdf" || filetype == ".doc")
                            {

                                int compID = invengrddetails.CreateInventory(sellid, CompName, Qntity, brndname, descption, StkInHnd, prcInINR, prcInUSD, "", companyname, Availfrom, status, notiifcationsent, prceInCNY);

                                if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + compID))
                                    Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + compID);

                                FuploadAdd.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + compID + "//" + FuploadAdd.FileName);
                                datasheetlink = ConfigurationManager.AppSettings["RequirementsSheetPath"] + compID + "//" + FuploadAdd.FileName;
                                invengrddetails.CreateInventory(sellid, CompName, Qntity, brndname, descption, StkInHnd, prcInINR, prcInUSD, datasheetlink, companyname, Availfrom, status, notiifcationsent, prceInCNY);
                                lblUploadMessage.Visible = true;
                                lblUploadMessage.CssClass = "greenmsg";
                                lblUploadMessage.Text = "Data saved Sucessfully !!!";
                            }
                            else
                            {
                                // only doc or pdf files are allowed
                                LogData("Only .pdf or .doc files are allowed", false);
                                lblExcessMessage.Visible = true;
                                lblExcessMessage.Text = "Only .pdf or .doc files are allowed.";
                            }
                        }
                        // User specifies URL.
                        else
                        {
                            if (txtDatasheetlink.Text != "")
                            {
                                if (!txtDatasheetlink.Text.StartsWith("http://"))
                                {
                                    datasheetlink = "http://" + txtDatasheetlink.Text;
                                }
                                else
                                {
                                    datasheetlink = txtDatasheetlink.Text;
                                }
                                invengrddetails.CreateInventory(sellid, CompName, Qntity, brndname, descption, StkInHnd, prcInINR, prcInUSD, datasheetlink, companyname, Availfrom, status, notiifcationsent, prceInCNY);
                                lblUploadMessage.Visible = true;
                                lblUploadMessage.CssClass = "greenmsg";
                                lblUploadMessage.Text = "Data Saved Sucessfully !!!";
                            }
                            else
                            {
                                invengrddetails.CreateInventory(sellid, CompName, Qntity, brndname, descption, StkInHnd, prcInINR, prcInUSD, datasheetlink, companyname, Availfrom, status, notiifcationsent, prceInCNY);
                                lblUploadMessage.Visible = true;
                                lblUploadMessage.CssClass = "greenmsg";
                                lblUploadMessage.Text = "Data Saved Sucessfully !!!";
                                ClearAll();
                            }
                        }

                        loadInventorygrid();
                    }
                }
                else
                {
                    LogData("Could not decrypt file.Error occured while file upload.", false);
                    // lblUploadMessage.CssClass = "red";
                    lblExcessMessage.Visible = true;
                    lblExcessMessage.Text = "Could not decrypt file.Error occured while file upload.";
                }
                ClearAll();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Upload")
                {
                    int id = Convert.ToInt32(hidComponentId.Value);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Label LblCompId = (System.Web.UI.WebControls.Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId");
                invengrddetails.deleteSelectedComponent(Convert.ToInt32(LblCompId.Text));
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedItem.Value);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        loadInventorygrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ViewState["Mode"] = "Update";
                string lblComponentId = ((System.Web.UI.WebControls.Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId")).Text;
                int status = Convert.ToInt32(((DropDownList)grdInventoryDetails.Rows[e.RowIndex].FindControl("ddlStatus")).Text);
                string txtComponentName = ((System.Web.UI.WebControls.TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtComponentName")).Text;
                string txtQuantity = ((System.Web.UI.WebControls.TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtQuantity")).Text;
                int txtstockinHand = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtStockInHand")).Text);
                string txtBrandName = ((System.Web.UI.WebControls.TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtBrandName")).Text;

                if (ViewState["FileName"].ToString() != "")
                {
                    //if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId)))
                    //{
                    //    Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId));
                    //}
                    //else
                    //{
                    //    if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId + "\\" + ViewState["FileName"].ToString())))
                    //    {
                    //        File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId + "\\" + ViewState["FileName"].ToString()));
                    //    }
                    //}

                    // FileUpload fil = (FileUpload)Session["upload"];
                    //if (fil.HasFile)
                    //{
                    // string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId) + "\\" + ViewState["FileName"].ToString();
                    // fil.SaveAs(savedFilePath);



                    invengrddetails.updateComponentRows(Convert.ToInt32(lblComponentId), txtComponentName, Convert.ToInt32(txtQuantity), txtBrandName, status, txtstockinHand, ConfigurationManager.AppSettings["RequirementsSheetPath"] + lblComponentId + "/" + ViewState["FileName"].ToString());
                    //}
                    ViewState["FileName"] = "";
                }
                else
                {
                    if (Session["UploadedLink"].ToString() != "")
                    {
                        invengrddetails.updateComponentRows(Convert.ToInt32(lblComponentId), txtComponentName, Convert.ToInt32(txtQuantity), txtBrandName, status, txtstockinHand, Session["UploadedLink"].ToString());
                        Session["UploadedLink"] = "";
                        txtlink.Text = "";
                    }
                    else
                    {
                        // invengrddetails.updateComponentRows(Convert.ToInt32(lblComponentId), txtComponentName, Convert.ToInt32(txtQuantity), txtBrandName, status, txtstockinHand, Session["UploadedLink"].ToString());
                        //invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), datasheetpopuplink);
                        invengrddetails.UpdateComponentWithoutDatasheetURL(Convert.ToInt32(lblComponentId), txtComponentName, Convert.ToInt32(txtQuantity), txtBrandName, status, txtstockinHand, DateTime.Now);
                    }
                }

                grdInventoryDetails.EditIndex = -1; //reset the edit index
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        loadInventorygrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
                ViewState["Mode"] = "";
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdInventoryDetails.EditIndex = -1;

                if (Convert.ToBoolean(ViewState["fileSaved"]) == true)
                {
                    int compid = Convert.ToInt32(hidComponentId.Value);
                    if (Session["PreviousUploadedFile"].ToString() != "")
                    {
                        char[] MyChar = { '.' };

                        string PreviousUploadedFile = (Session["PreviousUploadedFile"].ToString()).TrimEnd(MyChar);

                        if (PreviousUploadedFile.StartsWith("http://"))
                        {
                            invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), Session["PreviousUploadedFile"].ToString());
                            Session["PreviousUploadedFile"] = "";
                        }
                        else
                        {
                            invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + Session["PreviousUploadedFile"].ToString());
                        }

                    }

                    //try
                    //{
                    //    //if (fuGridUploader.HasFile)
                    //    //{
                    //    //    if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + ViewState["FileName"].ToString())))
                    //    //    {
                    //    //        File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + ViewState["FileName"].ToString()));
                    //    //    }
                    //    //    //update uploaded file with previuosly stored file name
                    //    //    invengrddetails.InsertUploadedfile(compid, ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + ViewState["PreviousUploadedFile"].ToString());
                    //    //    loadInventorygrid();
                    //    //}

                    //    //else
                    //    //{
                    //    //    if (txtlink.Text != "")
                    //    //    {
                    //    //        //delete the text link from database and save or update  ViewState["link"] in database for respective Componeet id 

                    //    //        invengrddetails.InsertUploadedfile(compid, ViewState["PreviousUploadedLink"].ToString());
                    //    //        loadInventorygrid();
                    //    //    }
                    //    //}

                    //}
                    //catch (Exception ex)
                    //{
                    //    //Error in deleting the Saved file 
                    //}


                }


                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                }
                else
                {
                    //if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0)
                    //{
                    //    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                    //    bindSearchFromGrid();
                    //}
                    //else
                    //{
                    //    loadInventorygrid();
                    //}

                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        loadInventorygrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void grdInventoryDetails_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
        }

        protected void FileUpload_Click(object sender, EventArgs e)  //Excelsheet File Upload 
        {
            try
            {
                ddlstatus.ClearSelection();
                ddlInventoryGridColumns.ClearSelection();
                txtSearchFromGrid.Text = "";
                try
                {
                    if (fuExcelSheet.HasFile)
                    {
                        finalData = new DataSet();
                        DataTable dtSheet = new DataTable("SheetCollection");
                        dtSheet.Columns.Add("Component_Name");
                        dtSheet.Columns.Add("Quantity");
                        dtSheet.Columns.Add("Brand_Name");
                        dtSheet.Columns.Add("Description");
                        dtSheet.Columns.Add("StockInHand");
                        dtSheet.Columns.Add("PriceInINR");
                        dtSheet.Columns.Add("PriceInUSD");
                        dtSheet.Columns.Add("DataSheetURL");
                        dtSheet.Columns.Add("AvailableFrom");
                        finalData.Tables.Add(dtSheet);

                        ReadFile(finalData.Tables[0]);
                        loadInventorygrid();
                    }
                    else
                    {
                        LogData("Please select file to Upload.", false);
                        //lblUploadMessage.CssClass = "red";
                        lblExcessMessage.Visible = true;
                        lblExcessMessage.Text = "Please select file to Upload.";
                    }
                }
                catch (Exception ex)
                {
                    LogData(ex.Message == "Could not decrypt file." ? "File must not be password protected " : "Error occured while file upload.", false);
                    // lblUploadMessage.CssClass = "red";
                    lblExcessMessage.Visible = true;
                    lblExcessMessage.Text = "Error in uploading file ";
                    IClogger.LogError(ex, "Error in uploading file ");
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }


        private void ReadFile(DataTable dt)
        {
            try
            {
                dtgetSellid = invengrddetails.getinventorylist(); //(gets SellerId ,compoanyName,TypeOfMembership)
                string filename = fuExcelSheet.FileName;
                string extension = Path.GetExtension(filename);

                if (extension != null)
                {
                    string filetype = extension.ToLower();

                    if (filetype == ".xls")
                    {
                        if (dtgetSellid.Rows.Count > 0)
                        {
                            sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
                            membershiptype = Convert.ToInt32(dtgetSellid.Rows[0]["TypeOfMembership"]);
                            int permittedcount = invengrddetails.getSellerListingCount(membershiptype);  //gets the permitted count
                            int savedComponentCount = invengrddetails.getComponentCount(sellid);  //gets the total saved component count


                            if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"]) + sellid))
                                Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid));

                            fuExcelSheet.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid) + "/" + filename);
                            string SavedfilePath = Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid) + "\\" + filename;
                            ExcelService service = new ExcelService(SavedfilePath);
                            string firstSheetName = service.Sheets[0];
                            DataTable dtExcelsheetdetails = new DataTable();
                            dtExcelsheetdetails = service.GetSheetData(firstSheetName);//(get number of components entered in Excelsheet) 
                            int leftspace = permittedcount - savedComponentCount; //gets the left space to save componenets 
                            int inventorySavedCount = 0;

                            if (dtExcelsheetdetails.Rows.Count > leftspace && leftspace > 0)
                            {
                                //  int SaveOnly = dtExcelsheetdetails.Rows.Count - leftspace;
                                int SaveOnly = leftspace;
                                inventorySavedCount = invengrddetails.GetInventoryDataOnMembership(SavedfilePath, SaveOnly); //limit the count of Component to be Saved
                                savedComponentCount = invengrddetails.getComponentCount(sellid);
                                leftspace = permittedcount - savedComponentCount;
                                lblExcessMessage.Visible = true;
                                lblExcessMessage.CssClass = "greenmsg";
                                lblExcessMessage.Text = " Total Rows Uploaded : " + inventorySavedCount + ";&nbsp;&nbsp;   Out Of : " + dtExcelsheetdetails.Rows.Count + ";&nbsp;&nbsp;   No. of Inventories that can be added : " + leftspace;
                            }
                            else
                            {
                                if (dtExcelsheetdetails.Rows.Count < leftspace && leftspace > 0)
                                {
                                    inventorySavedCount = invengrddetails.GetInventoryDataOnMembership(SavedfilePath, 0); //default loop no of rows datasheet contains
                                    savedComponentCount = invengrddetails.getComponentCount(sellid);
                                    leftspace = permittedcount - savedComponentCount;
                                    lblExcessMessage.Visible = true;
                                    lblExcessMessage.CssClass = "greenmsg";
                                    lblExcessMessage.Text = " Total Rows Uploaded : " + inventorySavedCount + ";&nbsp;&nbsp;   Out Of : " + dtExcelsheetdetails.Rows.Count + ";&nbsp;&nbsp;   No. of Inventories that can be added : " + leftspace;
                                }
                                else
                                {
                                    if (leftspace <= 0)
                                    {
                                        lblExcessMessage.Visible = true;
                                        // lblExcessMessage.CssClass = "red";
                                        lblExcessMessage.Text = "You have exceeded the amount of Inventories to be Uploaded. Please subscribe for the same.";
                                    }
                                }
                            }
                            Directory.Delete(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid), true);

                        }
                        else
                        {
                            IClogger.LogError("Only excel files allowed.");
                            lblExcessMessage.Visible = true;
                            lblExcessMessage.Text = "Excel files of the given format are only allowed.";
                        }
                    }
                    else
                    {
                        IClogger.LogError("Only excel files allowed.");
                        lblExcessMessage.Visible = true;
                        lblExcessMessage.Text = "Excel files of the given format are only allowed.";
                    }
                }
                else
                {
                    IClogger.LogError("Only excel files allowed.");
                    lblExcessMessage.Visible = true;
                    lblExcessMessage.Text = "Excel files of the given format are only allowed.";

                }
            }

            catch (Exception ex)
            {
                //  LogData(ex.Message == "Could not decrypt file." ? "File must not be password protected " : "Error occured while file upload.", false);
                lblExcessMessage.Visible = true;
                lblExcessMessage.Text = "Error occured while file upload. Please upload file of the given Template.";
                IClogger.LogError(ex, "File upload error");
            }

        }



        //private void ReadFile(DataTable dt) //Reads data from Excel sheet
        //{
        //    dtgetSellid = invengrddetails.getinventorylist(); //(gets SellerId ,compoanyName,TypeOfMembership)
        //    try
        //    {
        //        string filename = fuExcelSheet.FileName;
        //        var extension = Path.GetExtension(filename);

        //        if (extension != null)
        //        {
        //            string filetype = extension.ToLower();
        //            if (filetype == ".xls")
        //            {
        //                if (dtgetSellid.Rows.Count > 0)
        //                {
        //                    sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
        //                    membershiptype = Convert.ToInt32(dtgetSellid.Rows[0]["TypeOfMembership"]);
        //                    int permittedcount = invengrddetails.getSellerListingCount(membershiptype);  //gets the permitted count
        //                    int savedComponentCount = invengrddetails.getComponentCount(sellid);  //gets the total saved component count
        //                    if (savedComponentCount >= permittedcount)
        //                    {
        //                        //lblExcessMessage.Text = " * Total Rows that can be added : 0";
        //                        lblExcessMessage.Text = " * You have exceeded the Limit. Please upgrade your Membership !!! ";
        //                    }
        //                    else
        //                    {
        //                        if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"]) + sellid))
        //                            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid));
        //                        fuExcelSheet.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid) + "/" + filename);
        //                        string SavedfilePath = Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid) + "\\" + filename;
        //                        ExcelService service = new ExcelService(SavedfilePath);
        //                        string firstSheetName = service.Sheets[0];
        //                        DataTable dtExcelsheetdetails = new DataTable();
        //                        dtExcelsheetdetails = service.GetSheetData(firstSheetName);//(get number of components entered in Excelsheet)   

        //                        int savedcount = invengrddetails.GetInventoryDataOnMembership(SavedfilePath,0);
        //                     //   savedComponentCount = invengrddetails.getComponentCount(sellid); //get the count of all entered component after saving 
        //                        int leftspace = permittedcount - savedComponentCount;

        //                        if (dtExcelsheetdetails.Rows.Count == savedcount)       //wrong condition//
        //                        {
        //                            lblExcessMessage.Visible = true;
        //                            lblExcessMessage.Text = " Total Rows Uploaded : " + savedcount + ";&nbsp;&nbsp;   Out Of : " + dtExcelsheetdetails.Rows.Count + ";&nbsp;&nbsp;   No. of Inventories that can be added : " + leftspace;
        //                        }
        //                        else
        //                        {
        //                            if (dtExcelsheetdetails.Rows.Count > leftspace)
        //                            {
        //                                lblExcessMessage.Visible = true;
        //                                lblExcessMessage.Text = " Total Rows Uploaded : " + savedcount + ";&nbsp;&nbsp;   Out Of : " + dtExcelsheetdetails.Rows.Count + ";&nbsp;&nbsp;    No. of Inventories that can be added : " + leftspace;
        //                            }
        //                            else
        //                            {
        //                                lblExcessMessage.Visible = true;
        //                                lblExcessMessage.Text = " Total Rows Uploaded : " + savedcount + ";&nbsp;&nbsp;   Out Of : " + dtExcelsheetdetails.Rows.Count + ";&nbsp;&nbsp;    No. of Inventories that can be added : " + leftspace;
        //                            }
        //                        }
        //                        Directory.Delete(Server.MapPath(ConfigurationManager.AppSettings["DataSheetPath"] + sellid), true);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                LogData("Only excel files allowed", false);
        //                lblUploadMessage.Visible = true;
        //                lblUploadMessage.Text = "Excel files of the given format are only allowed.";
        //            }
        //        }
        //        else
        //        {
        //            LogData("Please select file to Upload.", false);
        //            lblUploadMessage.Visible = true;
        //            lblUploadMessage.Text = "Please select file to Upload.";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        LogData(ex.Message == "Could not decrypt file." ? "File must not be password protected " : "Error occured while file upload.", false);
        //        lblUploadMessage.Visible = true;
        //        lblUploadMessage.Text = "Error occured while file upload. Please upload file of the given Template.";
        //        IClogger.LogError(ex, "File upload error");
        //    }
        //}

        protected void btnUploadSave_Click(object sender, EventArgs e) //grid fileupload popup  savebtn
        {

            try
            {
                string compid = hidComponentId.Value;
                ViewState["fileSaved"] = true;
                if (fuGridUploader.HasFile)
                {
                    string uploadfilename = fuGridUploader.FileName;

                    string extnsion = Path.GetExtension(uploadfilename);
                    double filesize = Convert.ToDouble(Web.Properties.Settings.Default.FileSize);

                    if (extnsion == ".pdf" || extnsion == ".doc")
                    {
                        ViewState["FileName"] = uploadfilename;
                        if (fuGridUploader.PostedFile.ContentLength > filesize) //Only 4MB file upload is allowed 4194304
                        {
                            lblExcessMessage.Visible = true;
                            lblExcessMessage.Text = "Your file was not uploaded because it exceeds the 4MB size limit.";
                        }
                        else
                        {
                            if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid)))
                            {
                                Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid));
                            }
                            else
                            {
                                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + uploadfilename)))
                                {
                                    File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + uploadfilename));
                                }
                            }
                            //code for Saving the file
                            string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid) + "\\" + uploadfilename;
                            fuGridUploader.SaveAs(savedFilePath);

                            if (ViewState["Mode"].ToString() != "Edit")
                            {
                                invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + uploadfilename);
                                ViewState["Mode"] = "";
                            }

                            loadInventorygrid();
                        }
                    }
                    else
                    {
                        lblExcessMessage.Visible = true;
                        lblExcessMessage.Text = "Please Upload .pdf or .doc files.";
                    }
                }
                else
                {
                    string datasheetpopuplink = "";
                    if (txtlink.Text != "")
                    {
                        if (!txtlink.Text.StartsWith("http://"))
                        {
                            datasheetpopuplink = "http://" + txtlink.Text;
                            ViewState["link"] = datasheetpopuplink;
                        }
                        else
                        {
                            datasheetpopuplink = txtlink.Text;
                            ViewState["link"] = datasheetpopuplink;
                        }

                        Session["UploadedLink"] = datasheetpopuplink;


                        if (ViewState["Mode"].ToString() != "Edit")
                        {
                            invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), datasheetpopuplink);
                            ViewState["Mode"] = "";
                        }

                        //invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), datasheetpopuplink);
                        //  string prevfile = ViewState["PreviousUploadedFile"].ToString();
                    }
                }

                //code to Bind grid depending on Search conditions
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        loadInventorygrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);

            }
        }



        //protected void btnUploadSave_Click(object sender, EventArgs e) //grid fileupload popup  savebtn
        //{
        //    string compid = hidComponentId.Value;
        //    if (fuGridUploader.HasFile)
        //    {
        //        string uploadfilename = fuGridUploader.FileName;
        //        string extnsion = Path.GetExtension(uploadfilename);
        //        double filesize = Convert.ToDouble(Web.Properties.Settings.Default.FileSize);

        //        if (extnsion == ".pdf" || extnsion == ".doc")
        //        {
        //            if (fuGridUploader.PostedFile.ContentLength > filesize) //Only 4MB file upload is allowed 4194304
        //            {
        //                lblUploadMessage.Text = "Your file was not uploaded because it exceeds the 4MB size limit.";
        //            }
        //            else
        //            {
        //                Session["upload"] = fuGridUploader;
        //                ViewState["FileName"] = uploadfilename;
        //                ViewState["Link"] = "";

        //                if (ViewState["Mode"].ToString() != "Edit")
        //                {
        //                    if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid)))
        //                    {
        //                        Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid));
        //                    }
        //                    else
        //                    {
        //                        if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + ViewState["FileName"].ToString())))
        //                        {
        //                            File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + ViewState["FileName"].ToString()));
        //                        }
        //                    }
        //                    string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid) + "\\" + ViewState["FileName"].ToString();
        //                    fuGridUploader.SaveAs(savedFilePath);
        //                    invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + ViewState["FileName"].ToString());
        //                    loadInventorygrid();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            lblUploadMessage.Text = "Please Upload .pdf or .doc files.";
        //        }
        //    }
        //    else
        //    {
        //        string datasheetpopuplink = "";
        //        if (txtlink.Text != "")
        //        {
        //            ViewState["FileName"] = "";
        //            if (!txtlink.Text.StartsWith("http://"))
        //            {
        //                datasheetpopuplink = "http://" + txtlink.Text;
        //                ViewState["Link"] = datasheetpopuplink;
        //            }
        //            else
        //            {
        //                datasheetpopuplink = txtlink.Text;
        //                ViewState["Link"] = datasheetpopuplink;
        //            }
        //            if (ViewState["Mode"].ToString() != "Edit")
        //            {
        //                invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ViewState["Link"].ToString());
        //                //  loadInventorygrid();
        //                ViewState["Mode"] = "";
        //            }
        //        }
        //        else
        //        {
        //            //   lblUploadMessage.Text = "Incomplete Data. Please select a file or add a link.";
        //        }
        //    }

        //    if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
        //    {
        //        lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
        //        bindSearchFromGrid();
        //    }
        //    else
        //    {
        //        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
        //        {
        //            loadInventorygrid();
        //        }
        //        else
        //        {
        //            if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
        //            {
        //                lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
        //                bindSearchFromGrid();
        //            }
        //            else
        //            {
        //                loadInventorygrid();
        //            }
        //        }
        //    }

        //    ViewState["Mode"] = "";

        //}






        //protected void btnUploadSave_Click(object sender, EventArgs e) //grid fileupload popup  savebtn
        //{
        //    try
        //    {
        //        string compid = hidComponentId.Value;
        //        if (fuGridUploader.HasFile)
        //        {
        //            string uploadfilename = fuGridUploader.FileName;
        //            string extnsion = Path.GetExtension(uploadfilename);
        //            dtgetSellid = invengrddetails.getinventorylist();
        //            double filesize = Convert.ToDouble(Web.Properties.Settings.Default.FileSize);

        //            if (extnsion == ".pdf" || extnsion == ".doc")
        //            {
        //                if (fuGridUploader.PostedFile.ContentLength > filesize) //Only 4MB file upload is allowed 4194304
        //                {
        //                    lblUploadMessage.Text = "Your file was not uploaded because it exceeds the 4MB size limit.";
        //                }
        //                else
        //                {
        //                    sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
        //                    if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid)))
        //                    {
        //                        Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid));
        //                        string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid) + "\\" + uploadfilename;
        //                        fuGridUploader.SaveAs(savedFilePath);


        //                        invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + uploadfilename);

        //                        lblUploadMessage.CssClass = "green";
        //                        lblUploadMessage.Text = "File Uploaded Sucessfully!!!";

        //                        if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
        //                        {
        //                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
        //                            bindSearchFromGrid();
        //                        }
        //                        else
        //                        {
        //                            if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
        //                            {
        //                                loadInventorygrid();
        //                            }
        //                            else
        //                            {
        //                                if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
        //                                {
        //                                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
        //                                    bindSearchFromGrid();
        //                                }
        //                                else
        //                                {
        //                                    loadInventorygrid();
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + uploadfilename)))
        //                        {
        //                            File.Delete(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "\\" + uploadfilename));
        //                        }
        //                        string savedFilePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid) + "\\" + uploadfilename;
        //                        fuGridUploader.SaveAs(savedFilePath);
        //                        invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), ConfigurationManager.AppSettings["RequirementsSheetPath"] + compid + "/" + uploadfilename);

        //                        lblUploadMessage.CssClass = "green";
        //                        lblUploadMessage.Text = "File Uploaded Sucessfully!!!";

        //                        if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
        //                        {
        //                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
        //                            bindSearchFromGrid();
        //                        }
        //                        else
        //                        {
        //                            if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
        //                            {
        //                                loadInventorygrid();
        //                            }
        //                            else
        //                            {
        //                                if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
        //                                {
        //                                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
        //                                    bindSearchFromGrid();
        //                                }
        //                                else
        //                                {
        //                                    loadInventorygrid();
        //                                }
        //                            }
        //                        }
        //                        // }
        //                    }
        //                }
        //            }

        //            else
        //            {
        //                lblUploadMessage.Text = "Please Upload .pdf or .doc files";
        //            }
        //        }
        //        else
        //        {
        //            string datasheetpopuplink;

        //            if (txtlink.Text != "")
        //            {
        //                if (!txtlink.Text.StartsWith("http://"))
        //                {
        //                    datasheetpopuplink = "http://" + txtlink.Text;
        //                }
        //                else
        //                {
        //                    datasheetpopuplink = txtlink.Text;
        //                }

        //                invengrddetails.InsertUploadedfile(Convert.ToInt32(compid), datasheetpopuplink);
        //                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
        //                {
        //                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
        //                    bindSearchFromGrid();
        //                }
        //                else
        //                {

        //                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
        //                    {
        //                        loadInventorygrid();

        //                    }
        //                    else
        //                    {
        //                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
        //                        {
        //                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
        //                            bindSearchFromGrid();
        //                        }
        //                        else
        //                        {
        //                            loadInventorygrid();
        //                        }

        //                    }

        //                }
        //                txtlink.Text = string.Empty;
        //                // igd.CreateInventory(sellid, CompName, Qntity, brndname, descption, StkInHnd, prcInINR, prcInUSD, datasheetlink, companyname, Availfrom, status);
        //            }
        //            else
        //                lblUploadMessage.Text = "Incomplete Data. Please select a file or add a link.";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.ToString());
        //    }

        //}

        protected void grdInventoryDetails_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ViewState["Mode"] = "Edit";
                //ImageButton imgbutn = (ImageButton)grdInventoryDetails.FindControl("imguploadEdit");
                //imgbutn.Enabled = true;
                grdInventoryDetails.EditIndex = e.NewEditIndex;
                if (Convert.ToInt32(ddlstatus.SelectedValue) > -1)
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                    bindSearchFromGrid();
                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                    {
                        loadInventorygrid();
                    }
                    else
                    {
                        if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                        {
                            lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                            bindSearchFromGrid();
                        }
                        else
                        {
                            loadInventorygrid();
                        }
                    }
                }
                try
                {
                    ImageButton btngetUrl = (ImageButton)grdInventoryDetails.Rows[e.NewEditIndex].FindControl("imguploadEdit");
                    string checkUrlType = btngetUrl.CommandArgument;

                    if (checkUrlType.StartsWith("http://"))
                    {
                        trUploadedFile.Visible = false;
                        txtlink.Text = checkUrlType;
                        ViewState["PreviousUploadedLink"] = checkUrlType;
                        Session["PreviousUploadedFile"] = checkUrlType;
                    }
                    else
                    {
                        trUploadedFile.Visible = true;
                        lblUploadedFile.Text = checkUrlType;
                        ViewState["PreviousUploadedFile"] = checkUrlType;
                        Session["PreviousUploadedFile"] = checkUrlType;
                        txtlink.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    // LogData(ex.Message == "Could not decrypt file." ? "File must not be password protected " : "Error occured while file upload.", false);
                    lblUploadMessage.Text = "Error occured while operation .";
                    IClogger.LogError(ex, "Error occured while operation .");
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void ddlInventoryGridColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchFromGrid.Text = String.Empty;

                if (ddlInventoryGridColumns.SelectedValue == "4") //if selected ddl values is status 
                {
                    ddlstatus.Visible = true;
                    ddlstatus.SelectedValue = "-1";
                    txtSearchFromGrid.Visible = false;
                    imgSearchFromGrid.Visible = false;
                }
                else
                {
                    ddlstatus.Visible = false;
                    ddlstatus.SelectedValue = "-1";
                    txtSearchFromGrid.Visible = true;
                    imgSearchFromGrid.Visible = true;
                }

                //if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) >= 0 && txtSearchFromGrid.Text == "")
                //{
                //    loadInventorygrid();
                //}


                if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && txtSearchFromGrid.Text == "")
                {
                    loadInventorygrid();

                }
                else
                {
                    if (Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) > 0 && (txtSearchFromGrid.Text) != "")
                    {
                        lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                        bindSearchFromGrid();
                    }
                    else
                    {
                        loadInventorygrid();
                    }

                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void bindSearchFromGrid()  //Binding grid with search result
        {
            try
            {
                //bind the grid according to text entered          
                DataTable dtForGrid = new DataTable();
                dtForGrid.Columns.Add("Status", typeof(string));
                dtForGrid.Columns.Add("ComponentId", typeof(int));
                dtForGrid.Columns.Add("ComponentName", typeof(string));
                dtForGrid.Columns.Add("Quantity", typeof(int));
                dtForGrid.Columns.Add("StockInHand", typeof(int));
                dtForGrid.Columns.Add("Brandname", typeof(string));
                dtForGrid.Columns.Add("DataSheetFileName", typeof(string));
                dtForGrid.Columns.Add("DataSheetURL", typeof(string));
                DataRow dr;

                foreach (ICBrowser.Common.Component buyerReqEntry in lstfound)
                {
                    dr = dtForGrid.NewRow();
                    dr["ComponentId"] = buyerReqEntry.Componentid;
                    if (buyerReqEntry.Status == 1)
                        dr["Status"] = "Open";

                    else
                        dr["Status"] = "Closed";
                    dr["Quantity"] = buyerReqEntry.Quantity;
                    dr["StockInHand"] = buyerReqEntry.StockInHand;
                    dr["ComponentName"] = buyerReqEntry.ComponentName;
                    dr["BrandName"] = buyerReqEntry.BrandName;
                    dr["DataSheetURL"] = buyerReqEntry.DataSheetURL;
                    string dataSheetURL = dr["DataSheetURL"].ToString();
                    if (dataSheetURL == "")
                    {
                        dr["DataSheetFileName"] = dr["DataSheetURL"];
                    }
                    else
                    {
                        string dataSheetFileName = "";
                        if (!dataSheetURL.StartsWith("http://") && !dataSheetURL.Equals(""))
                        {
                            string[] subDataSheetURL = dataSheetURL.Split('/');
                            dataSheetFileName = subDataSheetURL.Last();

                            if (dataSheetFileName.EndsWith("..."))
                            {
                                if (dataSheetFileName.Length > 18)
                                    dr["DataSheetFileName"] = dataSheetFileName.Substring(0, 15) + "...";
                                else
                                    dr["DataSheetFileName"] = dataSheetFileName;
                            }

                            else
                            {

                                if (dataSheetFileName.Length > 18)
                                    dr["DataSheetFileName"] = dataSheetFileName.Substring(0, 15) + "...";
                                else
                                    dr["DataSheetFileName"] = dataSheetFileName + "...";
                            }
                        }
                        else
                        {

                            if (dataSheetFileName.EndsWith("..."))
                            {
                                if (dataSheetURL.Length > 18)
                                    dr["DataSheetFileName"] = dataSheetURL.Substring(0, 15) + "...";
                                else
                                    dr["DataSheetFileName"] = buyerReqEntry.DataSheetURL;
                            }

                            else
                            {
                                if (dataSheetURL.Length > 18)
                                    dr["DataSheetFileName"] = dataSheetURL.Substring(0, 15) + "...";
                                else
                                    dr["DataSheetFileName"] = buyerReqEntry.DataSheetURL + "...";
                            }
                        }
                    }
                    dtForGrid.Rows.Add(dr);
                }
                grdInventoryDetails.DataSource = dtForGrid;
                grdInventoryDetails.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), ddlstatus.SelectedValue);
                bindSearchFromGrid();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void imgSearchFromGrid_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(ddlInventoryGridColumns.SelectedValue) >= 0) && (txtSearchFromGrid.Text == ""))
                {
                    loadInventorygrid();
                }
                else
                {
                    lstfound = invengrddetails.GetRequestedSearchGridData(Convert.ToInt32(ddlInventoryGridColumns.SelectedItem.Value), txtSearchFromGrid.Text);
                    bindSearchFromGrid();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void imgClearSearchSelection_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                grdInventoryDetails.PageIndex = 0;
                clearsearchselection();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        public void clearsearchselection()
        {

            ddlInventoryGridColumns.ClearSelection();
            txtSearchFromGrid.Text = string.Empty;
            ddlstatus.Visible = false;
            txtSearchFromGrid.Visible = true;
            ddlstatus.ClearSelection();
            loadInventorygrid();
            imgSearchFromGrid.Visible = true;
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                modalpopou.Hide();
                ClearAll();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        protected void imgcancl_Click(object sender, ImageClickEventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void lnkBulkAddInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add10Inventory.aspx");
        }
    }
}