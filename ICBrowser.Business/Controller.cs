using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class Controller
    {
        public string UserName { get; set; }

        /// <summary>
        /// Search Inventory on Master Page
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<Component> SearchComponents(string searchText, Guid loggedinUserId)
        {
            ComponentRepository componentHelper = new ComponentRepository();
            return componentHelper.SearchComponents(searchText, loggedinUserId);
        }

        /// <summary>
        /// Search Requirements on Master Page
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<BuyersRequirements> SearchRequirements(string searchText)
        {
            BuyersRequirmentsRepository requirementHelper = new BuyersRequirmentsRepository();
            return requirementHelper.SearchRequirements(searchText);
        }

        /// <summary>
        /// Search Offers on Master Page
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<Component> SearchOffers(string searchText)
        {
            UserOfferDataRepository objUserOfferData = new UserOfferDataRepository();
            return objUserOfferData.SearchOffers(searchText);
        }

        public CompanyDetails GetBuyerCompanyDetails(int ID, string username)
        {
            BuyerCompanyDetailsRepository compDetailsHelper = new BuyerCompanyDetailsRepository();
            return compDetailsHelper.GetBuyerCompanyDetailsByID(ID, username);
        }

        public bool Create(TransactionDetails obj)
        {
            TransactionRepository transactionHelper = new TransactionRepository();
            return transactionHelper.Create(obj);
        }

        public TransactionDetails GetTranscationDetailById(string merchantOrderId)
        {
            TransactionRepository transactionHelper = new TransactionRepository();
            return transactionHelper.GetTransactionById(merchantOrderId);
        }

        public void UpdateTransaction(TransactionDetails transaction)
        {
            TransactionRepository transactionHelper = new TransactionRepository();
            transactionHelper.Update(transaction);
        }

        public UserDetails GetSellerDetailById(string UserID)
        {
            SellersRepository sellerDetailsHelper = new SellersRepository();
            return sellerDetailsHelper.GetSellerDetailsById(UserID);
        }

        public Users GetIsAdmin(Guid UserId)
        {
            Users usr = new Users();
            UsersRepository usrRepo = new UsersRepository();
            usr = usrRepo.GetAdmin(UserId);
            return usr;
        }

        public List<ICBrowser.Common.Component> SearchFilteredComponent(Guid userId, string partNumber, int quantity, string make, string package, string dateCode, string stockStatus, string lastupdated, int exMatch)
        {
            ComponentRepository componentHelper = new ComponentRepository();
            return componentHelper.filterSearchComponent(userId, partNumber, quantity, make, package, dateCode, stockStatus, lastupdated, exMatch);
        }

        public List<BuyersRequirements> SearchFilteredRequirement(string partNumber, int quantity, string make, string package, string dateCode, string reqStatus, string lastupdated, int exMatch)
        {
            BuyersRequirmentsRepository componentHelper = new BuyersRequirmentsRepository();
            return componentHelper.filterSearchRequirement(partNumber, quantity, make, package, dateCode, reqStatus, lastupdated, exMatch);
        }

        public UserMembershipDetails GetUserMembershipDetailById(string UserID)
        {
            SellersRepository sellerDetailsHelper = new SellersRepository();
            return sellerDetailsHelper.GetUserMembershipDetailsById(UserID);
        }

        public void UpdateUserMembershipDetails(UserMembershipDetails obj)
        {
            SellersRepository userProfile = new SellersRepository();
            userProfile.UpdateUserMembershipDetails(obj);
        }

        public bool GetIsValidUser(Guid userid)
        {
            Users usr = new Users();
            UsersRepository usrRepo = new UsersRepository();
            return usrRepo.GetValidUser(userid);             
        }
    }
}
