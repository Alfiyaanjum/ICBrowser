using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Collections;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class AdminChkMatch : BasePage
    {
        Common.UserProfile usrProf = new Common.UserProfile();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser userToLogin = Membership.GetUser();
            lblError.Visible = false;
            lblSucess.Visible = false;

            if (userToLogin != null)
            {
                Guid currUserId = (Guid)userToLogin.ProviderUserKey;
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    Common.UserProfile usrProf = new Common.UserProfile();
                    if (Request.QueryString["UserID"] != null)
                    {
                        Guid userId = new Guid(Request.QueryString["UserID"]);
                        ViewState["userId"] = userId;
                        UserProfileDetails usrProfDetails = new UserProfileDetails();
                        Session["userProf"] = usrProfDetails.GetUserProfileDetails(userId);
                        usrProf = (Common.UserProfile)Session["userProf"];
                        BindLables(usrProf);
                    }
                    BindGrid();
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        /// <summary>
        /// Binds the grid.
        /// </summary>
        private void BindGrid()
        {
            UserProfileDetails usrProfDetails = new UserProfileDetails();
            Common.UserProfile usrProf = new Common.UserProfile();
            usrProf = (Common.UserProfile)Session["userProf"];
            gvTrialUsrGrid.DataSource = usrProfDetails.GetMatchRecords(usrProf);
            gvTrialUsrGrid.DataBind();
        }

        /// <summary>
        /// Binds the lables.
        /// </summary>
        /// <param name="usrProf">The usr prof.</param>
        private void BindLables(Common.UserProfile usrProf)
        {
            lblEmailId1.Text = usrProf.email;
            lblPhoneNo1.Text = usrProf.LandLine;
            lblMobNo1.Text = usrProf.Mobile;
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTrialUsrGrid.PageIndex = e.NewPageIndex;
            BindGrid();
        }


        /// <summary>
        /// Handles the Click event of the delineImageCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void delineImageCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderSendDeclineMessage.Hide();
        }


        /// <summary>
        /// Handles the RowCommand event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "lnkBtn1") //Approved
            {
                OfflineSubscriptionDetails osd = new OfflineSubscriptionDetails();
                UserDetails ud = new UserDetails();
                LinkButton lnkSellerId1 = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkAppUsrId") as LinkButton;
                Label lblEmailId = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lblMailId") as Label;
                LinkButton lbtnContactName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnContactName") as LinkButton;
                LinkButton lbtnUserName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnUserName") as LinkButton;
                ud.UserID = new Guid(lnkSellerId1.Text);


                //------delete Users records who has degraded his Membership------------
                osd.deleteDegradedUserRecords(ud.UserID);   //deletes degraded Members record          


                //-----End--------------------------------------------------------------

                string toEmail = lblEmailId.Text;
                string contactName = lbtnContactName.Text;
                string userName = lbtnUserName.Text;


                bool flag = osd.UpdateOfflineSubscriptionDetails(ud);
                if (flag)
                {
                    lblSucess.Visible = true;
                    ///Summary
                    ///Description:Sends Mail to Approved User from Administrator.
                    ///Summary
                    Hashtable hash = new Hashtable { { "ToContactName", contactName }, { "FromUserName", "Administrator" }, { "ToUserName", userName } };
                    EmailFactory mailFactory = new EmailFactory();
                    Email mail = mailFactory.GetAccountApprovalMailByAdmin(toEmail, "support@icbrowser.com", hash);

                    if (mail.Send())
                    {
                        lblError.Visible = false;
                        lblSucess.Visible = true;
                        lblSucess.Text = "User Approved successfully. Mail sent to user.";
                    }
                    else
                    {
                        lblSucess.Visible = false;
                        lblError.Visible = true;
                        lblError.Text = "Error occured during operation. Please try again later";
                    }
                    this.BindGrid();
                }
                else
                {
                    lblError.Visible = true;
                }
            }

            if (e.CommandName == "lnkBtn2") //Decline
            {
                ModalPopupExtenderSendDeclineMessage.Show();

                LinkButton lnkSellerId2 = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkDecUserID") as LinkButton;
                ViewState["sellerId"] = lnkSellerId2.Text;
            }

        }

        /// <summary>
        /// Handles the Click event of the btndecline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btndecline_Click(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            UserProfileDetails usrProflDetails = new UserProfileDetails();
            Common.UserProfile Profile = new Common.UserProfile();
            Profile.ReasonToDecline = txtdecline.Text;
            string UserId = ViewState["sellerId"].ToString();
            Profile.UserID = new Guid(UserId);
            usrProflDetails.SetDeclineUser(Profile);
            txtdecline.Text = string.Empty;
            this.BindGrid();
            lblSucess.Visible = true;
            lblSucess.Text = "User has been declined.";

        }

        /// <summary>
        /// Handles the RowDataBound event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    UserProfileDetails profiledetais = new UserProfileDetails();
                    Common.UserProfile Profile = new Common.UserProfile();
                    //LinkButton btnReasn = sender as LinkButton;
                    //GridViewRow GVEmployeeRow = (GridViewRow)btnReasn.NamingContainer;
                    //LinkButton lbtnApprove = (((System.Web.UI.Control)(e.Row)).Parent).Parent.FindControl("lnkApprd") as LinkButton;
                    LinkButton lbtnApprove = ((LinkButton)e.Row.FindControl("lnkApprd") as LinkButton);
                    //LinkButton lbtnusrid = (((System.Web.UI.Control)(e.Row)).Parent).Parent.FindControl("lnkAppUsrId") as LinkButton;
                    LinkButton lbtnusrid = ((LinkButton)e.Row.FindControl("lnkAppUsrId") as LinkButton);
                    LinkButton lbtnMembshpType = ((LinkButton)e.Row.FindControl("lnkMembshpType") as LinkButton);
                    LinkButton lbtnIsdecline = ((LinkButton)e.Row.FindControl("lnkIsdecline") as LinkButton);
                    string userId = lbtnusrid.Text;
                    Guid usrId = new Guid(userId);
                    int Typeofmembshp = Convert.ToInt32(lbtnMembshpType.Text);
                    int Isdecline = Convert.ToInt32(lbtnIsdecline.Text);
                    //bool Approve = profiledetais.GetApprove(usrId);
                    if (Isdecline == 2 || Typeofmembshp == 1)
                    //if(Approve)
                    {
                        lbtnApprove.Visible = false;
                    }
                    else
                    {
                        lbtnApprove.Visible = true;
                    }


                    Label lblMemType = e.Row.FindControl("lblMemType") as Label;
                    Label lblOffMemType = e.Row.FindControl("lblOffMemType") as Label;
                    int OffMemType = Convert.ToInt32(lblOffMemType.Text);
                    if (lblMemType.Text == "1")
                    {
                        if (OffMemType >= 3)
                        {
                            lblMemType.Text = "Offline Paid";
                        }
                        else
                        {
                            lblMemType.Text = "Free";
                        }
                        
                    }
                    else if (lblMemType.Text == "2")
                    {
                        lblMemType.Text = "Trial";
                    }
                    else
                    {
                        lblMemType.Text = "Paid";
                    }

                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }
    }
}