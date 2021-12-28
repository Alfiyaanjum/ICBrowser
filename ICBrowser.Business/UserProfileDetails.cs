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
    public class UserProfileDetails
    {
        //to get User details 
        public UserProfile GetUserProfileDetails(Guid userid)
        {
            UserProfileRepository profile = new UserProfileRepository();
            //companyDetails = buyersreqrepo.GetBuyersId(userid);
            //int buyerid = companyDetails.BuyerID;

            UserProfile userprofile = new UserProfile();
            userprofile = profile.GetUserProfileDetails(userid);

            return userprofile;

        }

        //to update User details 
        public void UpdateUsersProfile(UserProfile obj)
        {

            UserProfileRepository profile = new UserProfileRepository();
            profile.UpdateUsersProfileDetails(obj);

        }

        //to update User details for bar country
        public void InsertUsersProfileforBarCountry(Guid userid, List<string> countryname)
        {
            UserProfileRepository profile = new UserProfileRepository();
            profile.InsertUsersProfileDetailsforBarCountry(userid, countryname);
        }

        // delete user details for bar country
        public void DeleteUsersProfileforBarCountry(Guid userid, List<string> countryname)
        {
            UserProfileRepository profile = new UserProfileRepository();
            profile.DeleteUsersProfileDetailsforBarCountry(userid, countryname);
        }

        /// <summary>
        /// Description:Get User Details for BarCountry.
        /// </summary>
        /// <returns></returns>

        public List<UserProfile> GetUserBarCountryDetails(Guid userid)
        {
            List<UserProfile> lstbarcountry = new List<UserProfile>();
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            lstbarcountry = usrProfRepo.GetUserBarCountryDetails(userid);
            return lstbarcountry;
        }




        // Membership Expiry Date Update..
        public void UpdateUsersMembershipExpiry(UserProfile obj)
        {

            UserProfileRepository profile = new UserProfileRepository();
            profile.UpdateUsersMembershipExpiry(obj);

        }



        /// <summary>
        /// Description:Get All User Details for Broadcast mail(Admin).
        /// </summary>
        /// <returns></returns>

        public List<UserProfile> GetAllUsrDetails()
        {
            List<UserProfile> lstUsrDetails = new List<UserProfile>();
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            lstUsrDetails = usrProfRepo.GetAllUserDetails();
            return lstUsrDetails;
        }

        /// <summary>
        /// Description:Get All User Details. 
        /// </summary>
        /// <returns></returns>
        
        
        public List<UserProfile> GetAllPaidUsrDetails(Guid loggedinUserId)
        {
            List<UserProfile> lstUsrDetails = new List<UserProfile>();
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            lstUsrDetails = usrProfRepo.GetAllPaidUserDetails(loggedinUserId);
            return lstUsrDetails;
        }

        public List<UserProfile> GetAllTrialUsrDetails()
        {
            List<UserProfile> lstTrialUsrDetails = new List<UserProfile>();
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            lstTrialUsrDetails = usrProfRepo.GetAllTrialUserDetails();
            return lstTrialUsrDetails;
        }

        //public bool SetUsrBlock(Guid usrId)
        //{
        //    UserProfileRepository usrProflRepo = new UserProfileRepository();
        //    bool block = usrProflRepo.SetUsrBlock(usrId);
        //    return block;
        //}
        //public bool SetUsrUnBlock(Guid usrId)
        //{
        //    UserProfileRepository usrProflRepo = new UserProfileRepository();
        //    bool block = usrProflRepo.SetUsrUnBlock(usrId);
        //    return block;
        //}

        /**ReferencelistDetails**/
        //public List<UserProfile> GetAllgvReferencelistDetails(Guid LoggedinUserID)
        //{
        //    List<UserProfile> lstUsrDetails = new List<UserProfile>();
        //    UserProfileRepository usrProfRepo = new UserProfileRepository();
        //    lstUsrDetails = usrProfRepo.GetAllgvReferencelistDetails(LoggedinUserID);
        //    return lstUsrDetails;
        //}

        public List<UserProfile> GetAllFreeUsrDetails(Guid LoggedinUserID)
        {
            List<UserProfile> lstUsrDetails = new List<UserProfile>();
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            lstUsrDetails = usrProfRepo.GetAllFreeUsrDetails(LoggedinUserID);
            return lstUsrDetails;
        }

        public List<UserProfile> GetMatchRecords(UserProfile usrProf)
        {
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            List<UserProfile> lstUserProf = new List<UserProfile>();
            lstUserProf = usrProfRepo.GetMatchRecords(usrProf);
            return lstUserProf;
        }

        public bool UpdateTrialUserRecord(Guid guid)
        {
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            bool block = usrProfRepo.UpdateTrialUserRecord(guid);
            return block;
        }

        public void SetMemberShipTypeForTrialUser(Guid currUserId)
        {
            UserProfileRepository usrProfRepo = new UserProfileRepository();
            usrProfRepo.UpdateMemberShipForTrialUser(currUserId);
        }

        //Exclude User
        public bool SetExcludeUser(Guid Loggedinuserid, Guid ExcludeUserId)
        {
            UserProfileRepository usrProflRepo = new UserProfileRepository();
            bool block = usrProflRepo.SetExcludeUsr(Loggedinuserid, ExcludeUserId);
            return block;
        }

        //Un-Exclude User
        public bool SetUnExludeUser(Guid Loggedinuserid, Guid UnexcludeUserId)
        {
            UserProfileRepository usrProflRepo = new UserProfileRepository();
            bool block = usrProflRepo.SetUnExcludeUsr(Loggedinuserid, UnexcludeUserId);
            return block;
        }



        //Block User
        public bool SetBlockUser(UserProfile obj)
        {
            UserProfileRepository usrProflRepo = new UserProfileRepository();
            bool block = usrProflRepo.SetBlockUsr(obj);
            return block;
        }

        //UnBlock User
        public bool SetUnBlockUser(UserProfile obj)
        {
            UserProfileRepository usrProflRepo = new UserProfileRepository();
            bool block = usrProflRepo.SetUnBlockUsr(obj);
            return block;
        }

        //Update Decline User
        public void SetDeclineUser(UserProfile Profile)
        {
            UserProfileRepository usrProflRepo = new UserProfileRepository();
            usrProflRepo.SetDeclineUsr(Profile);
            
        }

        ////Approved User
        //public bool GetApprove(Guid UserId)
        //{
        //    UserProfileRepository usrProflRepo = new UserProfileRepository();
        //    bool Approve = usrProflRepo.GetUserApprove(UserId);
        //    return Approve;
        //}
    }
}
