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


public class BuyersDataRequirement
{
    UserDetails companyDetails = new UserDetails();

    
    public CompanyDetails GetBuyersid(Guid userid)
    {
        Guid currUserId = new Guid();
        var membershipUser = Membership.GetUser();
        if (membershipUser != null)
            if (membershipUser.ProviderUserKey != null)
                currUserId = new Guid(membershipUser.ProviderUserKey.ToString());
        BuyersRepository buyersreqrepo = new BuyersRepository();

        return buyersreqrepo.GetBuyersId(currUserId);
       
    }

  
    

    public List<BuyerDetailsRevised> getBuyerDetailsOnBuyerId(int buyerid)
    {
        BuyerCompanyDetailsRepository bcdr = new BuyerCompanyDetailsRepository();
        List<BuyerDetailsRevised> objBuyerDetails = new List<BuyerDetailsRevised>();
        try
        {
            objBuyerDetails = bcdr.getBuyerDetailOnBuyerId(buyerid);
        }
        catch (Exception ex)
        {
            IClogger.LogError(ex.ToString());
        }
        return objBuyerDetails;
    }

 

   
    public List<EmailDetailsForUser> getLoginUsersSentEmailDetails(MembershipUser fromuserid)
    {
        List<EmailDetailsForUser> lst = new List<EmailDetailsForUser>();
        BuyerCompanyDetailsRepository bcdr = new BuyerCompanyDetailsRepository();
        try
        {
            lst = bcdr.getSentEmailDetailLoginUsers(Convert.ToString(fromuserid.ProviderUserKey));
        }
        catch (Exception ex)
        {
            IClogger.LogError(ex.ToString());
        }
        return lst;
    }

  

    public List<EmailDetailsForUser> getDeleteItemsMessageDetails(MembershipUser userToLogin)
    {
        BuyerCompanyDetailsRepository bcdr = new BuyerCompanyDetailsRepository();
        List<EmailDetailsForUser> lst = new List<EmailDetailsForUser>();
        try
        {
            lst = bcdr.BindGridonForDeleteItems(Convert.ToString(userToLogin.ProviderUserKey));
        }
        catch (Exception ex)
        {
            IClogger.LogError(ex.ToString());
        }
        return lst;
    }

   

    public UserDetails getSellerDetails(string UserID)
    {
        SellersRepository sellerDetailsHelper = new SellersRepository();
        return sellerDetailsHelper.GetSellerDetailsById(UserID);
    }



    public bool IsAdminCheckForLoggedInUsers(Guid userid)
    {
        bool IsAdmin = false;
        BuyerCompanyDetailsRepository bnr = new BuyerCompanyDetailsRepository();
        try
        {
            IsAdmin = bnr.IsAdminCheckForUserLogin(userid);
        }
        catch (Exception ex)
        {
            IClogger.LogError(ex.ToString());
        }
        return IsAdmin;
    }

    public void SaveBuyerUploadDetails(List<BuyersRequirements> finallst)
    {
        BuyersRequirmentsRepository SaveBuyerUploadedDetails = new BuyersRequirmentsRepository();
        foreach (BuyersRequirements buyerdetails in finallst)
        {
            SaveBuyerUploadedDetails.InserBuyerUploadRequirements(buyerdetails);
        }
    }
}

