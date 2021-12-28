using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public interface IUserDetails
    {
        Guid UserID { get; set; }
        string UserName { get; set; }
        string CompanyName { get; set; }
        string ContactName { get; set; }
        string OwnerName { get; set; }
        int EmailPreference { get; set; }
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string Currency { get; set; }
        string PanNumber { get; set; }
        string Specialization { get; set; }
        string EmailId { get; set; }

    }

    public class UserDetails : IUserDetails
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string GstNumber { get; set; }

        public string OwnerName { get; set; }

        public int EmailPreference { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Currency { get; set; }

        public string PanNumber { get; set; }

        public string Specialization { get; set; }

        public string EmailId { get; set; }

        public int IsDecline { get; set; }

        public string ReasonToDecline { get; set; }

        public int TypeOfMembership { get; set; }

        public int? OfflineMembership { get; set; }
    }

}
