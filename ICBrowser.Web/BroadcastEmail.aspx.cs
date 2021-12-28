using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ICBrowser.Business;
using System.Web.Security;
using System.Data;
using ICBrowser.Common;
using System.ComponentModel;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.IO;
using System.Diagnostics;

namespace ICBrowser.Web
{
    public partial class BroadcastEmail : BasePage
    {
        List<ICBrowser.Common.UserProfile> lstAllUsrProfl = new List<ICBrowser.Common.UserProfile>();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            lblError.Visible = false;
            //lblscs.Visible = false;
            //lblerr.Visible = false;
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;
            if (!Page.IsPostBack)
            {
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    BindAllUsrDetailsGrid();
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }

            ClearContents();

        }

        /// <summary>
        /// Binds all usr details grid.
        /// </summary>
        private void BindAllUsrDetailsGrid()
        {
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            lstAllUsrProfl = usrProfDetils.GetAllUsrDetails();
            gvAllUsrDetails.DataSource = lstAllUsrProfl;
            gvAllUsrDetails.DataBind();
        }


        /// <summary>
        /// Clears the contents.
        /// </summary>
        public void ClearContents()
        {
            lblError.Visible = false;
            lblSucess.Visible = false;
        }



        /// <summary>
        /// Handles the Click event of the btnSendMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                lblSucess.Visible = false;
                lblError.Visible = false;
                MembershipUser userToLogin = Membership.GetUser();
                Guid currUserId = (Guid)userToLogin.ProviderUserKey;
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    Hashtable hash = new Hashtable
                                     {
                                         {"ToUserName", "User"}, 
                                         {"FromUserName", "Admin"},
                                         {"Subject", txtSubject.Text},
                                         {"EmailAddress",hfToUserDetails.Value},
                                         {"Message",txtContent.Text}
                                     };

                    //for finding exixting parentid

                    EmailFactory mailFactory = new EmailFactory();
                    Email mail = mailFactory.SendBroadCastEmailByAdmin(hfToUserDetails.Value, "support@icbrowser.com", txtSubject.Text, txtContent.Text, hash);
                    if (mail.Send())
                    {
                        lblSucess.Visible = true;
                        lblSucess.Text = "Mail successfully sent to selected users";
                        txtContent.Text = string.Empty;
                        txtSubject.Text = string.Empty;
                    }

                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Mail sending failed";
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        /// <summary>
        /// Handles the Click event of the btnCancelMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        /// <summary>
        /// Handles the Click event of the lbtnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnPreview_Click(object sender, EventArgs e)
        {
            chkAllUsers.Checked = false;
            chkFreeUser.Checked = false;
            chkPaidUser.Checked = false;
            chkTrialUser.Checked = false;
            foreach (GridViewRow row in gvAllUsrDetails.Rows)
            {
                CheckBox chkgridbox = row.FindControl("chkbx") as CheckBox;
                chkgridbox.Checked = false;
            }
            modpopPreview.Show();
        }

        /// <summary>
        /// Handles the RowCancelingEdit event of the gvAllUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
        protected void gvAllUsrDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            gvAllUsrDetails.EditIndex = -1;
            //Bind data to the GridView control.         
            BindAllUsrDetailsGrid();
        }

        /// <summary>
        /// Handles the RowUpdating event of the gvAllUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void gvAllUsrDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        /// <summary>
        /// Handles the RowDataBound event of the gvAllUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvAllUsrDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Button btnStatus = row.FindControl("btnStat") as Button;
                Button btn = row.FindControl("btnedit") as Button;
                Label lblMemType = e.Row.FindControl("lblMemType") as Label;
                if (lblMemType.Text == "1")
                {
                    lblMemType.Text = "Free User";
                }
                else if (lblMemType.Text == "2" && lblMemType != null)
                {
                    lblMemType.Text = "Trial User";
                }
                else
                {
                    lblMemType.Text = "Paid User";
                }
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvAllUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvAllUsrDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllUsrDetails.PageIndex = e.NewPageIndex;
            BindAllUsrDetailsGrid();
        }

        /// <summary>
        /// Handles the RowEditing event of the gvAllUsrDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
        protected void gvAllUsrDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (Session["Search"] != null)
            {
                gvAllUsrDetails.EditIndex = e.NewEditIndex;
                gvAllUsrDetails.DataSource = Session["Search"];
                gvAllUsrDetails.DataBind();
                Session["Search"] = null;
            }
            else
            {
                gvAllUsrDetails.EditIndex = e.NewEditIndex;
                BindAllUsrDetailsGrid();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPreviewClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPreviewClose_Click(object sender, EventArgs e)
        {
            StringBuilder tableCompText = new StringBuilder();
            string sentToMailId = string.Empty;
            if (chkAllUsers.Checked == true)
            {
                foreach (GridViewRow row in gvAllUsrDetails.Rows)
                {
                    CheckBox chkfree = (CheckBox)row.FindControl("chkbx");
                    Label lblAllEmail = (Label)row.FindControl("lblEmail");
                    chkfree.Checked = true;
                    if (string.IsNullOrEmpty(sentToMailId))
                        sentToMailId = lblAllEmail.Text;
                    else
                        sentToMailId += (";") + lblAllEmail.Text;
                    hfToUserDetails.Value = sentToMailId;
                }

            }
            else if (chkTrialUser.Checked == true)
            {
                foreach (GridViewRow row in gvAllUsrDetails.Rows)
                {
                    CheckBox chkfree = (CheckBox)row.FindControl("chkbx");
                    chkfree.Checked = false;
                    Label lblMemTyp = (Label)row.FindControl("lblMemType");
                    Label lblTrialEmail = (Label)row.FindControl("lblEmail");
                    if (lblMemTyp.Text == "Trial User")
                    {
                        chkfree.Checked = true;
                        if (string.IsNullOrEmpty(sentToMailId))
                            sentToMailId = lblTrialEmail.Text;
                        else
                            sentToMailId += (";") + lblTrialEmail.Text;
                        hfToUserDetails.Value = sentToMailId;
                    }
                }

            }
            else if (chkFreeUser.Checked == true)
            {
                foreach (GridViewRow row in gvAllUsrDetails.Rows)
                {
                    CheckBox chkfree = (CheckBox)row.FindControl("chkbx");
                    chkfree.Checked = false;
                    Label lblMemTyp = (Label)row.FindControl("lblMemType");
                    Label lblFreeEmail = (Label)row.FindControl("lblEmail");
                    if (lblMemTyp.Text == "Free User")
                    {
                        chkfree.Checked = true;
                        if (string.IsNullOrEmpty(sentToMailId))
                            sentToMailId = lblFreeEmail.Text;
                        else
                            sentToMailId += ";" + lblFreeEmail.Text;
                        hfToUserDetails.Value = sentToMailId;
                    }
                }

            }
            else if (chkPaidUser.Checked == true)
            {
                foreach (GridViewRow row in gvAllUsrDetails.Rows)
                {
                    CheckBox chkfree = (CheckBox)row.FindControl("chkbx");
                    chkfree.Checked = false;
                    Label lblMemTyp = (Label)row.FindControl("lblMemType");
                    Label lblPaidEmail = (Label)row.FindControl("lblEmail");
                    if (lblMemTyp.Text == "Paid User")
                    {
                        chkfree.Checked = true;
                        if (string.IsNullOrEmpty(sentToMailId))
                            sentToMailId = lblPaidEmail.Text;
                        else
                            sentToMailId += ";" + lblPaidEmail.Text;
                        hfToUserDetails.Value = sentToMailId;
                    }
                }

            }
            else
            {
                foreach (GridViewRow row in gvAllUsrDetails.Rows)
                {
                    CheckBox chkfree = (CheckBox)row.FindControl("chkbx");
                    Label lblPaidEmail = (Label)row.FindControl("lblEmail");
                    if (chkfree.Checked == true)
                    {
                        if (string.IsNullOrEmpty(sentToMailId))
                            sentToMailId = lblPaidEmail.Text;
                        else
                            sentToMailId += (";") + lblPaidEmail.Text;
                        hfToUserDetails.Value = sentToMailId;
                    }
                }
            }
        }
    }
}