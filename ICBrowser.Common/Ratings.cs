using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public class Ratings
    {
        //public int buyerid { get; set; }
        //public int Question1rating { get; set; }
        //public int Question2rating { get; set; }
        //public int Question3rating { get; set; }
        //public int Question4rating { get; set; }
        //public int Question5rating { get; set; }
        //public int SellersAvgRate { get; set; }


        //----New rating attributes-----//
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public int Question1Rating { get; set; }
        public int Question2Rating { get; set; }
        public int Question3Rating { get; set; }
        public int Question4Rating { get; set; }
        public int Question5Rating { get; set; }
        public string Comment { get; set; }
        public int avg { get; set; }
        public int IsAdmin { get; set; }


        public string question1 { get; set; }
        public string question2 { get; set; }
        public string question3 { get; set; }
        public string question4 { get; set; }
        public string question5 { get; set; }

    }
}
