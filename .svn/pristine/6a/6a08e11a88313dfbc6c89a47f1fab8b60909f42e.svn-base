using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.DAL;
using ICBrowser.Common;

namespace ICBrowser.Business
{
    public class OfflineSubscriptionDetails
    {
        public List<UserDetails> GetOfflineSubscriptDetails()
        {
            List<UserDetails> lstOfflineSubscription = new List<UserDetails>();
            ComponentRepository compoRepo = new ComponentRepository();
            lstOfflineSubscription = compoRepo.GetOfflineSubscriDetails();
            return lstOfflineSubscription;
        }

        public bool UpdateOfflineSubscriptionDetails(UserDetails ud)
        {
            ComponentRepository compRepo = new ComponentRepository();
            bool flag = compRepo.UpdateOfflineSubscription(ud);
            return flag;
        }

        public void deleteDegradedUserRecords(Guid UserId)
        {
            ComponentRepository compRepo = new ComponentRepository();
            compRepo.deleteDegradedMembersData(UserId);
        }

    }

    public class DeclineUserDetails
    {
        public List<UserDetails> GetDeclineUserDetails()
        {
            List<UserDetails> lstDeclineUser = new List<UserDetails>();
            ComponentRepository compoRepo = new ComponentRepository();
            lstDeclineUser = compoRepo.GetDeclineUserDetails();
            return lstDeclineUser;
        }
    }
}
