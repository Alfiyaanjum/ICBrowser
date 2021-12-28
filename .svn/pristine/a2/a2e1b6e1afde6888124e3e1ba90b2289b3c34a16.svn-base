using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
using System.Data;
using System.Web.Security;

namespace ICBrowser.Business
{
    public class InventoryGridDetails : ComponentRepository
    {
        #region PrivateFunctions
        Guid currUserId = new Guid();
        ComponentRepository ivr = new ComponentRepository();
        public int sellid = 0;
        DataTable getCompanyname = new DataTable();
        #endregion


        /// <summary>
        /// Gets Membership ExpiryDate
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetMembershipExpireddate(Guid userid)
        {
            int Membershipstatus = 0;
            try
            {
                Membershipstatus = ivr.MembershipExpiredDate(userid);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return Membershipstatus;

        }


        /// <summary>
        /// deletes the selected componenet from grd
        /// </summary>
        /// <param name="ComponentId"></param>
        public void deleteSelectedComponent(int ComponentId)
        {
            try
            {
                ivr.delete(ComponentId);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

        }


        /// <summary>
        /// gets UserId(SellerId) and CompanyName and type Of membership
        /// </summary>
        /// <returns></returns>
        public DataTable getinventorylist()
        {
            // DataTable dtInventorydetails = new DataTable();
            DataTable dtgetid = new DataTable();
            try
            {
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                {
                    if (membershipUser.ProviderUserKey != null)
                    {
                        currUserId = new Guid(membershipUser.ProviderUserKey.ToString());
                        dtgetid = ivr.getSellerId(currUserId);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return dtgetid;
        }


        /// <summary>
        /// gets (*) from Component Table to display in grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllComponentDetails(Guid usrId)
        {
            DataTable dtInventorydetails = new DataTable();
            try
            {
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                {
                    if (membershipUser.ProviderUserKey != null)
                    {
                        dtInventorydetails = ivr.SelectInventoryDetailsforGrid(usrId);
                        //currUserId = new Guid(membershipUser.ProviderUserKey.ToString());
                        //dtInventorydetails = ivr.SelectInventoryDetailsforGrid(currUserId);
                    }
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return dtInventorydetails;
        }


        /// <summary>
        ///  gets the permitted count of Saving Compoenet
        /// </summary>
        /// <param name="membershiptype"></param>
        /// <returns></returns>
        public int getComponentListingCount(int membershiptype)
        {
            int listcount = 0;
            List<TypeOfMembership> lst = new List<TypeOfMembership>();
            // listcount = ivr.GetSellerListingCount(membershiptype);
            lst = ivr.GetSellersMemberShipDetails(membershiptype);
            listcount = lst[0].ListingCount;
            return listcount;
        }

        /// <summary>
        /// gets the saved Components count of a seller
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// 
        public int getOfferCount(Guid UserId)
        {
            int cnt = 0;
            cnt = ivr.getOfferCountBySellerId(UserId);
            return cnt;
        }

        public int getComponentCount(Guid UserId)
        {
            int cnt = 0;
            cnt = ivr.getComponentCountBySellerId(UserId);
            return cnt;
        }

        /// <summary>
        /// this method gets MembershipTypeId,UserId,Compoanyname and check for paid membership
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserProfile GetUserCountByUserId(Guid userid)
        {
            ComponentRepository sellerCountRep = new ComponentRepository();
            UserProfile Objuserprof = new UserProfile();
            try
            {
                Objuserprof = sellerCountRep.GetSellersCount(userid);
            }
            catch (Exception ex)
            {

                IClogger.LogMessage(ex.Message);
            }
            return Objuserprof;
        }

        /// <summary>
        /// Gets the result for searched data in Filter with grid 
        /// </summary>
        /// <param name="ddlSelectedValue"></param>
        /// <param name="searchtext"></param>
        /// <returns></returns>
        public List<Component> GetRequestedSearchGridData(Guid usrId, int ddlSelectedValue, string searchtext)
        {
            List<Component> lstinve = new List<Component>();
            try
            {
                //var membershipUser = Membership.GetUser();
                //currUserId = new Guid(membershipUser.ProviderUserKey.ToString());
                lstinve = ivr.GetSearchedData(usrId, searchtext, ddlSelectedValue);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return lstinve;

        }


        /// <summary>
        /// gets Users membership details
        /// </summary>
        /// <param name="typeOfMembership"></param>
        /// <returns></returns>
        public TypeOfMembership GetMembershipDetails(int typeOfMembership)
        {
            ComponentRepository componentHelper = new ComponentRepository();
            return componentHelper.getMembershipDetails(typeOfMembership);
        }

        /// <summary>
        /// new method to insert Invemtpries reqwuired
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        /// 


       


        public int AddBulkInventoriesManually(List<Common.Component> dir)
        {
            bool result = false;
            int insertcount = 0;
            Common.Component objComponent = new Common.Component();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            ComponentRepository objComponentRepository = new ComponentRepository();
            try
            {
                foreach (ICBrowser.Common.Component requestData in dir)
                {
                    result = objComponentRepository.InsertInventoryManually(requestData);
                    if (result)
                        insertcount++;
                    
                }
            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertcount;
        }




        public int AddBulkInventories(List<Common.Component> dir, int leftspace)
        {
            int insertcount = 0;
            bool result = false;
            Common.Component objComponent = new Common.Component();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            ComponentRepository objComponentRepository = new ComponentRepository();
            try
            {
                foreach (ICBrowser.Common.Component requestData in dir)
                {
                    if (insertcount < leftspace)
                    {
                        result = objComponentRepository.InsertInventory(requestData);
                        if (result)
                            insertcount++;
                    }
                    else
                        break;


                }
            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertcount;
        }

        public int DeleteOffers(List<Component> dir)
        {
            int result = 0;
            List<Component> list = new List<Component>();
            int insertcount = 0;
            Common.Component objComponent = new Common.Component();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            ComponentRepository objComponentRepository = new ComponentRepository();
            try
            {

                result = objComponentRepository.DeleteOffers(dir[0].stockstatus, dir[0].UserId);


            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return result;
        }


        public int DeleteInventories(List<Component> dir)
        {
            List<Component> list = new List<Component>();
            int result = 0;
            Common.Component objComponent = new Common.Component();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            ComponentRepository objComponentRepository = new ComponentRepository();
            try
            {

                result = objComponentRepository.DeleteInventory(dir[0].stockstatus, dir[0].UserId);


            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return result;
        }
        public int OverWriteInventories(List<Common.Component> dir)
        {
            int insertcount = 0;
            Common.Component objComponent = new Common.Component();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            ComponentRepository objComponentRepository = new ComponentRepository();
            try
            {
                foreach (ICBrowser.Common.Component requestData in dir)
                {
                    insertcount = objComponentRepository.OverWriteInventory(requestData);
                }
            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertcount;
        }
        /// <summary>
        /// passing list of updated inventory details(new required) **********
        /// </summary>
        /// <param name="lstUpdatedInventory"></param>
        public void UpdateInventories(Component objUpdatedInventory)
        {
            try
            {
                ivr.updateInventoriesDAL(objUpdatedInventory);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }
    }
}
