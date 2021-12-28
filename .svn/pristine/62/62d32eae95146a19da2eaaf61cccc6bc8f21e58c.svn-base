using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public interface IUserMembershipDetails
    {
         Guid UserId { get; set; }
         int TypeOfMembership { get; set; }
         DateTime? MembershipExpiryDate { get; set; }
         int? PaymentOption { get; set; }
         Boolean? PaymentStatus { get; set; }
         int? OfflineMembership { get; set; }
    }

    public class UserMembershipDetails : IUserMembershipDetails
    {
        public Guid UserId { get; set; }

        public int TypeOfMembership { get; set; }

        public DateTime? MembershipExpiryDate { get; set; }

        public int? PaymentOption { get; set; }

        public bool? PaymentStatus { get; set; }

        public int? OfflineMembership { get; set; }
    }
}
