using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ICBrowser.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;


namespace ICBrowser.DAL
{
    public class UserRatingRepository : Repository
    {
        Ratings rates = new Ratings();

        /// <summary>
        /// inserts the User Ratings
        /// </summary>
        /// <param name="FromLogInUserId"></param>
        /// <param name="ToRatedUserId"></param>
        /// <param name="questid"></param>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        /// <param name="IsAdmin"></param>
        /// <returns></returns>
        public bool InsertRatings(Guid FromLogInUserId, Guid ToRatedUserId, int questid, int rating, string comment, bool IsAdmin) //insert and update Seller rating  by Buyers if buyerid is already present 
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("InsertUserRating");

            db.AddInParameter(command, "@LogInUserId", DbType.Guid, FromLogInUserId);
            db.AddInParameter(command, "@RatedUserId", DbType.Guid, ToRatedUserId);
            db.AddInParameter(command, "@QuestionId", DbType.Int32, questid);
            db.AddInParameter(command, "@Rating", DbType.Int32, rating);
            db.AddInParameter(command, "@Comment", DbType.String, comment);
            db.AddInParameter(command, "@IsAdmin", DbType.Boolean, IsAdmin);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }

            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// get average rating of a Rated User
        /// </summary>
        /// <param name="RatedUserId"></param>
        /// <returns></returns>
        public List<Common.Ratings> getAverageratingsForUser(Guid RatedUserId, bool typeOfUser)//gets individual sellers rating while the logged in buyers View the SellerProfile 
        {

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[getAverageRating]");
            db.AddInParameter(command, "@ToUserId", DbType.Guid, RatedUserId);
            db.AddInParameter(command, "@TypeOfUser", DbType.Boolean, typeOfUser);
            // db.AddOutParameter(command, "@temp", DbType.String, 50);
            // String insertDataStatus = "";
            //   int rate = 0;
            List<Common.Ratings> listgetrate = new List<Common.Ratings>();

            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    listgetrate.Add(new Ratings()
                    {
                        avg = reader.GetValue<Int32>("avg_rating"),
                        IsAdmin = reader.GetValue<Int32>("isadmin")
                        //ToUserId = reader.GetValue<Guid>("ToUserId"),
                        //Comment = reader.GetValue<string>("Comment"),
                        //FromUserId = reader.GetValue<Guid>("FromUserId")
                    });
                }
                reader.Close();
                return listgetrate;

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return listgetrate;
        }

        /// <summary>
        /// Display rating for user ( wrong delete  later) not in use
        /// </summary>
        /// <param name="buyerid"></param>
        /// <returns></returns>
        public DataTable getQuestionRating(Guid ToUserId, Guid FromUserId, bool type) //gets question rating of all type of User
        {
            DataTable dtablequestion = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();
            try
            {

                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getQuestRating";

                p1.ParameterName = "@ToUserId";
                p1.Value = ToUserId;
                p1.DbType = DbType.Guid;
                cmd.Parameters.Add(p1);

                p2.ParameterName = "@FromUserId";
                p2.Value = FromUserId;
                p2.DbType = DbType.Guid;
                cmd.Parameters.Add(p2);

                p3.ParameterName = "@Type";
                p3.Value = type;
                p3.DbType = DbType.Boolean;
                cmd.Parameters.Add(p3);

                da.SelectCommand = cmd;
                da.Fill(dtablequestion);
               
            }
            catch (Exception ex)
            {

                IClogger.LogMessage(ex.Message);
            }
            finally
            {
                cn.Close();
            }


            return dtablequestion;
        }

        /// <summary>
        /// gets all rating Questions
        /// </summary>
        /// <returns></returns>
        public DataTable getRatingQuestion()
        {
            DataTable dtablequestion = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(ConnectionString);
            //SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRatingQuestion";


            //cmd = db.GetStoredProcCommand("[getRatingQuestion]");
            try
            {
                cmd.Connection = cn;
                da.SelectCommand = cmd;
                da.Fill(dtablequestion);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return dtablequestion;
        }

        /// <summary>
        /// Inserts rating questions
        /// </summary>
        public int insertRatingQuestionDAL(Guid currUserId, string ratingQuestion, bool rateType)
        {
            int insertStatus = 0;  //checks if data is Inserted in table or not
            try
            {
                SqlDatabase db = new SqlDatabase(ConnectionString);
                DbCommand command = db.GetStoredProcCommand("InsertRatingQuestions");

                db.AddInParameter(command, "@AdminUserId", DbType.Guid, currUserId);
                db.AddInParameter(command, "@Question", DbType.String, ratingQuestion);
                db.AddInParameter(command, "@TypeofUser", DbType.Boolean, rateType);
                db.AddOutParameter(command, "@temp", DbType.Int32, 0);

                try
                {
                    db.ExecuteNonQuery(command);
                    insertStatus = Convert.ToInt32(command.Parameters["@temp"].Value);
                    // return insertStatus;
                }

                catch (Exception ex)
                {
                    IClogger.LogMessage(ex.Message);
                    //  return false;
                }

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return insertStatus;

        }

        /// <summary>
        /// updated rating questions
        /// </summary>
        /// <param name="ratingQuestions"></param>
        /// <param name="type"></param>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public int UpdateRateQuestionDal(string ratingQuestions, int questionId)
        {
            int insertUpdateStatus = 0;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("UpdateRatingQuestions");
            db.AddInParameter(command, "@Question", DbType.String, ratingQuestions);
            // db.AddInParameter(command, "@TypeOfUser", DbType.Boolean, type);
            db.AddInParameter(command, "@QuestionId", DbType.Int32, questionId);
            db.AddOutParameter(command, "@temp", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(command);
                insertUpdateStatus = Convert.ToInt32(command.Parameters["@temp"].Value);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertUpdateStatus;
        }

        /// <summary>
        /// deletes the selected ratng questions
        /// </summary>
        /// <param name="questionId"></param>
        public int deleteRatingQuestionDal(int questionId, bool type)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteRatingQuestions");
            db.AddInParameter(command, "@QuestionId", DbType.Int32, questionId);
            db.AddInParameter(command, "@type", DbType.Boolean, type);
            db.AddOutParameter(command, "@status", DbType.Int32, 0);
            int deletestatus = 0;
            try
            {
                db.ExecuteNonQuery(command);
                deletestatus = Convert.ToInt32(command.Parameters["@status"].Value);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return deletestatus;
        }

        /// <summary>
        ///get rating question on Type
        /// </summary>
        /// <param name="typeOfMember"></param>
        /// <returns></returns>
        public DataTable getRatingQuestionDAL(bool typeOfMember)
        {
            DataTable dtablequestion = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection(ConnectionString);
            //SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlParameter p1 = new SqlParameter();
            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getRatingQuestionOnType";

                p1.ParameterName = "@typeOfUser";
                p1.Value = typeOfMember;
                p1.DbType = DbType.Boolean;
                cmd.Parameters.Add(p1);

                da.SelectCommand = cmd;
                da.Fill(dtablequestion);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return dtablequestion;
        }

        public List<Ratings> getCommentDetails(Guid ToUserId) //gets Average Seller Rating for buyer
        {
            List<Ratings> lstid = new List<Ratings>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetUserRatingDetails]");
            db.AddInParameter(command, "@ToUserId", DbType.Guid, ToUserId);

            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstid.Add(new Ratings()
                    {
                        ToUserId = reader.GetValue<Guid>("ToUserId"),
                        Comment = reader.GetValue<string>("Comment"),
                        FromUserId = reader.GetValue<Guid>("FromUserId")
                    });
                }
                reader.Close();
                return lstid;
            }
        }

        public List<Ratings> getCommentforUser(Guid ToUserId, Guid FromUserId) //gets Average Seller Rating for buyer
        {
            List<Ratings> lstid = new List<Ratings>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("[GetUserCommentsDetails]");
            db.AddInParameter(command, "@ToUserId", DbType.Guid, ToUserId);
            db.AddInParameter(command, "@FromUserId", DbType.Guid, FromUserId);

            {
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstid.Add(new Ratings()
                    {
                        ToUserId = reader.GetValue<Guid>("ToUserId"),
                        Comment = reader.GetValue<string>("Comment"),
                        FromUserId = reader.GetValue<Guid>("FromUserId")
                    });
                }
                reader.Close();
                return lstid;
            }
        }

        /// <summary>
        /// fills the comments
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Ratings fillcommentsDetails(IDataReader reader)
        {
            try
            {
                //Ratings rats = new Ratings();
                rates.Comment = reader.GetValue<string>("Comment");
                rates.FromUserId = reader.GetValue<Guid>("FromUserId");
                //rates.Question3Rating = reader.GetValue<int>("Question3rating");
                //rates.Question4Rating = reader.GetValue<int>("Question4rating");
                //rates.Question5Rating = reader.GetValue<int>("Question5rating");
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return rates;
        }

        /// <summary>
        /// deletes the comment  
        /// </summary>
        /// <param name="FromUserId"></param>
        /// <param name="ToUserId"></param>
        /// <returns></returns>
        public bool delete(Guid FromUserId, Guid ToUserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("DeleteComment");

            db.AddInParameter(command, "@FromUserId", DbType.Guid, FromUserId);
            db.AddInParameter(command, "@ToUserId", DbType.Guid, ToUserId);


            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// gets all Paid membership User  to bind the grid of paid member utilised in Admin View Ratings
        /// </summary>
        public List<Common.UserProfile> getAllPaidMembersDAL()
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("getAllPaidMembers");
            List<Common.UserProfile> lstid = new List<Common.UserProfile>();

            try
            {
                db.ExecuteNonQuery(command);
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    lstid.Add(new Common.UserProfile()
                    {
                        UserId = reader.GetValue<Guid>("UserId"),
                        CompanyName = reader.GetValue<String>("CompanyName")

                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return lstid;
        }

        /// <summary>
        /// method to get searched Paid Member utilized in Admin View Rating
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Common.UserProfile> getAllSearchMember(string searchText, int typemembership)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("getSearchedPaidMember");
            db.AddInParameter(command, "@searchCompany", DbType.String, searchText);
            db.AddInParameter(command, "@typeofMembership", DbType.Int32, typemembership);

            List<Common.UserProfile> listSearchMember = new List<Common.UserProfile>();
            try
            {
                db.ExecuteNonQuery(command);
                IDataReader reader = (IDataReader)db.ExecuteReader(command);

                while (reader.Read())
                {
                    listSearchMember.Add(new Common.UserProfile()
                    {
                        UserId = reader.GetValue<Guid>("UserId"),
                        CompanyName = reader.GetValue<String>("CompanyName")

                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listSearchMember;
        }

        /// <summary>
        /// deletes the ratings given by Admin of a specific member
        /// </summary>
        /// <param name="deletetype"></param>
        /// <param name="ToUserId"></param>
        /// <returns></returns>
        public bool deleteUserRatingDAL(bool deletetype, string ToUserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("deleteAdminRatings");
            db.AddInParameter(command, "@ToUserId", DbType.String, ToUserId);
            db.AddInParameter(command, "@TypeOfMember", DbType.Boolean, deletetype);

            try
            {
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return false;
            }

        }
    }
}
