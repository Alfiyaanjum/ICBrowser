using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ICBrowser.DAL
{
    public abstract class Repository
    {
        protected String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ICBrowserConnectionString"].ConnectionString;
            }
        }

    }
}
