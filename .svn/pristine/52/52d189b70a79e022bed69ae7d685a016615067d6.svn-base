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
    [Serializable]
    public class UserMatchRequirements
    {
        public Guid userId { get; set; }
        public string ComponentName { get; set; }
        public string DateCode { get; set; }
        public decimal PriceInUSD { get; set; }
        public string package { get; set; }
        public int Quantity { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int Flag { get; set; }
        public List<ICBrowser.Common.Component> Components { get; set; }

    }
    public partial class UserResponse : BasePage
    {

        StringBuilder builder = new StringBuilder();
        List<Common.Component> values = new List<Common.Component>();
        string typeName = "";
        //static string prevPage = String.Empty;
        Hashtable htMsgInfo = new Hashtable();
        Hashtable htMsgInformation = new Hashtable();
        Hashtable htMoreDataformation = new Hashtable();
        string PageType = "";
        MembershipUser userToLogin = Membership.GetUser();
        Hashtable htSrchHistory = new Hashtable();


        private void PreviousPageOnBackButtonClick()
        {
            // Need to use session for storing previous page value.
            // On Localization Page is Post back Twice so prevPage Lost its previous value stored.
            // hence to remember previous value of 'prevPage', Session["PreviousPageValue"] is used. which is clean after its use.

            try
            {
                string prevPage = string.Empty;
                prevPage = Request.UrlReferrer.ToString();
                if (Session["PreviousPageValue"] == null)
                {
                    //Session is Created.
                    Session["PreviousPageValue"] = prevPage;

                }
                else
                {
                    if (prevPage.Equals(Session["PreviousPageValue"].ToString()))
                    {
                        prevPage = Request.UrlReferrer.ToString();
                        Session.Remove("PreviousPageValue");
                        // do nothing
                    }
                    else
                    {
                        prevPage = Request.UrlReferrer.ToString();
                        //prevPage = Session["PreviousPageValue"].ToString();

                        //Session is destroy it of not no use now. It is of no use.,
                        Session.Remove("PreviousPageValue");
                    }
                }
                ViewState["ThePrevPage"] = prevPage;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (userToLogin != null)
                {
                    if (!Page.IsPostBack)
                    {
                        PreviousPageOnBackButtonClick();
                        htMoreDataformation = (Hashtable)Session["GetList"];
                        PageType = htMoreDataformation["Page"].ToString();
                        lnkfileAttachment.Text = "";
                        FileAttachmentLoad.Visible = true;
                        btnUpload.Visible = true;
                        lnkfileAttachment.Visible = false;
                        btnDelete.Visible = false;

                        if (Session["MsgDetails"] != null)
                        {
                            htMsgInformation = (Hashtable)Session["MsgDetails"];
                            PageType = htMsgInformation["Page"].ToString();

                            string PreviewRequestType = htMsgInformation["PreviewRequestType"].ToString();
                            if (PreviewRequestType == "Sent")
                            {
                                lblSend.Visible = true;
                                lblSend.Text = "Message sent Successfully.";
                                Session["FileUpload1"] = "";
                                FileAttachmentLoad.Visible = true;
                                btnUpload.Visible = true;
                                htMsgInformation.Remove("PreviewRequestType");
                                htMsgInformation.Add("PreviewRequestType", "");


                            }
                            else if (PreviewRequestType == "NotSent")
                            {
                                lblError.Visible = true;
                                lblError.Text = "Error Occurred in sending mail. Please try again later.";
                                Session["FileUpload1"] = "";
                                FileAttachmentLoad.Visible = true;
                                btnUpload.Visible = true;
                                htMsgInformation.Remove("PreviewRequestType");
                                htMsgInformation.Add("PreviewRequestType", "");

                            }
                            else
                            {
                                lblerrormsg.Text = "";
                                lblerrormsg.Visible = false;
                                lblSend.Text = "";
                                lblSend.Visible = false;
                                if (PreviewRequestType != "Back")
                                {
                                    Session["MsgDetails"] = null;
                                }
                                else
                                {
                                    //txtContent.Text = htMoreDataformation["htMsgInfo"].ToString();
                                    typeName = htMoreDataformation["RequestType"].ToString();
                                    Guid touserid = new Guid(htMoreDataformation["UserId"].ToString());
                                    //Session["FileUpload1"] = "";
                                    htMsgInfo.Add("RequestType", typeName);
                                    htMsgInfo.Add("userid", touserid);
                                }

                                string File = Session["FileUpload1"].ToString();
                                if (File != "")
                                {
                                    lnkfileAttachment.Text = htMsgInformation["lnkattachment"].ToString();
                                    lnkfileAttachment.Visible = true;
                                    btnDelete.Visible = true;
                                    FileAttachmentLoad.Visible = false;
                                    btnUpload.Visible = false;
                                }
                                else
                                {
                                    FileAttachmentLoad.Visible = true;
                                    btnUpload.Visible = true;
                                }
                            }


                        }
                        else
                        {
                            lblerrormsg.Text = "";
                            lblerrormsg.Visible = false;
                            lblSend.Text = "";
                            lblSend.Visible = false;
                            Session["FileUpload1"] = "";
                            typeName = htMoreDataformation["RequestType"].ToString();
                            Guid touserid = new Guid(htMoreDataformation["UserId"].ToString());
                            htMsgInfo.Add("RequestType", typeName);
                            htMsgInfo.Add("userid", touserid);
                        }
                    }

                    UserProfileDetails profiledetais = new UserProfileDetails();
                    Common.UserProfile objuserpro = new Common.UserProfile();
                    Common.UserProfile objuserproto = new Common.UserProfile();

                    //to check response is for Offer or Requirement
                    if (!Page.IsPostBack)
                    {

                        List<Common.Component> MoreDatavalues = new List<Common.Component>();
                        MoreDatavalues = htMoreDataformation["Values"] as List<ICBrowser.Common.Component>;
                        RepSendMsg.DataSource = MoreDatavalues;
                        RepSendMsg.DataBind();

                        //MembershipUser userToLogin = Membership.GetUser();
                        Guid FromUserId = (Guid)userToLogin.ProviderUserKey;
                        Guid ToUserId = new Guid(htMoreDataformation["UserId"].ToString());
                        objuserpro = profiledetais.GetUserProfileDetails(FromUserId);
                        objuserproto = profiledetais.GetUserProfileDetails(ToUserId);

                        txtFrom.Text = objuserpro.email;
                        txtbxTo.Text = objuserproto.email;



                        if (Session["MsgDetails"] != null)
                        {
                            htMsgInformation = (Hashtable)Session["MsgDetails"];
                            string PreviewRequestType = htMsgInformation["PreviewRequestType"].ToString();
                            if (PreviewRequestType != "Back")
                            {
                                txtSubject.Text = htMsgInformation["subject"].ToString();
                                txtContent.Text = htMsgInformation["content"].ToString();
                            }
                            else
                            {
                                txtSubject.Text += objuserpro.ContactName + "," + objuserpro.CompanyName;
                            }

                        }
                        else
                        {
                            txtSubject.Text += objuserpro.ContactName + "," + objuserpro.CompanyName;

                        }


                    }
                    lblerrormsg.Text = "";

                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }

        }

        // to send RFQ/Quotation in message         
        protected bool GetMessageData()
        {
            Guid touserid = new Guid();
            List<Common.Component> values1 = new List<Common.Component>();
            List<Common.Component> values2 = new List<Common.Component>();
            htMsgInformation = (Hashtable)Session["MsgDetails"];
            htMoreDataformation = (Hashtable)Session["GetList"];
            PageType = htMoreDataformation["Page"].ToString();


            foreach (RepeaterItem item in RepSendMsg.Items)
            {
                decimal unitprice = 0;
                decimal unitprice1 = 0;
                string v1 = "";
                TextBox txtpartNo = (TextBox)item.FindControl("txtpartNo");
                TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
                TextBox txtMake = (TextBox)item.FindControl("txtMake");
                TextBox txtPackage = (TextBox)item.FindControl("txtPackage");
                TextBox txtDateCode = (TextBox)item.FindControl("txtDateCode");
                TextBox txtUnitPrice = (TextBox)item.FindControl("txtUnitPriceUSD");
                TextBox txtComment = (TextBox)item.FindControl("txtComments");

                Label lblpartNo = (Label)item.FindControl("lblpartNo");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");
                Label lblMake = (Label)item.FindControl("lblMake");
                Label lblDateCode = (Label)item.FindControl("lblDateCode");
                Label lblUnitPrice = (Label)item.FindControl("lblUnitPrice");
                Label lblComments = (Label)item.FindControl("lblComments");

                CheckBox chb = (CheckBox)item.FindControl("chckbx");



                if (txtUnitPrice.Text != "")
                {
                    unitprice = Convert.ToDecimal(txtUnitPrice.Text);
                }

                if (lblUnitPrice.Text != "")
                {
                    unitprice1 = Convert.ToDecimal(lblUnitPrice.Text);
                }

                if (chb.Checked == true)
                {
                    if (unitprice != 0)
                    {
                        values1.Add(new Common.Component
                        {

                            ComponentName = txtpartNo.Text,
                            Quantity = Convert.ToInt32(txtQuantity.Text),
                            BrandName = txtMake.Text,
                            package = txtPackage.Text,
                            datecode = txtDateCode.Text,
                            PriceInUSD = unitprice,
                            Description = txtComment.Text

                        });
                    }
                    else
                    {
                        values1.Add(new Common.Component
                        {

                            ComponentName = txtpartNo.Text,
                            Quantity = Convert.ToInt32(txtQuantity.Text),
                            BrandName = txtMake.Text,
                            package = txtPackage.Text,
                            datecode = txtDateCode.Text,
                            Description = txtComment.Text

                        });
                    }


                    if (unitprice != 0)
                    {
                        values2.Add(new Common.Component
                        {

                            ComponentName = lblpartNo.Text,
                            Quantity = Convert.ToInt32(lblQuantity.Text),
                            BrandName = lblMake.Text,
                            package = txtPackage.Text,
                            datecode = lblDateCode.Text,
                            PriceInUSD = unitprice1,
                            Description = lblComments.Text

                        });
                    }
                    else
                    {
                        values2.Add(new Common.Component
                        {

                            ComponentName = lblpartNo.Text,
                            Quantity = Convert.ToInt32(lblQuantity.Text),
                            BrandName = lblMake.Text,
                            package = txtPackage.Text,
                            datecode = lblDateCode.Text,
                            Description = lblComments.Text

                        });
                    }

                }
            }
            if (values1.Count >= 1)
            {
                if (PageType != "MoreDetails")
                {
                    PageType = htMsgInformation["Page"].ToString();
                }
                else
                {
                    PageType = htMoreDataformation["Page"].ToString();
                    typeName = htMoreDataformation["RequestType"].ToString();
                }

                builder.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                builder.Append("<head>");
                builder.Append("<title>");

                builder.Append("</title>");
                builder.Append("</head>");
                builder.Append("<body>");
                builder.Append("<table border='1px' cellpadding='10' cellspacing='0' width ='100%'>");
                //builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");

                builder.Append("<tr align='left' valign='top'>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("");
                builder.Append("</td>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("Part No");
                builder.Append("</td>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("Quantity");
                builder.Append("</td>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("Make");
                builder.Append("</td>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("Package");
                builder.Append("</td>");

                builder.Append("<td align='left' valign='top'>");
                builder.Append("Date Code");
                builder.Append("</td>");


                builder.Append("<td align='left' valign='top'>");
                builder.Append("Unit price in IRs");
                builder.Append("</td>");


                builder.Append("<td align='left' valign='top'>");
                builder.Append("Comments");
                builder.Append("</td>");

                builder.Append("</tr>");

                bool flag = true;
                int j = 0;
                for (int i = 0; i <= values2.Count; i++)
                {
                    if (flag == true && i != values2.Count)
                    {
                        builder.Append("<tr align='left' valign='top'>");
                        builder.AppendLine();
                        if (typeName == "Offers")
                        {
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append("You Show:");

                        }
                        else
                        {
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append("You Need:");

                        }
                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(values2[i].ComponentName);
                        builder.Append("</td>");
                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(Convert.ToString(values2[i].Quantity));
                        builder.Append("</td>");
                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(values2[i].BrandName);
                        builder.Append("</td>");
                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(values2[i].package);
                        builder.Append("</td>");
                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(values2[i].datecode);
                        builder.Append("</td>");

                        builder.Append("<td align='left' valign='top'>");
                        if ((values2[i].PriceInUSD) == 0)
                        {
                            (values2[i].PriceInUSD) = null;
                        }
                        builder.Append(values2[i].PriceInUSD);
                        builder.Append("</td>");

                        builder.Append("<td align='left' valign='top'>");
                        builder.Append(values2[i].Description);
                        builder.Append("</td>");
                        builder.AppendLine();
                        builder.Append("</tr>");
                        flag = false;
                    }
                    else
                    {
                        for (; j < i; j++)
                        {
                            builder.Append("<tr align='left' valign='top'>");
                            builder.AppendLine();
                            if (typeName == "Offers")
                            {
                                builder.Append("<td align='left' valign='top'>");
                                builder.Append("I Need:");

                            }
                            else
                            {
                                builder.Append("<td align='left' valign='top'>");
                                builder.Append("I Have:");

                            }
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].ComponentName);
                            builder.Append("</td>");
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(Convert.ToString(values1[j].Quantity));
                            builder.Append("</td>");
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].BrandName);
                            builder.Append("</td>");
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].package);
                            builder.Append("</td>");
                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].datecode);
                            builder.Append("</td>");

                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].PriceInUSD);
                            builder.Append("</td>");

                            builder.Append("<td align='left' valign='top'>");
                            builder.Append(values1[j].Description);
                            builder.Append("</td>");
                            builder.AppendLine();

                            builder.Append("</tr>");
                            flag = true;

                        }
                        if (i != values2.Count)
                        {
                            i--;
                        }

                    }
                }
                builder.Append("</table>");
                builder.Append("</body>");
                builder.Append("<table>");
                builder.Append("<tr>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("<table>");
                builder.Append("<tr>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("<table>");
                builder.Append("<tr>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("</html>");

                builder.AppendLine();
                builder.AppendLine();
                builder.AppendLine();
                builder.AppendLine();
                builder.Append(txtContent.Text.Replace("\r\n", "<br/>"));

                values = Session["GetList"] as List<ICBrowser.Common.Component>;

                if (PageType != "Preview")
                {
                    typeName = htMoreDataformation["RequestType"].ToString();
                    touserid = new Guid(htMoreDataformation["UserId"].ToString());
                    htMsgInfo.Add("RequestType", typeName);
                    htMsgInfo.Add("userid", touserid);
                }
                else
                {
                    htMsgInformation = (Hashtable)Session["MsgDetails"];
                    typeName = htMsgInformation["RequestType"].ToString();
                    touserid = new Guid(htMsgInformation["userid"].ToString());
                    htMsgInfo.Add("RequestType", typeName);
                    htMsgInfo.Add("userid", touserid);
                }
                htMsgInfo.Add("Page", "Preview");
                htMsgInfo.Add("PreviewRequestType", "Back");
                htMsgInfo.Add("subject", txtSubject.Text);
                htMsgInfo.Add("from", txtFrom.Text);
                htMsgInfo.Add("content", txtContent.Text);
                htMsgInfo.Add("PartDetails", values);
                htMsgInfo.Add("lnkattachment", lnkfileAttachment.Text);
                if (ViewState["UploadedFileURL"] != null)
                    htMsgInfo.Add("attachmenturl", ViewState["UploadedFileURL"].ToString());
                else
                    htMsgInfo.Add("attachmenturl", "");
                //htMsgInfo.Add("userid", touserid);
                Session["MsgDetails"] = htMsgInfo;
                return true;
            }

            return false;
        }


        //to diplay selected message
        protected void HandleLinkClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = (LinkButton)sender;
                string Content = txtContent.Text;
                txtContent.Text = Content + Environment.NewLine + link.Text;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        protected void RepSendMsg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            htMoreDataformation = (Hashtable)Session["GetList"];


            //typeName = htMsgInformation["RequestType"].ToString();
            typeName = htMoreDataformation["RequestType"].ToString();

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lblshow = (Label)e.Item.FindControl("lblshow");
                Label lblNeed = (Label)e.Item.FindControl("lblNeed");
                Label lblpriceIrs = (Label)e.Item.FindControl("lblUnitPrice");

                if (lblpriceIrs.Text == "0" || lblpriceIrs.Text == "0.0" || lblpriceIrs.Text == "0.00" || lblpriceIrs.Text == "0.000")
                {
                    lblpriceIrs.Text = null;
                }

                if (typeName == "Offers")
                {

                    lblshow.Text = "You Show:";
                    lblNeed.Text = "I Need:";
                    divOffer.Visible = true;
                    txtSubject.Text = "RFQ- ";
                    if (htMoreDataformation["PartNo"] != null)
                    {
                        txtSubject.Text += "(" + htMoreDataformation["PartNo"] + ")";

                    }

                }
                else
                {
                    lblshow.Text = "You Need:";
                    lblNeed.Text = "I Have:";
                    divRequirement.Visible = true;

                    txtSubject.Text = "Quotation- ";
                    if (htMoreDataformation["PartNo"] != null)
                    {
                        txtSubject.Text += "(" + htMoreDataformation["PartNo"] + ")";

                    }
                }
            }
        }

        protected void RepSendMsg_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


        }

        protected void btnPrintPreview_Click(object sender, EventArgs e)
        {
            Guid ToUserId = new Guid();
            if (PageType == "Preview")
            {
                htMsgInformation = (Hashtable)Session["MsgDetails"];
                ToUserId = new Guid(htMsgInformation["userid"].ToString());
            }
            else
            {
                htMoreDataformation = (Hashtable)Session["GetList"];
                ToUserId = new Guid(htMoreDataformation["UserId"].ToString());

            }
            bool var = GetMessageData();
            if (var == true)
            {
                Session["Message"] = builder.ToString();
                modpopPreview.Show();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "alert('please select atleast one partno');", true);
            }
            //Response.Redirect("MessagePreview.aspx", false);
            //string prevUrl = ResolveUrl("~/MessagePreview.aspx");
            //ClientScript.RegisterStartupScript(this.GetType(), "PreviewMsg", "<script>window.open('" + prevUrl + "','','width=800,height=300,resizable= yes,scrollbars=yes');</script>");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormsg.Text = "";
                lblerrormsg.Visible = false;
                lblSend.Text = "";
                lblSend.Visible = false;
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
                        //lblerrormsg.Text = 

                        ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "alert('Exceeds the 4 MB size limit, please upload another file');", true);


                    }
                }
                else
                {
                    lblerrormsg.Visible = true;
                    lblerrormsg.Text = "No file found, please select file.";
                }
            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            lblerrormsg.Visible = false;
            lblSend.Text = "";
            lblSend.Visible = false;
            //DirectoryInfo thisFolder = new DirectoryInfo(myprocarg);
            //thisFolder.Delete();
            FileAttachmentLoad.Visible = true;
            btnUpload.Visible = true;
            lnkfileAttachment.Visible = false;
            btnDelete.Visible = false;
            lnkfileAttachment.Text = "";
            Session["FileUpload1"] = "";

            Session["msgid"] = "";
        }

        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            Session["FileUpload1"] = "";
            string prevpageUrl = "";
            if (Session["PreviousPageValue"] != null)
                prevpageUrl = Session["PreviousPageValue"].ToString();
            else
                prevpageUrl = ViewState["ThePrevPage"].ToString();
            Session["msgid"] = "";
            if (prevpageUrl.Contains("ComponentSearchFiltered.aspx"))
                Session["MsgCancld"] = "Yes";

            Response.Redirect(prevpageUrl);
        }

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
            else
            {
                fileInfo = new FileInfo(ICBrowser.Web.Properties.Settings.Default.FileAttachment + "\\" + Session["msgid"].ToString() + "\\" + ((FileUpload)Session["FileUpload1"]).FileName.Replace(" ", ""));
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name.Replace(" ", "")); //(FileUpload)Session["FileUpload1"]).FileName.Replace(" ", ""));
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.WriteFile(fileInfo.FullName);
            }
        }

    }
}
