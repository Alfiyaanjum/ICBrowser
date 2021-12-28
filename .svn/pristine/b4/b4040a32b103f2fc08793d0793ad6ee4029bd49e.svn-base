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
    public class TransactionRepository : Repository
    {
        public bool Create(TransactionDetails obj)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("TransactionCreate");

            db.AddOutParameter(command, "@TransactionId", DbType.Int32, 0);
            db.AddInParameter(command, "@DirectPayReferenceID", DbType.Int32, obj.DirectPayReferenceID);
            db.AddInParameter(command, "@UserId", DbType.Guid, obj.UserID);
            db.AddInParameter(command, "@MerchantOrderNo", DbType.String, obj.MerchantOrderNo);
            db.AddInParameter(command, "@TransactionDate", DbType.DateTime, obj.TransactionDate);
            db.AddInParameter(command, "@Status", DbType.Int32, obj.Status);
            db.AddInParameter(command, "@Amount", DbType.Double, obj.Amount);
            db.AddInParameter(command, "@MembershipType", DbType.Int32, obj.MembershipType);
            db.AddInParameter(command, "@Description", DbType.String, obj.Description);

            try
            {
                db.ExecuteNonQuery(command);

                obj.TransactionId = (int)command.Parameters["@TransactionId"].Value;

                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return false;
            }
        }

        public TransactionDetails GetTransactionById(string transactionId)
        {
            TransactionDetails obj = new TransactionDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("Transaction_GetTranscationDetailById");

            db.AddInParameter(command, "@TransactionId", DbType.String, transactionId);
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    obj = fill(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return null;
            }

            return obj;
        }

        public bool Update(TransactionDetails obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("TransactionUpdate");

            //Guid userID = new Guid(obj.UserID);

            db.AddInParameter(command, "@TransactionId", DbType.Int32, obj.TransactionId);
            db.AddInParameter(command, "@DirectPayReferenceID", DbType.Int64, obj.DirectPayReferenceID);
            db.AddInParameter(command, "@UserID", DbType.Guid, obj.UserID);
            db.AddInParameter(command, "@MerchantOrderNo", DbType.String, obj.MerchantOrderNo);
            db.AddInParameter(command, "@TransactionDate", DbType.DateTime, obj.TransactionDate);
            db.AddInParameter(command, "@Status", DbType.Int32, obj.Status);
            db.AddInParameter(command, "@Amount", DbType.Double, obj.Amount);
            db.AddInParameter(command, "@MembershipType", DbType.Int32, obj.MembershipType);
            db.AddInParameter(command, "@Description", DbType.String, obj.Description);
            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.ToString());
                return false;
            }
        }

        private TransactionDetails fill(IDataReader reader)
        {
            TransactionDetails transactionDetailsObj = new TransactionDetails();

            transactionDetailsObj.TransactionId = reader.GetValue<int>("TransactionId");
            transactionDetailsObj.DirectPayReferenceID = reader.GetValue<long>("DirectPayReferenceID");
            transactionDetailsObj.UserID = reader.GetValue<Guid>("UserID");
            transactionDetailsObj.MerchantOrderNo = reader.GetValue<String>("MerchantOrderNo");
            transactionDetailsObj.TransactionDate = reader.GetValue<DateTime>("TransactionDate");
            transactionDetailsObj.Status = reader.GetValue<int>("Status");
            transactionDetailsObj.Amount = reader.GetValue<decimal>("Amount");
            transactionDetailsObj.MembershipType = reader.GetValue<int>("MembershipType");
            transactionDetailsObj.Description = reader.GetValue<String>("Description");

            return transactionDetailsObj;
        }
    }
}
