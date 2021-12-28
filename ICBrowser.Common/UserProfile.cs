
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ICBrowser.Common
{
    public class UserProfile : IUserDetails, IAddressDetails, IUserMembershipDetails, ITypeOfMembership
    {
        public bool IsExcluded { get; set; }

        public string Barcountry { get; set; }

        public int MembershipTypeId { get; set; }

        public string MembershipTypeName { get; set; }

        public int ListingCount { get; set; }

        public int OfferLimit { get; set; }

        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountUSD { get; set; }

        public Guid UserId { get; set; }

        public int TypeOfMembership { get; set; }

        public DateTime? MembershipExpiryDate { get; set; }

        public DateTime? MembershipCreation { get; set; }

        public int? PaymentOption { get; set; }

        public bool? PaymentStatus { get; set; }

        public int? OfflineMembership { get; set; }


        public string PrimaryAddress { get; set; }

        public string PrimaryCity { get; set; }

        public string PrimaryState { get; set; }

        public string PrimaryZip { get; set; }

        public string PrimaryCountry { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryCity { get; set; }

        public string SecondaryState { get; set; }

        public string SecondaryZip { get; set; }

        public string SecondaryCountry { get; set; }

        public string LandLine { get; set; }

        public string Mobile { get; set; }

        public string Extension { get; set; }

        public string Website { get; set; }

        public string FaxNumber { get; set; }

        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string OwnerName { get; set; }

        public int EmailPreference { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Currency { get; set; }

        public string PanNumber { get; set; }

        public string Specialization { get; set; }

        public string EmailId { get; set; }

        public string email { get; set; }

        public bool? IsApproved { get; set; }

        public string QQId { get; set; }

        public string SkypeId { get; set; }

        public string MSNId { get; set; }

        public string ReasonToBlock { get; set; }

        public string ReasonToUnblock { get; set; }

        public string ReasonToDecline { get; set; }

        public int? IsDecline { get; set; }
    }
}
