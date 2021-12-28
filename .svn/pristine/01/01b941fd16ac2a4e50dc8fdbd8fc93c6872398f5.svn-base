using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    public class BuyersDetailedListing
    {
        public int TotalPages { get; set; }
        
        public IEnumerable<BuyersRequirements> BuyersDetailedRequirements(int pageSize, int pageIndex)
        {
            List<BuyersRequirements> lstbuyerid = new List<BuyersRequirements>();
            BuyersRepository buyerrep = new BuyersRepository();
            lstbuyerid = buyerrep.GetBuyersDetailedRequirements(pageSize, pageIndex);
            TotalPages = buyerrep.TotalPages;
            return lstbuyerid;
        }

        /// <summary>
        /// Display On Requirement Data having status on "PO"
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IEnumerable<BuyersRequirements> GetDetailedRequirementWithPO(int pageSize, int pageIndex)
        {
            List<BuyersRequirements> lstbuyerid = new List<BuyersRequirements>();
            BuyersRepository buyerrep = new BuyersRepository();
            lstbuyerid = buyerrep.GetBuyersDetailedRequirementsWithPO(pageSize, pageIndex);
            TotalPages = buyerrep.TotalPages;
            return lstbuyerid;
        }
    }
}
