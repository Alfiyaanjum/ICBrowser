using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Xml;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web;

namespace ICBrowser.DAL
{
    public class SellerCompanyDetailsRepository : Repository
    {

        #region PrivateFunctions

        private CompanyDetails fill(IDataReader reader)
        {
            CompanyDetails CompanyDetailsEntity = new CompanyDetails();

            CompanyDetailsEntity.CompanyName = reader.GetValue<String>("CompanyName");
            CompanyDetailsEntity.ContactName = reader.GetValue<String>("ContactName");
            CompanyDetailsEntity.PhoneNumber = reader.GetValue<String>("PhoneNumber");
            CompanyDetailsEntity.FaxNumber = reader.GetValue<String>("FaxNumber");
            CompanyDetailsEntity.Email = reader.GetValue<String>("Email");
            CompanyDetailsEntity.Website = reader.GetValue<String>("Website");
            CompanyDetailsEntity.Extension = reader.GetValue<String>("Extension");
            CompanyDetailsEntity.PrimaryAddress = reader.GetValue<String>("PrimaryAddress");
            CompanyDetailsEntity.SecondaryAddress = reader.GetValue<String>("SecondaryAddress");
            CompanyDetailsEntity.PrimaryCity = reader.GetValue<String>("PrimaryCity");
            CompanyDetailsEntity.SecondaryCity = reader.GetValue<String>("SecondaryCity");
            CompanyDetailsEntity.PrimaryCountry = reader.GetValue<String>("Country");
            CompanyDetailsEntity.SecondaryCountry = reader.GetValue<String>("SecondaryCountry");
            CompanyDetailsEntity.PrimaryZip = reader.GetValue<String>("PrimaryZip");
            CompanyDetailsEntity.SecondaryZip = reader.GetValue<String>("SecondaryZip");
            CompanyDetailsEntity.PrimaryState = reader.GetValue<String>("State");
            CompanyDetailsEntity.SecondaryState = reader.GetValue<String>("SecondaryState");
            CompanyDetailsEntity.Description = reader.GetValue<String>("Description");

            return CompanyDetailsEntity;

        }

        #endregion

        #region Repository<CompanyDetails> Members

        public CompanyDetails GetSellerCompanyDetailsBySellerID(int SellerId)
        {
            CompanyDetails requestsForUser = new CompanyDetails();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetSellerCompanyDetailsByID");

            db.AddInParameter(command, "@SellerID", DbType.Int32, SellerId);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    requestsForUser = fillin(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in GetSellerCompanyDetailsByID for ID: " + SellerId.ToString());
            }
            return requestsForUser;
        }

        #endregion

        #region PrivateFunctions

        private CompanyDetails fillin(IDataReader reader)
        {
            CompanyDetails CompanyDetailsEntity = new CompanyDetails();

            CompanyDetailsEntity.CompanyName = reader.GetValue<String>("CompanyName");
            CompanyDetailsEntity.ContactName = reader.GetValue<String>("ContactName");
            CompanyDetailsEntity.PhoneNumber = reader.GetValue<String>("PhoneNumber");
            CompanyDetailsEntity.FaxNumber = reader.GetValue<String>("FaxNumber");
            CompanyDetailsEntity.Email = reader.GetValue<String>("Email");
            CompanyDetailsEntity.Website = reader.GetValue<String>("Website");
            CompanyDetailsEntity.Extension = reader.GetValue<String>("Extension");
            CompanyDetailsEntity.PrimaryAddress = reader.GetValue<String>("PrimaryAddress");
            CompanyDetailsEntity.SecondaryAddress = reader.GetValue<String>("SecondaryAddress");
            CompanyDetailsEntity.PrimaryCity = reader.GetValue<String>("PrimaryCity");
            CompanyDetailsEntity.SecondaryCity = reader.GetValue<String>("SecondaryCity");
            CompanyDetailsEntity.PrimaryCountry = reader.GetValue<String>("Country");
            CompanyDetailsEntity.SecondaryCountry = reader.GetValue<String>("SecondaryCountry");
            CompanyDetailsEntity.PrimaryZip = reader.GetValue<String>("PrimaryZip");
            CompanyDetailsEntity.SecondaryZip = reader.GetValue<String>("SecondaryZip");
            CompanyDetailsEntity.PrimaryState = reader.GetValue<String>("State");
            CompanyDetailsEntity.SecondaryState = reader.GetValue<String>("SecondaryState");
            CompanyDetailsEntity.Description = reader.GetValue<String>("Description");

            return CompanyDetailsEntity;

        }

        #endregion
    }
}
