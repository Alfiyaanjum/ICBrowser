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
using ICBrowser.DAL;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;



namespace ICBrowser.Web
{
    public partial class Requirements : System.Web.UI.Page
    {

        #region "Private Parameters"
        private DataSet _finalData;
        #endregion

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


            }

        }


        private DataTable ReadFile(DataTable dt)
        {
            try
            {
                string strFileName = FileUpload1.FileName;
                //string strFilePath = Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"]);
                var extension = Path.GetExtension(strFileName);
                if (extension != null)
                {

                    string strFileType = extension.ToLower();
                    //Check file type

                    if (strFileType == ".xls" || strFileType == ".xlsx")
                    {

                        if (File.Exists(ConfigurationManager.AppSettings["DirectoryPath"] + strFileName))
                        {
                            //LogData("File of the same name already exists. Kinldy upload different file", false);
                            //return null;
                        }
                        FileUpload1.SaveAs(ConfigurationManager.AppSettings["DirectoryPath"] + strFileName);

                    }

                    else
                    {

                        //LogData("Only excel files allowed", false);
                        return null;
                    }
                }

                string strNewPath = ConfigurationManager.AppSettings["DirectoryPath"] + strFileName;


                ExcelService service = new ExcelService(strNewPath);
                //foreach (string firstSheetName in service.Sheets.Where(aa => !(aa.LastIndexOf('#') > -1 && (aa.Substring(aa.LastIndexOf('#')).Contains("#Print_Area") || aa.Substring(aa.LastIndexOf('#')).Contains("#Print_Titles") || aa.Substring(aa.LastIndexOf('#')).Contains("#_FilterDatabase")))))
                foreach (string firstSheetName in service.Sheets.Where(aa => !(aa.Contains("Print_Area") || aa.Contains("_FilterDatabase") || aa.Contains("Print_Titles"))))
                {

                    DataTable dtExcel = new DataTable();
                    dtExcel = service.GetSheetData(firstSheetName);
                    BuyersDataRequirement buyersreq = new BuyersDataRequirement();
                    dt = buyersreq.buyersRequirement(dtExcel);


                    //RequirementsRepository request = new RequirementsRepository();

                    //BuyersRequirmentsRepository request = new BuyersRequirmentsRepository();
                    //dt= request.InsertBuyersRequirments(dtExcel);

                        lblmsg2.Text = "Records Inserted Successfully";
                    }


                   
                }

            
            catch (Exception ex)
            {
                //XbrlLogger.LogError(ex, "File handling error");
                throw;
            }
            return dt;
        }

        private void LogData(string data, Boolean isValidData)
        {
            //lblMessage.Text = data;
            //XbrlLogger.LogMessage(data);
            //divMsg.Attributes.Add("class", (isValidData) ? "greenmsg" : "redmsg");
            //imgValidate.Attributes.Add("src", (isValidData) ? "images/right_icon.gif" : "images/del.png");
            //if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(data.Trim()))
            //{
            //    divMsg.Visible = true;
            //    lblMessage.Visible = true;
            //}
            //else
            //divMsg.Visible = false;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                // Get current User ID                
                           


                int quantity = Convert.ToInt32(txtQuantity.Text);
                string componentname = txtComponent.Text;
                string description = txtDescription.Text;
                string brandname = txtBrandName.Text;
                string companyname = txtCompanyName.Text;
                DateTime requiredbefore = Convert.ToDateTime(txtRequiredBefore.Text);

                BuyersDataRequirement bdr = new BuyersDataRequirement();
                bdr.buyersReqInfo(quantity, componentname, description, brandname, companyname, requiredbefore);

                //DataTable dtreq = new DataTable();
                //BuyersDataRequirement buyersdata = new BuyersDataRequirement();

                clearRequirments();
                lblmsg2.Text = "Records Inserted Successfully";
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        private void clearRequirments()
        {
            //txtStatus.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";

            txtBrandName.Text = "";
            txtRequiredBefore.Text = "";
            txtComponent.Text = "";
            txtCompanyName.Text = "";
        }

        protected void btnUpload_Click2(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload1.HasFile)
                {
                    if (ViewState["FinalData"] != null)
                    {
                        _finalData = (DataSet)ViewState["FinalData"];
                    }
                    else
                    {
                        _finalData = new DataSet();
                        DataTable dt = new DataTable("SheetCollection");
                        dt.Columns.Add("WorksheetList");
                        dt.Columns.Add("ViewWorksheetList");
                        dt.Columns.Add("SheetType");
                        _finalData.Tables.Add(dt);
                    }


                    DataTable sheetData = ReadFile(_finalData.Tables[0]);

                    if (sheetData != null)
                    {

                        LogData("Data retrieved successfully! Total Records:" + sheetData.Rows.Count, true);
                        lblmsg1.Text = "Data Inserted successfully";
                    }
                    else
                    {
                        LogData("Please select different excel file", false);
                    }
                }
                else
                {

                    LogData("Please select an excel file first", false);

                }


            }

            catch (Exception ex)
            {

            }


        }

        protected void txtComponent_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearRequirments();
        }
        #endregion
    }
}
