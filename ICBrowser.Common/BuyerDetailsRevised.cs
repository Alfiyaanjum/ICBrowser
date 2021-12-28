using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{

    public class BuyerDetailsRevised
    {
        # region Private Fields

        private int buyerID;
        private string companyName;
        private string contactName;
        private Guid userId;
        private string currency;
        private string ownerName;

        # endregion

        # region Public Properties

        public int BuyerID
        {
            get
            {
                return buyerID;
            }
            set
            {
                buyerID = value;
            }
        }


        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public Guid UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }
        public int TotalItems { get; set; }
        #endregion
    }

}
