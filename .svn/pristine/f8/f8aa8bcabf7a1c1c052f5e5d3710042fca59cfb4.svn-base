using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ICBrowser.Common;
using System.Configuration;
using System.Web.Security;
using System.Data;
using ICBrowser.Business;
using ICBrowser.DAL;
using System.Net;
using System.Collections;

namespace ICBrowser.Web.Controls
{
    public partial class UploadSheetData : System.Web.UI.UserControl
    {
        #region "Private variable"
        private DataTable _finalData;
        //static string strNewPath;
        #endregion

        Common.UserProfile ObjUserProfile = new Common.UserProfile();
        InventoryGridDetails invengrddetails = new InventoryGridDetails();
        public DataTable dtgetSellid = new DataTable();
        public Guid UserId;
        public string responseString;
        // int insertStatus = 0;
        public int membershiptype = 0;

        #region "Events"
        /// <summary>
        /// Handles the Init event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //Implemented for handling the Dynamic control selection
                if (Session["SelectedSheet"] != null)
                {
                    LoadSelectedDocument(Convert.ToString(Session["SelectedSheet"]).Split('~')[1]);
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //MembershipUser userToLogin = Membership.GetUser();
                //if (userToLogin != null)
                //{
                //    Guid userId = (Guid)userToLogin.ProviderUserKey;
                //    Controller controlIsAdmin = new Controller();
                //    Users Admin = controlIsAdmin.GetIsAdmin(userId);
                //    if (Admin.IsAdmin == true)
                //    {
                //        //img.Visible = false;
                //        //lnkdownloadTemp.Visible = false;
                //    }
                //}

                string querystring = Request.QueryString["RequestType"].ToString();
                if (!Page.IsPostBack)
                {

                    btnWorkSheetMapping.Enabled = false;
                    btnUpload.Enabled = true;
                    if (Session["UserProfile"] != null && (querystring != null || querystring != ""))
                    {
                        int MembershipType = ((ICBrowser.Common.UserProfile)(Session["UserProfile"])).TypeOfMembership;
                        if (MembershipType > 1) // User is Trial or Paid 
                        {
                            if (querystring == "Inventory")
                            {
                                lblUploadName.Text = "Post/Upload Inventory file in .xls format";
                                ddlStockStatus.Visible = true;
                                rfvddlStockStatus.Visible = true;
                                lblStkstatus.Visible = true;
                                ddlPorfq.Visible = false;
                                rfvddlPorfq.Visible = false;
                                lblPorfq.Visible = false;
                            }
                            else if (querystring == "Offers")
                            {
                                lblUploadName.Text = "Post/Upload Offer file in .xls format";
                                ddlStockStatus.Visible = true;
                                rfvddlStockStatus.Visible = true;
                                lblStkstatus.Visible = true;
                                ddlPorfq.Visible = false;
                                rfvddlPorfq.Visible = false;
                                lblPorfq.Visible = false;
                            }
                            else
                            {
                                //statustr.Style.Add("display", "none");
                                //potr.Style.Add("display", "inline-table");
                                ddlStockStatus.Visible = false;
                                rfvddlStockStatus.Visible = false;
                                lblStkstatus.Visible = false;
                            }
                        }
                        else // User is Free
                        {
                            if (querystring == "Requirement")
                            {
                                lblUploadName.Text = "Post/Upload Requirement/PO file in .xls format";
                                ddlStockStatus.Visible = false;
                                rfvddlStockStatus.Visible = false;
                                lblStkstatus.Visible = false;
                            }
                            else
                            {
                                Response.Redirect("Default.aspx", false);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    BindDefaultGrid();
                    btnClear_Click(sender, e);

                    // Template Download 
                    string temp = Request.QueryString["RequestType"].ToString();
                    if (temp.Equals("Requirement"))
                    {
                        lblUploadName.Text = "Post/Upload Requirement/PO file in .xls format";
                        hyplnkDwnloadRequirement.Visible = true;
                        hyplnkDwnloadInventory.Visible = false;
                    }
                    else
                    {
                        hyplnkDwnloadRequirement.Visible = false;
                        hyplnkDwnloadInventory.Visible = true;
                    }
                }
                else
                {
                    if (querystring == "Inventory")
                    {
                        responseString = "SellerUploadedInventory.aspx";
                    }
                    else if (querystring == "Offers")
                    {
                        responseString = "~/UserOffers.aspx";
                    }
                    else
                    {
                        responseString = "~/BuyersRequirment.aspx";
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the dvWorkSheetData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void dvWorkSheetData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<string> text = new List<string>();
            string usertype = Request.QueryString["RequestType"];
            if (usertype.Equals("Inventory") || usertype.Equals("Offers"))
            {
                text.Add("Part #");
                text.Add("qty.");
                text.Add("Make");
                text.Add("d/c");
                //text.Add("Stock In Hand");
                //text.Add("Price In INR");
                text.Add("Package");
                //text.Add("Price In CNY");
                text.Add("comment");
                //text.Add("Country");
                text.Add("Unit Price in USD");
            }
            else
            {
                text.Add("Part #");
                text.Add("qty.");
                text.Add("Make");
                text.Add("d/c");
                text.Add("Package");
                text.Add("comment");
                text.Add("PO/RFQ");
                text.Add("Unit Price In USD");
                //text.Add("Country");
            }


            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Handle the dynamic control
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    DropDownList ddlSelect = new DropDownList { ID = "ddlSelect" + i };
                    if (Convert.ToBoolean(HiddenField1.Value == "true"))
                    {
                        Session["CheckBoxState"] = "IsChecked";
                    }

                    if (Session["CheckBoxState"] != null)
                    {
                        ddlSelect.Items.Add(new ListItem { Text = text[i] });
                        e.Row.Cells[i].Controls.Add(ddlSelect);
                    }
                    else
                    {
                        PopulateDropdownList(ddlSelect);
                        e.Row.Cells[i].Controls.Add(ddlSelect);
                    }
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

            ObjUserProfile = (Common.UserProfile)Session["UserProfile"];
            UserId = ObjUserProfile.UserID;


            try
            {
                DropDownList dataMappingList = new DropDownList();
                PopulateDropdownList(dataMappingList);

                if (Request.QueryString["RequestType"].Equals("Inventory"))
                {
                    List<ICBrowser.Common.Component> inventry = new List<ICBrowser.Common.Component>();
                    if (!ddlStockStatus.SelectedItem.Text.Equals("SELECT"))
                    {
                        ComponentRepository cr = new ComponentRepository();
                        string strNewPath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + UserId + "\\" + Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                        PrepareInventorydata(strNewPath, UserId);
                    }
                    else
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Please select Stock Status.";
                    }
                }
                else if (Request.QueryString["RequestType"].Equals("Offers"))
                {
                    if (!ddlStockStatus.SelectedItem.Text.Equals("SELECT"))
                    {
                        //ICBrowser.Common.Component requestData = new ICBrowser.Common.Component();
                        Guid LoginUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                        string strNewPath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoginUserId + "\\" + Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                        PreparedUploadedOffersData(strNewPath, LoginUserId);
                    }
                    else
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Please select Stock Status.";
                    }
                }
                else
                {
                    BuyersRepository request = new BuyersRepository();
                    //UserId = (Guid)currUserId;
                    if (!ddlPorfq.SelectedItem.Text.Equals("SELECT"))
                    {
                        string strNewPath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + UserId + "\\" + Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                        PrepareData(strNewPath, UserId);
                    }
                    else
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Please select PO or RFQ.";
                    }

                }
                Session["SelectedSheet"] = null;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Step-2 complition error");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Session["CheckBoxState"] = null;
                Session["SelectedSheet"] = null;
                dvWorkSheetData.DataSource = null;
                dvWorkSheetData.DataBind();
                btnClear.Enabled = false;
                btnUpload.Enabled = true;
                //chkIsTemplate.Enabled = true;
                //chkIsTemplate.Checked = false;
                btnWorkSheetMapping.Enabled = false;
                //ddlStockstatus.ClearSelection(); //seller
                lblStatus.Text = "No File Uploaded";
                lblStatus.CssClass = "RedMessage";
                lblSelectedFileName.Text = "";
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "FileUpload"
        /// <summary>
        /// Handles the Click event of the btnUpload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 4200000)
                {
                    string strFileName = FileUpload1.FileName;
                    var extension = Path.GetExtension(strFileName);
                    if (extension != null)
                    {
                        string strFileType = extension.ToLower();
                        if (strFileType == ".xls" || strFileType == ".xlsx")
                        {
                            _finalData = new DataTable();
                            DataTable dt = new DataTable("SheetCollection");
                            dt.Columns.Add("WorksheetList");
                            dt.Columns.Add("ViewWorksheetList");
                            dt.Columns.Add("SheetType");
                            _finalData = dt;
                            DataTable sheetData = ReadFile(_finalData);
                            string FileName = "";
                            if (sheetData != null)
                            {
                                //if (sheetData.Rows.Count == 0)
                                //{
                                //    FileName = "Sheet1";//"new_inventory.xls~Sheet1$"
                                //    Session["SelectedSheet"] = strFileName +"~"+ FileName + "$";
                                //}
                                //else
                                //{
                                FileName = sheetData.Rows[0].ItemArray[1].ToString();
                                Session["SelectedSheet"] = _finalData.Rows[0]["WorksheetList"].ToString();
                                //}

                                UploadDocument(FileName);
                                btnWorkSheetMapping.Enabled = true;
                                btnUpload.Enabled = false;
                                btnClear.Enabled = true;
                                //chkIsTemplate.Enabled = false;
                                lblSelectedFileName.Text = "";
                                lblSelectedFileName.Text = strFileName + ".";
                                lblStatus.Text = "File Uploaded Successfully.";
                                lblStatus.CssClass = "GreenMessage";
                            }
                            else
                            {
                                BindDefaultGrid();
                                btnUpload.Enabled = false;
                                btnClear.Enabled = true;
                                btnWorkSheetMapping.Enabled = false;
                                lblStatus.Text = "Please select different excel file.";
                                lblStatus.CssClass = "RedMessage";
                            }
                        }
                        else
                        {
                            BindDefaultGrid();
                            btnUpload.Enabled = false;
                            btnClear.Enabled = true;
                            btnWorkSheetMapping.Enabled = false;
                            lblStatus.Text = "Please upload excel file with extensions '.xls' or '.xlsx' only.";
                            lblStatus.CssClass = "RedMessage";
                        }
                    }
                }
                else
                {
                    lblStatus.Text = "Exceeds the 4 MB size limit, Please upload another file";
                    lblStatus.CssClass = "RedMessage";
                }
            }
            else
            {
                BindDefaultGrid();
                btnUpload.Enabled = false;
                btnClear.Enabled = true;
                btnWorkSheetMapping.Enabled = false;
                lblStatus.Text = "Please Upload File.";
                lblStatus.CssClass = "RedMessage";
            }
        }

        /// <summary>
        /// Loads the selected document.
        /// </summary>
        /// <param name="documentName">Name of the document.</param>
        /// <exception cref="System.IO.IOException">File does not exist</exception>
        private void LoadSelectedDocument(string documentName)
        {
            try
            {
                string uploadedFileName = FetchSavedFileName();
                FileInfo rawFile = new FileInfo(uploadedFileName);
                if (rawFile.Exists)
                {
                    dvWorkSheetData.DataSource = (new ExcelService(uploadedFileName)).GetSheetData(documentName);
                    dvWorkSheetData.DataBind();
                }
                else
                {
                    lblStatus.Text = "File does not exist";
                    lblStatus.CssClass = "RedMessage";
                    throw new IOException("File does not exist");
                }
            }
            catch (Exception ex)
            {
                //LogData(ex.Message, false);

                lblStatus.Text = "Datasheet Loading Error";
                lblStatus.CssClass = "RedMessage";
                IClogger.LogError(ex, "Datasheet Loading Error");
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>DataTable.</returns>
        private DataTable ReadFile(DataTable dt)
        {
            string LoggedInID = "";
            try
            {
                if (Request.QueryString["RequestType"].Equals("Inventory"))
                {
                    LoggedInID = Membership.GetUser().ProviderUserKey.ToString();
                }
                else if (Request.QueryString["RequestType"].Equals("Offers"))
                {
                    LoggedInID = Membership.GetUser().ProviderUserKey.ToString();
                }
                else
                {
                    Guid currUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                    BuyersRepository request = new BuyersRepository();
                    LoggedInID = currUserId.ToString();
                }

                string strFileName = FileUpload1.FileName;
                var extension = Path.GetExtension(strFileName);
                if (extension != null)
                {
                    string strFileType = extension.ToLower();
                    //Check file type
                    if (strFileType == ".xls" || strFileType == ".xlsx")
                    {
                        if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoggedInID))
                        {
                            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoggedInID);
                        }
                        string savepath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoggedInID + "\\" + strFileName;
                        FileUpload1.SaveAs(savepath);
                    }
                    else
                    {
                        //LogData("Only excel files allowed", false);
                        return null;
                    }
                }

                string strNewPath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoggedInID + "\\" + strFileName;

                ExcelService service = new ExcelService(strNewPath);
                foreach (string firstSheetName in service.Sheets.Where(aa => !(aa.LastIndexOf('#') > -1 && (aa.Substring(aa.LastIndexOf('#')).Contains("#Print_Area") || aa.Substring(aa.LastIndexOf('#')).Contains("#Print_Titles") || aa.Substring(aa.LastIndexOf('#')).Contains("#_FilterDatabase")))))
                {
                    DataRow dr = dt.NewRow();
                    dr["WorksheetList"] = strFileName + "~" + firstSheetName;
                    string fileName = firstSheetName;
                    if (firstSheetName.LastIndexOf('$') > -1)
                        fileName = firstSheetName.Remove(firstSheetName.LastIndexOf('$'));
                    if (fileName.IndexOf("'") == 0 && fileName.Length > 1)
                        fileName = fileName.Substring(1);
                    dr["ViewWorksheetList"] = fileName;
                    dr["SheetType"] = string.Empty;
                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return dt;
        }

        /// <summary>
        /// Fetches the name of the saved file.
        /// </summary>
        /// <returns>System.String.</returns>
        private string FetchSavedFileName()
        {
            string fileName = "";
            Guid LoggedInID = new Guid(Membership.GetUser().ProviderUserKey.ToString());
            if (Session["SelectedSheet"] != null)
            {
                fileName = Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
            }
            return Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + LoggedInID + "\\" + fileName;
        }

        /// <summary>
        /// Uploads the document.
        /// </summary>
        /// <param name="selectedsheet">The selectedsheet.</param>
        /// <exception cref="System.IO.IOException">File does not exist</exception>
        private void UploadDocument(string selectedsheet)
        {
            //int buyerid = 0;
            string loggedinID = "";
            try
            {
                Guid currUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                if (Request.QueryString["RequestType"].Equals("Inventory")) // seller
                {
                    dtgetSellid = invengrddetails.getinventorylist(); //(gets SellerId ,compoanyName,TypeOfMembership)
                    UserId = (Guid)(dtgetSellid.Rows[0]["UserId"]);
                    loggedinID = UserId.ToString();
                }
                else if (Request.QueryString["RequestType"].Equals("Offers"))
                {
                    BuyersRepository request = new BuyersRepository();
                    loggedinID = currUserId.ToString();
                }
                else // buyer
                {
                    BuyersRepository request = new BuyersRepository();
                    loggedinID = currUserId.ToString();
                }

                string strNewPath = Server.MapPath(ConfigurationManager.AppSettings["RequirementsSheetPath"]) + loggedinID + "\\" + Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                FileInfo rawFile = new FileInfo(strNewPath);
                if (rawFile.Exists)
                {
                    dvWorkSheetData.DataSource = (new ExcelService(strNewPath)).GetSheetData(selectedsheet + "$");
                    dvWorkSheetData.DataBind();
                }
                else
                {
                    dvWorkSheetData.DataSource = null;
                    dvWorkSheetData.DataBind();
                    throw new IOException("File does not exist");
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Grid"
        /// <summary>
        /// Binds the default grid.
        /// </summary>
        private void BindDefaultGrid()
        {
            try
            {
                dvWorkSheetData.DataSource = null;
                dvWorkSheetData.DataBind();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Populates the dropdown list.
        /// </summary>
        /// <param name="ddlSelect">The DDL select.</param>
        private void PopulateDropdownList(DropDownList ddlSelect)
        {
            try
            {
                if (Request.QueryString["RequestType"].Equals("Inventory") || Request.QueryString["RequestType"].Equals("Offers"))
                {
                    //bind dropdown for Seller
                    ddlSelect.Items.Clear();
                    ddlSelect.Items.Add(new ListItem { Text = "Select", Value = "-1" });
                    ddlSelect.Items.Add(new ListItem { Text = "Part #", Value = "0" });
                    ddlSelect.Items.Add(new ListItem { Text = "qty.", Value = "1" });
                    ddlSelect.Items.Add(new ListItem { Text = "Make", Value = "2" });
                    ddlSelect.Items.Add(new ListItem { Text = "d/c", Value = "3" });
                    //ddlSelect.Items.Add(new ListItem { Text = "Stock In Hand", Value = "4" });
                    ddlSelect.Items.Add(new ListItem { Text = "Package", Value = "4" });
                    ddlSelect.Items.Add(new ListItem { Text = "comment", Value = "5" });
                    //ddlSelect.Items.Add(new ListItem { Text = "Country", Value = "7" });
                    ddlSelect.Items.Add(new ListItem { Text = "Unit price in IRs", Value = "6" });
                    // ApplyStyleToDropdownList(ddlSelect);
                }
                else
                {
                    //else bind dropdown for Buyer
                    ddlSelect.Items.Clear();
                    ddlSelect.Items.Add(new ListItem { Text = "Select", Value = "-1" });
                    ddlSelect.Items.Add(new ListItem { Text = "Part #", Value = "0" });
                    ddlSelect.Items.Add(new ListItem { Text = "qty.", Value = "1" });
                    ddlSelect.Items.Add(new ListItem { Text = "Make", Value = "2" });
                    ddlSelect.Items.Add(new ListItem { Text = "d/c", Value = "3" });
                    ddlSelect.Items.Add(new ListItem { Text = "Package", Value = "4" });
                    ddlSelect.Items.Add(new ListItem { Text = "comment", Value = "5" });
                    //ddlSelect.Items.Add(new ListItem { Text = "PO/RFQ", Value = "6" });
                    ddlSelect.Items.Add(new ListItem { Text = "Unit price in IRs", Value = "6" });

                    //ApplyStyleToDropdownList(ddlSelect);
                }
                ApplyStyleToDropdownList(ddlSelect);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        /// <summary>
        /// Applies the style to dropdown list.
        /// </summary>
        /// <param name="ddlSelect">The DDL select.</param>
        private void ApplyStyleToDropdownList(DropDownList ddlSelect)
        {
            ddlSelect.CssClass = "smallinput_t139";
        }

        /// <summary>
        /// Prepares the inventorydata.
        /// </summary>
        /// <param name="strNewPath">The string new path.</param>
        /// <param name="UserId">The user identifier.</param>
        private void PrepareInventorydata(string strNewPath, Guid UserId)
        {
            List<string> columns = new List<string>();
            List<WorkSheetColumnMapping> mapping = new List<WorkSheetColumnMapping>();
            int permittedcount = 0;
            int savedComponentCount = 0;
            int leftspace = 0;
            List<Component> final = new List<Component>();
            try
            {
                if (Session["SelectedSheet"] != null)
                {
                    string uploadedFileName = Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                    string uploadedsheet = Convert.ToString(Session["SelectedSheet"]).Split('~')[1];
                    DataTable dt = (new ExcelService(strNewPath).GetSheetData(uploadedsheet));

                    ObjUserProfile = (Common.UserProfile)Session["UserProfile"];
                    membershiptype = ObjUserProfile.TypeOfMembership;

                    permittedcount = invengrddetails.getComponentListingCount(membershiptype);  //gets the permitted count
                    savedComponentCount = invengrddetails.getComponentCount(UserId);  //gets the total saved component count
                    leftspace = permittedcount - savedComponentCount; //gets the left space to save componenets 

                    for (int i = 0; i < dvWorkSheetData.HeaderRow.Cells.Count; i++)
                    {
                        Control dataControl = dvWorkSheetData.HeaderRow.Cells[i].FindControl("ddlSelect" + i);

                        if (dataControl != null)
                        {
                            string columnName = ((ListControl)dataControl).SelectedItem.Text;
                            if (Session["CheckBoxState"] != null)
                            {
                                if (!columns.Contains(columnName))
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                            else
                            {
                                if (!columns.Contains(columnName) && ((ListControl)dataControl).SelectedIndex != 0)
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                        }
                    }


                    if (!ValidateMappingColumns(mapping)) // No Duplicate Mapped Columns (Mapping is Correct)
                    {
                        int count = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            Common.Component requestData = new Common.Component();
                            foreach (WorkSheetColumnMapping columnmapped in mapping)
                            {
                                if (columnmapped.ColumnName.Equals("Part #"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                    {
                                        requestData.ComponentName = dr[columnmapped.ColumnNo].ToString();
                                        count += 1;
                                    }
                                    else
                                    {
                                        requestData.ComponentName = null;
                                    }
                                }
                                else if (columnmapped.ColumnName.Equals("qty."))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                    {
                                        requestData.Quantity = Convert.ToInt32(dr[columnmapped.ColumnNo].ToString());
                                        count += 1;
                                    }
                                    else
                                    {
                                        requestData.ComponentName = null;
                                    }
                                }
                                else if (columnmapped.ColumnName.Equals("Make"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.BrandName = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.BrandName = null;
                                }
                                else if (columnmapped.ColumnName.Equals("comment"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.Description = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.Description = null;
                                }

                                else if (columnmapped.ColumnName.Equals("Unit Price in USD"))
                                {
                                    if (dr[columnmapped.ColumnNo].ToString() == "")
                                    {
                                        // requestData.PriceInUSD = null;
                                    }
                                    else
                                    {
                                        requestData.PriceInUSD = Convert.ToDecimal(dr[columnmapped.ColumnNo]);
                                    }

                                }

                                else if (columnmapped.ColumnName.Equals("d/c"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.datecode = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.datecode = null;
                                }

                                else if (columnmapped.ColumnName.Equals("Package"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.package = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.package = null;
                                }
                                //requestData.Status = null; //status ='Open' by default 
                                requestData.stockstatus = Convert.ToInt32(ddlStockStatus.SelectedItem.Value);
                                requestData.UserId = UserId;
                                requestData.country = null;
                                requestData.PriceInINR = null;
                                requestData.PriceInCNY = null;
                                requestData.StockInHand = null;
                            }
                            if (requestData != null && (requestData.ComponentName != null || requestData.ComponentName != "") && requestData.Quantity > 0)
                            {
                                final.Add(requestData);
                                final.TrimExcess();
                            }
                        }

                        //This Method check whether file contains any scripting language
                        if (!CheckForScriptTextInListOfData(final))
                        {
                            List<Component> listComponent = new List<Component>();
                            if (leftspace != 0 || rdbOverwrite.Checked)
                            {
                                //call insert code here
                                if (final.Count <= leftspace || rdbOverwrite.Checked)
                                {
                                    try
                                    {

                                        if (rdbExist.Checked)
                                        {
                                            savedComponentCount = invengrddetails.AddBulkInventories(final, leftspace);
                                        }
                                        else
                                        {

                                            int DeleteCount = invengrddetails.DeleteInventories(final);
                                            savedComponentCount = invengrddetails.getComponentCount(UserId);
                                            leftspace = permittedcount - savedComponentCount;
                                            savedComponentCount = invengrddetails.AddBulkInventories(final, leftspace);
                                        }
                                        if (savedComponentCount > 0)
                                        {
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('" + savedComponentCount + "  record(s) has been saved successfully. ');document.location.href='/SellerUploadedInventory.aspx?UserId=" + final[0].UserId + "';", true);
                                        }
                                        else
                                        {
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Record Saved.');document.location.href='/SellerUploadedInventory.aspx?UserId=" + final[0].UserId + "';", true);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        savedComponentCount = invengrddetails.AddBulkInventories(listComponent, leftspace);
                                        IClogger.LogError(ex.Message);
                                    }
                                    finally
                                    {
                                        listComponent.Clear();
                                    }
                                }
                                else if (final.Count > leftspace)
                                {
                                    int deleteExcessComponent = final.Count - leftspace;
                                    // final.RemoveRange(0, deleteExcessComponent);
                                    //final.RemoveRange(leftspace, deleteExcessComponent);
                                    savedComponentCount = invengrddetails.AddBulkInventories(final, leftspace);
                                    if (savedComponentCount > 0)
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('" + savedComponentCount + "  record(s) has been saved successfully. ');document.location.href='/SellerUploadedInventory.aspx?UserId=" + final[0].UserId + "';", true);
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Status", "alert('No Record Saved.');document.location.href='/SellerUploadedInventory.aspx?UserId=" + final[0].UserId + "';", true);
                                    }


                                    // lblStatus.CssClass = "RedMessage";
                                    // string msg = " You have exceeded the Inventory upload Limit . Only ";
                                    //lblStatus.Text = " You have exceeded the Inventory upload Limit . Only " + final.Count + " Inventories uploaded successfully.";
                                }
                            }
                            else
                            {
                                lblStatus.CssClass = "RedMessage";
                                lblStatus.Text = " No records uploaded. As you have exceeded the Inventory upload Limit. ";
                            }
                        }
                        else
                        {
                            lblStatus.CssClass = "RedMessage";
                            lblStatus.Text = "No Records Updated. As Excel File Contains Scripting Language '<' or '>' .";
                            btnWorkSheetMapping.Enabled = false;
                            btnUpload.Enabled = true;
                            btnClear.Enabled = true;
                        }
                    }
                    else // Duplicate Mapped Columns
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Incorrect Mapping of columns.";
                        btnWorkSheetMapping.Enabled = true;
                        btnUpload.Enabled = true;
                        btnClear.Enabled = true;
                    }
                }
                else
                {
                    lblStatus.CssClass = "RedMessage";
                    lblStatus.Text = "Please Upload File.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.CssClass = "RedMessage";
                lblStatus.Text = "No Records Updated.<br/> 1. Part Number And Quantity Mapping is mandatory.<br/> 2. Incorrect mapping of columns.";
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Checks for script text in list of data.
        /// </summary>
        /// <param name="final">The final.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckForScriptTextInListOfData(List<Component> final)
        {
            try
            {
                if (final.Any(s => s.ComponentName.Contains('<')) || final.Any(s => s.ComponentName.Contains('>')) ||
                                final.Any(s => s.BrandName != null && s.BrandName.Contains('<')) || final.Any(s => s.BrandName != null && s.BrandName.Contains('>')) ||
                                final.Any(s => s.datecode != null && s.datecode.Contains('<')) || final.Any(s => s.datecode != null && s.datecode.ToString().Contains('>')) ||
                                final.Any(s => s.package != null && s.package.Contains('<')) || final.Any(s => s.package != null && s.package.Contains('>')) ||
                                final.Any(s => s.Description != null && s.Description.Contains('<')) || final.Any(s => s.Description != null && s.Description.Contains('>')) ||
                                final.Any(s => s.PriceInUSD != null && s.PriceInUSD.ToString().Equals('<')) || final.Any(s => s.PriceInUSD != null && s.PriceInUSD.ToString().Equals('>')) ||
                                final.Any(s => s.Quantity != null && s.Quantity.ToString().Equals('<')) || final.Any(s => s.Quantity != null && s.Quantity.ToString().Equals('>')))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// Prepares the data.
        /// </summary>
        /// <param name="strNewPath">The string new path.</param>
        /// <param name="UserId">The user identifier.</param>
        private void PrepareData(string strNewPath, Guid UserId)
        {
            MembershipUser currUser = Membership.GetUser();
            List<string> columns = new List<string>();
            List<WorkSheetColumnMapping> mapping = new List<WorkSheetColumnMapping>();
            UserRequirements objUserRequirement = new UserRequirements();
            List<ICBrowser.Common.BuyersRequirements> finalData = new List<Common.BuyersRequirements>();
            bool status = false;
            int Rowsaffected = 0;
            try
            {
                if (Session["SelectedSheet"] != null)
                {
                    string uploadedFileName = Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                    string uploadedsheet = Convert.ToString(Session["SelectedSheet"]).Split('~')[1];
                    DataTable dt = (new ExcelService(strNewPath).GetSheetData(uploadedsheet));

                    // Mapping of Template
                    for (int i = 0; i < dvWorkSheetData.HeaderRow.Cells.Count; i++)
                    {
                        Control dataControl = dvWorkSheetData.HeaderRow.Cells[i].FindControl("ddlSelect" + i);

                        if (dataControl != null)
                        {
                            string columnName = ((ListControl)dataControl).SelectedItem.Text;
                            if (Session["CheckBoxState"] != null)
                            {
                                if (!columns.Contains(columnName))
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                            else
                            {
                                if (!columns.Contains(columnName) && ((ListControl)dataControl).SelectedIndex != 0)
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                        }
                    }
                    //int no_of_records_save = 0;
                    //Now Check for Duplicate Mapping of columns for the uploaded excel file
                    if (!ValidateMappingColumns(mapping)) // No Duplicate Mapped Columns (Mapping is Correct)
                    {
                        // Save Data into an object
                        string scriptTextCheck = string.Empty;
                        foreach (DataRow dr in dt.Rows)
                        {
                            ICBrowser.Common.BuyersRequirements requestData = new ICBrowser.Common.BuyersRequirements();
                            foreach (WorkSheetColumnMapping columnmapped in mapping)
                            {
                                if (columnmapped.ColumnName.Equals("Part #"))
                                {
                                    requestData.ComponentName = dr[columnmapped.ColumnNo].ToString();
                                }
                                else if (columnmapped.ColumnName.Equals("qty."))
                                {
                                    requestData.Quantity = Convert.ToInt32(dr[columnmapped.ColumnNo].ToString());
                                }
                                else if (columnmapped.ColumnName.Equals("Make"))
                                {
                                    requestData.BrandName = dr[columnmapped.ColumnNo].ToString();
                                }
                                else if (columnmapped.ColumnName.Equals("Package"))
                                {
                                    requestData.Package = dr[columnmapped.ColumnNo].ToString();
                                }
                                else if (columnmapped.ColumnName.Equals("d/c"))
                                {
                                    requestData.DateCode = dr[columnmapped.ColumnNo].ToString();
                                }
                                //else if (columnmapped.ColumnName.Equals("PO/RFQ")) // YES,yes,y 
                                //{
                                //    if ((dr[columnmapped.ColumnNo].ToString() == "PO") || (dr[columnmapped.ColumnNo].ToString() == "po") || (dr[columnmapped.ColumnNo].ToString() == "Po"))
                                //    {
                                //        requestData.RequirementwithPO = true;
                                //    }
                                //    else // all other thing will b false
                                //    {
                                //        requestData.RequirementwithPO = false;
                                //    }
                                //}
                                else if (columnmapped.ColumnName.Equals("Unit Price In USD"))
                                {
                                    if (dr[columnmapped.ColumnNo].ToString() != "")
                                    {
                                        requestData.PriceInUSD = Convert.ToDecimal(dr[columnmapped.ColumnNo]);
                                    }
                                    else
                                    {
                                        requestData.PriceInUSD = 0;
                                    }
                                }
                                else if (columnmapped.ColumnName.Equals("comment"))
                                {
                                    requestData.Description = dr[columnmapped.ColumnNo].ToString();
                                }
                            }
                            if (ddlPorfq.SelectedItem.Text.Equals("PO"))
                            {
                                requestData.RequirementwithPO = true;
                            }
                            else // all other thing will b false
                            {
                                requestData.RequirementwithPO = false;
                            }
                            requestData.userId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                            requestData.Country = null;
                            if (requestData != null && (requestData.ComponentName != null || requestData.ComponentName != "") && requestData.Quantity > 0)
                            {
                                finalData.Add(requestData);
                            }
                            else
                            {
                                lblStatus.CssClass = "RedMessage";
                                lblStatus.Text = "No Records Updated. Please correct your mapping.";
                                btnWorkSheetMapping.Enabled = true;
                                btnUpload.Enabled = true;
                                btnClear.Enabled = true;
                            }
                        }

                        //This Method is to check wheather file containts any scripting tag
                        if (!CheckForScriptTextInListOfRequirementData(finalData))
                        {
                            List<Common.BuyersRequirements> listRequirement = new List<Common.BuyersRequirements>();
                            try
                            {


                                if (rdbExist.Checked)
                                {
                                    Rowsaffected = objUserRequirement.InsertUserRequirements(finalData);
                                }
                                else
                                {
                                    listRequirement = objUserRequirement.DeleteRequirements(finalData);
                                    Rowsaffected = objUserRequirement.InsertUserRequirements(finalData);
                                }
                            }
                            catch (Exception ex)
                            {
                                Rowsaffected = objUserRequirement.InsertUserRequirements(listRequirement);
                                IClogger.LogError(ex.Message);
                            }
                            finally
                            {
                                listRequirement.Clear();
                            }
                            if (Rowsaffected > 0)
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "MessagePopUp", "alert('" + Rowsaffected + " Record(s) saved successfully.');document.location.href='/BuyersRequirment.aspx';", true);
                                //Response.Redirect("BuyersRequirment.aspx", false);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "MessagePopUp", "alert('No Record Saved.');document.location.href='/BuyersRequirment.aspx';", true);

                                //  lblStatus.CssClass = "RedMessage";
                                // lblStatus.Text = "No Records Updated.";
                                btnWorkSheetMapping.Enabled = true;
                                btnUpload.Enabled = true;
                                btnClear.Enabled = true;
                            }
                        }
                        else
                        {
                            lblStatus.CssClass = "RedMessage";
                            lblStatus.Text = "No Records Updated. As Excel File Contains Scripting Language '<' or '>'.";
                            btnWorkSheetMapping.Enabled = false;
                            btnUpload.Enabled = true;
                            btnClear.Enabled = true;
                        }
                    }
                    else // Duplicate Mapped Columns
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Incorrect Mapping of columns.";
                        btnWorkSheetMapping.Enabled = true;
                        btnUpload.Enabled = true;
                        btnClear.Enabled = true;
                    }
                }
                else // Session is null than do not allow to enter data
                {
                    lblStatus.CssClass = "RedMessage";
                    lblStatus.Text = "Error has occurred in reading file. Please try again";
                    btnClear.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblStatus.CssClass = "RedMessage";
                lblStatus.Text = "No Records Updated.<br/> 1. Part Number And Quantity Mapping is mandatory.<br/> 2. Incorrect mapping of columns.";
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Checks for script text in list of requirement data.
        /// </summary>
        /// <param name="finalData">The final data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckForScriptTextInListOfRequirementData(List<Common.BuyersRequirements> finalData)
        {
            try
            {
                if (finalData.Any(s => s.ComponentName.Contains('<')) || finalData.Any(s => s.ComponentName.Contains('>')) ||
                                finalData.Any(s => s.BrandName.Contains('<')) || finalData.Any(s => s.BrandName.Contains('>')) ||
                                finalData.Any(s => s.DateCode.Contains('<')) || finalData.Any(s => s.DateCode.Contains('>')) ||
                                finalData.Any(s => s.Package.Contains('<')) || finalData.Any(s => s.Package.Contains('>')) ||
                                finalData.Any(s => s.Description.Contains('<')) || finalData.Any(s => s.Description.Contains('>')) ||
                                finalData.Any(s => s.RequirementwithPO.Equals('<')) || finalData.Any(s => s.RequirementwithPO.Equals('>')) ||
                                finalData.Any(s => s.PriceInUSD.ToString().Equals('<')) || finalData.Any(s => s.PriceInUSD.ToString().Equals('>')) ||
                                finalData.Any(s => s.Quantity.ToString().Equals('<')) || finalData.Any(s => s.Quantity.ToString().Equals('>')))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// Prepareds the uploaded offers data.
        /// </summary>
        /// <param name="strNewPath">The string new path.</param>
        /// <param name="UserId">The user identifier.</param>
        private void PreparedUploadedOffersData(string strNewPath, Guid UserId)
        {
            List<string> columns = new List<string>();
            List<WorkSheetColumnMapping> mapping = new List<WorkSheetColumnMapping>();
            ComponentRepository cr = new ComponentRepository();
            UserOffersData objUserOfferData = new UserOffersData();
            //int limit = 0;
            int noOfRowsSaveAffected = 0;
            try
            {
                if (Session["SelectedSheet"] != null)
                {
                    string uploadedFileName = Convert.ToString(Session["SelectedSheet"]).Split('~')[0];
                    string uploadedsheet = Convert.ToString(Session["SelectedSheet"]).Split('~')[1];
                    DataTable dt = (new ExcelService(strNewPath).GetSheetData(uploadedsheet));

                    // Mapping of Template
                    for (int i = 0; i < dvWorkSheetData.HeaderRow.Cells.Count; i++)
                    {
                        Control dataControl = dvWorkSheetData.HeaderRow.Cells[i].FindControl("ddlSelect" + i);

                        if (dataControl != null)
                        {
                            string columnName = ((ListControl)dataControl).SelectedItem.Text;
                            if (Session["CheckBoxState"] != null)
                            {
                                if (!columns.Contains(columnName))
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                            else
                            {
                                if (!columns.Contains(columnName) && ((ListControl)dataControl).SelectedIndex != 0)
                                    mapping.Add(new WorkSheetColumnMapping { ColumnNo = i, ColumnName = columnName });
                            }
                        }
                    }

                    //int MembershipType = ((ICBrowser.Common.UserProfile)(Session["UserProfile"]))break.obje.TypeOfMembership;
                    //Now Check for Duplicate Mapping of columns for the uploaded excel file
                    int permitted_no_offer_upload = CheckAvalaibileUploadOffersAsPerMembershipType(((ICBrowser.Common.UserProfile)(Session["UserProfile"])).TypeOfMembership);
                    if (!ValidateMappingColumns(mapping)) // No Duplicate Mapped Columns (Mapping is Correct)
                    {
                        List<Component> final = new List<Component>();

                        // Save Data into an object
                        foreach (DataRow dr in dt.Rows)
                        {
                            ICBrowser.Common.Component requestData = new ICBrowser.Common.Component();
                            foreach (WorkSheetColumnMapping columnmapped in mapping)
                            {
                                if (columnmapped.ColumnName.Equals("Part #"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.ComponentName = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.ComponentName = null;
                                }
                                else if (columnmapped.ColumnName.Equals("qty."))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.Quantity = Convert.ToInt32(dr[columnmapped.ColumnNo].ToString());
                                    else
                                        requestData.ComponentName = null;
                                }
                                else if (columnmapped.ColumnName.Equals("Make"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.BrandName = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.BrandName = null;
                                }
                                else if (columnmapped.ColumnName.Equals("comment"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.Description = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.Description = null;
                                }
                                else if (columnmapped.ColumnName.Equals("Unit Price in USD")) // YES,yes,y 
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.PriceInUSD = Convert.ToDecimal(dr[columnmapped.ColumnNo]);
                                    else
                                        requestData.PriceInUSD = 0;
                                }
                                else if (columnmapped.ColumnName.Equals("d/c"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.datecode = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.datecode = null;
                                }
                                else if (columnmapped.ColumnName.Equals("Package"))
                                {
                                    if (!dr[columnmapped.ColumnNo].ToString().Equals(""))
                                        requestData.package = dr[columnmapped.ColumnNo].ToString();
                                    else
                                        requestData.package = null;
                                }
                            }
                            requestData.stockstatus = Convert.ToInt32(ddlStockStatus.SelectedValue);
                            requestData.UserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                            requestData.PriceInINR = null;
                            requestData.PriceInCNY = null;
                            requestData.country = null;
                            requestData.StockInHand = null;
                            if (requestData != null && (requestData.ComponentName != null || requestData.ComponentName != "") && requestData.Quantity > 0)
                            {
                                //noOfRowsSaveAffected = objUserOfferData.SaveOffersByUser(requestData);
                                final.Add(requestData);
                                final.TrimExcess();
                            }
                            //else
                            //{
                            //    lblStatus.CssClass = "RedMessage";
                            //    lblStatus.Text = "No Records Updated. Please correct your mapping.";
                            //    btnWorkSheetMapping.Enabled = true;
                            //    btnUpload.Enabled = true;
                            //    btnClear.Enabled = true;
                            //}
                        }

                        if (!CheckForScriptTextInListOfData(final))
                        {

                            int savedComponentCount = invengrddetails.getOfferCount(UserId);
                            int leftspace = permitted_no_offer_upload - savedComponentCount;
                            List<Component> listOffer = new List<Component>();
                            try
                            {


                                if (rdbExist.Checked)
                                {

                                    noOfRowsSaveAffected = objUserOfferData.SaveOffersByUser(final, leftspace);
                                }
                                else
                                {

                                    int DeleteCount = invengrddetails.DeleteOffers(final);
                                    savedComponentCount = invengrddetails.getOfferCount(UserId);
                                    leftspace = permitted_no_offer_upload - savedComponentCount;
                                    noOfRowsSaveAffected = objUserOfferData.SaveOffersByUser(final, leftspace);
                                }
                                // Once all data is saved successfully delete TOP elements as per modified date.
                                if (noOfRowsSaveAffected > permitted_no_offer_upload)
                                {
                                    DeleteUploadedOfferByModifiedDate(permitted_no_offer_upload, final[0].UserId);
                                }
                                if (noOfRowsSaveAffected > 0)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MessagePopUp", "alert('" + noOfRowsSaveAffected + " Record(s) saved successfully.');document.location.href='/UserOffers.aspx?UserId=" + final[0].UserId + "';", true);
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MessagePopUp", "alert('No Record saved.');document.location.href='/UserOffers.aspx?UserId=" + final[0].UserId + "';", true);

                                }
                                // Response.Redirect("UserOffers.aspx?UserId=" + final[0].UserId, false);
                            }
                            catch (Exception ex)
                            {
                                noOfRowsSaveAffected = objUserOfferData.SaveOffersByUser(listOffer, leftspace);
                                IClogger.LogError(ex.Message);
                            }
                            finally
                            {
                                listOffer.Clear();
                            }
                        }
                        else
                        {
                            lblStatus.CssClass = "RedMessage";
                            lblStatus.Text = "No Records Updated. As Excel File Contains Scripting Language '<' or '>' .";
                            btnWorkSheetMapping.Enabled = false;
                            btnUpload.Enabled = true;
                            btnClear.Enabled = true;
                        }
                    }
                    else
                    {
                        lblStatus.CssClass = "RedMessage";
                        lblStatus.Text = "Incorrect Mapping of columns.";
                        btnWorkSheetMapping.Enabled = true;
                        btnUpload.Enabled = true;
                        btnClear.Enabled = true;
                    }
                }
                else
                {
                    lblStatus.CssClass = "RedMessage";
                    lblStatus.Text = "Error has occurred in reading file. Please try again";
                    btnWorkSheetMapping.Enabled = true;
                    btnUpload.Enabled = true;
                    btnClear.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
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
        /// Validates the mapping columns.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ValidateMappingColumns(List<WorkSheetColumnMapping> mapping)
        {
            int getCountDuplicateMappingColumns = 0;
            if ((mapping.Count == 0 || mapping.Count == 1) && Session["CheckBoxState"] == null)
            {
                return true;
            }
            else
            {
                foreach (WorkSheetColumnMapping columnmapped in mapping)
                {
                    getCountDuplicateMappingColumns = (from mappedColumn in mapping
                                                       where mappedColumn.ColumnName == columnmapped.ColumnName
                                                       select mappedColumn).AsEnumerable().Count();
                    if (getCountDuplicateMappingColumns > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btnback control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect(responseString);
        }


        //protected void rdblistuploadparts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToBoolean(HiddenField2.Value == "true"))
        //    {
        //        rdblistuploadparts.SelectedValue = "rdbOverwrite";
        //    }
        //    else
        //    {
        //        rdblistuploadparts.SelectedValue = "rdbExist";
        //    }
        //}

    }
}