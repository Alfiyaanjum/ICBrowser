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
    public partial class UserProfile : BasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MembershipUser userToLogin = Membership.GetUser();
                UserId = (Guid)userToLogin.ProviderUserKey;

                //chk for Admin.......
                Controller controlIsAdmin = new Controller();
                Users Admin = controlIsAdmin.GetIsAdmin(UserId);

                if (Request.QueryString["UserID"] != null)
                {

                    ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
                }

                //objUserProfile = objInventoryGridDetails.GetUserCountByUserId(UserId);//this object gets TypeofmembershipId,UsedrId,Companyname
                objUserProfile = (Common.UserProfile)Session["UserProfile"];
                typeOfMembershipId = objUserProfile.TypeOfMembership;


                objUserProfile = objInventoryGridDetails.GetUserCountByUserId(ViewUserProfileId);
                ratedMembershipTypeId = objUserProfile.TypeOfMembership;

                //condition check for Logged In member and RatedMember
                chkConditionforRatings(typeOfMembershipId, ratedMembershipTypeId, Admin);

                //check condition for Admin
                chkConditionforAdmin(Admin);

                BindData(ViewUserProfileId);

                prevPage = Request.UrlReferrer.ToString();
            }
            //Add to Favorite Condition to check whether user is already added or not
            ChckForAddedToFavoriteCondtion();
        }


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

        private void chkConditionforAdmin(Users Admin)
        {
            if (Admin.IsAdmin)
            {
                lnkEmilAddress.Enabled = false;
                a1.Visible = true;
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
                        ShortComment = i.Comment

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
                    }

                }

                RepDetailed.DataSource = values;
                RepDetailed.DataBind();



            }
            else
            {
                a1.Visible = false;
            }
            BindData(ViewUserProfileId);

        }



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

                    lblCurrency.Text = objUserProfile.Currency;
                    lblExtension.Text = objUserProfile.Extension;
                    lblPhoneNumber.Text = objUserProfile.LandLine;
                    lblFaxNumber.Text = objUserProfile.FaxNumber;
                    lnkEmilAddress.Text = objUserProfile.email;
                    lnkWebSite.Text = objUserProfile.Website;
                    lnkWebSite.NavigateUrl = objUserProfile.Website;
                }
            }

            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        #endregion

        #region "Email"
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
                objSaveEmailDetailsOfUser.SaveMessageDetails(objLoggedInUser.UserID, objSelectUserProfile.UserID, txtSubject.Text.Trim(), txtContent.Text.Trim(), DateTime.Now, 1, false, false, 0,file);

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

        #region "Favorite"
        protected void imgbtnaddFav_Click(object sender, ImageClickEventArgs e)
        {
            Business.FavouritesDetails objFavDetails = new Business.FavouritesDetails();
            try
            {
                Guid buyerid = new Guid(Request.QueryString["UserId"]);
                Common.UserProfile objUserProfile = new Common.UserProfile();
                UserProfileDetails objUserProfileDetails = new UserProfileDetails();
                objUserProfile = objUserProfileDetails.GetUserProfileDetails(buyerid);
                Guid loggedInUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());

                if (objUserProfile != null) // seller is not trail user
                {
                    bool flag = objFavDetails.AddToFavourite(loggedInUserId, objUserProfile.UserID, DateTime.Now, 0);

                    if (flag == true) // Favorite is added
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Add Favorite", "alert('You have added Favorite Successfully.');", true);
                        imgbtnaddFav.Enabled = false;
                        imgbtnaddFav.ToolTip = "Already Added to Favorite List";
                    }
                    else // Favorite is already added 
                    {
                        imgbtnaddFav.Enabled = true;
                        imgbtnaddFav.ToolTip = "Add Favourite";
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void ChckForAddedToFavoriteCondtion()
        {
            bool status = false;
            Common.UserProfile objUserProfile = new Common.UserProfile();
            UserProfileDetails objUserProfileDetails = new UserProfileDetails();
            Business.FavouritesDetails objFavDetails = new Business.FavouritesDetails();
            try
            {
                Guid ViewUserProfileId = new Guid(Request.QueryString["UserId"]);
                objUserProfile = objUserProfileDetails.GetUserProfileDetails(ViewUserProfileId);
                if (objUserProfile != null)
                {
                    // User cannot add himself to favorite list code
                    if (objUserProfile.UserID.Equals(new Guid(Membership.GetUser().ProviderUserKey.ToString())))
                    {
                        imgbtnaddFav.Enabled = false;
                        imgbtnaddFav.ToolTip = "You cannot add yourself to favorite list.";
                    }
                    else // both are different users
                    {
                        // Now check whether users has already added to his favorite list
                        status = objFavDetails.CheckForAddedFavListForUser(new Guid(Membership.GetUser().ProviderUserKey.ToString()), objUserProfile.UserID);
                        if (status == true) // user has already added to his favorite list so disable start button
                        {
                            imgbtnaddFav.Enabled = false;
                            imgbtnaddFav.ToolTip = "Already Added to Favorite List";
                        }
                        else // user has not added to his favorite list. so enable image button
                        {
                            imgbtnaddFav.Enabled = true;
                            imgbtnaddFav.ToolTip = "Add Favourite";
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

        #region "Pop-Up Close"
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
        /// Calculates the Average rating of a User
        /// </summary>
        /// <param name="RatedUserId"></param>
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
        protected void lnkRate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRating.aspx?&RatedUserId=" + Request.QueryString["UserId"]);
        }
        #endregion

        protected void RepDetailed_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item)
            {
                LinkButton button = (e.Item.FindControl("lnkDetails") as LinkButton);
                button.Click += new EventHandler(button_Click);
            }

        }

        void button_Click(object sender, EventArgs e)
        {

        }
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {


        }
        protected void lnkDetails_Command(object sender, CommandEventArgs e)
        {
        }
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
                foreach (RepeaterItem RI in RepDetailed.Items)
                {
                    LinkButton lnk = RI.FindControl("lnkDetails") as LinkButton;

                    Guid Fromuserid = new Guid(e.CommandArgument.ToString());

                    if (lnk != null)
                    {

                        UserRatings UserRate = new UserRatings();
                        List<Ratings> rate = new List<Ratings>();
                        rate = UserRate.getCommentforUser(ViewUserProfileId, Fromuserid);
                        if (rate.Count != 0)
                        {
                            if (rate[0].Comment != "")
                            {
                                lblComments.Text = rate[0].Comment;
                                ModalPopupExtenderComments.Show();
                            }
                            else
                            {
                                lblComments.Text = "Comment Not Added.";
                                ModalPopupExtenderComments.Show();
                            }
                        }

                    }


                }

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

        protected void hyplnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}

public class Fields
{
    public string CompanyName { set; get; }
    public string Comments { set; get; }
    public Guid FromUserId { set; get; }
    public Guid UserId { set; get; }
    public string ShortComment { set; get; }
}