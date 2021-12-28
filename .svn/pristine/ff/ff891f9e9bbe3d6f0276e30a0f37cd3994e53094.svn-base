using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;

namespace ICBrowser.Business
{
    public class BuyerRegistration
    {
        /// <summary>
        /// Method to Access DAL to Add new User's Address details
        /// </summary>
        /// <param name="newUserAddressDetails"></param>
        public bool AddAddressDetails(AddressDetails newUserAddressDetails)
        {
            bool status = false;
            BuyerCompanyDetailsRepository repBuyerAddress = new BuyerCompanyDetailsRepository();
            try
            {
                // Access DAL and insert new Buyer's Address details entry
                status = repBuyerAddress.CreateBuyerAddressDetailsEntry(newUserAddressDetails);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return status;
        }

        /// <summary>
        /// Method to Access DAL to Add new User's Users details
        /// </summary>
        /// <param name="newUserRequest"></param>
        public bool AddUserDetails(UserDetails newUserRequest)
        {
            bool status = false;
            BuyersRepository repBuyerDetails = new BuyersRepository();
            try
            {
                // Access DAL and insert new Buyer's entry
                status = repBuyerDetails.CreateBuyerDetailsEntry(newUserRequest);
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return status;
        }

        public bool CreateUserMembershipDetails(Guid userId, int typeOfMembership, DateTime? membershipExpiryDate)
        {
            UsersRepository objUserMembershipType = new UsersRepository();
            bool status = false;
            try
            {
                status = objUserMembershipType.InsertMembershipTypeDetails(userId, typeOfMembership, membershipExpiryDate);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return status;
        }

        public bool checkAvailability(string userName)
        {
            UsersRepository objUsernameAvailability = new UsersRepository();
            return objUsernameAvailability.CheckUserAvailability(userName);
        }
    }
}
