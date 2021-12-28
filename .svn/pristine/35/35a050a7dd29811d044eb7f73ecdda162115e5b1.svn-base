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
using System.Data;
using System.Web.UI.HtmlControls;

namespace ICBrowser.Web
{
    public partial class NewUserProfile : BasePage
    {
        #region "BindData"
        static string prevPage = String.Empty;
        public Guid UserId;
        public Guid ViewUserProfileId;
        public int ratedMembershipTypeId = 0;
        InventoryGridDetails objInventoryGridDetails = new InventoryGridDetails(); //class Object
        UserProfileDetails Userprofile = new UserProfileDetails();

        Common.UserProfile objUserProfile = new Common.UserProfile(); //class Object
        public int typeOfMembershipId = 0;
        public bool freeMember = false;
        bool typeOfUser;

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MembershipUser userToLogin = Membership.GetUser();
                UserId = (Guid)userToLogin.ProviderUserKey;

                //chk for Admin.......
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(UserId);
                if (Admin.IsAdmin)
                {
                    // hyplnkBack.Visible = false;
                }
                else
                {
                    // hyplnkBack.Visible = false;
                }

                if (Request.QueryString["UserID"] != null)
                {
                    ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
                }



                objUserProfile = (Common.UserProfile)Session["UserProfile"];
                typeOfMembershipId = objUserProfile.TypeOfMembership;


                objUserProfile = objInventoryGridDetails.GetUserCountByUserId(ViewUserProfileId);
                ratedMembershipTypeId = objUserProfile.TypeOfMembership;

                //condition check for Logged In member and RatedMember
                chkConditionforRatings(typeOfMembershipId, ratedMembershipTypeId, Admin);

                //check condition for Admin
                chkConditionforAdmin(Admin);

                BindData(ViewUserProfileId);

                PreviousPageOnBackButtonClick();
            }
        }

        /// <summary>
        /// Previouses the page on back button click.
        /// </summary>
        private void PreviousPageOnBackButtonClick()
        {
            // Need to use session for storing previous page value.
            // On Localization Page is Post back Twice so prevPage Lost its previous value stored.
            // hence to remember previous value of 'prevPage', Session["PreviousPageValue"] is used. which is clean after its use.

            try
            {
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
                        // do nothing
                    }
                    else
                    {
                        prevPage = Session["PreviousPageValue"].ToString();

                        //Session is destroy it of not no use now. It is of no use.,
                        Session.Remove("PreviousPageValue");
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.ToString());
            }
        }

        /// <summary>
        /// CHKs the conditionfor ratings.
        /// </summary>
        /// <param name="typeOfMembershipId">The type of membership identifier.</param>
        /// <param name="ratedMembershipTypeId">The rated membership type identifier.</param>
        /// <param name="Admin">The admin.</param>
        private void chkConditionforRatings(int typeOfMembershipId, int ratedMembershipTypeId, Users Admin)
        {
            //check if the person logged In is Free and rated Person is also Free then Give Rating Link is made visible false
            if (typeOfMembershipId == 1 && ratedMembershipTypeId == 1)// (free=Free)
            {
                freeMember = true;
            }

            //check if LoggedInUser = RatedUser OR IF LoggedIn member is Trial OR LoggedIn(Free/Buyer) = RatedMember(Free/Buyer) and  they cant rate
            if (ViewUserProfileId == UserId || typeOfMembershipId == 2 || freeMember == true || ratedMembershipTypeId == 2)
            {
                lnkRate.Visible = false;
            }
            else
            {
                lnkRate.Visible = true;
            }

            //if View Profile is of Trial Member then dont show rating else need to show current rating of all Profile Member
            if (ratedMembershipTypeId == 2)
            {
                trCurrntrate.Visible = false;
            }
            else
            {
                if (ratedMembershipTypeId > 2 && ((typeOfMembershipId >= 1) || (Admin.IsAdmin == true))) //check if ViewProfile Person is a paid member Then show both his ratings as Seller and rating as Buyer
                {
                    //call Average rating of Buyer
                    trRatingAsBuyer.Visible = true;
                    typeOfUser = false;
                    calculateAverageRatings(ViewUserProfileId, typeOfUser);

                    //call Average rating of Seller
                    trRatingAsSeller.Visible = true;
                    typeOfUser = true;
                    calculateAverageRatings(ViewUserProfileId, typeOfUser);

                    trCurrntrate.Visible = false;
                }
                else
                {
                    //if Profile is of a Buyer (Free Member then show Avewrage rating of this Member as Buyer)
                    if (ratedMembershipTypeId == 1 && ((typeOfMembershipId >= 1) || (Admin.IsAdmin == true)))
                    {
                        trRatingAsBuyer.Visible = true;
                        trRatingAsSeller.Visible = false;
                        typeOfUser = false;
                        calculateAverageRatings(ViewUserProfileId, typeOfUser);
                    }
                    else
                    {
                        trRatingAsBuyer.Visible = false;
                        trRatingAsSeller.Visible = false;
                        trCurrntrate.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// CHKs the conditionfor admin.
        /// </summary>
        /// <param name="Admin">The admin.</param>
        private void chkConditionforAdmin(Users Admin)
        {
            if (Admin.IsAdmin)
            {
                lnkEmilAddress.Enabled = false;
                a1.Visible = true;
                a2.Visible = false;
                divcomment1.Visible = true;


                UserRatings UserRate = new UserRatings();
                List<Ratings> rate = new List<Ratings>();
                rate = UserRate.getCommentDetails(ViewUserProfileId);

                List<Fields> values = new List<Fields>();
                foreach (var i in rate)
                {
                    rate = UserRate.getCommentDetails(ViewUserProfileId);
                    objUserProfile = Userprofile.GetUserProfileDetails(i.FromUserId);
                    values.Add(new Fields
                    {
                        CompanyName = objUserProfile.CompanyName,
                        Comments = i.Comment,
                        UserId = i.ToUserId,
                        FromUserId = i.FromUserId,
                        ShortComment = i.Comment,
                        FullDetails = i.Comment

                    });
                    //string s = values[0].Comments;

                }

                for (int i = 0; values.Count > i; i++)
                {
                    if (rate[i].Comment != "")
                    {
                        if (rate[i].Comment.Length > 10)
                        {

                            values[i].ShortComment = rate[i].Comment.Substring(0, 10) + ".....";
                        }
                    }
                    else
                    {
                        values[i].ShortComment = "No Comment";
                        values[i].FullDetails = "No Comment";
                    }

                }

                RepDetailed.DataSource = values;
                RepDetailed.DataBind();



            }
            else
            {
                a1.Visible = false;
                a2.Visible = true;
            }
            //BindData(ViewUserProfileId);

        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <param name="userid">The userid.</param>
        private void BindData(Guid userid)
        {
            try
            {
                Common.UserProfile objUserProfile = new Common.UserProfile();
                UserProfileDetails objUserProfileDetails = new UserProfileDetails();

                objUserProfile = objUserProfileDetails.GetUserProfileDetails(userid);
                if (objUserProfile != null)
                {
                    lblCompanyName.Text = objUserProfile.CompanyName;
                    lblOwnerName.Text = objUserProfile.OwnerName;
                    lblSpecialization.Text = objUserProfile.Specialization;
                    lblContactName.Text = objUserProfile.ContactName;


                    lblPrimaryAddress.Text = objUserProfile.PrimaryAddress;
                    lblPrimaryCountry.Text = objUserProfile.PrimaryCountry;
                    lblPrimaryState.Text = objUserProfile.PrimaryState;
                    lblPrimaryCity.Text = objUserProfile.PrimaryCity;
                    lblPrimaryZip.Text = objUserProfile.PrimaryZip;

                    //lblCurrency.Text = objUserProfile.Currency;
                    lblExtension.Text = objUserProfile.Extension;

                    string Mobile = objUserProfile.Mobile;
                    if (!string.IsNullOrEmpty(Mobile))
                    {
                        if (Mobile.Substring(0, 1) == "-")
                        {
                            lblMobValue.Text = Mobile.Remove(0, 1);
                        }
                        else
                        {
                            lblMobValue.Text = objUserProfile.Mobile;
                        }
                    }
                        


                    string Phone = objUserProfile.LandLine;
                    if (Phone.Substring(1, 1) == "-")
                    {                       
                        lblPhoneNumber.Text = Phone.Replace("-", "");
                    }
                    else if(Phone.Contains("--"))
                    {
                        lblPhoneNumber.Text = Phone.Replace("--","-");
                    }
                    else if (Phone.Substring(0,1) == "-")
                    {

                        lblPhoneNumber.Text = Phone.Remove(0, 1);
                    }
                    else
                    {
                        lblPhoneNumber.Text = objUserProfile.LandLine;
                    }


                    //int s = lblPhoneNumber.Text.Where(c => c == '-').Count();
                    string Fax = objUserProfile.FaxNumber;
                    if (!string.IsNullOrEmpty(Fax))
                    {

                        if (Fax.Substring(1, 1) == "-")
                        {
                            lblFaxNumber.Text = Fax.Replace("-", "");
                        }
                        else if (Fax.Contains("--"))
                        {
                            lblFaxNumber.Text = Fax.Replace("--", "-");
                        }
                        else if (Fax.Substring(0, 1) == "-")
                        {

                            lblFaxNumber.Text = Fax.Remove(0, 1);
                        }
                        else
                        {
                            lblFaxNumber.Text = objUserProfile.FaxNumber;
                        }
                    }
                    else
                    {
                        lblFaxNumber.Text = objUserProfile.FaxNumber;
                    }

                    lnkEmilAddress.Text = objUserProfile.email;
                    string value = objUserProfile.Website;
                    if (string.IsNullOrEmpty(objUserProfile.Website))
                    {
                        lnkWebSite.Text = objUserProfile.Website;
                        lnkWebSite.NavigateUrl = objUserProfile.Website;
                    }
                    else
                    {
                        if (!value.Contains("http://"))
                        {
                            lnkWebSite.Text += "http://" + objUserProfile.Website;
                            lnkWebSite.NavigateUrl += "http://" + objUserProfile.Website;
                        }
                        else
                        {
                            lnkWebSite.Text = objUserProfile.Website;
                            lnkWebSite.NavigateUrl = objUserProfile.Website;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        #endregion

        #region "Email"
        /// <summary>
        /// Handles the Click event of the lnkEmilAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkEmilAddress_Click(object sender, EventArgs e)
        {
            Guid buyerUserId = new Guid(Request.QueryString["UserId"]);
            Common.UserProfile objUserProfile = new Common.UserProfile();
            UserProfileDetails objUserProfileDetails = new UserProfileDetails();

            try
            {
                txtContent.Text = "";
                txtSubject.Text = "";
                objUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerUserId);
                if (objUserProfile != null) // seller is not trail user
                {
                    ModalPopupExtenderSendEmail.Show();
                    lblError.Visible = false;
                    lblError.Text = "";
                    txtTo.Text = objUserProfile.ContactName;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            UserProfileDetails objUserProfileDetails = new UserProfileDetails();

            Guid buyerUserId = new Guid(Request.QueryString["UserId"]);
            Common.UserProfile objSelectUserProfile = new Common.UserProfile();
            objSelectUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerUserId);

            Guid objLoggedInUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
            Common.UserProfile objLoggedInUser = new Common.UserProfile();

            objLoggedInUser = objUserProfileDetails.GetUserProfileDetails(objLoggedInUserId);

            if (objSelectUserProfile != null && objLoggedInUser != null)
            {
                Hashtable hash = new Hashtable
                                     {
                                         {"ToUserName", objSelectUserProfile.ContactName},
                                         {"FromUserName", objLoggedInUser.ContactName},
                                         {"Subject", txtSubject.Text},
                                         {"EmailAddress", objSelectUserProfile.email},
                                         {"Message", txtContent.Text}
                                     };

                // Send Email

                EmailFactory mailFactory = new EmailFactory();
                Email mail = mailFactory.SendEmail(Convert.ToString(objSelectUserProfile.email), "support@icbrowser.com", txtSubject.Text, txtContent.Text, hash);

                // Save Email
                string file = "";
                EmailDetails objSaveEmailDetailsOfUser = new EmailDetails();
                objSaveEmailDetailsOfUser.SaveMessageDetails(objLoggedInUser.UserID, objSelectUserProfile.UserID, txtSubject.Text.Trim(), txtContent.Text.Trim(), DateTime.Now, 1, false, false, 0, file);

                if (mail.Send())
                {
                    ModalPopupExtenderSendEmail.Hide();
                    lblSentMessage.Visible = true;
                    lblSentMessage.Text = "Message Sent Successfully.";
                }
                else
                {
                    ModalPopupExtenderSendEmail.Show();
                    //lblError.Visible = true;
                    lblNotSentMessage.Visible = true;
                    lblNotSentMessage.Text = "Message  has not been Sent. Please try again later.";
                }
            }
        }
        #endregion

        #region "Pop-Up Close"
        /// <summary>
        /// Handles the Click event of the imgCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtenderSendEmail.Hide();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the imgCancel2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void imgCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtenderComments.Hide();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
        #endregion

        #region "Rating"


        /// <summary>
        /// Calculates the average ratings.
        /// </summary>
        /// <param name="RatedUserId">The rated user identifier.</param>
        /// <param name="typeOfUser">if set to <c>true</c> [type of user].</param>
        protected void calculateAverageRatings(Guid RatedUserId, bool typeOfUser)
        {
            UserRatings objUserRating = new UserRatings();
            List<Common.Ratings> listrate = new List<Common.Ratings>();
            // int RatedTotal = 0;
            try
            {
                string TypeOfUser = Convert.ToString(typeOfUser);
                int ratingFrom = 0;
                listrate = objUserRating.getAverageratingsForUser(RatedUserId, typeOfUser);

                switch (TypeOfUser)
                {
                    case "True":

                        ratingAsSeller.CurrentRating = listrate[0].avg;
                        ratingFrom = listrate[0].IsAdmin;

                        if (listrate[0].avg != 0)
                        {
                            if (ratingFrom == 1)
                            {
                                ratingAsSeller.ToolTip = "Ratings given to this Seller from Admin.";
                            }
                            else
                            {
                                ratingAsSeller.ToolTip = "Ratings given to this Seller from other User.";
                            }
                        }
                        else
                        {
                            ratingAsSeller.ToolTip = "No ratings given to this seller.";
                        }

                        break;

                    case "False":
                        ratingAsBuyer.CurrentRating = listrate[0].avg;
                        ratingFrom = listrate[0].IsAdmin;
                        if (listrate[0].avg != 0)
                        {
                            if (ratingFrom == 1)
                            {
                                ratingAsBuyer.ToolTip = "Ratings given to this Buyer from Admin.";
                            }
                            else
                            {
                                ratingAsBuyer.ToolTip = "Ratings given to this Buyer from other User.";
                            }
                        }
                        else
                        {
                            ratingAsBuyer.ToolTip = "No ratings given to this buyer.";
                        }

                        break;

                    default:
                        ratingSeller.CurrentRating = listrate[0].avg;

                        break;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }
        /// <summary>
        /// Handles the Click event of the lnkRate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkRate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRating.aspx?&RatedUserId=" + Request.QueryString["UserId"]);
        }
        #endregion

        /// <summary>
        /// Handles the ItemDataBound event of the RepDetailed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void RepDetailed_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item)
            {
                LinkButton button = (e.Item.FindControl("lnkDetails") as LinkButton);
                button.Click += new EventHandler(button_Click);
            }

        }

        /// <summary>
        /// Handles the Click event of the button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void button_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Command event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CommandEventArgs"/> instance containing the event data.</param>
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {


        }

        /// <summary>
        /// Handles the Command event of the lnkDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CommandEventArgs"/> instance containing the event data.</param>
        protected void lnkDetails_Command(object sender, CommandEventArgs e)
        {
        }

        /// <summary>
        /// Handles the ItemCommand event of the RepDetailed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void RepDetailed_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            bool isdelete = false;
            ViewUserProfileId = new Guid(Request.QueryString["UserId"]);


            MembershipUser userToLogin = Membership.GetUser();
            UserId = (Guid)userToLogin.ProviderUserKey;

            Controller controlIsAdmin = new Controller();
            Users Admin = controlIsAdmin.GetIsAdmin(UserId);

            if (e.CommandName == "MyUpdate")
            {
                //lblComments.Text = ((LinkButton)e.CommandSource).Text.Trim();


                //LinkButton test = (LinkButton)RepDetailed.FindControl("lnktest");
                LinkButton test = (LinkButton)e.Item.FindControl("lnktest");
                if (test != null)
                {
                    lblComments.Text = test.Text.Trim();
                }
                ModalPopupExtenderComments.Show();
                //Guid Fromuserid = new Guid(e.CommandArgument.ToString());
                //UserRatings UserRate = new UserRatings();
                //List<Ratings> rate = new List<Ratings>();
                //rate = UserRate.getCommentforUser(ViewUserProfileId, Fromuserid);


                //foreach (RepeaterItem RI in RepDetailed.Items)
                //{
                //    LinkButton lnk = RI.FindControl("lnkDetails") as LinkButton;

                //    Guid Fromuserid = new Guid(e.CommandArgument.ToString());

                //    if (lnk != null)
                //    {

                //        UserRatings UserRate = new UserRatings();
                //        List<Ratings> rate = new List<Ratings>();
                //        rate = UserRate.getCommentforUser(ViewUserProfileId, Fromuserid);
                //        if (rate.Count != 0)
                //        {
                //            if (rate[0].Comment != "")
                //            {
                //                lblComments.Text = rate[0].Comment;
                //                ModalPopupExtenderComments.Show();
                //            }
                //            else
                //            {
                //                lblComments.Text = "Comment Not Added.";
                //                ModalPopupExtenderComments.Show();
                //            }
                //        }

                //    }




            }

            if (e.CommandName == "MyDelete")
            {
                UserRatings UserRate = new UserRatings();
                List<Ratings> rate = new List<Ratings>();
                rate = UserRate.getCommentDetails(ViewUserProfileId);

                Guid Fromuserid = new Guid(e.CommandArgument.ToString());
                if (rate.Count != 0)
                {
                    isdelete = UserRate.DeleteComment(Fromuserid, ViewUserProfileId);
                }

                if (isdelete == true)
                {

                    objUserProfile = objInventoryGridDetails.GetUserCountByUserId(ViewUserProfileId);
                    ratedMembershipTypeId = objUserProfile.TypeOfMembership;
                    //condition check for Logged In member and RatedMember
                    chkConditionforRatings(typeOfMembershipId, ratedMembershipTypeId, Admin);
                }


                chkConditionforAdmin(Admin);
            }



        }

        /// <summary>
        /// Handles the Click event of the hyplnkBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void hyplnkBack_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close('close.html', '_self', null);", true);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            //Response.Redirect(prevPage);
        }
    }

    /// <summary>
    /// Class Fields.
    /// </summary>
    public class Fields
    {
        public string CompanyName { set; get; }
        public string Comments { set; get; }
        public Guid FromUserId { set; get; }
        public Guid UserId { set; get; }
        public string ShortComment { set; get; }
        public string FullDetails { set; get; }
    }
}