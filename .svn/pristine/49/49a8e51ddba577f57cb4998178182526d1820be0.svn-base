using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using System.Data;
using ICBrowser.Common;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class UserRating : BasePage
    {
        #region "public Parameters"
        bool typeofuser;
        public Guid RatedUserId;
        public Guid LoggedInId;
        InventoryGridDetails objInventoryGridDetails = new InventoryGridDetails(); //class Object
        Common.UserProfile objUserProfile = new Common.UserProfile(); //class Object
        public int typeOfMembershipId = 0;
        public int ratedMembershipTypeId = 0;
        Users Admin = new Users();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                LoggedInId = (Guid)userToLogin.ProviderUserKey;  //Current logged In user 

                //check for Admin
                Controller controlIsAdmin = new Controller();
                Admin = controlIsAdmin.GetIsAdmin(LoggedInId);

                // RatedUserId = new Guid(Request.QueryString["RatedUserId"]); 
                RatedUserId = new Guid(Request.QueryString["RatedUserId"]); //rated user Id

                //this object gets TypeofmembershipId,UsedrId,Companyname (instead use session)
                objUserProfile = objInventoryGridDetails.GetUserCountByUserId(LoggedInId);
                typeOfMembershipId = objUserProfile.TypeOfMembership; //logged in memberId

                //gets the membership details of Rated User
                objUserProfile = objInventoryGridDetails.GetUserCountByUserId(RatedUserId);
                ratedMembershipTypeId = objUserProfile.TypeOfMembership;

                if (RatedUserId != null)
                {
                    if (!IsPostBack)
                    {
                        //commented
                        //  calculateAverageRatings(RatedUserId, UserId);//again check if the code is correct or not

                        if (typeOfMembershipId == 1 && ratedMembershipTypeId > 2) //check if Loggedin Member is Free(Buyer) & rated member is Paid(buyer&Seller) then set of question should be related to Seller 
                        {
                            //show question related to seller
                            typeofuser = true;
                            //****************************call rate question************************
                            //getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, true); //true cz for freeMember Paid Member will always be a Seller 
                            getRatingQuestion(typeofuser);
                        }
                        else
                        {
                            if (typeOfMembershipId > 2 && ratedMembershipTypeId == 1 || (Admin.IsAdmin == true) && ratedMembershipTypeId == 1)//check if logged in member is Paid(buyer&seller) then the set of question should be related to buyer
                            {
                                //show question related to buyer
                                typeofuser = false;
                                getRatingQuestion(typeofuser);
                                //****************************call rate question************************
                                // getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, false); //false cz for PaidMember/Admin Free Member will always be a Buyer 
                            }
                            else
                            {
                                if (typeOfMembershipId > 2 && ratedMembershipTypeId > 2 || (Admin.IsAdmin == true) && ratedMembershipTypeId > 2) //check if bth the Loggedin Member and rated member both are paid(Seller&buyer) then ask for radiobutton selection option
                                {
                                    //ask user for radio button selection option in this case 
                                    trSelectType.Visible = true; //Radio button Selection
                                    tbquestion.Visible = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }


        /// <summary>
        /// gets the rating of individual questions that the logged in Person has given in His previous rating to the View Profile member
        /// </summary>
        public DataTable getQuestionRatingOfLoggedInmember(Guid RatedUserId, Guid LoggedInId, bool type)
        {
            UserRatings ObjUserratings = new UserRatings();
            DataTable dt = new DataTable();
            try
            {
                dt = ObjUserratings.getQuestionRating(RatedUserId, LoggedInId, type);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                    //grdrating.DataSource = dt;
                    //grdrating.DataBind();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// method that gets set of question related to Seller 
        /// </summary>
        public void getRatingQuestion(bool typeOfMember)
        {
            UserRatings objUserRatings = new UserRatings();
            DataTable dtablequestion = new DataTable();
            try
            {
                dtablequestion = objUserRatings.getRatingQuestion(typeOfMember);
                if (dtablequestion.Rows.Count > 0)
                {
                    grdrating.DataSource = dtablequestion;
                    grdrating.DataBind();

                }
                else
                {
                    grdrating.DataSource = null;
                    grdrating.DataBind();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }
        
        protected void lbkback_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"]);
                string redUrl = "NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"];
                ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>window.open('" + redUrl + "');</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Business.UserRatings objUserRatings = new Business.UserRatings();

            //if (rblist.SelectedIndex > 0)
            //{

            
            
            try
            {
                for (int i = 0; i <= grdrating.Rows.Count - 1; i++)
                {
                    AjaxControlToolkit.Rating grdRatingControl = (AjaxControlToolkit.Rating)grdrating.Rows[i].FindControl("ratingQuest");
                    Label lblQUestId = (Label)grdrating.Rows[i].FindControl("lblQuestionId");
                    int questId = Convert.ToInt32(lblQUestId.Text);
                    int userRating = grdRatingControl.CurrentRating;

                    if (userRating == 0)
                    {
                        lblratingmsg.Visible = true;
                    }
                    else
                    {
                        if (userRating != 0)
                        {



                            if (Admin.IsAdmin == true)
                            {
                                objUserRatings.InsertUserRating(LoggedInId, RatedUserId, questId, userRating, txtComments.Text, true);
                            }
                            else
                            {
                                objUserRatings.InsertUserRating(LoggedInId, RatedUserId, questId, userRating, txtComments.Text, false);
                            }


                           // string redUrl = "NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"];
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "alert('  Your ratings have been saved. ');document.location.href='/NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"] + "';", true);
                           
                            //ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>document.location.href='" + redUrl + "';</script>");
                        }
                    }
                    //Response.Redirect("NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"]);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            //}


           
                    

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect();
                string redUrl = "NewUserProfile.aspx?UserId=" + Request.QueryString["RatedUserId"];               
                ClientScript.RegisterStartupScript(this.GetType(), "ViewCompany", "<script>document.location.href='" + redUrl + "';</script>");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        protected void rblist_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (rblist.SelectedItem.Value == "0")
            {
                typeofuser = false;
                getRatingQuestion(typeofuser);
                tbquestion.Visible = true;
                //****************************call rate question************************
                //  dt= getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, false); //false  cz Paid Member has rated the other Paid member as Buyer

            }
            else
            {
                if (rblist.SelectedItem.Value == "1")
                {
                    typeofuser = true;
                    getRatingQuestion(typeofuser);
                    tbquestion.Visible = true;
                    //****************************call rate question************************
                    //  getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, true); //true  cz Paid Member has rated the other Paid member as Seller
                }
            }
        }

        protected void grdrating_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AjaxControlToolkit.Rating ratingcnt = new AjaxControlToolkit.Rating();
                ratingcnt = (AjaxControlToolkit.Rating)e.Row.FindControl("ratingQuest");

                Label lblQuest = (Label)e.Row.FindControl("lblQuestionId");
                //ratingcnt.CurrentRating = Convert.ToInt32(lblRating.Text);

                if (typeOfMembershipId == 1 && ratedMembershipTypeId > 2) //check if Loggedin Member is Free(Buyer) & rated member is Paid(buyer&Seller) then set of question should be related to Seller 
                {
                    //show question related to seller
                    typeofuser = true;
                    //****************************call rate question************************
                    dt = getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, true); //true cz for freeMember Paid Member will always be a Seller 
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["QuestionId"].ToString()) == Convert.ToInt32(lblQuest.Text))
                            {
                                ratingcnt.CurrentRating = Convert.ToInt32(dt.Rows[i]["Rating"].ToString());
                                txtComments.Text = dt.Rows[i]["Comment"].ToString();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (typeOfMembershipId > 2 && ratedMembershipTypeId == 1 || (Admin.IsAdmin == true) && ratedMembershipTypeId == 1)//check if logged in member is Paid(buyer&seller) then the set of question should be related to buyer
                    {
                        //show question related to buyer
                        typeofuser = false;

                        //****************************call rate question************************
                        dt = getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, false); //false cz for PaidMember/Admin Free Member will always be a Buyer 
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                if (Convert.ToInt32(dt.Rows[i]["QuestionId"].ToString()) == Convert.ToInt32(lblQuest.Text))
                                {
                                    txtComments.Text = "";
                                    ratingcnt.CurrentRating = Convert.ToInt32(dt.Rows[i]["Rating"].ToString());
                                    txtComments.Text = dt.Rows[i]["Comment"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (typeOfMembershipId > 2 && ratedMembershipTypeId > 2 || (Admin.IsAdmin == true) && ratedMembershipTypeId > 2) //check if bth the Loggedin Member and rated member both are paid(Seller&buyer) then ask for radiobutton selection option
                        {
                            ////ask user for radio button selection option in this case 
                            //trSelectType.Visible = true; //Radio button Selection

                            if (Convert.ToInt32(rblist.SelectedItem.Value) == 0)
                            {
                                txtComments.Text = "";//clear previous comment
                                dt = getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, false); //false cz for PaidMember/Admin Free Member will always be a Buyer 
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                    {
                                        if (Convert.ToInt32(dt.Rows[i]["QuestionId"].ToString()) == Convert.ToInt32(lblQuest.Text))
                                        {
                                            ratingcnt.CurrentRating = Convert.ToInt32(dt.Rows[i]["Rating"].ToString());
                                            txtComments.Text = dt.Rows[i]["Comment"].ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(rblist.SelectedItem.Value) == 1)
                                {
                                    txtComments.Text = "";//clear previous comment
                                    dt = getQuestionRatingOfLoggedInmember(RatedUserId, LoggedInId, true); //true cz for freeMember Paid Member will always be a Seller 
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                        {
                                            if (Convert.ToInt32(dt.Rows[i]["QuestionId"].ToString()) == Convert.ToInt32(lblQuest.Text))
                                            {
                                                ratingcnt.CurrentRating = Convert.ToInt32(dt.Rows[i]["Rating"].ToString());
                                                txtComments.Text = dt.Rows[i]["Comment"].ToString();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}