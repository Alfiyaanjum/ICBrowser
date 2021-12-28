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
    public class BuyersRequirmentsRepository : Repository
    {
        #region IRepository<Request> Members
        public IEnumerable<BuyersRequirements> SearchRequirements(string searchText)
        {
            List<BuyersRequirements> requestsForUser = new List<BuyersRequirements>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("RequirementSearch");

            db.AddInParameter(command, "@StringToSearch", DbType.String, searchText);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    requestsForUser.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in RequirementSearch for text: " + searchText);
            }
            return requestsForUser;
        }

    

        private BuyersRequirements fill(IDataReader reader)
        {
            BuyersRequirements buyersreq = new BuyersRequirements();
            buyersreq.BuyerRequirementId = Convert.ToInt32(reader.GetValue<int>("BuyerRequirementId"));
            buyersreq.userId = reader.GetValue<Guid>("UserId");
            buyersreq.Status = Convert.ToInt32(reader.GetValue<int>("Status"));
            buyersreq.Quantity = reader.GetValue<int>("Quantity");
            buyersreq.ComponentName = reader.GetValue<string>("ComponentName");
            buyersreq.Description = reader.GetValue<string>("Description");           
            buyersreq.CreationDate = reader.GetValue<DateTime>("CreationDate");
            buyersreq.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");
            //buyersreq.RequiredBefore = reader.GetValue<DateTime>("RequiredBefore");
            buyersreq.BrandName = reader.GetValue<string>("BrandName");
            buyersreq.BuyerName = reader.GetValue<string>("CompanyName");
            buyersreq.NotificationSent = reader.GetValue<bool>("NotificationSent");
            buyersreq.PriceInUSD = reader.GetValue<decimal>("PriceInUSD");
            buyersreq.DateCode = reader.GetValue<string>("DateCode");
            buyersreq.Package = reader.GetValue<string>("Package");
            //buyersreq.Country = reader.GetValue<string>("Country");
            buyersreq.RequirementwithPO = reader.GetValue<Boolean>("WithPO");
            return buyersreq;
        }

      
        #endregion


        public List<BuyersRequirements> getBuyerRequirementsDetailsForSearch(int buyerId, string txtSearch, string ddlType)
        {
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("getBuyerRequirementDetailsForSearch");
            db.AddInParameter(command, "@BuyerId", DbType.String, buyerId);
            db.AddInParameter(command, "@SearchText", DbType.String, txtSearch);
            db.AddInParameter(command, "@SelectType", DbType.String, ddlType);
            try
            {
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    lst.Add(new BuyersRequirements
                    {
                        BuyerRequirementId = reader.GetValue<int>("BuyerRequirementId"),
                        Status = reader.GetValue<int>("Status"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        Description = reader.GetValue<string>("Description"),
                        RequiredBefore = reader.GetValue<DateTime>("RequiredBefore"),
                        ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        userId = reader.GetValue<Guid>("userId"),
                        Country = reader.GetValue<string>("Country"),
                        DateCode = reader.GetValue<string>("DateCode"),
                        Package = reader.GetValue<string>("Package"),
                        RequirementwithPO = reader.GetValue<bool>("WithPO")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return lst;
        }




        public List<BuyersRequirements> filterSearchRequirement(string partNumber, int quantity, string make, string package, string dateCode, string reqStatus, string lastupdated, int exMatch)
        {
            List<BuyersRequirements> requestsForUser = new List<BuyersRequirements>();

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("FILTER_REQUIREMENT_SEARCH"); //FilteredRequirementSearch

            db.AddInParameter(command, "@PartNumber", DbType.String, partNumber);
            db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
            db.AddInParameter(command, "@Make", DbType.String, make);
            db.AddInParameter(command, "@WithPO", DbType.String, reqStatus);
            db.AddInParameter(command, "@DateCode", DbType.String, dateCode);
            db.AddInParameter(command, "@Package", DbType.String, package);
            db.AddInParameter(command, "@LastUpdated", DbType.String, lastupdated);
            db.AddInParameter(command, "@exMatch", DbType.Int32, exMatch);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    requestsForUser.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in FilteredRequirementSearch for text ");
            }
            return requestsForUser;
        }

        public IEnumerable<BuyersRequirements> GetLatestRequirementsByHour()
        {
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetLatestRequirement");


            //db.AddInParameter(command, "@Hour", DbType.Int32, hours);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(fill(reader));
                }

                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return null;
            }

            return lst;
        }

        public void UpdateNotificationSent(BuyersRequirements obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateNotificationSentByBuyerRequirementId");

            try
            {
                db.AddInParameter(command, "@BuyerRequirementId", DbType.Int32, obj.BuyerRequirementId);
                db.AddInParameter(command, "@NotificationSent", DbType.Boolean, obj.NotificationSent);
                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            finally
            {

            }
        }

        public void InserBuyerUploadRequirements(BuyersRequirements buyerdetails)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("BuyerRequirementsCreate");
            db.AddInParameter(command, "@BuyerId", DbType.Guid, buyerdetails.userId);
            db.AddInParameter(command, "@Quantity", DbType.Int32, buyerdetails.Quantity);
            db.AddInParameter(command, "@ComponentName", DbType.String, buyerdetails.ComponentName);
            db.AddInParameter(command, "@Description", DbType.String, buyerdetails.Description);
            db.AddInParameter(command, "@BrandName", DbType.String, buyerdetails.BrandName);
            db.AddInParameter(command, "@CreationDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@RequirementwithPO", DbType.Boolean, buyerdetails.RequirementwithPO);
            db.AddInParameter(command, "@Package", DbType.String, buyerdetails.Package);
            db.AddInParameter(command, "@DateCode", DbType.String, buyerdetails.DateCode);
            db.AddInParameter(command, "@Country", DbType.String, buyerdetails.Country);
            db.AddInParameter(command, "@NotificationStatus", DbType.Int32, 1);
            db.ExecuteNonQuery(command);
        }
    }
}












