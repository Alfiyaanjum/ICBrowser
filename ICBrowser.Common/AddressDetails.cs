using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{

    public interface IAddressDetails
    {
         Guid UserId { get; set; }
         string PrimaryAddress { get; set; }
         string PrimaryCity { get; set; }
         string PrimaryState { get; set; }
         string PrimaryZip { get; set; }
         string PrimaryCountry { get; set; }

         string SecondaryAddress { get; set; }
         string SecondaryCity { get; set; }
         string SecondaryState { get; set; }
         string SecondaryZip { get; set; }
         string SecondaryCountry { get; set; }

         string LandLine { get; set; }
         string Mobile { get; set; }
         string Extension { get; set; }
         string Website { get; set; }
         string FaxNumber { get; set; }
         string QQId { get; set; }
         string SkypeId { get; set; }
         string MSNId { get; set; }
    }

    public class AddressDetails : IAddressDetails
    {
        public Guid UserId { get; set; }

        public string PrimaryAddress { get; set; }

        public string PrimaryCity { get; set; }

        public string PrimaryState { get; set; }

        public string PrimaryZip { get; set; }

        public string PrimaryCountry { get; set; }

        public string SecondaryAddress { get; set; }
        public string SecondaryCity { get; set; }

        public string SecondaryState { get; set; }

        public string SecondaryZip { get; set; }

        public string SecondaryCountry { get; set; }

        public string LandLine { get; set; }

        public string Mobile { get; set; }

        public string Extension { get; set; }

        public string Website { get; set; }

        public string FaxNumber { get; set; }

        public string QQId { get; set; }

        public string SkypeId { get; set; }

        public string MSNId { get; set; }
    }
}
