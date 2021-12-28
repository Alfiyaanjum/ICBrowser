using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class SellerRegistration
    {
       

        /// <summary>
        /// Method to access DAL to retrieve membership packages
        /// </summary>
        /// <returns></returns>
        public List<TypeOfMembership> GetMembershipPackageDetails()
        {
            List<TypeOfMembership> membershipPackages = new List<TypeOfMembership>();
            try
            {
                // Access DAL to get types of memberships from database
                SellersRepository repForMembership = new SellersRepository();
                membershipPackages = repForMembership.GetMembershipPackages();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return membershipPackages;
        }

        /// <summary>
        /// Method to access DAL to retrieve 'Trial' membership's details
        /// </summary>
        /// <returns></returns>
        public TypeOfMembership GetTrialMembership()
        {
            TypeOfMembership trial = new TypeOfMembership();
            try
            {
                // Access DAL to get 'Trial' membership's details
                SellersRepository repForTrial = new SellersRepository();
                trial = repForTrial.GetTrialMembershipDetails();
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return trial;
        }
    }
}
