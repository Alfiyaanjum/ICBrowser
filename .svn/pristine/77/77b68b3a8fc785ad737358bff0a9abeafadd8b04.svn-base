using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
namespace ICBrowser.Business
{
    public class FavouritesDetails
    {
        FavouritesRepository favrepo = new FavouritesRepository();
        List<FavouriteDetails> lst = new List<FavouriteDetails>();
        public List<FavouriteDetails> getFavouriteDetails(Guid userID, int typeoflogin)
        {
            try
            {
                lst = favrepo.getfavouriteDeatilsonUserId(userID, typeoflogin);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }


        public void DeleteSelectedFavouriteOnId(string userlogin, string FavId)
        {
            BuyerCompanyDetailsRepository bcdr = new BuyerCompanyDetailsRepository();
            try
            {
                bcdr.DeleteFavoriteOnId(userlogin, FavId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                throw;
            }
        }


        // For User Profile Page
        public bool AddToFavourite(Guid userlogin, Guid AddedFavouriteUserId, DateTime dateTime, int status)
        {
            bool flag = false;
            FavouritesRepository bcdr = new FavouritesRepository();
            try
            {
                flag = bcdr.AddToFavourite(userlogin, AddedFavouriteUserId, dateTime, status);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return flag;
        }

        // Check wheahther user is already added to fav list
        public bool CheckForAddedFavListForUser(Guid usertologin, Guid addedfavuserid)
        {
            bool flag = false;
            FavouritesRepository objFavRepo = new FavouritesRepository();
            try
            {
                flag = objFavRepo.CheckForAddedFavListForUser(usertologin, addedfavuserid);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return flag;
        }
    }
}
