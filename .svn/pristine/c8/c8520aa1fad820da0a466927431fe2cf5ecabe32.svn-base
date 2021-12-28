using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Web.Security;

//Last
namespace ICBrowser.Web
{
    public partial class StaticData : BasePage
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
                MembershipUser userToLogin = Membership.GetUser();
                Guid currUserId = (Guid)userToLogin.ProviderUserKey;

                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(currUserId);
                if (Admin.IsAdmin == true)
                {
                    //ClearContent();
                    //if (!IsPostBack)
                    //{
                    SetDefaultView();
                    //}
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
            ClearContent();
        }

        /// <summary>
        /// Clears the content.
        /// </summary>
        private void ClearContent()
        {
            try
            {
                lblmsg.Visible = false;
                lblMesg.Visible = false;
                lblMesg1.Visible = false;
                lblmsg1.Visible = false;
                lblMesg2.Visible = false;
                lblmsg2.Visible = false;
                lblSucess.Visible = false;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Sets the default view.
        /// </summary>
        private void SetDefaultView()
        {
            myMV.ActiveViewIndex = 0;
            AdminStaticData asd = new AdminStaticData();
            EscrowDetails escrow = new EscrowDetails();

            escrow = asd.GetStaticAboutUsData();
            EngAu.Content = Server.HtmlDecode(escrow.StaticEnIN);
            CnAu.Content = Server.HtmlDecode(escrow.StaticZhCN);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkTab1').style.color='green';", true);
        }

        /// <summary>
        /// Handles the Click event of the lnkTab1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkTab1_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            EscrowDetails escrow = new EscrowDetails();
            escrow = asd.GetStaticAboutUsData();

            EngAu.Content = Server.HtmlDecode(escrow.StaticEnIN);
            CnAu.Content = Server.HtmlDecode(escrow.StaticZhCN);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkTab1').style.color='green';", true);
            myMV.ActiveViewIndex = 0;

            lblmsg.Visible = false;
            lblMesg.Visible = false;

        }
        /// <summary>
        /// Handles the Click event of the lnkTab2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkTab2_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();

            EscrowDetails escrow = new EscrowDetails();

            escrow = asd.GetStaicEscrowData();

            EngEs.Content = Server.HtmlDecode(escrow.StaticEnIN);
            CnEs.Content = Server.HtmlDecode(escrow.StaticZhCN);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkTab2').style.color='green';", true);
            myMV.ActiveViewIndex = 1;

            lblMesg1.Visible = false;
            lblmsg1.Visible = false;


        }
        /// <summary>
        /// Handles the Click event of the lnkTab4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkTab4_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            Common.ContactUs cu = new Common.ContactUs();
            cu = asd.GetStaticContactUsData();

            EngCu.Content = Server.HtmlDecode(cu.StaticEnIN);
            CnCu.Content = Server.HtmlDecode(cu.StaticZhCN);

            txtCustSerEmail.Text = cu.CustServiceEmail;
            txtCustSerPhNo.Text = cu.CustServicePhNo;

            txtAddEmail.Text = cu.AdvertisementEmail;
            txtAddPno.Text = cu.AdvertisementPhNo;

            txtSalesEmail.Text = cu.SalesOfficeEmail;
            txtSalesPno.Text = cu.SalesOfficePhNo;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkTab4').style.color='green';", true);
            myMV.ActiveViewIndex = 2;

            lblmsg2.Visible = false;
            lblMesg2.Visible = false;
        }



        /// <summary>       
        /// Description:Saves Data and Image for AboutUs  page      
        /// </summary>      
        protected void btnSubAu_Click(object sender, EventArgs e)
        {
            try
            {
                EscrowDetails ed = new EscrowDetails();
                this.EngAu.Content = Server.HtmlEncode(this.EngAu.Content);
                this.CnAu.Content = Server.HtmlEncode(this.CnAu.Content);
                ed.StaticEnIN = EngAu.Content;
                ed.StaticZhCN = CnAu.Content;
                AdminStaticData Asd = new AdminStaticData();
                Asd.UpdateAboutUs(ed);
                SaveImageAu();
                lblSucess.Visible = true;
                this.EngAu.Content = Server.HtmlDecode(this.EngAu.Content);
                this.CnAu.Content = Server.HtmlDecode(this.CnAu.Content);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Saves the image au.
        /// </summary>
        private void SaveImageAu()
        {
            if (FuImage.HasFile)
            {
                if (FuImage.PostedFile.ContentLength < 4200000)
                {
                    string fileext = System.IO.Path.GetExtension(FuImage.FileName.ToLower());
                    if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                    {
                        try
                        {
                            AdminStaticData asd = new AdminStaticData();
                            string filename = Server.MapPath("~/Images/StaticUploads/") + System.IO.Path.GetFileName(FuImage.FileName);
                            FuImage.SaveAs(filename);
                            EscrowDetails ed = new EscrowDetails();
                            ed.ImagePath = "~/Images/StaticUploads/" + FuImage.FileName;
                            asd.UpdateStaticImageAu(ed);
                            lblMesg.Visible = true;
                            lblmsg.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            IClogger.LogError(ex.Message);
                        }
                    }
                    else
                    {
                        lblMesg.Visible = false;
                        lblmsg.Visible = true;
                    }
                }

                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Exceeds the 4 MB size limit,Please upload another file.";
                }
            }
        }

        /// <summary>       
        /// Description:Saves Data and Image for Transaction Guideline page
        /// </summary>     
        protected void btnSubEs_Click(object sender, EventArgs e)
        {
            try
            {
                EscrowDetails ed = new EscrowDetails();
                this.EngEs.Content = Server.HtmlEncode(this.EngEs.Content);
                this.CnEs.Content = Server.HtmlEncode(this.CnEs.Content);
                ed.StaticEnIN = EngEs.Content;
                ed.StaticZhCN = CnEs.Content;
                AdminStaticData Asd = new AdminStaticData();
                Asd.UpdateEscroSecurity(ed);
                SaveImageEs();
                lblSucess.Visible = true;
                this.EngEs.Content = Server.HtmlDecode(this.EngEs.Content);
                this.CnEs.Content = Server.HtmlDecode(this.CnEs.Content);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Saves the image es.
        /// </summary>
        private void SaveImageEs()
        {

            if (FuImage1.HasFile)
            {
                if (FuImage1.PostedFile.ContentLength < 4200000)
                {
                    string fileext = System.IO.Path.GetExtension(FuImage1.FileName.ToLower());
                    if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                    {
                        try
                        {
                            AdminStaticData asd = new AdminStaticData();
                            string filename = Server.MapPath("~/Images/StaticUploads/") + System.IO.Path.GetFileName(FuImage1.FileName);
                            FuImage1.SaveAs(filename);
                            EscrowDetails ed = new EscrowDetails();
                            ed.ImagePath = "~/Images/StaticUploads/" + FuImage1.FileName;
                            asd.UpdateStaticImageEs(ed);
                            lblmsg1.Visible = false;
                            lblMesg1.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            IClogger.LogError(ex.Message);
                        }
                    }
                    else
                    {
                        lblMesg1.Visible = false;
                        lblmsg1.Visible = true;
                    }
                }
                else
                {
                    lblmsg1.Visible = true;
                    lblmsg1.Text = "Exceeds the 4 MB size limit,Please upload another file.";
                }

            }
        }

        /// <summary>       
        /// Description:Saves Data image for ContactUs Page        
        /// </summary>           
        protected void btnSubCu_Click(object sender, EventArgs e)
        {
            try
            {
                // EscrowDetails ed = new EscrowDetails();
                AdminStaticData Asd = new AdminStaticData();
                Common.ContactUs cu = new Common.ContactUs();

                cu.CustServiceEmail = txtCustSerEmail.Text;
                cu.CustServicePhNo = txtCustSerPhNo.Text;

                cu.AdvertisementEmail = txtAddEmail.Text;
                cu.AdvertisementPhNo = txtAddPno.Text;

                cu.SalesOfficeEmail = txtSalesEmail.Text;
                cu.SalesOfficePhNo = txtSalesPno.Text;

                this.EngCu.Content = Server.HtmlEncode(this.EngCu.Content);
                this.CnCu.Content = Server.HtmlEncode(this.CnCu.Content);

                cu.StaticEnIN = EngCu.Content;
                cu.StaticZhCN = CnCu.Content;

                Asd.UpdateContactUs(cu);
                SaveImageCu();
                lblSucess.Visible = true;
                this.EngCu.Content = Server.HtmlDecode(this.EngCu.Content);
                this.CnCu.Content = Server.HtmlDecode(this.CnCu.Content);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Saves the image cu.
        /// </summary>
        private void SaveImageCu()
        {
            if (FuImage3.HasFile)
            {
                if (FuImage3.PostedFile.ContentLength < 4200000)
                {
                    string fileext = System.IO.Path.GetExtension(FuImage3.FileName.ToLower());
                    if (fileext.Equals(".jpg") || fileext.Equals(".jpeg") || fileext.Equals(".png") || fileext.Equals(".gif"))
                    {
                        try
                        {
                            AdminStaticData asd = new AdminStaticData();
                            string filename = Server.MapPath("~/Images/StaticUploads/") + System.IO.Path.GetFileName(FuImage3.FileName);
                            FuImage3.SaveAs(filename);
                            EscrowDetails ed = new EscrowDetails();
                            ed.ImagePath = "~/Images/StaticUploads/" + FuImage3.FileName;
                            asd.UpdateStaticImageCu(ed);
                            lblmsg2.Visible = false;
                            lblMesg2.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            IClogger.LogError(ex.Message);
                        }
                    }
                    else
                    {
                        lblMesg2.Visible = false;
                        lblmsg2.Visible = true;
                    }
                }

                else
                {
                    lblmsg2.Visible = true;
                    lblmsg2.Text = "Exceeds the 4 MB size limit,Please upload another file.";
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCanAu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Clear buttons
        protected void btnCanAu_Click(object sender, EventArgs e)
        {
            EngAu.Content = string.Empty;
            CnAu.Content = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnCanEs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCanEs_Click(object sender, EventArgs e)
        {
            EngEs.Content = string.Empty;
            CnEs.Content = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnCanCu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnCanCu_Click(object sender, EventArgs e)
        {
            EngCu.Content = string.Empty;
            CnCu.Content = string.Empty;
        }




        /// <summary>
        /// Binds the d dl.
        /// </summary>
        public void BindDDl()
        {
            List<Common.FAQ> allFaq = new List<Common.FAQ>();
            AdminStaticData asd = new AdminStaticData();



            allFaq = asd.GetFaqData();

            for (int i = 0; i < allFaq.Count; i++)
            {
                allFaq[i].Index = i + 1;
            }

            if (allFaq.Count != 0)
            {
                ddlQueId.DataSource = allFaq;
                ddlQueId.DataTextField = "Index";
                ddlQueId.DataValueField = "QuestionId";
                ddlQueId.DataBind();
                ddlQueId.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlQueId.SelectedIndex = 0;
                ddlLang.SelectedIndex = 1;
            }

        }

        /// <summary>
        /// Handles the Click event of the lbtnFaq control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnFaq_Click(object sender, EventArgs e)
        {
            BindDDl();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lbtnFaq').style.color='green';", true);
            Common.FAQ faq = new Common.FAQ();

            myMV.ActiveViewIndex = 3;
            faq = GetFaqbyQuestionNo(1);
            queEdtr.Content = Server.HtmlDecode(faq.QuestionEng);
            ansEdtr.Content = Server.HtmlDecode(faq.AnswerEng);
            lblmsg2.Visible = false;
            lblMesg2.Visible = false;
        }

        /// <summary>
        /// Gets the faqby question no.
        /// </summary>
        /// <param name="QueId">The que identifier.</param>
        /// <returns>Common.FAQ.</returns>
        public Common.FAQ GetFaqbyQuestionNo(int QueId)
        {
            Common.FAQ faq = new Common.FAQ();
            AdminStaticData asd = new AdminStaticData();
            faq = asd.GetFaqbyQueId(QueId);
            return faq;
        }

        /// <summary>
        /// Handles the Click event of the btnQueSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnQueSave_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            Common.FAQ faq = new Common.FAQ();
            if (ddlLang.SelectedIndex == 1)
            {
                int ddlQuestionIndex = Convert.ToInt32(ddlQueId.SelectedValue);

                faq.QuestionId = ddlQuestionIndex;
                queEdtr.Content = Server.HtmlEncode(queEdtr.Content);
                ansEdtr.Content = Server.HtmlEncode(ansEdtr.Content);

                faq.QuestionEng = queEdtr.Content;
                faq.AnswerEng = ansEdtr.Content;

                queEdtr.Content = Server.HtmlDecode(queEdtr.Content);
                ansEdtr.Content = Server.HtmlDecode(ansEdtr.Content);

                asd.UpdateEngFaq(faq);
                lblSucess.Visible = true;
                lblSucess.Text = "Question Changed Successfully";
            }
            else
            {
                int ddlQuestionIndex = Convert.ToInt32(ddlQueId.SelectedValue);

                faq.QuestionId = ddlQuestionIndex;
                queEdtr.Content = Server.HtmlEncode(queEdtr.Content);
                ansEdtr.Content = Server.HtmlEncode(ansEdtr.Content);

                faq.QuestionCny = queEdtr.Content;
                faq.AnswerCny = ansEdtr.Content;

                asd.UpdateCnyFaq(faq);
                lblSucess.Visible = true;

                queEdtr.Content = Server.HtmlDecode(queEdtr.Content);
                ansEdtr.Content = Server.HtmlDecode(ansEdtr.Content);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnQueClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnQueClear_Click(object sender, EventArgs e)
        {
            ddlLang.SelectedIndex = 0;
            ddlQueId.SelectedIndex = 0;
            queEdtr.Content = string.Empty;
            ansEdtr.Content = string.Empty;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlQueId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlQueId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.FAQ faq = new Common.FAQ();

            int ddlIndex = Convert.ToInt32(ddlQueId.SelectedValue);

            if (ddlLang.SelectedIndex == 1)
            {
                faq = GetFaqbyQuestionNo(ddlIndex);
                queEdtr.Content = Server.HtmlDecode(faq.QuestionEng);
                ansEdtr.Content = Server.HtmlDecode(faq.AnswerEng);
            }
            else if (ddlLang.SelectedIndex == 2)
            {
                faq = GetFaqbyQuestionNo(ddlIndex);
                queEdtr.Content = Server.HtmlDecode(faq.QuestionCny);
                ansEdtr.Content = Server.HtmlDecode(faq.AnswerCny);
            }
            else
            {
                ddlLang.SelectedIndex = 1;
                faq = GetFaqbyQuestionNo(ddlIndex);
                queEdtr.Content = Server.HtmlDecode(faq.QuestionEng);
                ansEdtr.Content = Server.HtmlDecode(faq.AnswerEng);

            }

        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlQueId.SelectedIndex != 0)
            {
                int ddlQuestionIndex = Convert.ToInt32(ddlQueId.SelectedValue);
                AdminStaticData asd = new AdminStaticData();
                asd.DeleteFaq(ddlQuestionIndex);
                lblSucess.Visible = true;
                lblSucess.Text = "Question Deleted Successfully";
                queEdtr.Content = "";
                ansEdtr.Content = "";
                BindDDl();               
            }
            else
            {
                lblError.Text = "Please Select Question to Delete From Drop Down List";
                lblError.Visible = true;
            }


        }


        /// <summary>
        /// Legal Agreement Page events and methods.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>

        protected void lnkBtnLegalAgreement_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            EscrowDetails escrow = new EscrowDetails();
            escrow = asd.GetStaticLegalAgreementData();

            edtrLegalAgreeEng.Content = Server.HtmlDecode(escrow.StaticEnIN);
            edtrLegalAgreeCn.Content = Server.HtmlDecode(escrow.StaticZhCN);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkBtnLegalAgreement').style.color='green';", true);
            myMV.ActiveViewIndex = 5;
        }

        /// <summary>
        /// Handles the Click event of the btnSaveLegalAgree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSaveLegalAgree_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            EscrowDetails ed = new EscrowDetails();

            edtrLegalAgreeEng.Content = Server.HtmlEncode(edtrLegalAgreeEng.Content);
            edtrLegalAgreeCn.Content = Server.HtmlEncode(edtrLegalAgreeCn.Content);

            ed.StaticEnIN = edtrLegalAgreeEng.Content;
            ed.StaticZhCN = edtrLegalAgreeCn.Content;

            edtrLegalAgreeEng.Content = Server.HtmlDecode(edtrLegalAgreeEng.Content);
            edtrLegalAgreeCn.Content = Server.HtmlDecode(edtrLegalAgreeCn.Content);
            asd.UpdateLegalAgreementData(ed);
            lblSucess.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the btnClearLegalAgree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClearLegalAgree_Click(object sender, EventArgs e)
        {
            edtrLegalAgreeEng.Content = string.Empty;
            edtrLegalAgreeCn.Content = string.Empty;
            lblSucess.Visible = false;
            lblError.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the lbtnWhyUs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbtnWhyUs_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();

            WhyUs whyUs = new WhyUs();

            whyUs = asd.GetWhyUsData();

            edtrlblWhyUsEng.Content = Server.HtmlDecode(whyUs.QuestionEng);
            edtrWhyUsCn.Content = Server.HtmlDecode(whyUs.QuestionCny);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lbtnWhyUs').style.color='green';", true);
            myMV.ActiveViewIndex = 4;

            lblMesg1.Visible = false;
            lblmsg1.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the btnSavewhyUs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSavewhyUs_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            WhyUs ed = new WhyUs();

           
            edtrlblWhyUsEng.Content = Server.HtmlEncode(edtrlblWhyUsEng.Content);
            edtrWhyUsCn.Content = Server.HtmlEncode(edtrWhyUsCn.Content);

            ed.QuestionEng = edtrlblWhyUsEng.Content;
            ed.QuestionCny = edtrWhyUsCn.Content;

            edtrlblWhyUsEng.Content = Server.HtmlDecode(edtrlblWhyUsEng.Content);
            edtrWhyUsCn.Content = Server.HtmlDecode(edtrWhyUsCn.Content);
            asd.UpdateWhyUsData(ed);
            lblSucess.Visible = true;

        }

        /// <summary>
        /// Handles the Click event of the btnClearwhyus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClearwhyus_Click(object sender, EventArgs e)
        {
            
            edtrlblWhyUsEng.Content = string.Empty;
            edtrWhyUsCn.Content = string.Empty;
            lblSucess.Visible = false;
            lblError.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the lnkBtnPrivacyPolicy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkBtnPrivacyPolicy_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();


            PrivatePolicy privatepolicy = new PrivatePolicy();

            privatepolicy = asd.GetPrivatePolicy();


            edtrPrivatePolicyEng.Content = Server.HtmlDecode(privatepolicy.PrivatePolicyEn);
            edtrPrivatePolicyCn.Content = Server.HtmlDecode(privatepolicy.PrivatePolicyCn);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "document.getElementById('MainContent_lnkBtnPrivacyPolicy').style.color='green';", true);
            myMV.ActiveViewIndex = 6;

            lblMesg1.Visible = false;
            lblmsg1.Visible = false;
        }



        /// <summary>
        /// Handles the Click event of the btnSavePrivatePolicy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSavePrivatePolicy_Click(object sender, EventArgs e)
        {
            AdminStaticData asd = new AdminStaticData();
            PrivatePolicy policy = new PrivatePolicy();


            edtrPrivatePolicyEng.Content = Server.HtmlEncode(edtrPrivatePolicyEng.Content);
            edtrPrivatePolicyCn.Content = Server.HtmlEncode(edtrPrivatePolicyCn.Content);

            policy.PrivatePolicyEn = edtrPrivatePolicyEng.Content;
            policy.PrivatePolicyCn = edtrPrivatePolicyCn.Content;

            edtrPrivatePolicyEng.Content = Server.HtmlDecode(edtrPrivatePolicyEng.Content);
            edtrPrivatePolicyCn.Content = Server.HtmlDecode(edtrPrivatePolicyCn.Content);
            asd.UpdatePrivetPolicy(policy);
            lblSucess.Visible = true;
        }



        /// <summary>
        /// Handles the Click event of the btnClearPrivatePolicy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClearPrivatePolicy_Click(object sender, EventArgs e)
        {
            
            edtrPrivatePolicyEng.Content = string.Empty;
            edtrPrivatePolicyCn.Content = string.Empty;
            lblSucess.Visible = false;
            lblError.Visible = false;
        }

    }
}