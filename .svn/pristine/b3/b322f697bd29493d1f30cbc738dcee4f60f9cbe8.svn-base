using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Xml;


namespace ICBrowser.DAL
{
    public class BuyerDetailsRepository : Repository
    {
        #region IRepository<Request> Members

        public bool Create(BuyerDetails obj)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("BuyerDetailsCreate");

            db.AddOutParameter(command, "@BuyerId", DbType.Int32, 0);
            db.AddInParameter(command, "@CompanyName", DbType.String, obj.CompanyName);
            db.AddInParameter(command, "@ContactName", DbType.String, obj.ContactName);
            db.AddInParameter(command, "@UserId", DbType.Guid, new Guid(obj.UserId));
            db.AddInParameter(command, "@Currency", DbType.String, obj.Currency);
            try
            {
                db.ExecuteNonQuery(command);

                obj.BuyerID = (int)command.Parameters["@BuyerId"].Value;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(BuyerDetails obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("BuyerIdDelete");

            db.AddInParameter(command, "@BuyerId", DbType.Int32, obj.BuyerID);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BuyerDetails Select(int id)
        {

            BuyerDetails request = null;

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("BuyerDetails_SelectById");

            db.AddInParameter(command, "@Id", DbType.Int32, id);

            IDataReader reader = db.ExecuteReader(command);

            if (reader.Read())
            {
                request = fill(reader);
            }

            return request;
        }

 

        private BuyerDetails fill(IDataReader reader)
        {
            BuyerDetails objBuyerDetails = new BuyerDetails();

            objBuyerDetails.BuyerID = reader.GetValue<int>("BuyerId");
            objBuyerDetails.CompanyName = reader.GetValue<string>("CompanyName");
            objBuyerDetails.ContactName = reader.GetValue<string>("ContactName");
            objBuyerDetails.UserId = reader.GetValue<Guid>("UserId").ToString();
            objBuyerDetails.Currency = reader.GetValue<string>("Currency");

            return objBuyerDetails;
        }
          

        #endregion
    }
}
