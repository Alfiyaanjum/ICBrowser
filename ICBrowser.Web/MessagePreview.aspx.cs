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
    public partial class MessagePreview : System.Web.UI.Page
    {
        UserProfileDetails profiledetais = new UserProfileDetails();
        Common.UserProfile objuserpro = new Common.UserProfile();
        MembershipUser userToLogin = Membership.GetUser();

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (userToLogin != null)
                {
                    Hashtable htMsgInformation = (Hashtable)Session["MsgDetails"];
                    Guid Touserid = new Guid(htMsgInformation["userid"].ToString());
                    string Message = Session["Message"].ToString();
                    objuserpro = profiledetais.GetUserProfileDetails(Touserid);

                    lblSubjectValue.Text = htMsgInformation["subject"].ToString();
                    lblAttachmentValue.Text = htMsgInformation["lnkattachment"].ToString();
                    lblAttachmentURL.Text = htMsgInformation["attachmenturl"].ToString();

                    StringBuilder build = new StringBuilder();
                    build.Append("To,");
                    build.Append("<br/>");
                    build.Append("Email: " + "" + objuserpro.email);
                    build.Append("<br/>");
                    build.Append("Company Name: " + "" + objuserpro.CompanyName);
                    LitFroms.Text = build.ToString();

                    //MembershipUser userToLogin = Membership.GetUser();
                    Guid FromUserId = (Guid)userToLogin.ProviderUserKey;
                    objuserpro = profiledetais.GetUserProfileDetails(FromUserId);

                    StringBuilder builder = new StringBuilder();
                    builder.Append("From,");
                    builder.Append("<br/>");
                    builder.Append("Email: " + "" + objuserpro.email);
                    builder.Append("<br/>");
                    builder.Append("Company Name: " + "" + objuserpro.CompanyName);
                    LitTos.Text = builder.ToString();
                    builder.Append("<br/>");
                    LiteralMessage.Text = Message.ToString(); // Message.ToString() + htMsgInformation["content"].ToString().Replace("\r\n", "<br/>"); 
                }
                else
                {
                    Response.Redirect("Default.aspx",false);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }


        }

        //protected void BtnBack_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Hashtable htMsgInformation = (Hashtable)Session["MsgDetails"];
        //        //htMsgInformation.Remove("Page");
        //        //htMsgInformation.Remove("PreviewRequestType");
        //        //htMsgInformation.Add("Page", "Preview");
        //        //htMsgInformation.Add("PreviewRequestType", "Back");
        //        //Session["MsgDetails"] = htMsgInformation;
        //        //Response.Redirect("UserResponse.aspx",false);
        //        //(typeof(Page), "closePage", "window.close('close.html', '_self', null);", true)
        //        //ClientScript.RegisterStartupScript(this.GetType(), "ClosePreview", "<script>window.close();</script>");
        //        AjaxControlToolkit.ModalPopupExtender modalpop = (AjaxControlToolkit.ModalPopupExtender)Page.PreviousPage.FindControl("modpopPreview");
        //        modalpop.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogMessage(ex.Message.ToString());
        //    }

        //}


        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable htMsgInformation = (Hashtable)Session["MsgDetails"];
                Guid Touserid = new Guid(htMsgInformation["userid"].ToString());
                //  Label lblCorrectMsg = null;
                EmailDetails objSaveEmailDetailsOfUser = new EmailDetails();

                bool isInboxDelete = false, isSentItemsDelete = false;
                Guid userFrom = (Guid)Membership.GetUser().ProviderUserKey;
                List<Guid> UserIds = new List<Guid>();
                MembershipUser user = Membership.GetUser();
                string userName = user.UserName;

                string Message = Session["Message"].ToString();

                string from = htMsgInformation["from"].ToString();
                string Subject = htMsgInformation["subject"].ToString();
                string Content = htMsgInformation["content"].ToString();

                Common.UserProfile objuserpro = new Common.UserProfile();
                UserProfileDetails profiledetais = new UserProfileDetails();

                objuserpro = profiledetais.GetUserProfileDetails(Touserid);

                string ToUserDetail = string.Concat(objuserpro.ContactName, " ", objuserpro.CompanyName, " ", objuserpro.FaxNumber);

                Hashtable hash = new Hashtable { { "ToUserName", objuserpro.ContactName },
                                                     { "FromUserName", userName },
                                                     { "Subject", Subject },
                                                     { "Message", Content} };
                EmailFactory mailFactory = new EmailFactory();
                Email mail = mailFactory.SendEmailBySellerId(objuserpro.email, "support@icbrowser.com", Subject, Message, hash);

                if (mail.Send())
                {
                    string filename = "";

                    int MessageId = 0;

                    string File = Session["FileUpload1"].ToString();
                    if (File != "")
                    {

                        FileUpload FileAttachmentLoad = (FileUpload)Session["FileUpload1"];
                        filename = FileAttachmentLoad.FileName;
                    }
                    MessageId = objSaveEmailDetailsOfUser.SaveMessageDetailsFromUsers(userFrom, Touserid, Subject, Message, DateTime.Now, 1, isInboxDelete, isSentItemsDelete, filename);
                    SaveAttchmentFile(MessageId);
                    //htMsgInformation.Remove("Page");
                    //htMsgInformation.Remove("PreviewRequestType");
                    //htMsgInformation.Add("Page", "Preview");
                    //htMsgInformation.Add("PreviewRequestType", "Sent");
                    //Session["MsgDetails"] = htMsgInformation;
                    //Response.Redirect("UserResponse.aspx", false);

                    //Delete File From MessageAttachment
                    String delpath = ICBrowser.Web.Properties.Settings.Default.MessageAttachment + Membership.GetUser().ProviderUserKey;
                    if (Directory.Exists(delpath))
                    {                        
                        Directory.Delete(delpath, true);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "SendSuccess", "<script>alert('Message sent successfully.');</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "ClosePreview", "<script>window.close();</script>");
                    AjaxControlToolkit.ModalPopupExtender modalpop = (AjaxControlToolkit.ModalPopupExtender)Page.PreviousPage.FindControl("modpopPreview");
                    modalpop.Hide();
                }
                else
                {
                    //htMsgInformation.Remove("PreviewRequestType");
                    //htMsgInformation.Add("PreviewRequestType", "NotSent");
                    //htMsgInformation.Add("Page", "Preview");
                    //Response.Redirect("UserResponse.aspx", false);
                    ClientScript.RegisterStartupScript(this.GetType(), "SendFail", "<script>alert('Message sending failed.');</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "ClosePreview", "<script>window.close();</script>");
                    AjaxControlToolkit.ModalPopupExtender modalpop = (AjaxControlToolkit.ModalPopupExtender)Page.PreviousPage.FindControl("modpopPreview");
                    modalpop.Hide();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Saves the attchment file.
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
                    Session["msgid"] = Messageid;
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
        /// Handles the Click event of the lblAttachmentValue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lblAttachmentValue_Click(object sender, EventArgs e)
        {
            string URL = lblAttachmentURL.Text;
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