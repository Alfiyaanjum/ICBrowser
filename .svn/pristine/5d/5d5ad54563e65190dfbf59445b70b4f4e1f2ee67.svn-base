using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Web.Security;
using System.IO;
using System.Data;

namespace ICBrowser.Web
{
    public partial class UploadAdvertisement : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string adImageDirectory = Server.MapPath("~/Images/Uploaded Ads");

                if (!Directory.Exists(adImageDirectory))
                    Directory.CreateDirectory(adImageDirectory);

                ViewState["ImageRedirectUrl"] = "";
                ViewUploadedAds();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fuAdImage.HasFile)
            {
                string fileext = System.IO.Path.GetExtension(fuAdImage.FileName.ToLower());
                if (fuAdImage.PostedFile.ContentLength < 4200000)
                {
                    if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                    {
                        try
                        {
                            fuAdImage.SaveAs(Server.MapPath("~/Images/Uploaded Ads/") + fuAdImage.FileName);
                            Common.AdvertPanel newAd = new Common.AdvertPanel();
                            MembershipUser loggedUser = Membership.GetUser();
                            newAd.StartDate = Convert.ToDateTime(datepickerStart.Value);
                            newAd.EndDate = Convert.ToDateTime(datepickerEnd.Value);
                            newAd.UserID = new Guid(loggedUser.ProviderUserKey.ToString());
                            newAd.Text = tbxInfoText.Text;

                            if (!tbxRedirectUrl.Text.StartsWith("http://") && !tbxRedirectUrl.Text.StartsWith("https://"))
                                newAd.RedirectUrl = "http://" + tbxRedirectUrl.Text;
                            else
                                newAd.RedirectUrl = tbxRedirectUrl.Text;

                            newAd.Position = ddlPosition.SelectedItem.Text;
                            newAd.Email = tbxemailid.Text;
                            newAd.ImageUrl = "~/Images/Uploaded Ads/" + fuAdImage.FileName;
                            int resolution = checkResolution(newAd, fuAdImage);
                            if (resolution != 0)
                            {
                                AdvertisePanel addNewAd = new AdvertisePanel();
                                DateTime currentEndDate = addNewAd.InsertNewAd(newAd);

                                if (currentEndDate.Equals(Convert.ToDateTime("01-Jan-2012")))
                                {
                                    lblUploadMessage.Text = "New advertisement inserted successfully.";
                                    lblUploadMessage.Visible = true;

                                    switch (newAd.Position)
                                    {
                                        case "Right": ibtnPreview.Height = 100;
                                            ibtnPreview.Width = 270;
                                            break;

                                        case "Top Left": ibtnPreview.Height = 150;
                                            ibtnPreview.Width = 440;
                                            break;

                                        case "Top Right": ibtnPreview.Height = 150;
                                            ibtnPreview.Width = 440;
                                            break;

                                        case "Bottom Left": ibtnPreview.Height = 150;
                                            ibtnPreview.Width = 440;
                                            break;

                                        case "Bottom Right": ibtnPreview.Height = 150;
                                            ibtnPreview.Width = 440;
                                            break;

                                        default: break;
                                    }

                                    ViewUploadedAds();
                                    ibtnPreview.ImageUrl = newAd.ImageUrl;
                                    ibtnPreview.ToolTip = newAd.Text;
                                    ViewState["ImageRedirectUrl"] = newAd.RedirectUrl;
                                    modpopPreview.Show();
                                    pnlPreview.Visible = true;
                                    ibtnPreview.Visible = true;
                                    //lbtnPreview.Text = "Here is how this advertisement will look like ";

                                    if (!Directory.Exists(Server.MapPath("~/Images/Uploaded Ads/Temp")))
                                        Directory.Delete(Server.MapPath("~/Images/Uploaded Ads/Temp"));
                                }
                                else
                                    lblUploadMessage.Text = "Cannot insert new advertisement. There is already an active Ad for " + newAd.Position + " position, till " + currentEndDate.ToString("dd-MMM-yyyy") + ".";
                                ClearPage();
                            }
                            else
                            {
                                //lblUploadMessage.Text = "An error has occured. Please try again later.";
                                lblUploadMessage.Visible = true;
                                //getPosition();
                            }
                        }
                        catch (Exception ex)
                        {
                            IClogger.LogError(ex.Message);
                        }
                    }
                    else
                    {
                        lblUploadMessage.Text = "Only .jpg, .jpeg, .png, .gif files are allowed to upload.";
                        lblUploadMessage.Visible = true;
                    }
                }
                else
                {
                    // File Size is more than 4 mb
                    lblUploadMessage.Text = "Exceeds the 4 MB size limit,Please upload another file.";
                    lblUploadMessage.Visible = true;
                }
            }
            else
            {
                // Please upload file
                lblUploadMessage.Text = "Please upload file.";
                lblUploadMessage.Visible = true;
            }
            enableRedirectURl();
        }

        /// <summary>
        /// Checks the resolution.
        /// </summary>
        /// <param name="newAd">The new ad.</param>
        /// <param name="fuimage">The fuimage.</param>
        /// <returns>System.Int32.</returns>
        protected int checkResolution(Common.AdvertPanel newAd, FileUpload fuimage)
        {
            if (newAd.Position == "Top Left" || newAd.Position == "Top Right")
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Uploaded Ads/") + fuimage.FileName);
                int verticalresolution = img.Width;
                int horizontalresolution = img.Height;
                if (horizontalresolution > 150 || verticalresolution > 440)
                {
                    lblUploadMessage.Text = "Top image resolution must be between 400*100 and 440*150";
                    return 0;
                }
                else
                {
                    if (horizontalresolution < 100 || verticalresolution < 400)
                    {
                        lblUploadMessage.Text = "Top image resolution must be between 400*100 and 440*150";
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (newAd.Position == "Bottom Left" || newAd.Position == "Bottom Right")
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Uploaded Ads/") + fuimage.FileName);
                    int verticalresolution = img.Width;
                    int horizontalresolution = img.Height;
                    if (horizontalresolution > 150 || verticalresolution > 440)
                    {
                        lblUploadMessage.Text = "Bottom image resolution must be between 400*100 and 440*150";
                        return 0;
                    }
                    else
                    {
                        if (horizontalresolution < 100 || verticalresolution < 400)
                        {
                            lblUploadMessage.Text = "Bottom image resolution must be between 400*100 and 440*150";
                            return 0;
                        }
                        else
                        {

                            return 1;

                        }
                    }
                }
                else
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Uploaded Ads/") + fuimage.FileName);
                    int verticalresolution = img.Width;
                    int horizontalresolution = img.Height;
                    if (horizontalresolution > 200 || verticalresolution > 270)
                    {
                        lblUploadMessage.Text = "Right image resolution must be between 200*150 and 270*200";
                        return 0;
                    }
                    else
                    {
                        if (horizontalresolution < 150 || verticalresolution < 220)
                        {
                            lblUploadMessage.Text = "Right image resolution must be between 200*150 and 270*200";
                            return 0;
                        }
                        else
                        {
                            return 1;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears the page.
        /// </summary>
        private void ClearPage()
        {
            tbxInfoText.Text = "";
            tbxRedirectUrl.Text = "";
            datepickerStart.Value = "";
            datepickerEnd.Value = "";
            ddlPosition.ClearSelection();
            enableRedirectURl();
            tbxRedirectUrl.Text = "";
            tbxemailid.Text = "";
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblUploadMessage.Visible = false;
            ClearPage();
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvUploadedAds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvUploadedAds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUploadedAds.PageIndex = e.NewPageIndex;
            ViewUploadedAds();
        }

        /// <summary>
        /// Views the uploaded ads.
        /// </summary>
        private void ViewUploadedAds()
        {
            AdvertisePanel uploadedAdsObj = new AdvertisePanel();
            List<Common.AdvertPanel> lstAds = uploadedAdsObj.GetAllUploadedAds();

            DataTable dtAds = new DataTable();
            dtAds.Columns.Add("AdvertisementID", typeof(string));
            dtAds.Columns.Add("ImageUrl", typeof(string));
            dtAds.Columns.Add("StartDate", typeof(string));
            dtAds.Columns.Add("EndDate", typeof(string));
            dtAds.Columns.Add("PaymentStatus", typeof(string));
            dtAds.Columns.Add("Text", typeof(string));
            dtAds.Columns.Add("RedirectUrl", typeof(string));
            dtAds.Columns.Add("Position", typeof(string));
            dtAds.Columns.Add("Email", typeof(string));
            DataRow drAd;
            foreach (Common.AdvertPanel ad in lstAds)
            {
                drAd = dtAds.NewRow();
                drAd["AdvertisementID"] = ad.AdvertisementID;
                drAd["ImageUrl"] = ad.ImageUrl;
                drAd["StartDate"] = ad.StartDate.ToString("dd-MMM-yyyy");
                drAd["EndDate"] = ad.EndDate.ToString("dd-MMM-yyyy");
                drAd["Text"] = ad.Text;
                drAd["RedirectUrl"] = ad.RedirectUrl;
                drAd["Position"] = ad.Position;
                drAd["Email"] = ad.Email;

                dtAds.Rows.Add(drAd);
            }
            gvUploadedAds.DataSource = dtAds;
            gvUploadedAds.DataBind();
            gvUploadedAds.Visible = true;
            pnlAdGrid.Visible = true;
        }

        /// <summary>
        /// Handles the RowEditing event of the gvUploadedAds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void gvUploadedAds_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUploadedAds.EditIndex = e.NewEditIndex;
            ViewUploadedAds();
        }

        /// <summary>
        /// Handles the RowUpdating event of the gvUploadedAds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void gvUploadedAds_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Common.AdvertPanel updatedAd = new Common.AdvertPanel();
                int resolution = 0;
                updatedAd.AdvertisementID = Convert.ToInt32(((Label)gvUploadedAds.Rows[e.RowIndex].FindControl("colLblAdvId")).Text);
                FileUpload funewImage = ((FileUpload)gvUploadedAds.Rows[e.RowIndex].FindControl("fuGridImage"));
                string startDate = (((TextBox)gvUploadedAds.Rows[e.RowIndex].FindControl("tbxGridStartDate")).Text);
                updatedAd.StartDate = Convert.ToDateTime(startDate);
                string endDate = (((TextBox)gvUploadedAds.Rows[e.RowIndex].FindControl("tbxGridEndDate")).Text);
                updatedAd.EndDate = Convert.ToDateTime(endDate);
                updatedAd.Text = ((TextBox)gvUploadedAds.Rows[e.RowIndex].FindControl("tbxGridInfoText")).Text;
                TextBox tbxRedirectUrl = ((TextBox)gvUploadedAds.Rows[e.RowIndex].FindControl("tbxGridRedirectUrl"));
                if (!tbxRedirectUrl.Text.StartsWith("http://") && !tbxRedirectUrl.Text.StartsWith("https://"))
                    updatedAd.RedirectUrl = "http://" + tbxRedirectUrl.Text;
                else
                    updatedAd.RedirectUrl = tbxRedirectUrl.Text;
                updatedAd.Position = ((DropDownList)gvUploadedAds.Rows[e.RowIndex].FindControl("ddlGridPosition")).SelectedItem.Text;
                updatedAd.Email = ((TextBox)gvUploadedAds.Rows[e.RowIndex].FindControl("tbxGridEmail")).Text;

                if (funewImage.HasFile)
                {
                    string fileext = System.IO.Path.GetExtension(funewImage.FileName.ToLower());
                    if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                    {
                        try
                        {
                            funewImage.SaveAs(Server.MapPath("~/Images/Uploaded Ads/") + funewImage.FileName);
                            updatedAd.ImageUrl = "~/Images/Uploaded Ads/" + funewImage.FileName;
                            resolution = checkResolution(updatedAd, funewImage);
                        }
                        catch (Exception ex)
                        {
                            IClogger.LogError(ex.Message);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Only .jpg, .jpeg, .png, .gif files are allowed to upload. Old Image will be retained.');</script>");
                        updatedAd.ImageUrl = ((Label)gvUploadedAds.Rows[e.RowIndex].FindControl("colLblAdImage")).Text;
                    }
                }
                else
                {
                    updatedAd.ImageUrl = ((Label)gvUploadedAds.Rows[e.RowIndex].FindControl("colLblAdImage")).Text;
                    resolution = 1;
                }

                if (resolution != 0)
                {
                    AdvertisePanel updateAd = new AdvertisePanel();
                    DateTime currentEndDate = updateAd.UpdateAd(updatedAd);

                    if (currentEndDate.Equals(Convert.ToDateTime("01-Jan-2012")))
                    {
                        ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('Advertisement Details updated successfully.');</script>");
                    }
                    else
                    {
                        string alertMessage = "Cannot update this advertisement. There is already an active Ad for " + updatedAd.Position + " position, till " + currentEndDate.ToString("dd-MMM-yyyy") + ".";
                        ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('" + alertMessage + "');</script>");
                    }
                    gvUploadedAds.EditIndex = -1;
                    ViewUploadedAds();
                }
                else
                {
                    string alertMessage = "Invalid resolutuions for " + updatedAd.Position + " image. ";
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alert", "<script>alert('" + alertMessage + "');</script>");
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowDeleting event of the gvUploadedAds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void gvUploadedAds_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label lblGridAdId = (Label)gvUploadedAds.Rows[e.RowIndex].FindControl("colLblAdvId");
                int delAdId = Convert.ToInt32(lblGridAdId.Text);
                AdvertisePanel delAd = new AdvertisePanel();
                delAd.DeleteAd(delAdId);
                ViewUploadedAds();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the gvUploadedAds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void gvUploadedAds_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUploadedAds.EditIndex = -1;
            ViewUploadedAds();
        }

        /// <summary>
        /// Handles the Click event of the ibtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void ibtnPreview_Click(object sender, ImageClickEventArgs e)
        {
            if (!ViewState["ImageRedirectUrl"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectURL", "<script>window.open('" + ViewState["ImageRedirectUrl"].ToString() + "');</script>");
            }
        }

        /// <summary>
        /// Handles the Click event of the lbtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnPreview_Click(object sender, EventArgs e)
        {
            //if (!lbtnPreview.Text.Equals("Here is how this advertisement will look like "))
            //{
            if (fuAdImage.HasFile)
            {
                string fileext = System.IO.Path.GetExtension(fuAdImage.FileName.ToLower());

                if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                {
                    try
                    {
                        if (lblUploadMessage.Visible == true)
                            lblUploadMessage.Visible = false;

                        string tempAdImageDirectory = Server.MapPath("~/Images/Uploaded Ads/Temp");

                        if (!Directory.Exists(tempAdImageDirectory))
                            Directory.CreateDirectory(tempAdImageDirectory);

                        fuAdImage.SaveAs(Server.MapPath("~/Images/Uploaded Ads/Temp/") + fuAdImage.FileName);

                        ibtnPreview.ImageUrl = "~/Images/Uploaded Ads/Temp/" + fuAdImage.FileName;

                        if (!tbxInfoText.Text.Equals(""))
                            ibtnPreview.ToolTip = tbxInfoText.Text;
                        else
                            ibtnPreview.ToolTip = "";

                        if (!tbxRedirectUrl.Text.Equals(""))
                        {
                            if (!tbxRedirectUrl.Text.StartsWith("http://") || !tbxRedirectUrl.Text.StartsWith("https://"))
                                ViewState["ImageRedirectUrl"] = "http://" + tbxRedirectUrl.Text;
                            else
                                ViewState["ImageRedirectUrl"] = tbxRedirectUrl.Text;
                        }

                        if (!ddlPosition.SelectedValue.Equals("0"))
                        {
                            switch (ddlPosition.SelectedItem.Text)
                            {
                                case "Right": ibtnPreview.Height = 150;
                                    ibtnPreview.Width = 280;
                                    break;

                                case "Top": ibtnPreview.Height = 147;
                                    ibtnPreview.Width = 697;
                                    break;

                                case "Bottom": ibtnPreview.Height = 64;
                                    ibtnPreview.Width = 967;
                                    break;

                                default: break;
                            }
                        }

                        modpopPreview.Show();
                        pnlPreview.Visible = true;
                        ibtnPreview.Visible = true;

                        //lbtnPreview.Text = "Here is how this advertisement will look like ";
                    }
                    catch (Exception ex)
                    {
                        IClogger.LogError(ex.Message);
                    }
                }
                else
                {
                    lblUploadMessage.Text = "Only .jpg, .jpeg, .png, .gif files are allowed to upload.";
                    lblUploadMessage.Visible = true;
                }
            }
            else
            {
                lblUploadMessage.Text = "Please select an image file first";
                lblUploadMessage.Visible = true;
            }
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnPreviewClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            modpopPreview.Hide();
        }

        /// <summary>
        /// Enables the redirect u rl.
        /// </summary>
        protected void enableRedirectURl()
        {
            lblRedirectUrl.Enabled = true;
            lblRedirectUrl.Visible = true;
            lblHttp.Enabled = true;
            lblHttp.Visible = true;
            //tbxRedirectUrl.Text = "";
            tbxRedirectUrl.Enabled = true;
            tbxRedirectUrl.Visible = true;
            rfvRedirectUrl.Enabled = true;
            regexvalRedirectUrl.Enabled = true;
            msgspan.Visible = true;
            //msgspan1.Visible = true;
        }
    }
}