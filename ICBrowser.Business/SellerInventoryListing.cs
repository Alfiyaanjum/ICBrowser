using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;
using System.Data;


namespace ICBrowser.Business
{
    public class SellerInventoryListing
    {
        public int TotalPages { get; set; }

        public List<Component> SellerInventoryDetails(Guid loggedinUserId)
        {
            List<Component> lstinve = new List<Component>();
            ComponentRepository comprepo = new ComponentRepository();
            //ComponentRepository cr= new ComponentRepository();
            lstinve = comprepo.GetSellerInventoryDetails(loggedinUserId);
            return lstinve;
        }

        public List<Component> ComponentDetailsByComponentName(string componentName)
        {
            List<Component> lstcompo = new List<Component>();
            ComponentRepository comprepo = new ComponentRepository();
            //ComponentRepository cr= new ComponentRepository();
            lstcompo = comprepo.GetComponentDetailsByComponentName(componentName);
            return lstcompo;
        }

        public List<Component> DetailedInventory(int pageSize, int pageIndex)
        {
            List<Component> lstcomp = new List<Component>();
            ComponentRepository comprep = new ComponentRepository();
            lstcomp = comprep.GetDetailedInventory(pageSize, pageIndex);           

            TotalPages = comprep.TotalPages;
            return lstcomp;
        }

     

        public void CreateSellerEmailDetails(int sellerid, int buyerid, string txtSubject, string txtContent, DateTime dateTime, int status)
        {
            SellersRepository sr = new SellersRepository();
            try
            {
                sr.createSellerEmailDetails(sellerid, buyerid, txtSubject, txtContent, dateTime, status);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public void createBuyerEmailDetails(int buyerid, string sellerid, string txtSubject, string txtContent, DateTime dateTime, int status)
        {
            SellersRepository sr = new SellersRepository();
            try
            {
                sr.CreateBuyerSentEmailDetails(buyerid, sellerid, txtSubject, txtContent, dateTime, status);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
        }

        public List<UserDetails> GetEmailIds(string newSellId)
        {
            List<UserDetails> lstEmail = new List<UserDetails>();
            ComponentRepository compoRepo = new ComponentRepository();
            lstEmail = compoRepo.GetEmailIds(newSellId);
            return lstEmail;
        }

        public List<Component> UserOfferDetailsForMatch(Guid userId, Guid loggedInUserId)
        {
            List<Component> lstinve = new List<Component>();
            ComponentRepository comprepo = new ComponentRepository();
            lstinve = comprepo.GetUserOfferDetailsForMatch(userId, loggedInUserId);
            return lstinve;
        }

        public List<Component> GetAllInventoryDetailsForMatch(Guid userid, int pageSize, int pageIndex)
        {
            List<Component> lstmatch = new List<Component>();
            ComponentRepository compmatch = new ComponentRepository();
            lstmatch = compmatch.GetAllInventoryDetailsForMatch(userid, pageSize, pageIndex);

            TotalPages = compmatch.TotalPages;
            
            return lstmatch;
        }

        public List<Component> GetAllInventoryDetailsForMatchSearch(Guid userid, string searchtext)
        {
            List<Component> lstmatch = new List<Component>();
            ComponentRepository compmatch = new ComponentRepository();
            lstmatch = compmatch.GetAllInventoryDetailsForMatchSearchDAL(userid, searchtext);
            return lstmatch;
        }


    }
}

