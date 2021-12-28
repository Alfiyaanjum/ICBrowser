using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Security;
using System.IO;
using ICBrowser.Business;
using System.Collections.Generic;
using ICBrowser.Common;
using ICBrowser.DAL;


namespace ICBrowser.Business
{
    public class UserRequirements
    {
        /// <summary>
        /// Requirement Grid Binding
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BuyersRequirements> UserRequirementListingRFQByUserId(Guid userId)
        {
            UserRequirementRepository UserRepoObj = new UserRequirementRepository();
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            try
            {
                lst = UserRepoObj.BuyersRequirementDetailsRFQById(userId);
                if (lst != null)
                {
                    return lst;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return null;
        }

        public List<BuyersRequirements> UserRequirementListingByUserId(Guid userId)
        {
            UserRequirementRepository UserRepoObj = new UserRequirementRepository();
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            try
            {
                lst = UserRepoObj.BuyersRequirementDetailsById(userId);
                if (lst != null)
                {
                    return lst;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return null;
        }

        public List<BuyersRequirements> UserDetailRequirementsByUserIdwithPO(Guid userId)
        {
            UserRequirementRepository UserRepoObj = new UserRequirementRepository();
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            try
            {
                lst = UserRepoObj.BuyersRequirementDetailswithPOById(userId);
                if (lst != null)
                {
                    return lst;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Requirement Search
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="ddlType"></param>
        /// <returns></returns>
        public List<BuyersRequirements> getSearchContent(string txtSearch, string ddlType, Guid userId)
        {
            UserRequirementRepository UserRepoObj = new UserRequirementRepository();
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            //Guid userId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
            try
            {
                lst = UserRepoObj.getBuyerRequirementsDetailsForSearch(userId, txtSearch, ddlType);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                throw;
            }
            return lst;
        }

        /// <summary>
        /// Requirement Updating on row update
        /// </summary>
        /// <param name="buyerreqid"></param>
        /// <param name="userId"></param>
        /// <param name="withpo"></param>
        /// <param name="quantity"></param>
        /// <param name="componentName"></param>
        /// <param name="description"></param>
        /// <param name="brandname"></param>
        /// <param name="NotificationStatus"></param>
        /// <param name="datecode"></param>
        /// <param name="package"></param>
        /// <param name="country"></param>
        public void rowUpdatebuyrsreq(int buyerreqid, Guid userId, int withpo, int quantity, string componentName, string description, string brandname, int NotificationStatus, string package, string datecode, decimal? priceinusd)
        {
            UserRequirementRepository buyerrep = new UserRequirementRepository();
            buyerrep.rowUpdateBuysReq(buyerreqid, userId, withpo, quantity, componentName, description, brandname, NotificationStatus, package, datecode, priceinusd);
        }

        /// <summary>
        /// Requirement Delete on row delete
        /// </summary>
        /// <param name="Buyerreqid"></param>
        public void rowDeletebuyrsreq(int Buyerreqid)
        {
            UserRequirementRepository buyerreqrep = new UserRequirementRepository();
            buyerreqrep.rowDeleteBuysReq(Buyerreqid);
        }

        /*************************************************************************************
         * This method is of now use, but it has been kept if in case of any issue or
         * problem- Minoy Kansara, Date : 01-08-2012, Will Remove this method in code enhancement phase
         **************************************************************************************/
        /// <summary>
        /// Insert Requirement for mapping and bulk requirement upload
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public bool AddUserRequirements(List<BuyersRequirements> dirList)
        {
            bool returnFlag = false;
            UserRequirementRepository objUserRequirementRepo = new UserRequirementRepository();
            try
            {
                DataTable dtReqList = new DataTable();

                DataColumn creationDate = new DataColumn("creationData");
                creationDate.DataType = System.Type.GetType("System.DateTime");
                dtReqList.Columns.Add(creationDate);

                DataColumn modifiedDate = new DataColumn("modifiedDate");
                modifiedDate.DataType = System.Type.GetType("System.DateTime");
                dtReqList.Columns.Add(modifiedDate);

                DataColumn brandName = new DataColumn("brandName");
                brandName.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(brandName);

                DataColumn buyerName = new DataColumn("buyerName");
                buyerName.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(buyerName);

                DataColumn userId = new DataColumn("userId");
                userId.DataType = System.Type.GetType("System.Guid");
                dtReqList.Columns.Add(userId);

                DataColumn status = new DataColumn("status");
                status.DataType = System.Type.GetType("System.Int32");
                dtReqList.Columns.Add(status);

                DataColumn componentName = new DataColumn("componentName");
                componentName.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(componentName);

                DataColumn Quantity = new DataColumn("Quantity");
                Quantity.DataType = System.Type.GetType("System.Int32");
                dtReqList.Columns.Add(Quantity);

                DataColumn description = new DataColumn("description");
                description.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(description);

                DataColumn PriceInUSD = new DataColumn("PriceInUSD");
                PriceInUSD.DataType = System.Type.GetType("System.Decimal");
                dtReqList.Columns.Add(PriceInUSD);

                DataColumn notificationSent = new DataColumn("notificationSent");
                notificationSent.DataType = System.Type.GetType("System.Boolean");
                dtReqList.Columns.Add(notificationSent);

                DataColumn conc_cat = new DataColumn("conc_cat");
                conc_cat.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(conc_cat);

                DataColumn Package = new DataColumn("Package");
                Package.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(Package);

                DataColumn DateCode = new DataColumn("DateCode");
                DateCode.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(DateCode);

                DataColumn RequirementwithPO = new DataColumn("RequirementwithPO");
                RequirementwithPO.DataType = System.Type.GetType("System.Boolean");
                dtReqList.Columns.Add(RequirementwithPO);

                DataColumn CompanyName = new DataColumn("CompanyName");
                CompanyName.DataType = System.Type.GetType("System.String");
                dtReqList.Columns.Add(CompanyName);


                DataRow drForGrid;

                foreach (BuyersRequirements dir in dirList)
                {
                    drForGrid = dtReqList.NewRow();
                    drForGrid["creationData"] = DateTime.Now.ToString("dd-MMM-yyyy");
                    drForGrid["modifiedDate"] = DateTime.Now.ToString("dd-MMM-yyyy");
                    //drForGrid["RequiredBefore"] = dir.RequiredBefore.GetValueOrDefault().ToString("dd-MMM-yyyy");
                    drForGrid["brandName"] = dir.BrandName;
                    drForGrid["buyerName"] = dir.BuyerName;
                    drForGrid["userId"] = dir.userId;
                    drForGrid["status"] = dir.Status;
                    drForGrid["componentName"] = dir.ComponentName;
                    drForGrid["Quantity"] = dir.Quantity;
                    drForGrid["PriceInUSD"] = dir.PriceInUSD;
                    drForGrid["description"] = dir.Description;
                    drForGrid["notificationSent"] = dir.NotificationSent;
                    drForGrid["Package"] = dir.Package;
                    drForGrid["DateCode"] = dir.DateCode;
                    drForGrid["RequirementwithPO"] = dir.RequirementwithPO;
                    //drForGrid["Country"] = dir.Country;
                    drForGrid["CompanyName"] = dir.CompanyName;
                    dtReqList.Rows.Add(drForGrid);

                }
                returnFlag = objUserRequirementRepo.InsertUserRequirments(dtReqList);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return returnFlag;
        }
        public List<Common.BuyersRequirements> DeleteRequirements(List<BuyersRequirements> dir)
        {
            List<Common.BuyersRequirements> list = new List<Common.BuyersRequirements>();
          //  int insertcount = 0;
            Common.BuyersRequirements objRequirements = new Common.BuyersRequirements();
            //int status = 1; // if status=1 then Open if 0 then Close
            //bool NotificationStatus = false;
            UserRequirementRepository objRequirementsRepository = new UserRequirementRepository();
            try
            {
                foreach (BuyersRequirements data in dir)
                {
                    list = objRequirementsRepository.DeleteRequirements(data);
                }

            }


            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return list;
        }
        public bool InsertUserRequirementsManually(List<BuyersRequirements> dirList)
        {
            bool returnFlag = false;
            UserRequirementRepository objUserRequirementRepo = new UserRequirementRepository();
            try
            {
                foreach (BuyersRequirements data in dirList)
                {
                    returnFlag = objUserRequirementRepo.SaveUserRequirementsManually(data);
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return returnFlag;
        }

        public int InsertUserRequirements(List<BuyersRequirements> dirList)
        {
            int count = 0;
            bool result = false;
            UserRequirementRepository objUserRequirementRepo = new UserRequirementRepository();
            try
            {
                foreach (BuyersRequirements data in dirList)
                {
                    result = objUserRequirementRepo.SaveUserRequirements(data);
                    if (result)
                        count++;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return count;
        }
        //**********************************************************************************
        // NEED TO REMOVE THIS PROPERTY FROM THIS CLASS
        //**********************************************************************************
        /// <summary>
        ///
        /// To check wheather user if buyer or not
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int GetUserCountByUserId(Guid UserId)
        {
            //BuyersRequirmentsRepository buyerreqrep = new BuyersRequirmentsRepository();
            UsersRepository UsrRepo = new UsersRepository();

            int UserCount = 0;
            try
            {
                UserCount = UsrRepo.getUserCount(UserId);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return UserCount;
        }

        public UserDetails getUserDetails(string UserID)
        {
            UsersRepository userDetailsHelper = new UsersRepository();
            return userDetailsHelper.GetUserDetailsById(UserID);
        }
    }
}
