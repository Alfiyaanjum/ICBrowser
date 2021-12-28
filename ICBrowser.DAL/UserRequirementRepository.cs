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
    public class UserRequirementRepository : Repository
    {
        /// <summary>
        /// Bind Grid for User Requirements
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BuyersRequirements> BuyersRequirementDetailsRFQById(Guid userId)
        {
            List<BuyersRequirements> lstUserRequirements = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[UserRequirementListingRFQ]");
            db.AddInParameter(command, "@userId", DbType.Guid, userId);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUserRequirements.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
            lstUserRequirements.TrimExcess();
            return lstUserRequirements;
        }

        public List<BuyersRequirements> BuyersRequirementDetailsById(Guid userId)
        {
            List<BuyersRequirements> lstUserRequirements = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[UserRequirementListing]");
            db.AddInParameter(command, "@userId", DbType.Guid, userId);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUserRequirements.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
            lstUserRequirements.TrimExcess();
            return lstUserRequirements;
        }

        public List<BuyersRequirements> BuyersRequirementDetailswithPOById(Guid userId)
        {
            List<BuyersRequirements> lstUserRequirements = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetDetailRequirementWithPO]");
            db.AddInParameter(command, "@userId", DbType.Guid, userId);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);
                while (reader.Read())
                {
                    lstUserRequirements.Add(fill(reader));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error");
            }
            lstUserRequirements.TrimExcess();
            return lstUserRequirements;
        }

        private BuyersRequirements fill(IDataReader reader)
        {
            BuyersRequirements buyersreq = new BuyersRequirements();
            buyersreq.BuyerRequirementId = Convert.ToInt32(reader.GetValue<int>("buyerrequirementId"));
            //buyersreq.BuyerID = Convert.ToInt32(reader.GetValue<int>("buyerID"));
            buyersreq.Status = Convert.ToInt32(reader.GetValue<int>("status"));
            buyersreq.Quantity = reader.GetValue<int>("quantity");
            buyersreq.ComponentName = reader.GetValue<string>("componentName");
            buyersreq.CompanyName = reader.GetValue<string>("CompanyName");
            buyersreq.Description = reader.GetValue<string>("description");
            buyersreq.PriceInUSD = reader.GetValue<decimal>("PriceInUSD");
            buyersreq.CreationDate = reader.GetValue<DateTime>("creationdate");
            buyersreq.ModifiedDate = reader.GetValue<DateTime>("modifieddate");
            buyersreq.RequiredBefore = reader.GetValue<DateTime>("requiredbefore");
            buyersreq.BrandName = reader.GetValue<string>("brandName");
            //buyersreq.BuyerName = reader.GetValue<string>("BuyerName");
            buyersreq.Package = reader.GetValue<string>("Package");
            buyersreq.DateCode = reader.GetValue<string>("DateCode");
            buyersreq.RequirementwithPO = reader.GetValue<Boolean>("WithPO");
            buyersreq.userId = reader.GetValue<Guid>("UserId");
            buyersreq.NotificationSent = reader.GetValue<bool>("NotificationSent");
            buyersreq.Package = reader.GetValue<string>("Package");
            buyersreq.DateCode = reader.GetValue<string>("DateCode");
            buyersreq.Country = reader.GetValue<string>("Country");
            buyersreq.RequirementwithPO = reader.GetValue<bool>("WithPO");
            return buyersreq;
        }

        /// <summary>
        /// Get Search Result for requirement
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="txtSearch"></param>
        /// <param name="ddlType"></param>
        /// <returns></returns>
        public List<BuyersRequirements> getBuyerRequirementsDetailsForSearch(Guid userId, string txtSearch, string ddlType)
        {
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("getUserRequirementDetailsForSearch");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
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
                        //BuyerID = reader.GetValue<int>("BuyerID"),
                        Country = reader.GetValue<string>("Country"),
                        DateCode = reader.GetValue<string>("DateCode"),
                        Package = reader.GetValue<string>("Package"),
                        RequirementwithPO = reader.GetValue<bool>("WithPO"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD")
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

        /// <summary>
        /// Update Requirements
        /// </summary>
        /// <param name="buyerreqid"></param>
        /// <param name="userId"></param>
        /// <param name="withpo"></param>
        /// <param name="quantity"></param>
        /// <param name="componentName"></param>
        /// <param name="description"></param>
        /// <param name="brandname"></param>
        /// <param name="NotificationStatus"></param>
        /// <param name="datecode"></param>
        /// <param name="package"></param>
        /// <param name="country"></param>
        public void rowUpdateBuysReq(int buyerreqid, Guid userId, int withpo, int quantity, string componentName, string description, string brandname, int NotificationStatus, string package, string datecode, decimal? priceinusd)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateUserRequirementByBuyerReqId");
            try
            {
                db.AddInParameter(command, "@BuyerRequirementId", DbType.Int32, buyerreqid);
                db.AddInParameter(command, "@UserId", DbType.Guid, userId);
                db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
                db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
                db.AddInParameter(command, "@BrandName", DbType.String, brandname);
                db.AddInParameter(command, "@DateCode", DbType.String, datecode);
                db.AddInParameter(command, "@Package", DbType.String, package);
                db.AddInParameter(command, "@Description", DbType.String, description);
                db.AddInParameter(command, "@WithPO", DbType.Int32, withpo);
                //db.AddInParameter(command, "@Country", DbType.String, null);
                db.AddInParameter(command, "@NotificationStatus", DbType.Int32, NotificationStatus);
                db.AddInParameter(command, "@PriceInUSD", DbType.Decimal, priceinusd);
                db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, DateTime.Now);
                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }

        /// <summary>
        /// Delete Requirements
        /// </summary>
        /// <param name="buyerreqid"></param>
        public void rowDeleteBuysReq(int buyerreqid)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("DeleteUserRequirementByBuyerReqId");
            db.AddInParameter(command, "@BuyerRequirementId", DbType.Int32, buyerreqid);
            db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Insert Requirements
        /// </summary>
        /// <param name="buyerID"></param>
        /// <param name="companyname"></param>
        /// <param name="quantity"></param>
        /// <param name="componentName"></param>
        /// <param name="description"></param>
        /// <param name="brandname"></param>
        /// <param name="NotificationStatus"></param>
        /// <param name="datecode"></param>
        /// <param name="package"></param>
        /// <param name="withpo"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public bool InsertUserRequirments(DataTable dtReqList)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("UserRequirementsCreate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;

                // Set the Parameter with appropriate Source Column Name
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 0, dtReqList.Columns[4].ColumnName);
                command.Parameters.Add("@Quantity", SqlDbType.Int, 0, dtReqList.Columns[7].ColumnName);
                command.Parameters.Add("@ComponentName", SqlDbType.NVarChar, 50, dtReqList.Columns[6].ColumnName);
                command.Parameters.Add("@Description", SqlDbType.NVarChar, 150, dtReqList.Columns[8].ColumnName);
                command.Parameters.Add("@BrandName", SqlDbType.NVarChar, 50, dtReqList.Columns[2].ColumnName);
                command.Parameters.Add("@CreationDate", SqlDbType.DateTime, 0, dtReqList.Columns[0].ColumnName);
                command.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 0, dtReqList.Columns[1].ColumnName);
                command.Parameters.Add("@Package", SqlDbType.NVarChar, 100, dtReqList.Columns[12].ColumnName);
                command.Parameters.Add("@DateCode", SqlDbType.NVarChar, 100, dtReqList.Columns[13].ColumnName);
                //command.Parameters.Add("@Country", SqlDbType.NVarChar, 100, dtReqList.Columns[15].ColumnName);
                command.Parameters.Add("@PriceInUSD", SqlDbType.NVarChar, 100, dtReqList.Columns[9].ColumnName);
                command.Parameters.Add("@RequirementwithPO", SqlDbType.Bit, 0, "RequirementwithPO");
                command.Parameters.Add("@NotificationStatus", SqlDbType.Int, 0, "notificationSent");
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 5;

                connection.Open();
                int recordsInserted = adpt.Update(dtReqList);
                connection.Close();

                //MessageBox.Show("Number of records affected : " + recordsInserted.ToString());

                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.ToString());
                return false;
            }

        }


        public List<Common.BuyersRequirements> DeleteRequirements(Common.BuyersRequirements listRequirements)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);

            List<BuyersRequirements> list = new List<BuyersRequirements>();
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("OverwriteRequirements", con);

            db.AddInParameter(cmd, "@UserId", DbType.Guid, listRequirements.userId);

            if (!string.IsNullOrEmpty(listRequirements.RequirementwithPO.ToString()))
                db.AddInParameter(cmd, "@WithPO", DbType.String, listRequirements.RequirementwithPO);
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                list.Add(new Common.BuyersRequirements()
                {
                    userId = reader.GetValue<Guid>("UserId"),
                    ComponentName = reader.GetValue<string>("ComponentName"),
                    Quantity = reader.GetValue<int>("Quantity"),
                    BrandName = reader.GetValue<string>("BrandName"),
                    Description = reader.GetValue<string>("Description"),
                    PriceInUSD = reader.GetValue<decimal>("PriceinUSD"),
                    CreationDate = reader.GetValue<DateTime>("CreationDate"),
                    NotificationSent = reader.GetValue<bool>("NotiifcationSent"),
                    RequirementwithPO = reader.GetValue<bool>("WithPO"),
                    ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                    DateCode = reader.GetValue<string>("DateCode"),
                    Package = reader.GetValue<string>("Package"),
                    Status = reader.GetValue<int>("Status")
                });
            }

            reader.Close();

            // // List<DataRow> list = dt.AsEnumerable().ToList();
            return list;
        }
        /// <summary>
        /// Insert Data to Buyer Requirement table and Update data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        public bool SaveUserRequirementsManually(BuyersRequirements data)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("[UserRequirementsCreateManually]");
            try
            {
                db.AddInParameter(command, "@UserId", DbType.Guid, data.userId);
                db.AddInParameter(command, "@Quantity", DbType.String, data.Quantity);
                db.AddInParameter(command, "@ComponentName", DbType.String, data.ComponentName);
                db.AddInParameter(command, "@PriceInUSD", DbType.String, data.PriceInUSD);
                db.AddInParameter(command, "@Description", DbType.String, data.Description);
                db.AddInParameter(command, "@BrandName", DbType.String, data.BrandName);
                db.AddInParameter(command, "@CreationDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(command, "@RequirementwithPO", DbType.String, data.RequirementwithPO);
                db.AddInParameter(command, "@Package", DbType.String, data.Package);
                db.AddInParameter(command, "@DateCode", DbType.String, data.DateCode);
                db.AddInParameter(command, "@NotificationStatus", DbType.String, 0);
                db.ExecuteReader(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return false;
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }

        public bool SaveUserRequirements(BuyersRequirements data)
        {
            bool result = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UserRequirementsCreate");


            db.AddInParameter(command, "@UserId", DbType.Guid, data.userId);
            db.AddInParameter(command, "@Quantity", DbType.String, data.Quantity);
            db.AddInParameter(command, "@ComponentName", DbType.String, data.ComponentName);
            db.AddInParameter(command, "@PriceInUSD", DbType.String, data.PriceInUSD);
            db.AddInParameter(command, "@Description", DbType.String, data.Description);
            db.AddInParameter(command, "@BrandName", DbType.String, data.BrandName);
            db.AddInParameter(command, "@CreationDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(command, "@RequirementwithPO", DbType.String, data.RequirementwithPO);
            db.AddInParameter(command, "@Package", DbType.String, data.Package);
            db.AddInParameter(command, "@DateCode", DbType.String, data.DateCode);
            db.AddInParameter(command, "@NotificationStatus", DbType.String, 0);
           // db.ExecuteReader(command);
            try
            {
                int count = db.ExecuteNonQuery(command);
                if (count == 1)
                    result = true;

            }
            catch (Exception ex)
            {
                result = false;
                IClogger.LogError(ex.ToString());
                //return false;
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
            return result;

        }
    }
}
