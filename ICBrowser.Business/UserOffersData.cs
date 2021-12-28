using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using System.Data;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    public class UserOffersData
    {
        /// <summary>
        /// Insert Data For Offer As per User Id
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        /// 
        public int SaveOffersByUserManually(List<Common.Component> requestDataList)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            int count = 0;
            try
            {
                foreach (ICBrowser.Common.Component requestData in requestDataList)
                {
                    count = objRepo.SaveOfferUploadedByUserManually(requestData);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return count;
        }



        public int SaveOffersByUser(List<Common.Component> requestDataList, int leftspace)
        {
            int count = 0;
            bool result = false;
            UserOfferDataRepository objRepo = new UserOfferDataRepository();

            try
            {
                foreach (ICBrowser.Common.Component requestData in requestDataList)
                {
                    if (count < leftspace)
                    {
                        result = objRepo.SaveOfferUploadedByUser(requestData);
                        if (result)
                            count++;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return count;
        }

        public void UpdateOffers(Common.Component requestData)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            //int count = 0;
            try
            {
                objRepo.updateOffersDAL(requestData);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            //  return count;
        }


        /// <summary>
        /// Delete Extra Offer Data as per Modified Date
        /// </summary>
        /// <param name="noOfRowsToBeSave"></param>
        /// <param name="UserId"></param>
        /// 
        public void DeleteExtraUploadedInventoryAsPerMofiedDate(int noOfRowsToBeSave, Guid UserId)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            try
            {
                objRepo.DeleteExtraUploadedInventories(noOfRowsToBeSave, UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }
        

        public void DeleteExtraUploadedOfferAsPerMofiedDate(int noOfRowsToBeSave, Guid UserId)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            try
            {
                objRepo.DeleteExtraUploadedOffer(noOfRowsToBeSave, UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Select all data for binding grid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetAllOfferDetailsByUserID(Guid UserId)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            DataTable dt = new DataTable();
            try
            {
                dt = objRepo.getAllOfferDetailsByUserID(UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Delete Offer On Row Deleting for User
        /// </summary>
        /// <param name="p"></param>
        /// <param name="UserId"></param>
        public void DeleteOfferOnRowDeleting(int OfferId, string UserId)
        {
            UserOfferDataRepository objRepo = new UserOfferDataRepository();
            try
            {
                objRepo.DeleteOfferOnRowDeleting(OfferId, new Guid(UserId));
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// gets Offer Details depending on Search filter
        /// </summary>
        public List<Component> getOfferDetailsOnSearch(int ddlSelectedValue, string searchtext, Guid UserId)
        {
            List<Component> listfound = new List<Component>();
            UserOfferDataRepository ObjUserOfferRepo = new UserOfferDataRepository();
            try
            {
                listfound = ObjUserOfferRepo.GetSearchedData(UserId, searchtext, ddlSelectedValue);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listfound;
        }

        /// <summary>
        /// Get Offer Details for OfferDetails.aspx page. User Get all offer details based on offerName 
        /// </summary>
        /// <param name="offerName"></param>
        /// <returns></returns>
        public List<Component> getOfferDetailsByOfferName(string offerName)
        {
            List<Component> lstOfferDetails = new List<Component>();
            UserOfferDataRepository objUserOfferRepo = new UserOfferDataRepository();
            try
            {
                lstOfferDetails = objUserOfferRepo.getOfferDetailsByOfferName(offerName);
                if (lstOfferDetails == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lstOfferDetails;
        }

        /// <summary>
        /// Get Offer Uploading Limit as per membership of the Users
        /// </summary>
        /// <param name="membershiptype"></param>
        /// <returns></returns>
        
        /// 


       
        public int GetOfferUploadingLimitAsPerMembershipType(int membershiptype)
        {
            UserOfferDataRepository objUserOfferRepo = new UserOfferDataRepository();
            int limit = 0;
            try
            {
                limit = objUserOfferRepo.GetOfferUploadingLimitAsPerMembershipType(membershiptype);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return limit;
        }
    }
}
