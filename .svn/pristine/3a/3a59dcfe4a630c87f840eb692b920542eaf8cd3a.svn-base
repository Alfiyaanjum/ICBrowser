using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public static class TransactionReponse
    {
        public static string Direcpayreferenceid { get; set; }
        public static TransactionState Flag { get; set; }
        public static string Country { get; set; }
        public static string Currency { get; set; }
        public static MembershipType Otherdetails { get; set; }
        public static string Merchantorderno { get; set; }
        public static decimal Amount { get; set; }
        public static string Description { get; set; }
    }


    public class TransactionDetails
    {
        public int TransactionId { get; set; }
        public long DirectPayReferenceID { get; set; }
        public Guid UserID { get; set; }
        public string MerchantOrderNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public int MembershipType { get; set; }
        public string Description { get; set; }
    }

    public enum TransactionState
    {
        SUCCESS = 1,
        FAIL,
        ERROR,
        INITIATE
    }

    public enum MembershipType
    {
        Free = 1,
        TRIAL,
        SILVER,
        GOLD,
        PLATINUM
    }
}
