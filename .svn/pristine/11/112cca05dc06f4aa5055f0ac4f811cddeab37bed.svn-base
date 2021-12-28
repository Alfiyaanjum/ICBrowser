using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Collections;
using System.Drawing;
using System.Data;

namespace ICBrowser.Web
{

    public partial class EmailSentReceiveDetails : BasePage
    {
        string bindDatatype;
        Hashtable htEmailInfo = new Hashtable();
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string prevPage = Request.QueryString["Page"];

                    if (prevPage != "Mail")
                    {
                        Session["EmailData"] = null;
                    }
                    else
                    {
                        htEmailInfo = (Hashtable)Session["EmailData"];
                        bindDatatype = htEmailInfo["BindDataType"].ToString();
                    }


                }


                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                UserRequirements UserReq = new UserRequirements();
                UserProfileDetails userProfile = new UserProfileDetails();

                if (string.IsNullOrEmpty(bindDatatype))
                {
                    if (!Page.IsPostBack)
                    {
                        if (userToLogin != null)
                        {

                            if (bindDatatype == null)
                            {
                                ViewState["BindDataType"] = "InboxType";
                                Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                            }

                        }
                        else
                        {

                            Response.Redirect("Default.aspx", false);
                        }
                    }
                }
                else
                {
                    ViewState["BindDataType"] = bindDatatype;
                    if (ViewState["BindDataType"].ToString().Equals("InboxType"))
                    {
                        lblHeaderSentItem.Visible = false;
                        lblHeaderInbox.Visible = true;
                        lblHeaderDeleteItems.Visible = false;

                    }
                    else if (ViewState["BindDataType"].ToString().Equals("SentItems"))
                    {
                        lblHeaderSentItem.Visible = true;
                        lblHeaderInbox.Visible = false;
                        lblHeaderDeleteItems.Visible = false;

                    }
                    else if (ViewState["BindDataType"].ToString().Equals("DeleteItem"))
                    {
                        lblHeaderSentItem.Visible = false;
                        lblHeaderInbox.Visible = false;
                        lblHeaderDeleteItems.Visible = true;
                    }
                    Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                }


            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Clears the content of the text box.
        /// </summary>
        private void ClearTextBoxContent()
        {
            try
            {
                lblMessageForDelete.Text = "";
                lblMessageForDelete.Visible = false;

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Bindgrids the specified touserid.
        /// </summary>
        /// <param name="touserid">The touserid.</param>
        /// <param name="SelectionType">Type of the selection.</param>
        private void Bindgrid(MembershipUser touserid, string SelectionType)
        {
            try
            {
                EmailDetails emaildet = new EmailDetails();
                List<EmailDetailsForUser> lstInbox = new List<EmailDetailsForUser>();
                //to retrieve login user message details
                lstInbox = emaildet.getLoginUsersEmailDetails(touserid, SelectionType);

                DataTable dtBuyersDetails = new DataTable();
                dtBuyersDetails.Columns.Add("MessageId", typeof(int));
                dtBuyersDetails.Columns.Add("Status", typeof(string));
                dtBuyersDetails.Columns.Add("FromUserId", typeof(string));
                dtBuyersDetails.Columns.Add("ToUserId", typeof(string));
                dtBuyersDetails.Columns.Add("Subject", typeof(string));
                //dtBuyersDetails.Columns.Add("SentDate", typeof(string));
                dtBuyersDetails.Columns.Add("SentDate", typeof(string));
                dtBuyersDetails.Columns.Add("AttachedFile", typeof(string));


                DataRow dr;
                int count = 0;
                foreach (ICBrowser.Common.EmailDetailsForUser buyerReqEntry in lstInbox)
                {
                    dr = dtBuyersDetails.NewRow();
                    dr["MessageId"] = buyerReqEntry.MessageId;
                    if (buyerReqEntry.Status == true)
                    {
                        dr["Status"] = "UnRead";
                        count = count + 1;
                    }
                    else
                    {
                        dr["Status"] = "Read";
                    }
                    dr["Subject"] = buyerReqEntry.Subject;
                    dr["FromUserId"] = buyerReqEntry.FromUserId;
                    dr["SentDate"] = buyerReqEntry.SentDate.ToString("dd-MMM-yyyy HH:mm:ss");
                    dr["ToUserId"] = buyerReqEntry.ToUserId;
                    if (buyerReqEntry.AttachedFile != null)
                    {
                        dr["AttachedFile"] = buyerReqEntry.AttachedFile;
                    }

                    dtBuyersDetails.Rows.Add(dr);


                }

                // Count Number of Unread mails only for Type Inbox
                gvEmailDetails.DataSource = dtBuyersDetails;
                gvEmailDetails.DataBind();

                if (ViewState["BindDataType"].ToString().Equals("InboxType"))
                {
                    if (count > 0)
                    {
                        //btnInbox.Font.Bold = true;
                        btnInbox.Text = "Inbox (" + count + ")";
                    }
                    else
                    {
                        //btnInbox.Font.Bold = false;
                        btnInbox.Text = "Inbox (" + count + ")";
                    }
                }

                else if (ViewState["BindDataType"].ToString().Equals("DeleteItem"))
                {
                    for (int i = 0; i < gvEmailDetails.Rows.Count; i++)
                    {
                        GridViewRow row = gvEmailDetails.Rows[i];
                        ImageButton imgbtnDelete = ((ImageButton)row.FindControl("imgbtnDelete"));
                        imgbtnDelete.Visible = true;
                    }
                }

                ClearTextBoxContent();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSentItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSentItems_Click(object sender, EventArgs e)
        {
            lblHeaderInbox.Visible = false;
            lblHeaderDeleteItems.Visible = false;
            lblHeaderSentItem.Visible = true;
            gvEmailDetails.PageIndex = 0;
            MembershipUser userToLogin = Membership.GetUser();
            ViewState["BindDataType"] = "SentItems";
            //BindgridSentItems(userToLogin);
            Bindgrid(userToLogin, ViewState["BindDataType"].ToString());

        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblHeaderInbox.Visible = false;
            lblHeaderDeleteItems.Visible = true;
            lblHeaderSentItem.Visible = false;
            gvEmailDetails.PageIndex = 0;
            MembershipUser userToLogin = Membership.GetUser();
            ViewState["BindDataType"] = "DeleteItem";
            //BindgridDeleteItems(userToLogin);
            Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
            for (int i = 0; i < gvEmailDetails.Rows.Count; i++)
            {
                GridViewRow row = gvEmailDetails.Rows[i];
                ImageButton imgbtnDelete = ((ImageButton)row.FindControl("imgbtnDelete"));
                imgbtnDelete.Visible = true;
            }

        }

        /// <summary>
        /// Handles the RowDataBound event of the gvEmailDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvEmailDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.Control imgAttchment = (System.Web.UI.Control)e.Row.FindControl("imgAttachment");
                Label lblAttachedFileName = e.Row.FindControl("lblAttachedFileName") as Label;
                if (lblAttachedFileName != null && imgAttchment != null)
                {
                    if (!string.IsNullOrEmpty(lblAttachedFileName.Text.Trim()))
                    {
                        imgAttchment.Visible = true;
                    }
                    else
                    {
                        imgAttchment.Visible = false;
                    }
                }



                if (ViewState["BindDataType"].ToString().Equals("InboxType"))
                {
                    Label lblFromId = e.Row.FindControl("lblStatus") as Label;
                    if (lblFromId != null && lblFromId.Text == "UnRead")
                    {
                        e.Row.Font.Underline = false;
                        e.Row.ForeColor = Color.Black;
                        e.Row.Font.Bold = true;
                    }
                }

            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvEmailDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvEmailDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                UserRequirements UserReq = new UserRequirements();

                EmailDetails emaildet = new EmailDetails();
                EmailDetailsForUser UserEmailDetails = new EmailDetailsForUser();
                //lblErrorMessage.Visible = false;
                if (e.CommandName == "subject")
                {
                    Session["EmailData"] = null;
                    int MessageId = int.Parse(e.CommandArgument.ToString());
                    ViewState["MessageId"] = MessageId;

                    int buyersidcount = UserReq.GetUserCountByUserId(userid);
                    if (buyersidcount > 0) // If Buyer
                    {
                        if (ViewState["BindDataType"].ToString().Equals("InboxType")) // check for selection type "Inbox"
                        {

                            //to retrieve user message details history
                            UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 1);
                            //btnReply.Visible = true;
                            // to set the status in table MessageDetails
                            emaildet.SetUpdateStatusForSelectedMessageId(MessageId);
                            Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                        }
                        else if (ViewState["BindDataType"].ToString().Equals("SentItems")) // "Sent Item"
                        {
                            UserEmailDetails = emaildet.getUserDetailsOnMessageIdForReadingMails(userid, MessageId, 1);
                            //btnReply.Visible = false;
                        }
                        else if (ViewState["BindDataType"].ToString().Equals("DeleteItem")) // "Sent Item"
                        {

                            //to retrieve user message details history
                            UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 0);
                            //btnReply.Visible = false;
                        }

                    }
                    else // If Seller
                    {
                        if (ViewState["BindDataType"].ToString().Equals("InboxType")) // "Inbox"
                        {

                            //to retrieve user message details history
                            UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 0);
                            //btnReply.Visible = true;
                            emaildet.SetUpdateStatusForSelectedMessageId(MessageId);
                            Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                        }
                        else if (ViewState["BindDataType"].ToString().Equals("SentItems")) // "Sent Items"
                        {
                            //to retrieve user message details history for sent item
                            UserEmailDetails = emaildet.getUserDetailsOnMessageIdForReadingMails(userid, MessageId, 0);
                            //btnReply.Visible = false;
                        }
                        else if (ViewState["BindDataType"].ToString().Equals("DeleteItem")) // "Sent Item"
                        {

                            //to retrieve user message details history
                            UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 0);
                            //btnReply.Visible = false;
                        }
                    }
                    htEmailInfo.Add("MessageId", MessageId);
                    htEmailInfo.Add("BindDataType", ViewState["BindDataType"]);
                    Session["EmailData"] = htEmailInfo;
                    Session["panlvalue"] = 0;
                    Response.Redirect("~/Mailbox.aspx", false);

                }


                else if (e.CommandName == "Delete")
                {
                    int MessageId = int.Parse(e.CommandArgument.ToString());
                    ViewState["MessageId"] = MessageId;

                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the RowDeleting event of the gvEmailDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void gvEmailDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmailDetails emaildet = new EmailDetails();
            int MessageId = Convert.ToInt32(ViewState["MessageId"]);
            MembershipUser userToLogin = Membership.GetUser();
            if (ViewState["BindDataType"].ToString().Equals("InboxType"))
            {
                Boolean IsInboxDelete = true;
                //to delete message details
                emaildet.OnDeleteMailsOnMessageId(IsInboxDelete, MessageId, ViewState["BindDataType"].ToString());
                Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
            }
            else if (ViewState["BindDataType"].ToString().Equals("SentItem"))
            {
                Boolean IsSentItemDelete = true;
                //to delete message details
                emaildet.OnDeleteMailsOnMessageId(IsSentItemDelete, MessageId, ViewState["BindDataType"].ToString());
                //BindgridSentItems(userToLogin, ViewState["BindDataType"].ToString());
                Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
            }
            else
            {
                Boolean IsTrashItemDelete = true;
                //to delete message details
                emaildet.OnDeleteMailsOnMessageId(IsTrashItemDelete, MessageId, ViewState["BindDataType"].ToString());
                //BindgridSentItems(userToLogin, ViewState["BindDataType"].ToString());
                Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvEmailDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void gvEmailDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvEmailDetails.PageIndex = e.NewPageIndex;
                MembershipUser userToLogin = Membership.GetUser();
                if (ViewState["BindDataType"].ToString().Equals("InboxType"))
                {
                    Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                }
                else if (ViewState["BindDataType"].ToString().Equals("SentItems"))
                {
                    //BindgridSentItems(userToLogin);
                    Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                }
                else if (ViewState["BindDataType"].ToString().Equals("DeleteItem"))
                {
                    //BindgridDeleteItems(userToLogin);
                    Bindgrid(userToLogin, ViewState["BindDataType"].ToString());
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnInbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnInbox_Click(object sender, EventArgs e)
        {
            lblHeaderInbox.Visible = true;
            lblHeaderSentItem.Visible = false;
            lblHeaderDeleteItems.Visible = false;
            gvEmailDetails.PageIndex = 0;
            MembershipUser userToLogin = Membership.GetUser();
            ViewState["BindDataType"] = "InboxType";
            Bindgrid(userToLogin, ViewState["BindDataType"].ToString());

        }


    }
}