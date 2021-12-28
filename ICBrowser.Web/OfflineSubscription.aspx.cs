using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Linq.Expressions;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class OfflineSubscription : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            lblError.Visible = false;
            MembershipUser userToLogin = Membership.GetUser();
            Guid currUserId = (Guid)userToLogin.ProviderUserKey;

            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
            if (Admin.IsAdmin == true)
            {
                this.BindGrid();
                this.BindTrialGrid();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }


        /// <summary>
        /// Region for Offline User Grid
        /// </summary>

        #region

        /// <summary>
        /// Binds the grid.
        /// </summary>
        private void BindGrid()
        {
            OfflineSubscriptionDetails osd = new OfflineSubscriptionDetails();
            gvOfflineSub.DataSource = osd.GetOfflineSubscriptDetails();
            gvOfflineSub.DataBind();
        }

        /// <summary>
        /// Handles the RowCommand event of the gvOfflineSub control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvOfflineSub_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "lnkBtn1") //Approved
            {
                OfflineSubscriptionDetails osd = new OfflineSubscriptionDetails();
                UserDetails ud = new UserDetails();
                LinkButton lnkSellerId1 = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkSellerId1") as LinkButton;
                LinkButton lbtnEmailId = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnEmailId") as LinkButton;
                LinkButton lbtnContactName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnContactName") as LinkButton;
                LinkButton lbtnUserName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnUserName") as LinkButton;
                ud.UserID = new Guid(lnkSellerId1.Text);


                //------delete Users records who has degraded his Membership------------
                osd.deleteDegradedUserRecords(ud.UserID);   //deletes degraded Members record          


                //-----End--------------------------------------------------------------

                string toEmail = lbtnEmailId.Text;
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
                    // Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Visible = true;
                }
            }

            if (e.CommandName == "lnkBtn2") //Decline
            {
                ModalPopupExtender1.Show();

                LinkButton lnkSellerid = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkSellerId") as LinkButton;
                LinkButton lbtnEmailId = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnEmailId") as LinkButton;
                LinkButton lbtnContactName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnContactName") as LinkButton;

                ViewState["sellerId"] = lnkSellerid.Text;
                ViewState["toEmailId"] = lbtnEmailId.Text;
                ViewState["contactName"] = lbtnContactName.Text;
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvOfflineSub control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvOfflineSub_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfflineSub.PageIndex = e.NewPageIndex;
            gvOfflineSub.DataBind();
        }

        /// <summary>
        /// Handles the Sorting event of the gvOfflineSub control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
        protected void gvOfflineSub_Sorting(object sender, GridViewSortEventArgs e)
        {
            IList<UserDetails> Ilist = gvOfflineSub.DataSource as IList<UserDetails>;
            DataTable dt = ToDataTable<UserDetails>(Ilist);
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);

                gvOfflineSub.DataSource = dataView;
                gvOfflineSub.DataBind();
            }
        }

        /// <summary>
        /// Handles the Sorting event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<UserProfile> Ilist = gvTrialUsrGrid.DataSource as List<UserProfile>;
            DataTable dt = ToDataTable1<UserProfile>(Ilist);
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);

                gvTrialUsrGrid.DataSource = dataView;
                gvTrialUsrGrid.DataBind();
            }
        }

        /// <summary>
        /// Description:Following Method is for Sorting Gridview.
        /// </summary>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private string ConvertSortDirection(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
            return newSortDirection;
        }

        /// <summary>
        /// Description:Following Method converts IList<UserDetails> Into DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<UserDetails> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (UserDetails item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }


        /// <summary>
        /// To the data table1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>DataTable.</returns>
        public static DataTable ToDataTable1<T>(List<UserProfile> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (UserProfile item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(values);
            }
            return table;
        }

        //for Model PopUp Cancel.
        //protected void imgCancel_Click(object sender, EventArgs e)
        //{
        //    ModalPopupExtenderSendEmail.Hide();
        //    txtSubject.Text = string.Empty;
        //    txtContent.Text = string.Empty;
        //}

        /// <summary>
        /// Description:sends mail to Decline user,getting subject and content from ModelPopUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    string toEmailId = ViewState["toEmailId"].ToString();
        //    string contactName = ViewState["contactName"].ToString();
        //    string userName = "Administrator";

        //    Hashtable hash = new Hashtable { { "ToUserName", contactName }, { "FromUserName", userName }, { "Subject", txtSubject.Text }, { "Message", txtContent.Text } };
        //    EmailFactory mailFactory = new EmailFactory();
        //    Email mail = mailFactory.SendEmailBySellerId(toEmailId, "support@icbrowser.com", txtSubject.Text, txtContent.Text, hash);

        //    if (mail.Send())
        //    {
        //        // ModalPopupExtenderSendEmail.Hide();
        //        txtContent.Text = string.Empty;
        //        txtSubject.Text = string.Empty;
        //        lblSucess.Visible = true;
        //        lblSucess.Text = "Mail sent to user sucessfully.";
        //    }
        //    else
        //    {
        //        ModalPopupExtenderSendEmail.Show();
        //        lbleror.Visible = true;
        //        lbleror.Text = "Error occurred in sending mail. Please try again later.";
        //    }
        //}

        #endregion


        /// <summary>
        /// Handles the Click event of the btndecline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btndecline_Click(object sender, EventArgs e)
        {
            UserProfileDetails usrProflDetails = new UserProfileDetails();
            Common.UserProfile Profile = new Common.UserProfile();
            Profile.ReasonToDecline = txtdecline.Text;
            string UserId = ViewState["sellerId"].ToString();
            Profile.UserID = new Guid(UserId);
            usrProflDetails.SetDeclineUser(Profile);
            txtdecline.Text = string.Empty;
            this.BindGrid();
            this.BindTrialGrid();
            lblSucess.Visible = true;
            lblSucess.Text = "User has been declined.";
            
            

        }

        /// <summary>
        /// Handles the Click event of the delineImageCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void delineImageCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        /// <summary>
        /// Region for Trial User Grid
        /// </summary>

        /// <summary>
        /// Binds the trial grid.
        /// </summary>
        private void BindTrialGrid()
        {
            UserProfileDetails upd = new UserProfileDetails();
            gvTrialUsrGrid.DataSource = upd.GetAllTrialUsrDetails();
            gvTrialUsrGrid.DataBind();
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTrialUsrGrid.PageIndex = e.NewPageIndex;
            BindTrialGrid();
        }

        /// <summary>
        /// Approves trial user Account and sets trial user Expiry Date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// Handles the RowCommand event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkBtn1")
            {
                LinkButton lnkSellerId1 = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkUId") as LinkButton;
                LinkButton lbtnEmailId = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtn") as LinkButton;
                LinkButton lbtnContactName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnContactName") as LinkButton;
                LinkButton lbtnUserName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnUserName") as LinkButton;

                string toEmail = lbtnEmailId.Text;
                string contactName = lbtnContactName.Text;
                string userName = lbtnUserName.Text;

                UserDetails ud = new UserDetails();
                ud.UserID = new Guid(lnkSellerId1.Text);
                //OfflineSubscriptionDetails osd = new OfflineSubscriptionDetails();
                // bool flag = osd.UpdateOfflineSubscriptionDetails(ud);

                UserProfileDetails usrProflDetails = new UserProfileDetails();
                //bool flag = usrProflDetails.SetUsrUnBlock(ud.UserID);
                //bool flag = true; 
                bool flag = usrProflDetails.UpdateTrialUserRecord(ud.UserID);


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
                        lblError.Text = "Error occured during Operation. Please try again later";
                    }
                    this.BindTrialGrid();
                    // Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Visible = true;
                }
            }

            if (e.CommandName == "lnkBtn2")
            {
                ModalPopupExtender1.Show();

                LinkButton lnkUid = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lnkUId") as LinkButton;
                LinkButton lbtnEmailId = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtn") as LinkButton;
                LinkButton lbtnContactName = (((System.Web.UI.Control)(e.CommandSource)).Parent).Parent.FindControl("lbtnContactName") as LinkButton;

                ViewState["sellerId"] = lnkUid.Text;
                ViewState["toEmailId"] = lbtnEmailId.Text;
                ViewState["contactName"] = lbtnContactName.Text;
            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvTrialUsrGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvTrialUsrGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Button btnStatus = e.Row.FindControl("btnStat") as Button;
                LinkButton hypApproved = e.Row.FindControl("lnkApprd") as LinkButton;
                Label lblApproved = ((Label)e.Row.FindControl("lblApproved"));
                if (hypApproved != null && lblApproved != null)
                {
                    if (btnStatus.Text == "True")
                    {
                        hypApproved.Visible = false;
                        lblApproved.Visible = true;
                        lblApproved.Text = "Approved";
                    }
                }

            }
        }


    }
}