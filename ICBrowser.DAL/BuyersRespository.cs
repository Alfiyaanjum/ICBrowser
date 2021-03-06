using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ICBrowser.DAL
{
    public class BuyersRepository : Repository
    {
        /// <summary>
        /// Create new entry for Buyer's Details
        /// </summary>
        /// <param name="newBuyerDetails"></param>
        /// <returns></returns>

        public bool CreateBuyerDetailsEntry(UserDetails newUserRequest)
        {

            try
            {
                // Connect to database
                SqlDatabase db = new SqlDatabase(ConnectionString);
              
                DbCommand command = db.GetStoredProcCommand("UserDetailsCreate");

                // Create parameters for stored proc
                db.AddInParameter(command, "@UserName", DbType.String, newUserRequest.UserName);
                db.AddInParameter(command, "@CompanyName", DbType.String, newUserRequest.CompanyName);
                db.AddInParameter(command, "@ContactName", DbType.String, newUserRequest.ContactName);
                db.AddInParameter(command, "@UserId", DbType.Guid, newUserRequest.UserID);
                db.AddInParameter(command, "@Currency", DbType.String, newUserRequest.Currency);
                db.AddInParameter(command, "@OwnerName", DbType.String, newUserRequest.OwnerName);
                db.AddInParameter(command, "@EmailPreference", DbType.Int32, newUserRequest.EmailPreference);
                db.AddInParameter(command, "@GstNumber", DbType.String, newUserRequest.GstNumber);
                if (newUserRequest.Specialization == "" || newUserRequest.Specialization == string.Empty)
                {
                    db.AddInParameter(command, "@Specialization", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(command, "@Specialization", DbType.String, newUserRequest.Specialization);
                }
                db.AddInParameter(command, "@CreatedDate", DbType.DateTime, newUserRequest.CreateDate);
                db.AddInParameter(command, "@PanNumber", DbType.String, newUserRequest.PanNumber);
                db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(command, "@IsDecline", DbType.Int32, newUserRequest.IsDecline);

                // Execute stored proc
                int temp = db.ExecuteNonQuery(command);
                if (temp > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception message
                IClogger.LogError(ex.Message);
            }
            return false;
            //return status;
        }

        public List<BuyersRequirements> GetBuyersRequirements()
        {
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            
            DbCommand command = db.GetStoredProcCommand("SP_BuyersRequirementsDetails");
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new BuyersRequirements()
                    {
                        userId = reader.GetValue<Guid>("userId"),
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        Package = reader.GetValue<string>("Package"),
                        DateCode = reader.GetValue<string>("DateCode"),
                        Description = reader.GetValue<string>("Description")
                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
           
            return lst;
        }

    

        public List<BuyersRequirements> GetBuyersDetailedRequirements(int pageSize, int pageIndex)
        {
            List<BuyersRequirements> lstid = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetAllBuyersDetailedRequirements]");
            db.AddInParameter(command, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(command, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(command, "@returnvalue", DbType.Int32, 0);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstid.Add(new BuyersRequirements()
                    {
                        ComponentName = Convert.ToString(reader.GetValue<string>("componentName")),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = reader.GetValue<string>("brandName"),
                        RequiredBefore = reader.GetValue<DateTime>("RequiredBefore"),
                        ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                        CreationDate = reader.GetValue<DateTime>("CreationDate"),
                        Description = reader.GetValue<string>("Description"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        userId = reader.GetValue<Guid>("userId"),
                        //BuyerName = reader.GetValue<string>("buyerName"),
                        DateCode = reader.GetValue<string>("DateCode"),
                        Package = reader.GetValue<string>("Package"),
                        RequirementwithPO = reader.GetValue<bool>("WithPO"),
                        Country = reader.GetValue<string>("PrimaryCountry"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        City = reader.GetValue<string>("PrimaryCity"),
                        LandLine = reader.GetValue<string>("Landline"),
                        EmailId = reader.GetValue<string>("Email"),
                        QQId = reader.GetValue<string>("QQId"),
                        SkypeId = reader.GetValue<string>("SkypeId"),
                        MSNId = reader.GetValue<string>("MSNId")
                    });
                }
                reader.Close();
                TotalPages = Convert.ToInt32(command.Parameters["@returnvalue"].Value);
                lstid.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lstid;
        }

        public List<BuyersRequirements> GetBuyersDetailedRequirementsWithPO(int pageSize, int pageIndex)
        {
            List<BuyersRequirements> lstid = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetRequirementHavingPO");
            db.AddInParameter(command, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(command, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(command, "@returnvalue", DbType.Int32, 0);
            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstid.Add(new BuyersRequirements()
                    {
                        ComponentName = Convert.ToString(reader.GetValue<string>("componentName")),
                        Quantity = reader.GetValue<int>("quantity"),
                        BrandName = reader.GetValue<string>("brandName"),
                        RequiredBefore = reader.GetValue<DateTime>("RequiredBefore"),
                        ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                        CreationDate = reader.GetValue<DateTime>("CreationDate"),
                        Description = reader.GetValue<string>("Description"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        userId = reader.GetValue<Guid>("userId"),
                        //BuyerName = reader.GetValue<string>("buyerName"),
                        DateCode = reader.GetValue<string>("DateCode"),
                        Package = reader.GetValue<string>("Package"),
                        RequirementwithPO = reader.GetValue<bool>("WithPO"),
                        Country = reader.GetValue<string>("PrimaryCountry"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        City = reader.GetValue<string>("PrimaryCity"),
                        LandLine = reader.GetValue<string>("Landline"),
                        EmailId = reader.GetValue<string>("Email"),
                        QQId = reader.GetValue<string>("QQId"),
                        SkypeId = reader.GetValue<string>("SkypeId"),
                        MSNId = reader.GetValue<string>("MSNId")
                    });
                }
                reader.Close();
                TotalPages = Convert.ToInt32(command.Parameters["@returnvalue"].Value);
                lstid.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);

            }
            return lstid;
        }


        public IEnumerable<EmailNotification> GetAllBuyersForComponent(string componentName, int quantity)
        {
            List<EmailNotification> lst = new List<EmailNotification>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
           
            DbCommand command = db.GetStoredProcCommand("GetBuyersForComponent");

            db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
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

        private EmailNotification fill(IDataReader reader)
        {
            EmailNotification emailNotificationObj = new EmailNotification();

            //emailNotificationObj.NotificationId = reader.GetValue<int>("NotificationId");
            emailNotificationObj.ToUserId = reader.GetValue<Guid>("UserId");
            emailNotificationObj.ComponentName = reader.GetValue<string>("ComponentName");
            emailNotificationObj.CompanyName = reader.GetValue<string>("CompanyName");
            emailNotificationObj.ContactName = reader.GetValue<string>("ContactName");
            emailNotificationObj.Quantity = reader.GetValue<int>("Quantity");
            emailNotificationObj.PhoneNumber = reader.GetValue<string>("Landline");
            emailNotificationObj.Email = reader.GetValue<string>("Email");
            //emailNotificationObj.NotificationStatus = reader.GetBoolean(reader.GetOrdinal("NotificationStatus"));
            emailNotificationObj.EmailPreference = reader.GetValue<int>("EMailPreference");

            return emailNotificationObj;
        }

    
        public CompanyDetails GetBuyersId(Guid UserId)
        {

            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            CompanyDetails userData = new CompanyDetails();

            try
            {
                SqlDatabase db = new SqlDatabase(ConnectionString);

                // Prepare stored procedure with parameters
                DbCommand command = db.GetStoredProcCommand("GetBuyersId");
                db.AddInParameter(command, "@UserId", DbType.Guid, UserId);

                IDataReader DataReader = (IDataReader)db.ExecuteReader(command);

                // Add each row in reader into the list
                userData = GetCompanyData(DataReader);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return userData;
        }


        private CompanyDetails GetCompanyData(IDataReader reader)
        {
            CompanyDetails usersDetails = new CompanyDetails();

            try
            {
                while (reader.Read())
                {

                    usersDetails.ContactName = reader.GetValue<string>("ContactName");
                    usersDetails.OwnerName = reader.GetValue<string>("OwnerName");
                    usersDetails.CompanyName = reader.GetValue<string>("CompanyName");
                

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return usersDetails;

        }


    

        public int TotalPages { get; set; }

        public List<BuyersRequirements> GetUsersRequirementsDetailsForMatch(Guid userId)
        {
            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("SP_UserRequirementsDetailsForMatch");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
            try
            {

                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new BuyersRequirements()
                    {
                      
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        DateCode = reader.GetValue<string>("Datecode"),
                        Package = reader.GetValue<string>("Package"),
                        ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                        Quantity = reader.GetValue<int>("Quantity")

                    });
                }
                reader.Close();
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return lst;
        }

        public List<BuyersRequirements> GetAllUsersRequirementsDetailsForMatch(Guid userId, int pageSize, int pageIndex)
        {

            List<BuyersRequirements> lst = new List<BuyersRequirements>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetAllUsersRequirementDetailsForMatch");
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
            db.AddInParameter(command, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(command, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(command, "@returnValue", DbType.Int32, 0);
            try
            {

                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lst.Add(new BuyersRequirements()
                    {
                        userId = reader.GetValue<Guid>("userId"),
                        ComponentName = reader.GetValue<string>("ComponentName"),
                        BrandName = reader.GetValue<string>("BrandName"),
                        DateCode = reader.GetValue<string>("Datecode"),
                        Package = reader.GetValue<string>("Package"),
                        ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                        Quantity = reader.GetValue<int>("Quantity"),
                        CompanyName = reader.GetValue<string>("CompanyName"),
                        Description = reader.GetValue<string>("Description"),
                        PriceInUSD = reader.GetValue<decimal>("PriceInUSD"),
                        CreationDate = reader.GetValue<DateTime>("CreationDate")
                    });
                }
                reader.Close();
                TotalPages = Convert.ToInt32(command.Parameters["@returnValue"].Value);
                lst.TrimExcess();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return lst;
        }

        public IEnumerable<EmailNotification> GetAllBuyersForOffer(string componentName, int quantity, Guid userId)
        {
            List<EmailNotification> lst = new List<EmailNotification>();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetBuyersForOffer");

            db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
            db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
            db.AddInParameter(command, "@UserId", DbType.Guid, userId);
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
    }
}
