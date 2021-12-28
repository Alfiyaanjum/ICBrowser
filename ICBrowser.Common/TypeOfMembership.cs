using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ICBrowser.Common
{
    public interface ITypeOfMembership
    {
         int MembershipTypeId { get; set; }
         string MembershipTypeName { get; set; }
         int ListingCount { get; set; }
         int OfferLimit { get; set; }
         int Duration { get; set; }
         decimal Amount { get; set; }
         decimal AmountUSD { get; set; }
    }


    public class TypeOfMembership : ITypeOfMembership
    {
        public int MembershipTypeId { get; set; }

        public string MembershipTypeName { get; set; }

        public int ListingCount { get; set; }

        public int OfferLimit { get; set; }

        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountUSD { get; set; }
    }
}
