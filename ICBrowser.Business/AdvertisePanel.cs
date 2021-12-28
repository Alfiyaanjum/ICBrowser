using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ICBrowser.Business;
using ICBrowser.Common;
using ICBrowser.DAL;
namespace ICBrowser.Business
{
    public class AdvertisePanel
    {        
        AdvertisementRepository adv = new AdvertisementRepository();
        List<AdvertPanel> lst = new List<AdvertPanel>();

        public List<AdvertPanel> GetAdvertisementDetail(string position)
        {
            lst = adv.GetAdvertisementDetail(position);
            return lst;
        }

        /// <summary>
        /// Method to access DAL to insert new Ad
        /// </summary>
        /// <param name="newAd"></param>
        /// <returns></returns>
        public DateTime InsertNewAd(AdvertPanel newAd)
        {
            // Use sample end date for reference
            DateTime currentEndDate = Convert.ToDateTime("01-Jan-2012");
            try
            {
                // Access DAL to insert new Ad                
                AdvertisementRepository repAdvert = new AdvertisementRepository();
                currentEndDate = repAdvert.InsertNewAd(newAd);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return currentEndDate;
        }

        /// <summary>
        /// Method to access DAL to update an Ad
        /// </summary>
        /// <param name="updatedAd"></param>
        /// <returns></returns>
        public DateTime UpdateAd(AdvertPanel updatedAd)
        {
            // Use sample end date for reference
            DateTime currentEndDate = Convert.ToDateTime("01-Jan-2012");
            try
            {
                // Access DAL to update a particular Ad
                AdvertisementRepository repAdvert = new AdvertisementRepository();
                currentEndDate = repAdvert.UpdateAd(updatedAd);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return currentEndDate;
        }

        /// <summary>
        /// Method to access DAL to delete an Ad
        /// </summary>
        /// <param name="delAdId"></param>
        public void DeleteAd(int delAdId)
        {
            try
            {
                // Access DAL to delete a particular Ad
                AdvertisementRepository repAdvert = new AdvertisementRepository();
                repAdvert.DeleteAd(delAdId);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Method to access DAL to retrieve previously uploaded Ads
        /// </summary>
        /// <returns></returns>
        public List<AdvertPanel> GetAllUploadedAds()
        {
            List<AdvertPanel> lstAds = new List<AdvertPanel>();
            try
            {
                // Access DAL to retrieve Uploaded Ads
                AdvertisementRepository repAdvert = new AdvertisementRepository();
                lstAds = repAdvert.GetUploadedAds();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return lstAds;
        }

    }
}
