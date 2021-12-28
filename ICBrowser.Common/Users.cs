using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public class Users
    {
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }
        //public int AvgRating { get; set; }

    }
}
