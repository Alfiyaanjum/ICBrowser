using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{   
    public class EmailNotificationAdvertiser
    {
        public int AdvertisementID { get; set; }
        public Guid UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
