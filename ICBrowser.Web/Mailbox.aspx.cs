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
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace ICBrowser.Web
{
    public partial class Mailbox : BasePage
    {
        Hashtable htMoreDataformation = new Hashtable();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            htMoreDataformation = (Hashtable)Session["EmailData"];
            ViewState["Binddatatype"] = htMoreDataformation["BindDataType"];
            int MessageId = Convert.ToInt32(htMoreDataformation["MessageId"]);
            try
            {
                if (!IsPostBack)
                {


                    //visible panels id mantained in session for localization
                    int pnlvis = Convert.ToInt32(Session["panlvalue"]);

                    if (pnlvis != 0)
                    {

                        Panel1.Visible = false;
                        Panel2.Visible = true;

                        txtTo.Text = Session["to"].ToString();
                        txtReplySubject.Text = Session["subject"].ToString();
                        Lithistory.Text = Session["Lithistory"].ToString();

                    }
                }
                string pnl;
                if (Panel1.Visible)
                {
                    pnl = "0";
                }
                else
                {
                    pnl = "1";
                }
                Session["panlvalue"] = pnl;

                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = (Guid)userToLogin.ProviderUserKey;
                UserRequirements UserReq = new UserRequirements();
                EmailDetails emaildet = new EmailDetails();
                EmailDetailsForUser UserEmailDetails = new EmailDetailsForUser();

                int messageid = MessageId;

                int buyersidcount = UserReq.GetUserCountByUserId(userid);
                if (buyersidcount > 0) // If Buyer
                {
                    //to retrieve user message details history
                    UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, messageid, 1);

                }
                else // If Seller
                {
                    //to retrieve user message details history
                    UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, messageid, 0);
                }

                if (UserEmailDetails.AttachedFile != "")
                {
                    string AttachedFile = UserEmailDetails.AttachedFile.Replace(" ", "");
                    if (File.Exists(ICBrowser.Web.Properties.Settings.Default.FileAttachment + messageid + "\\" + AttachedFile))
                    {
                        lnkAttachment.Visible = true;
                        string path = ICBrowser.Web.Properties.Settings.Default.FileAttachment + messageid + "\\" + AttachedFile;
                        ViewState["path"] = path;
                        ViewState["FileName"] = AttachedFile;

                    }
                }
                lblfromValue.Text = UserEmailDetails.FromUserName;
                lblTo1Value.Text = UserEmailDetails.ToUserName;
                lblsubjectValue.Text = UserEmailDetails.Subject;
                lblLastUpdateValue.Text = Convert.ToString(UserEmailDetails.SentDate);

                UserProfileDetails profiledetais = new UserProfileDetails();
                Common.UserProfile Profile = new Common.UserProfile();
                Profile = profiledetais.GetUserProfileDetails(userid);
                int memTypeId = 0;
                memTypeId = Profile.TypeOfMembership;
                string Binddatatype = ViewState["Binddatatype"].ToString();
                if (Binddatatype == "SentItems")
                {
                    Profile = profiledetais.GetUserProfileDetails(UserEmailDetails.ToUserId);
                    if (memTypeId > 1)
                    {
                        lnkToCompanyName.Visible = true;
                        lnkToCompanyName.Text = Profile.CompanyName;
                    }

                }
                else
                {
                    Profile = profiledetais.GetUserProfileDetails(UserEmailDetails.FromUserId);
                    if (memTypeId > 1)
                    {
                        lnkCompanyName.Visible = true;
                        lnkCompanyName.Text = Profile.CompanyName;
                    }
                }

                ViewState["fromuserid"] = Profile.UserID;

                string NewMessage = Server.HtmlDecode(UserEmailDetails.MessageDescription);
                if (UserEmailDetails.ParentId == 0)
                {
                    txtMsg.Text = NewMessage;
                }

                StringBuilder builder = new StringBuilder();
                while (UserEmailDetails.ParentId != 0)
                {

                    if (buyersidcount > 0)
                    {
                        //to retrieve user message details history
                        UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, UserEmailDetails.ParentId, 1);
                    }
                    else
                    {
                        //to retrieve user message details history
                        UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, UserEmailDetails.ParentId, 0);
                    }


                    builder.AppendLine();
                    builder.AppendLine("-------------------------------------------------------------");
                    builder.Append("  ");

                    builder.AppendLine("Subject: " + UserEmailDetails.Subject);
                    builder.Append("  ");

                    builder.AppendLine("From: " + UserEmailDetails.FromUserName);

                    builder.Append("  ");

                    builder.AppendLine("To: " + UserEmailDetails.ToUserName);
                    builder.Append("  ");

                    builder.AppendLine("SentDate: " + UserEmailDetails.SentDate);
                    builder.Replace(Environment.NewLine, "<br />");
                    builder.Append("  ");

                    builder.Append("Message: " + Server.HtmlDecode(UserEmailDetails.MessageDescription));
                    builder.Append("  ");

                    string history = Server.HtmlEncode(builder.ToString());
                    lblhistory.Text = "History:";
                    ViewState["History"] = Server.HtmlDecode(history);
                    txtMsg.Text = NewMessage.Replace(Environment.NewLine, "<br />");

                }

                txtMsg.Text += Convert.ToString(ViewState["History"]);

                //txtMsg.Text = txtMsg.Text.Replace("\n", "<br />");
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }



        }

        /// <summary>
        /// Handles the Click event of the btnResponse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnResponse_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            lblSentMessage.Visible = false;
           
            htMoreDataformation = (Hashtable)Session["EmailData"];
            int MessageId = Convert.ToInt32(htMoreDataformation["MessageId"]);
            //to get panels id mantained in session for localization
            int pnlvis = Convert.ToInt32(Session["panlvalue"]);

            if (pnlvis == 0)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;

            }
            else
            {
                Panel2.Visible = false;

            }


            BuyersDataRequirement bdr = new BuyersDataRequirement();
            List<EmailDetailsForUser> lstdata = new List<EmailDetailsForUser>();
            MembershipUser userToLogin = Membership.GetUser();

            int messageid = MessageId;

            try
            {

                txtTo.Text = lblfromValue.Text;
                txtReplySubject.Text = "Re:" + lblsubjectValue.Text;
                Session["to"] = txtTo.Text;
                Session["subject"] = txtReplySubject.Text;

                if (!string.IsNullOrEmpty(lblLastUpdateValue.Text))
                {
                    StringBuilder build = new StringBuilder();
                    build.AppendLine();
                    build.Append("Subject : " + lblsubjectValue.Text);
                    build.Append("<br />");
                    build.Append("From : " + lblfromValue.Text);
                    build.Append("<br />");
                    build.Append("To : " + lblTo1Value.Text);
                    build.Append("<br />");
                    build.Append("Sent Date : " + lblLastUpdateValue.Text);
                    build.Append("<br />");
                    build.Append("Message: " + txtMsg.Text);

                    Lithistory.Text = build.ToString();
                    //Lithistory.Text = Lithistory.Text.Replace("\n", "<br />");
                    Session["Lithistory"] = Lithistory.Text;

                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// To send the Message and save message details.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            htMoreDataformation = (Hashtable)Session["EmailData"];
            int MessageId = Convert.ToInt32(htMoreDataformation["MessageId"]);
            UserRequirements UserReq = new UserRequirements();
            EmailDetails emaildet = new EmailDetails();
            EmailDetails objSaveEmailDetailsOfUser = new EmailDetails();
            EmailDetailsForUser UserEmailDetails = new EmailDetailsForUser();
            MembershipUser userToLogin = Membership.GetUser();
            Guid userid = (Guid)userToLogin.ProviderUserKey;
            Boolean isInboxDelete = false, isSentItemsDelete = false;

            try
            {


                EmailDetailsForUser email = new EmailDetailsForUser();


                int buyersidcount = UserReq.GetUserCountByUserId(userid);
                if (buyersidcount > 0) // If Buyer
                {
                    //to retrieve user message details history
                    UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 1);
                }
                else // If Seller
                {
                    //to retrieve user message details history
                    UserEmailDetails = emaildet.getUserDetailsOnMessageId(userid, MessageId, 0);
                }
                //for sending mail to correct place and saving correct data
                if (userToLogin != null && UserEmailDetails != null)
                {
                    if (userToLogin.IsLockedOut)
                    {
                        userToLogin.UnlockUser();
                    }
                    Hashtable hash = new Hashtable
                                     {
                                        
                                         {"ToUserName", UserEmailDetails.FromUserName}, // here sending person contact name is fromuserid as per database entry
                                         {"FromUserName", UserEmailDetails.ToUserName}, // here receiving person contact name is touserid as per database entry
                                         {"Subject", txtReplySubject.Text},
                                         {"EmailAddress",UserEmailDetails.fromEmailAddress },
                                         {"Message", txtReplyMessage.Text}
                                     };

                    //for finding exixting parentid

                    EmailFactory mailFactory = new EmailFactory();
                    Email mail = mailFactory.SendEmail(UserEmailDetails.fromEmailAddress, "support@icbrowser.com", txtReplySubject.Text, txtReplyMessage.Text, hash);

                    if (!string.IsNullOrEmpty(txtTo.Text))
                    {
                        //sending mail 
                        string filename = "";
                        int rturnmessageid = 0;
                        string File = string.Empty;
                        if (Session["FileUpload1"] != null)
                        {
                             File = Session["FileUpload1"].ToString();
                        }
                        
                        if (File != "")
                        {
                            FileUpload FileAttachmentLoadObj = (FileUpload)Session["FileUpload1"];
                            filename = FileAttachmentLoadObj.FileName;
                        }
                        //messageid = objSaveEmailDetailsOfUser.SaveMessageDetailsFromUsers(UserEmailDetails.FromUserId, UserEmailDetails.ToUserId, txtReplySubject.Text, txtReplyMessage.Text, DateTime.Now, 1, isInboxDelete, isSentItemsDelete, filename);

                        ////Save Message Details in Message Details Table

                        rturnmessageid = emaildet.SaveMessageDetails(UserEmailDetails.ToUserId, UserEmailDetails.FromUserId, txtReplySubject.Text, txtReplyMessage.Text, DateTime.Now, 1, isInboxDelete, isSentItemsDelete, MessageId, filename);
                        SaveAttchmentFile(rturnmessageid);
                        lblSentMessage.Visible = true;
                        lblnotSentMessage.Visible = false;

                        txtReplyMessage.Text = "";
                        txtReplySubject.Text = "";
                        txtTo.Text = "";
                        if (mail.Send())
                        {
                            Panel2.Visible = false;
                            Panel1.Visible = true;
                            lblSentMessage.Visible = true;
                            lblSentMessage.Text = "Message Sent Successfully..";
                            lnkfileAttachment.Visible = false;
                            lnkfileAttachment.Text = "";
                            FileAttachmentLoad.Visible = true;
                            btnUpload.Visible = true;
                            btnDelete.Visible = false;
                            txtReplyMessage.Text = "";
                            Session["FileUpload1"] = "";

                        }

                    }
                    else
                    {
                        lblSentMessage.Visible = false;
                        lblnotSentMessage.Visible = true;
                        lblnotSentMessage.Text = "Message  has not been Sent. Please try again later.";
                    }

                }
                else
                {

                    lblnotSentMessage.Text = "Message  has not been Sent. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                lblnotSentMessage.Text = "Message  has not been Sent. Please try again later.";

            }
            Panel1.Visible = true;
        }

        /// <summary>
        /// Saves the attachment file.
        /// </summary>
        /// <param name="Messageid">The messageid.</param>
        protected void SaveAttchmentFile(int Messageid)
        {
            try
            {

                if (Session["FileUpload1"] != null)
                {

                    FileUpload FileAttachmentLoad = (FileUpload)Session["FileUpload1"];
                    string path = ICBrowser.Web.Properties.Settings.Default.FileAttachment;
                    Directory.CreateDirectory(path + Messageid);
                    FileAttachmentLoad.SaveAs(path + Messageid + "//" + FileAttachmentLoad.FileName.Replace(" ", ""));
                    //if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["MessageAttachmentPath"]) + Messageid))
                    //    Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["MessageAttachmentPath"] + Messageid));
                    //FileAttachmentLoad.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["MessageAttachmentPath"] + Messageid + "//" + FileAttachmentLoad.FileName));
                }


            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lnkfileAttachment.Visible = false;
                lnkfileAttachment.Text = "";
                FileAttachmentLoad.Visible = true;
                btnUpload.Visible = true;
                btnDelete.Visible = false;
                txtReplyMessage.Text = "";
                lblerrormsg.Text = "";
                lblerrormsg.Visible = false;
                Panel2.Visible = false;
                lblSentMessage.Visible = false;
                lblnotSentMessage.Visible = false;
                Panel1.Visible = true;
                Session["FileUpload1"] = "";
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }


        }

        /// <summary>
        /// Remove attachment
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            try
            {
                Hashtable htMsgInformation = (Hashtable)Session["MsgDetails"];
                htMsgInformation.Remove("Page");
                htMsgInformation.Remove("PreviewRequestType");
                htMsgInformation.Add("Page", "Preview");
                htMsgInformation.Add("PreviewRequestType", "Back");
                Session["MsgDetails"] = htMsgInformation;
                //Response.Redirect("UserResponse.aspx",false);
                //(typeof(Page), "closePage", "window.close('close.html', '_self', null);", true)
                ClientScript.RegisterStartupScript(this.GetType(), "ClosePreview", "<script>window.close();</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }
        
        /// <summary>
        /// Link to view profile of CompanyHandles the Click event of the lnkCompanyName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkCompanyName_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = ViewState["fromuserid"].ToString();
                //Response.Redirect();
                string redUrl = "NewUserProfile.aspx?UserID=" + userid;
                ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }

        }

        /// <summary>
        /// Handles the TextChanged event of the txtReplyMessage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void txtReplyMessage_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnBack control and Redirect to inbox
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {

                ViewState["BindDataType"] = htMoreDataformation["BindDataType"];
                Panel2.Visible = false;
                lblSentMessage.Visible = false;
                lblnotSentMessage.Visible = false;
                Response.Redirect("EmailSentReceiveDetails.aspx?Page=Mail");
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click1 event of the lnkToCompanyName control and Redirect to user profile from inbox
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkToCompanyName_Click1(object sender, EventArgs e)
        {
            try
            {
                string userid = ViewState["fromuserid"].ToString();
                string redUrl = "NewUserProfile.aspx?UserID=" + userid;
                ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click1 event of the lnkCompanyName control and Redirect to user profile from Sent Item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkCompanyName_Click1(object sender, EventArgs e)
        {
            try
            {
                string userid = ViewState["fromuserid"].ToString();
                //Response.Redirect("NewUserProfile.aspx?UserID=" + userid);
                string redUrl = "NewUserProfile.aspx?UserID=" + userid;
                ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkAttachment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkAttachment_Click(object sender, EventArgs e)
        {
            Response.AddHeader("Content-Disposition", "attachment; filename=" + ViewState["FileName"].ToString());
            Response.ContentType = "application/octet-stream";
            string attachmentpath = ViewState["path"].ToString();
            Response.TransmitFile(attachmentpath);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// Handles the Click event of the btnUpload control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormsg.Text = "";
                lblerrormsg.Visible = false;
                lblSentMessage.Text = "";
                lblSentMessage.Visible = false;
                if (FileAttachmentLoad.FileName != "")
                {
                    string fileExtension = System.IO.Path.GetExtension(FileAttachmentLoad.FileName);

                    if (FileAttachmentLoad.PostedFile.ContentLength < 4200000)
                    {
                        //wait for the scan to complete

                        ProcessStartInfo startInfo = new ProcessStartInfo();

                        startInfo.FileName = @"C:\Program Files\ESET\ESET NOD32 Antivirus\ecls.exe";
                        string path = ICBrowser.Web.Properties.Settings.Default.MessageAttachment + Membership.GetUser().ProviderUserKey;
                        Directory.CreateDirectory(path);
                        FileAttachmentLoad.SaveAs(path + "\\" + FileAttachmentLoad.FileName.Replace(" ", ""));
                        string myprocarg = path + "\\" + FileAttachmentLoad.FileName.Replace(" ", "");
                        startInfo.Arguments = myprocarg.Replace(" ", "");
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        Process myProcess = Process.Start(startInfo);
                        myProcess.WaitForExit();

                        if (myProcess.ExitCode == 0)
                        {
                            Session["FileUpload1"] = FileAttachmentLoad;
                            FileAttachmentLoad.Visible = false;
                            btnUpload.Visible = false;
                            lnkfileAttachment.Visible = true;
                            btnDelete.Visible = true;
                            lnkfileAttachment.Text = FileAttachmentLoad.FileName.Replace(" ", "") + " (";
                            //lnkfileAttachment.Text += "(" + FileAttachmentLoad.PostedFile.ContentType + ")";

                            lnkfileAttachment.Text += (FileAttachmentLoad.PostedFile.ContentLength / 1024.00).ToString("#.##") + "KB" + ")";
                            //lnkfileAttachment.PostBackUrl = myprocarg; //Server.MapPath("");
                            ViewState["UploadedFileURL"] = myprocarg;
                            //if (Directory.Exists(path))
                            //{
                            //    File.Delete(myprocarg);
                            //    Directory.Delete(path, true);
                            //}
                        }
                        else
                        {
                            if (Directory.Exists(path))
                            {
                                File.Delete(path + FileAttachmentLoad.FileName.Replace(" ", ""));
                                Directory.Delete(path);
                                lblerrormsg.Text = "File is Corrupted,Please upload another file.";
                            }
                        }

                    }
                    else
                    {
                        //lblerrormsg.Visible = true;
                        //lblerrormsg.Text = "Exceeds the 4 MB size limit,Please upload another file";
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Exceeds the 4 MB size limit, please upload another file');", true);  
                    }
                }
                else
                {
                    lblerrormsg.Visible = true;
                    lblerrormsg.Text = "No File Found,Please Select File.";
                }
            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            lblerrormsg.Visible = false;
            lblSentMessage.Text = "";
            lblSentMessage.Visible = false;
            //DirectoryInfo thisFolder = new DirectoryInfo(myprocarg);
            //thisFolder.Delete();
            FileAttachmentLoad.Visible = true;
            btnUpload.Visible = true;
            lnkfileAttachment.Visible = false;
            btnDelete.Visible = false;
            lnkfileAttachment.Text = "";
            Session["FileUpload1"] = "";


        }

        /// <summary>
        /// Handles the Click event of the lnkfileAttachment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkfileAttachment_Click(object sender, EventArgs e)
        {
            string URL = ViewState["UploadedFileURL"].ToString();
            FileInfo fileInfo = new FileInfo(URL);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.WriteFile(fileInfo.FullName);
            }
        }
    }
}
