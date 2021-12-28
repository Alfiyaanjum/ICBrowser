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
    public class RequirementsRepository : Repository
    {
        #region IRepository<Request> Members

        public List<BuyerDetails> GetBuyersId(Guid UserId)
        {
           
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            List<BuyerDetails> buyersData = new List<BuyerDetails>();

              try
                {
                    SqlDatabase db = new SqlDatabase(ConnectionString);

                    // Prepare stored procedure with parameters
                    DbCommand command = db.GetStoredProcCommand("GetBuyersId");
                    db.AddInParameter(command, "@UserId", DbType.Guid, UserId);

                    IDataReader DataReader = (IDataReader)db.ExecuteReader(command);

                    // Add each row in reader into the list
                    buyersData = GetCompanyData(DataReader);
                }
                catch (Exception ex)
                { 

                }
              return buyersData;
            }

        private List<BuyerDetails> GetCompanyData(IDataReader reader)
        {
            List<BuyerDetails> lstBuyerDetails = new List<BuyerDetails>();
            
            try
            {
                while (reader.Read())
                {
                    BuyerDetails buyerDetails = new BuyerDetails();
                    buyerDetails.BuyerID = reader.GetValue<int>("BuyerId");
                    int buyerid = buyerDetails.BuyerID;
                    lstBuyerDetails.Add(buyerDetails);
                    
                }
            }
            catch (Exception ex)
            { 

            }

            return lstBuyerDetails;
            
        }
        
        public void InsertBuyersRequirments(int buyerID, int status, int quantity, string componentName, string description,string brandname,string companyname,DateTime modifieddate,DateTime requiredbefore)
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("BuyerRequirementsCreate");
            db.AddInParameter(command, "@BuyerId", DbType.Int32, buyerID);
            db.AddInParameter(command, "@Status", DbType.Int32, status);
            db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
            db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
            db.AddInParameter(command, "@Description", DbType.String, description);
            db.AddInParameter(command, "@BrandName", DbType.String, brandname);
            db.AddInParameter(command, "@CompanyName", DbType.String, companyname);
            db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, modifieddate);
            db.AddInParameter(command, "@RequiredBefore", DbType.DateTime, requiredbefore);
                      
            db.ExecuteNonQuery(command);


        }


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
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex, "Error in RequirementSearch for text: " + searchText);
            }
            return requestsForUser;
        }



        //public void UpdateBuyersRequirments(int buyerID, int status, int quantity, string componentName, string description)
        //{
        //    SqlDatabase db = new SqlDatabase(ConnectionString);
        //    DbCommand command = db.GetStoredProcCommand("UpdateBuyersRequirements");
        //    db.AddInParameter(command, "@BuyerId", DbType.Int32, buyerID);
        //    db.AddInParameter(command, "@Status", DbType.Int32, status);
        //    db.AddInParameter(command, "@Quantity", DbType.Int32, quantity);
        //    db.AddInParameter(command, "@ComponentName", DbType.String, componentName);
        //    db.AddInParameter(command, "@Description", DbType.String, description);
        //    db.ExecuteNonQuery(command);
        //}

        //public DataTable SelectBuyersRequirements(int buyerID, string componentName)
        //{
            
        //    SqlConnection cn = new SqlConnection(ConnectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();


        //    try
        //    {
        //        cn.Open();
        //        cmd.CommandType  = CommandType.StoredProcedure;
        //        cmd.Connection = cn;
        //        cmd.CommandText = "BuyerRequirements_SelectById";

        //        SqlParameter buyer = new SqlParameter();
        //        buyer.ParameterName = "@BuyerId";
        //        buyer.Value = buyerID;
        //        buyer.DbType = DbType.Int32;
        //        cmd.Parameters.Add(buyer);

        //        SqlParameter compname = new SqlParameter();
        //        compname.ParameterName = "@ComponentName";
        //        compname.Value = componentName;
        //        compname.DbType = DbType.String;
        //        cmd.Parameters.Add(compname);

        //        da.SelectCommand = cmd;
        //        da.Fill(dt);


        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
         
            
        //    return dt;

        //}




        //public bool Delete(BuyersRequirements obj)
        //{
        //    SqlDatabase db = new SqlDatabase(ConnectionString);

        //    DbCommand command = db.GetStoredProcCommand("BuyerIdDeleted");

        //    db.AddInParameter(command, "@BuyerId", DbType.Int32);

        //    try
        //    {
        //        db.ExecuteNonQuery(command);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public BuyersRequirements Select(int id)
        //{

        //    BuyersRequirements request = null;

        //    SqlDatabase db = new SqlDatabase(ConnectionString);

        //    DbCommand command = db.GetStoredProcCommand("BuyerRequirements");

        //    db.AddInParameter(command, "@Id", DbType.Int32, id);

        //    IDataReader reader = db.ExecuteReader(command);

        //    if (reader.Read())
        //    {
        //        //string  = reader.GetValue<int>("BuyerID");
        //        ////request = fill(reader);
        //    }

        //    return request;
        //}

        //public BuyersRequirements fill(IDataReader reader)
        //{
        //BuyersRequirements objBuyersRequirements = new BuyersRequirements();
        //    //string temp = reader.GetValue<string>("Quantity");
        //    //objBuyersRequirements.Quantity = reader.GetValue<string>("Quantity");
        //    //objBuyersRequirements.ComponentName = reader.GetValue<string>("ComponentName");
        //    //objBuyersRequirements.Description = reader.GetValue<string>("Description").ToString();

        //    //return objBuyersRequirements;
        //}


        #endregion

        #region PrivateFunctions

            private BuyersRequirements fill(IDataReader reader)
            {
                BuyersRequirements BuyersRequirementEntity = new BuyersRequirements();

                BuyersRequirementEntity.BuyerRequirementId = reader.GetValue<int>("BuyerRequirementId");
                BuyersRequirementEntity.BuyerID = reader.GetValue<int>("BuyerId");
                BuyersRequirementEntity.Status = reader.GetValue<int>("Status");
                BuyersRequirementEntity.Quantity = reader.GetValue<int>("Quantity");
                BuyersRequirementEntity.ComponentName = reader.GetValue<String>("ComponentName");
                BuyersRequirementEntity.Description = reader.GetValue<String>("Description");
                BuyersRequirementEntity.CreationDate = reader.GetValue<DateTime>("CreationDate");
                BuyersRequirementEntity.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");
                BuyersRequirementEntity.RequiredBefore = reader.GetValue<DateTime>("RequiredBefore");
                BuyersRequirementEntity.BrandName = reader.GetValue<String>("BrandName");
                BuyersRequirementEntity.BuyerName = reader.GetValue<String>("BuyerName");

                return BuyersRequirementEntity;

            }

        #endregion
    }
}
