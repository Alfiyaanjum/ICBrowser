using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
namespace ICBrowser.Business
{
    public class BuyersRequirement
    {
        BuyersRepository rep = new BuyersRepository();
        List<BuyersRequirements> lst = new List<BuyersRequirements>();
        public int TotalPages { get; set; }

        public List<BuyersRequirements> GetRequirementsDetails()
        {
            lst = rep.GetBuyersRequirements();

            return lst;
        }

        public List<BuyersRequirements> GetRequirementsDetailsForMatch(Guid userId)
        {
            lst = rep.GetUsersRequirementsDetailsForMatch(userId);

            return lst;
        }

        public List<BuyersRequirements> GetAllRequirementsDetailsForMatch(Guid UserId, int pageSize, int pageIndex)
        {
            lst = rep.GetAllUsersRequirementsDetailsForMatch(UserId, pageSize, pageIndex);


            TotalPages = rep.TotalPages;
            return lst;
        }
    }
}
