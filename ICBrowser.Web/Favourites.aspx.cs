using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;
using System.Web.Security;

namespace ICBrowser.Web
{
    public partial class Favourites : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FavouritesDetails fav = new FavouritesDetails();
            try
            {
                // check wheather is buyer or seller
                Common.UserProfile UserPrfl = new Common.UserProfile();
                UserPrfl = (Common.UserProfile)Session["UserProfile"];
                int typeOfMembershipId = UserPrfl.TypeOfMembership;
                MembershipUser userToLogin = Membership.GetUser();
                Guid userid = new Guid(userToLogin.ProviderUserKey.ToString());
                //BuyersDataRequirement buyersdata = new BuyersDataRequirement();
                //int buyersidcount = buyersdata.getCountBuyersRequirementDetailsByUserId(userid);
                if (userToLogin != null)
                {
                    if (typeOfMembershipId > 1) // if Paid Member.
                    {
                        if (!Page.IsPostBack)
                        {
                            if (userToLogin != null)
                            {
                                ViewState["logintype"] = "Buyer";
                                Bindgrid(userid, 1);
                            }
                        }
                    }
                    else  // if Free Member.
                    {
                        //List<SellerDetails> sellersubsciptiontype = buyersdata.GetSellerDetails(userToLogin.ProviderUserKey.ToString()); // find seller subscription type
                        //if (sellersubsciptiontype[0].TypeOfMembership != 1) // paid seller
                        {
                            if (!Page.IsPostBack)
                            {
                                if (userToLogin != null)
                                {
                                    ViewState["logintype"] = "Seller";
                                    Bindgrid(userid, 0);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        private void Bindgrid(Guid userid, int typeoflogin)
        {
            FavouritesDetails favu = new FavouritesDetails();

            try
            {
                favDetails.DataSource = favu.getFavouriteDetails(userid, typeoflogin);
                favDetails.DataBind();
                for (int i = 0; i < favDetails.Rows.Count; i++)
                {
                    GridViewRow row = favDetails.Rows[i];
                    if (ViewState["logintype"].ToString().Equals("Buyer"))
                    {

                        ((DataControlField)favDetails.Columns.Cast<DataControlField>().Where(fld => fld.HeaderText == "Favourite of Buyer").SingleOrDefault()).Visible = false;
                        ((DataControlField)favDetails.Columns.Cast<DataControlField>().Where(fld => fld.HeaderText == "Favourite of Seller").SingleOrDefault()).Visible = true;
                    }
                    else if (ViewState["logintype"].ToString().Equals("Seller"))
                    {
                        ((DataControlField)favDetails.Columns.Cast<DataControlField>().Where(fld => fld.HeaderText == "Favourite of Buyer").SingleOrDefault()).Visible = true;
                        ((DataControlField)favDetails.Columns.Cast<DataControlField>().Where(fld => fld.HeaderText == "Favourite of Seller").SingleOrDefault()).Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void favDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MembershipUser userToLogin = Membership.GetUser();
                string userid = userToLogin.ProviderUserKey.ToString();
                // BuyersDataRequirement buydata = new BuyersDataRequirement();
                //int buyercount = buydata.getCountBuyersRequirementDetailsByUserId(userid);
                // if (buyercount > 0)
                //{
                if (e.CommandName == "btn")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    var LnkBtn = (LinkButton)row.Cells[0].FindControl("lnkuserid");
                    string Id = LnkBtn.Text;
                    int rowindex = row.RowIndex;
                    if (Membership.GetUser() == null)
                    {
                        Response.Redirect("Default.aspx?Id=" + Id, false);
                    }

                    else
                    {
                        Response.Redirect("UserProfile.aspx?UserId=" + Id, false);
                    }

                }

                //else
                //{
                //    if (e.CommandName == "btn")
                //    {
                //        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //        var LnkBtn = (LinkButton)row.Cells[0].FindControl("lnkBuyerId");
                //        string Id = LnkBtn.Text;
                //        int rowindex = row.RowIndex;
                //        if (Membership.GetUser() == null)
                //        {
                //            Response.Redirect("Default.aspx?Id=" + Id, true);
                //        }

                //        //else
                //        //{

                //        //    if (userToLogin != null)
                //        //    {
                //        //        if (buyercount > 0)
                //        //        {
                //        //            Response.Redirect("SellerProfile.aspx?SellerId=" + Id, true);
                //        //        }
                //        //        else
                //        //        {
                //        //            Response.Redirect("BuyerProfile.aspx?Id=" + Id, true);
                //        //        }
                //        //    }
                //        //}
                //    }
                //}

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        protected void favDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                FavouritesDetails Fd = new FavouritesDetails();
                MembershipUser userToLogin = Membership.GetUser();
                LinkButton lnkFavId = (LinkButton)favDetails.Rows[e.RowIndex].FindControl("lnkFavId");
                Fd.DeleteSelectedFavouriteOnId(userToLogin.ProviderUserKey.ToString(), lnkFavId.Text);
                int temp = 0;
                if (ViewState["logintype"].ToString().Equals("Buyer"))
                {
                    temp = 1;
                }
                else if (ViewState["logintype"].ToString().Equals("Seller"))
                {
                    temp = 0;
                }
                Bindgrid(new Guid(userToLogin.ProviderUserKey.ToString()), temp);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }
    }
}