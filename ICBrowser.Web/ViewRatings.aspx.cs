using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Business;
using ICBrowser.Common;
using System.Data;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class ViewRatings : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    MembershipUser userToLogin = Membership.GetUser();
                    Guid LoggedInId = (Guid)userToLogin.ProviderUserKey;  //Current logged In user 

                    //check for Admin
                    Controller controlIsAdmin = new Controller();
                    Users Admin = controlIsAdmin.GetIsAdmin(LoggedInId);
                    if (Admin.IsAdmin)
                    {
                        loadPaidMemberGrid();
                        loadFreeMemberGrid();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    IClogger.LogMessage(ex.Message);
                }
            }
        }

        #region "Paid Member methods"
        /// <summary>
        /// gets all paid members (Not Trial members as No body can rate Trial members and Trial cannot rate any Other Member)
        /// </summary>
        public void loadPaidMemberGrid()
        {
            Business.UserRatings objUserRatings = new Business.UserRatings();
            List<Common.UserProfile> listpaidMember = new List<Common.UserProfile>();

            listpaidMember = objUserRatings.getAllPaidMembers();
            grdSellerRating.DataSource = listpaidMember;
            grdSellerRating.DataBind();
        }

        /// <summary>
        ///button Search for Filter search for Paid Member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgSearchFromGrid_Click(object sender, ImageClickEventArgs e)
        {
            UserRatings objUserRatings = new UserRatings();
            List<Common.UserProfile> listsearchPaidMember = new List<Common.UserProfile>();
            try
            {
                if (txtSearchFromGrid.Text != "")
                {
                    listsearchPaidMember = bindSearchData(txtSearchFromGrid.Text, 2);
                    grdSellerRating.DataSource = listsearchPaidMember;
                    grdSellerRating.DataBind();

                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }

        /// <summary>
        /// clears the search for Paid member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgClearSearchSelection_Click(object sender, ImageClickEventArgs e)
        {
            txtSearchFromGrid.Text = string.Empty;
            loadPaidMemberGrid();

        }
        #endregion

        #region "Paid Member Grid Events"
        protected void grdSellerRating_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int chkIsAdmin = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Common.Ratings> listrate = new List<Common.Ratings>();
                Label lblUserId = (Label)e.Row.FindControl("lblSellerId");
                AjaxControlToolkit.Rating sellerRatingControl = new AjaxControlToolkit.Rating();
                sellerRatingControl = (AjaxControlToolkit.Rating)e.Row.FindControl("ratingQuestSeller");
                listrate = calculateAverageRatings(new Guid(lblUserId.Text), true);
                int ratedSellerValues = listrate[0].avg;
                sellerRatingControl.CurrentRating = ratedSellerValues;
                chkIsAdmin = listrate[0].IsAdmin;
                Button btndelPaidForSeller = (Button)e.Row.FindControl("imgbtnPaidAsSellerDelete");
                if (chkIsAdmin == 1)
                {

                    btndelPaidForSeller.Visible = true;
                }
                else
                {
                    btndelPaidForSeller.Visible = false;
                }

                AjaxControlToolkit.Rating buyerRatingControl = new AjaxControlToolkit.Rating();
                buyerRatingControl = (AjaxControlToolkit.Rating)e.Row.FindControl("ratingQuestBuyer");
                listrate = calculateAverageRatings(new Guid(lblUserId.Text), false);
                int ratedBuyerValues = listrate[0].avg;
                buyerRatingControl.CurrentRating = ratedBuyerValues;
                chkIsAdmin = listrate[0].IsAdmin;
                Button btndelPaidForBuyer = (Button)e.Row.FindControl("imgbtnPaidAsBuyerDelete");
                if (chkIsAdmin == 1)
                {
                    btndelPaidForBuyer.Visible = true;
                }
                else
                {
                    btndelPaidForBuyer.Visible = false;
                }
            }
        }

        protected void grdSellerRating_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            UserRatings objUserRatings = new UserRatings();
            bool deleteStatus;

            if (e.CommandName == "DeletePaidMemberRatingAsSeller")
            {
                deleteStatus = objUserRatings.deleteUserRating(true, e.CommandArgument.ToString());
                loadPaidMemberGrid();
            }

            if (e.CommandName == "DeletePaidMemberRatingAsBuyer")
            {
                deleteStatus = objUserRatings.deleteUserRating(false, e.CommandArgument.ToString());
                loadPaidMemberGrid();
            }
        }

        protected void grdSellerRating_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Common.UserProfile> listPaidmember = new List<Common.UserProfile>();
            try
            {
                grdSellerRating.PageIndex = e.NewPageIndex; //code for new page index 
                if (txtSearchFromGrid.Text != "")
                {
                    listPaidmember = bindSearchData(txtSearchFromGrid.Text, 2);
                    grdSellerRating.DataSource = listPaidmember;
                    grdSellerRating.DataBind();
                }
                else
                {
                    loadPaidMemberGrid();
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
        #endregion

        #region "Free Member methods"
        /// <summary>
        /// gets all free (Buyers) Members 
        /// </summary> 
        public void loadFreeMemberGrid()
        {
            MembershipUser userToLogin = Membership.GetUser();
            Guid LoggedInId = (Guid)userToLogin.ProviderUserKey;
            List<Common.UserProfile> listFreeMember = new List<Common.UserProfile>();
            UserProfileDetails usrProfDetils = new UserProfileDetails();
            listFreeMember = usrProfDetils.GetAllFreeUsrDetails(LoggedInId);
            grdFreeMember.DataSource = listFreeMember;
            grdFreeMember.DataBind();

        }

        /// <summary>
        /// button search event for Free member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgSearchFreeMember_Click(object sender, ImageClickEventArgs e)
        {
            UserRatings objUserRatings = new UserRatings();
            List<Common.UserProfile> listsearchFreeMember = new List<Common.UserProfile>();
            try
            {
                if (txtSearchFreeMember.Text != "")
                {
                    listsearchFreeMember = bindSearchData(txtSearchFreeMember.Text, 1);
                    grdFreeMember.DataSource = listsearchFreeMember;
                    grdFreeMember.DataBind();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        /// <summary>
        /// clears search of Free Members
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgClearFreeMmeberSearch_Click(object sender, ImageClickEventArgs e)
        {
            txtSearchFreeMember.Text = string.Empty;
            loadFreeMemberGrid();
        }
        #endregion

        #region "Free mmeber Grid Events"
        protected void grdFreeMember_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btndelFreeForBuyer = (Button)e.Row.FindControl("imgbtnFreeDelete");
                List<Common.Ratings> listrate = new List<Common.Ratings>();
                Label lblUserId = (Label)e.Row.FindControl("lblBuyerId");

                AjaxControlToolkit.Rating buyerRatingControl = new AjaxControlToolkit.Rating();
                buyerRatingControl = (AjaxControlToolkit.Rating)e.Row.FindControl("ratingQuestASBuyer");
                listrate = calculateAverageRatings(new Guid(lblUserId.Text), false);
                int ratedBuyerValues = listrate[0].avg;
                buyerRatingControl.CurrentRating = ratedBuyerValues;
                int chkIsAdmin = listrate[0].IsAdmin;
                if (chkIsAdmin == 1)
                {
                    btndelFreeForBuyer.Visible = true;
                }
                else
                {
                    btndelFreeForBuyer.Visible = false;
                }

            }
        }

        protected void grdFreeMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            UserRatings objUserRatings = new UserRatings();
            bool deleteStatus;

            if (e.CommandName == "DeleteFreeMemberRating")
            {
                deleteStatus = objUserRatings.deleteUserRating(false, e.CommandArgument.ToString());
                loadFreeMemberGrid();
            }
        }

        protected void grdFreeMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                List<Common.UserProfile> listFreeMember = new List<Common.UserProfile>();
                grdFreeMember.PageIndex = e.NewPageIndex; //code for new page index 
                if (txtSearchFreeMember.Text != "")
                {
                    listFreeMember = bindSearchData(txtSearchFreeMember.Text, 1);
                    grdFreeMember.DataSource = listFreeMember;
                    grdFreeMember.DataBind();
                }
                else
                {
                    loadFreeMemberGrid();
                }
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
        #endregion

        #region "Common Methods to calculate Averageratings && Binding Search"
        /// <summary>
        ///  calculates Average rating of a Member depending on typeOfUser ie Free(false) or Paid Member (true)
        /// </summary>
        /// <param name="RatedUserId"></param>
        /// <param name="typeOfUser"></param>
        /// <returns></returns>
        protected List<Common.Ratings> calculateAverageRatings(Guid RatedUserId, bool typeOfUser)
        {
            UserRatings objUserRating = new UserRatings();
            List<Common.Ratings> listrate = new List<Common.Ratings>();

            try
            {
                listrate = objUserRating.getAverageratingsForUser(RatedUserId, typeOfUser);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listrate;

        }

        /// <summary>
        /// binds the grid depending on the Membername which is searched in filter Search
        /// </summary>
        /// <param name="searchtext"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Common.UserProfile> bindSearchData(string searchtext, int type)
        {
            UserRatings objUserRatings = new UserRatings();
            List<Common.UserProfile> listsearchMember = new List<Common.UserProfile>();
            try
            {
                listsearchMember = objUserRatings.getsearchedMembers(searchtext, type);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listsearchMember;

        }
        #endregion

    }
}