using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ICBrowser.Business;
using System.Reflection;
using System.IO;
using Microsoft.CSharp;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using ICBrowser.Web;
using ICBrowser.Common;


namespace ICBrowser.Web.Controls
{
    public partial class InventoryGrid : System.Web.UI.UserControl
    {
        InventoryGridDetails igd = new InventoryGridDetails();//Call for Business class
        DataTable dtInventoryDetails = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadInventorygrid();

            }

        }

        protected void loadInventorygrid()
        {
            //dtInventoryDetails = igd.getinventorylist();
            dtInventoryDetails = igd.GetAllComponentDetails();
            grdInventoryDetails.DataSource = dtInventoryDetails;
            grdInventoryDetails.DataBind();
        }

        protected void grdInventoryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Datasheeturl = (string)DataBinder.Eval(e.Row.DataItem, "DataSheetURL");

                if (Datasheeturl == "")
                {
                    //LinkButton lnkurl = (LinkButton)e.Row.FindControl("LnkURL");
                    //lnkurl.Visible = false;

                    Button btupload = (Button)e.Row.FindControl("btnUpload");
                    btupload.Visible = true;
                }

                else
                {
                    //LinkButton lnkurl = (LinkButton)e.Row.FindControl("LnkURL");
                    //lnkurl.Visible = true;

                    Button btupload = (Button)e.Row.FindControl("btnUpload");
                    btupload.Visible = false;
                }
            }
        }

        protected void grdInventoryDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upload")
            {
                //mdpextPhoto.Show();
                ViewState["ComponentId"] = Convert.ToInt16(e.CommandArgument);
                //mpeUploadgrid.Show();

            }

        }

        protected void grdInventoryDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label LblCompId = (Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId");

            igd.deleteSelectedComponent(Convert.ToInt32(LblCompId.Text));

            loadInventorygrid();

        }

        protected void grdInventoryDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdInventoryDetails.EditIndex = e.NewEditIndex;
            loadInventorygrid();

            LinkButton lnkEditview = (LinkButton)grdInventoryDetails.Rows[e.NewEditIndex].FindControl("LnkEdit");
            lnkEditview.Visible = false;

            Button btnUpld = (Button)grdInventoryDetails.Rows[e.NewEditIndex].FindControl("btnUpload");
            btnUpld.Visible = true;
        }

        protected void grdInventoryDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // GridViewRow row = grdInventoryDetails.Rows[e.RowIndex];
            string lblComponentId = ((Label)grdInventoryDetails.Rows[e.RowIndex].FindControl("LblComponentId")).Text;
            string txtComponentName = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtComponentName")).Text;
            string txtQuantity = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtQuantity")).Text;
            string txtBrandName = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtBrandName")).Text;
            //string txtDataSheetlnk = ((TextBox)grdInventoryDetails.Rows[e.RowIndex].FindControl("txtDataSheetlnk")).Text;

            igd.updateComponentRows(Convert.ToInt32(lblComponentId), txtComponentName, Convert.ToInt32(txtQuantity), txtBrandName);
            grdInventoryDetails.EditIndex = -1; //reset the edit index
            loadInventorygrid();

            LinkButton lnkUpdateview = (LinkButton)grdInventoryDetails.Rows[e.RowIndex].FindControl("LnkUpdate");
            lnkUpdateview.Visible = false;

            LinkButton lnkEditview = (LinkButton)grdInventoryDetails.Rows[e.RowIndex].FindControl("LnkEdit");
            lnkEditview.Visible = true;


        }

        protected void grdInventoryDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            loadInventorygrid();
        }

        protected void grdInventoryDetails_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
        }

        protected void grdInventoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInventoryDetails.PageIndex = e.NewPageIndex;
            loadInventorygrid();
        }

        protected void btnSavefUpload_Click(object sender, EventArgs e)
        {
            //    try
            //{
            //    string filename = fuExcelSheet.FileName;
            //    var extension = Path.GetExtension(filename);
            //    if (extension != null)
            //    {
            //        string filetype = extension.ToLower();

            //        if (filetype == ".xls")
            //        {
            //            if (dtgetSellid.Rows.Count > 0)
            //            {
            //                sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
            //                if (File.Exists(ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename))
            //                {
            //                    LogData("File of the same name already exists. Kindly upload different file", false);
            //                    LblUploadMessage.CssClass = "red";
            //                    LblUploadMessage.Text = "File of the same name already exists. Kindly upload different file";
            //                }
            //                else
            //                {

            //                    fuExcelSheet.SaveAs(ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename);
            //                    string SavedfilePath = ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename;
            //                    igd.GetInventoryData(SavedfilePath);
            //                }

            //            }

            //            //else
            //            //{

            //            //    fuExcelSheet.SaveAs(ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename);
            //            //    string SavedfilePath = ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename;
            //            //    igd.GetInventoryData(SavedfilePath);

            //            //}


            //        }

            //        else
            //        {
            //            LogData("Only excel files allowed", false);
            //            LblUploadMessage.CssClass = "red";
            //            LblUploadMessage.Text = "Only excel files allowed";

            //        }
            //    }
            //}

            //catch (Exception ex)
            //{
            //    LogData(ex.Message == "Could not decrypt file." ? "File must not be password protected " : "Error occured while file upload.", false);
            //    LblUploadMessage.CssClass = "red";
            //    LblUploadMessage.Text = "Error occured while file upload.";
            //    IClogger.LogError(ex, "File upload error");
            //}

            //DataTable dtgetSellid = new DataTable();
            //dtgetSellid = igd.getinventorylist();
            //int sellid = Convert.ToInt32(dtgetSellid.Rows[0]["SellerId"]);
            //if (fuploadgrid.HasFile)
            //{
            //    string filename = fuploadgrid.FileName;
            //    var extension = Path.GetExtension(filename);
            //    string filetype = extension.ToLower();

            //    if (filetype == ".pdf" || filetype == ".doc")
            //    {
            //        if (File.Exists(ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename))
            //        {

            //            IClogger.LogError("File of the same name already exists. Kindly upload different file");
            //            //LblUploadMessage.CssClass = "red";
            //            //LblUploadMessage.Text = "File of the same name already exists. Kindly upload different file";
            //        }

            //        else
            //        {
            //            fuploadgrid.SaveAs(ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename);
            //            string SavedfilePath = ConfigurationManager.AppSettings["DirectoryPath"] + sellid + filename;

            //            igd.InsertUploadedfile(Convert.ToInt32(ViewState["ComponentId"]), SavedfilePath);//saves the file uploaded


            //        }

            //    }
            //}

            //else
            //{

            //    if (txtLink.Text != "")
            //    {

            //        //checked for txtboxlink if iterator HasChildViewState a link
            //    }

            //    else
            //    {
            //        //please upload a file 

            //    }

            //}


        }



        //protected void grdInventoryDetails_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}

        //protected void grdInventoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdInventoryDetails.PageIndex = e.NewPageIndex;
        //    grdInventoryDetails.DataBind();
        //}
    }

}