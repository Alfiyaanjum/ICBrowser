using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using ICBrowser.Common;
using System.Data.SqlClient;

namespace ICBrowser.DAL
{
    public class UsersRepository : Repository
    {
        public Users GetAdmin(Guid UserId)
        {
            Users usr = new Users();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetIsAdmin]");

            db.AddInParameter(command, "@UserId", DbType.Guid, UserId);
            IDataReader DataReader = (IDataReader)db.ExecuteReader(command);

            // Add each row in reader into the list
            usr = GetIsAdmin(DataReader);
            return usr;
        }

        private Users GetIsAdmin(IDataReader DataReader)
        {
            Users usr = new Users();
            try
            {
                while (DataReader.Read())
                {
                    usr.IsAdmin = DataReader.GetValue<bool>("IsAdmin");
                    usr.UserName = DataReader.GetValue<string>("UserName");
                }
                DataReader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return usr;
        }

        public bool InsertMembershipTypeDetails(Guid userId, int typeOfMembership, DateTime? membershipExpiryDate)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CreateMemberhipTypeForUsers");
            try
            {
                db.AddInParameter(command, "@UserId", DbType.Guid, userId);
                db.AddInParameter(command, "@TypeOfMembership", DbType.Int32, typeOfMembership);
                db.AddInParameter(command, "@MembershipExpiryDate", DbType.DateTime, membershipExpiryDate);
                db.AddInParameter(command, "@LastMembershipTypeId", DbType.Int32, null);
                int temp = db.ExecuteNonQuery(command);
                if (temp > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return false;
        }

        //Transfered from BuyerRequirement Repository
        public int getUserCount(Guid userId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int UserCount = 0;
            try
            {
                DbCommand command = db.GetStoredProcCommand("getBuyersCount");
                db.AddInParameter(command, "@UserId", DbType.Guid, userId);
                UserCount = Convert.ToInt32(db.ExecuteScalar(command));
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
            }
            return UserCount;
        }

        public UserDetails GetUserDetailsById(string UserId)
        {
            UserDetails obj = new UserDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);


            Guid userId = new Guid(UserId);

            DbCommand command = db.GetStoredProcCommand("GetUserDetailsById");


            db.AddInParameter(command, "@UserID", DbType.Guid, userId);
            try
            {
                IDataReader reader = db.ExecuteReader(command);


                if (reader.Read())
                {
                    obj = fillWithEmail(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return null;
            }

            return obj;
        }

        private UserDetails fillWithEmail(IDataReader reader)
        {
            UserDetails userDetailsObj = new UserDetails();

            userDetailsObj.CompanyName = reader.GetValue<string>("CompanyName");
            userDetailsObj.ContactName = reader.GetValue<string>("ContactName");
            userDetailsObj.Currency = reader.GetValue<string>("Currency");
            userDetailsObj.UserID = reader.GetValue<Guid>("UserId");
            userDetailsObj.EmailPreference = reader.GetValue<int>("EmailPreference");
            userDetailsObj.UserName = reader.GetValue<String>("UserName");
            userDetailsObj.OwnerName = reader.GetValue<String>("OwnerName");
            userDetailsObj.Specialization = reader.GetValue<String>("Specialization");
            userDetailsObj.PanNumber = reader.GetValue<String>("PanNumber");
            userDetailsObj.CreateDate = reader.GetValue<DateTime>("CreateDate");
            userDetailsObj.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");
            userDetailsObj.EmailId = reader.GetValue<String>("Email");

            return userDetailsObj;
        }

        public bool CheckUserAvailability(string userName)
        {
            //bool flag;
            int UserCount;
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("CheckUserAvailability");

            db.AddInParameter(command, "@userName", DbType.String, userName);
            try
            {
                UserCount = Convert.ToInt32(db.ExecuteScalar(command));
                if (UserCount > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return true;
            }

            //return obj;
        }

        //Check Valid User

        public bool GetValidUser(Guid userid)
        {
            int ValidUser;
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetValidUserDetails");

            db.AddInParameter(command, "@userid", DbType.Guid, userid);
            try
            {
                ValidUser = Convert.ToInt32(db.ExecuteScalar(command));
                if (ValidUser > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return false;
            }
        }

    }
}
