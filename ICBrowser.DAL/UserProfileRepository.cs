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
    public class UserProfileRepository : Repository
    {
        //to get user details 
        public UserProfile GetUserProfileDetails(Guid userid)
        {
            UserProfile buyersprofile = new UserProfile();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetUserProfileDetailsById");
            db.AddInParameter(command, "@UserId", DbType.Guid, userid);

            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    buyersprofile = FillUserProfile(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return buyersprofile;
        }

        private UserProfile FillUserProfile(IDataReader reader)
        {
            UserProfile userProfile = new UserProfile();
            try
            {


                //cmpdet.BuyerOrSellerId = Convert.ToInt32(reader.GetValue<int>("userid"));
                userProfile.UserID = reader.GetValue<Guid>("UserID");
                userProfile.UserName = reader.GetValue<string>("UserName");
                userProfile.CompanyName = reader.GetValue<string>("CompanyName");
                userProfile.ContactName = reader.GetValue<string>("ContactName");
                userProfile.OwnerName = reader.GetValue<string>("OwnerName");
                userProfile.PanNumber = reader.GetValue<string>("PanNumber");
                userProfile.PrimaryAddress = reader.GetValue<string>("PrimaryAddress");
                userProfile.SecondaryAddress = reader.GetValue<string>("SecondaryAddress");

                userProfile.PrimaryState = reader.GetValue<string>("PrimaryState");
                userProfile.SecondaryState = reader.GetValue<string>("SecondaryState");
                userProfile.PrimaryCountry = reader.GetValue<string>("PrimaryCountry");
                userProfile.SecondaryCountry = reader.GetValue<string>("SecondaryCountry");
                userProfile.PrimaryCity = reader.GetValue<string>("PrimaryCity");
                userProfile.SecondaryCity = reader.GetValue<string>("SecondaryCity");
                userProfile.PrimaryZip = reader.GetValue<string>("PrimaryZip");
                userProfile.SecondaryZip = reader.GetValue<string>("SecondaryZip");

                userProfile.email = reader.GetValue<string>("Email");
                userProfile.LandLine = reader.GetValue<string>("LandLine");
                userProfile.Mobile = reader.GetValue<string>("Mobile");
                userProfile.Extension = reader.GetValue<string>("Extension");
                userProfile.FaxNumber = reader.GetValue<string>("FaxNumber");
                userProfile.PanNumber = reader.GetValue<string>("PanNumber");
                userProfile.Website = reader.GetValue<string>("Website");
                userProfile.Specialization = reader.GetValue<string>("Specialization");
                //userProfile.Currency = reader.GetValue<string>("Currency");
                userProfile.EmailPreference = reader.GetValue<int>("EMailPreference");
                userProfile.ModifiedDate = reader.GetValue<DateTime>("ModifiedDate");

                userProfile.TypeOfMembership = reader.GetValue<int>("TypeOfMembership");
                userProfile.MembershipCreation = reader.GetValue<DateTime>("CreateDate");
                userProfile.PaymentStatus = reader.GetValue<bool?>("PaymentStatus");
                userProfile.PaymentOption = reader.GetValue<int>("PaymentOption");
                userProfile.IsApproved = reader.GetValue<bool>("IsApproved");

                userProfile.MembershipTypeName = reader.GetValue<string>("MembershipTypeName");
                userProfile.Duration = reader.GetValue<int>("Duration");

                userProfile.SkypeId = reader.GetValue<string>("SkypeId");
                userProfile.MSNId = reader.GetValue<string>("MSNId");
                userProfile.QQId = reader.GetValue<string>("QQId");
                userProfile.ReasonToBlock = reader.GetValue<string>("ReasonToBlock");
                userProfile.ReasonToUnblock = reader.GetValue<string>("ReasonToUnblock");
                userProfile.ReasonToDecline = reader.GetValue<string>("ReasonToDecline");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return userProfile;

        }

        //to update user details 
        public void UpdateUsersProfileDetails(UserProfile obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateUsersProfilebyUserId");

            try
            {
                //db.AddInParameter(command, "@BuyerId", DbType.Int32, obj.BuyerOrSellerId);
                db.AddInParameter(command, "@UserId", DbType.Guid, obj.UserID);
                db.AddInParameter(command, "@CompanyName", DbType.String, obj.CompanyName);
                db.AddInParameter(command, "@OwnerName", DbType.String, obj.OwnerName);
                db.AddInParameter(command, "@ContactName", DbType.String, obj.ContactName);
                db.AddInParameter(command, "@PanNumber", DbType.String, obj.PanNumber);
                db.AddInParameter(command, "@PrimaryAddress", DbType.String, obj.PrimaryAddress);
                db.AddInParameter(command, "@SecondaryAddress", DbType.String, obj.SecondaryAddress);
                db.AddInParameter(command, "@PrimaryCountry", DbType.String, obj.PrimaryCountry);
                db.AddInParameter(command, "@SecondaryCountry", DbType.String, obj.SecondaryCountry);
                db.AddInParameter(command, "@PrimaryState", DbType.String, obj.PrimaryState);
                db.AddInParameter(command, "@SecondaryState", DbType.String, obj.SecondaryState);
                db.AddInParameter(command, "@PrimaryCity", DbType.String, obj.PrimaryCity);
                db.AddInParameter(command, "@SecondaryCity", DbType.String, obj.SecondaryCity);
                db.AddInParameter(command, "@PrimaryZip", DbType.String, obj.PrimaryZip);
                db.AddInParameter(command, "@SecondaryZip", DbType.String, obj.SecondaryZip);
                db.AddInParameter(command, "@LandLine", DbType.String, obj.LandLine);
                db.AddInParameter(command, "@Mobile", DbType.String, obj.Mobile);
                db.AddInParameter(command, "@Extension", DbType.String, obj.Extension);
                db.AddInParameter(command, "@FaxNumber", DbType.String, obj.FaxNumber);
                db.AddInParameter(command, "@Email", DbType.String, obj.email);
                db.AddInParameter(command, "@Website", DbType.String, obj.Website);
                db.AddInParameter(command, "@Specialization", DbType.String, obj.Specialization);
                //db.AddInParameter(command, "@Currency", DbType.String, obj.Currency);
                db.AddInParameter(command, "@EMailPreference", DbType.Int32, obj.EmailPreference);

                db.AddInParameter(command, "@QQId", DbType.String, obj.QQId);
                db.AddInParameter(command, "@SkypeId", DbType.String, obj.SkypeId);
                db.AddInParameter(command, "@MSNId", DbType.String, obj.MSNId);
                //db.AddInParameter(command, "@ModifiedDate", DbType.DateTime, obj.objUserDetails.ModifiedDate);

                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }


        //to Insert user details for Bar country 
        public void InsertUsersProfileDetailsforBarCountry(Guid userid, List<string> countryname)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("InsertUsersProfileforBarCountrybyUserId");

            try
            {
                //db.AddInParameter(command, "@BuyerId", DbType.Int32, obj.BuyerOrSellerId);
                foreach (var i in countryname)
                {
                    command.Parameters.Clear();
                    db.AddInParameter(command, "@UserId", DbType.Guid, userid);
                    db.AddInParameter(command, "@BarCountryName", DbType.String, i);
                    db.ExecuteNonQuery(command);
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }


        //to Delete user details for Bar country 
        public void DeleteUsersProfileDetailsforBarCountry(Guid userid, List<string> countryname)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("DeleteUsersProfileforBarCountrybyUserId");

            try
            {
                foreach (var i in countryname)
                {
                    command.Parameters.Clear();
                    db.AddInParameter(command, "@UserId", DbType.Guid, userid);
                    db.AddInParameter(command, "@CountryName", DbType.String, i);
                    db.ExecuteNonQuery(command);
                }

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }


        /// <summary>
        /// Description : Get User Details for Barcountry. 
        /// </summary>
        /// <returns></returns>
        /// 

        public List<UserProfile> GetUserBarCountryDetails(Guid userid)
        {
            List<UserProfile> lstBarCountry = new List<UserProfile>();

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetUsersProfileforBarCountrybyUserId");
            db.AddInParameter(cmd, "@UserId", DbType.Guid, userid);

            try
            {
                IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

                while (reader.Read())
                {
                    lstBarCountry.Add(new UserProfile()
                    {
                        Barcountry = reader.GetValue<string>("Countryname"),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return lstBarCountry;
        }


        // Membership Expiry Date Update..

        public void UpdateUsersMembershipExpiry(UserProfile obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateUsersMembershipExpiryDatebyUserId");

            try
            {
                db.AddInParameter(command, "@UserId", DbType.Guid, obj.UserID);
                db.AddInParameter(command, "@MembershipExpiryDate", DbType.DateTime, obj.MembershipExpiryDate);
                db.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                command.Dispose();
            }
        }


        /// <summary>
        /// Description : Get All User Details for Broadcast mail(Admin). 
        /// </summary>
        /// <returns></returns>
        /// 

        public List<UserProfile> GetAllUserDetails()
        {
            List<UserProfile> lstUsrProfile = new List<UserProfile>();

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetAllUserDetailsForBroadcastMail");

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                lstUsrProfile.Add(new UserProfile()
                {
                    EmailId = reader.GetValue<string>("Email"),
                    ContactName = reader.GetValue<string>("ContactName"),
                    TypeOfMembership = reader.GetValue<int>("TypeOfMembership")
                });
            }
            reader.Close();
            return lstUsrProfile;
        }




        /// <summary>
        /// Description : Gets all Users Data For Admin
        /// </summary>
        /// <returns></returns>
        /// 
        public List<UserProfile> GetAllPaidUserDetails(Guid loggedinUserId)
        {
            List<UserProfile> lstUsrProfile = new List<UserProfile>();

            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetAllPaidUsrDetails");
            db.AddInParameter(cmd, "@loggedinUserId", DbType.Guid, loggedinUserId);

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                lstUsrProfile.Add(new UserProfile()
                {
                    UserId = reader.GetValue<Guid>("UserID"),
                    EmailId = reader.GetValue<string>("Email"),
                    UserName = reader.GetValue<string>("UserName"),
                    CompanyName = reader.GetValue<string>("CompanyName"),
                    ContactName = reader.GetValue<string>("ContactName"),
                    MembershipExpiryDate = reader.GetValue<DateTime>("MembershipExpiryDate"),
                    CreateDate = reader.GetValue<DateTime>("CreateDate"),
                    ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                    PaymentStatus = reader.GetValue<bool>("IsBlocked"),
                    TypeOfMembership = reader.GetValue<int>("TypeOfMembership"),
                    ReasonToBlock = reader.GetValue<string>("ReasonToBlock"),
                    ReasonToUnblock = reader.GetValue<string>("ReasonToUnblock"),
                    PrimaryCountry = reader.GetValue<string>("PrimaryCountry"),
                    //IsExcluded = reader.GetValue<bool>("IsExcluded")
                });
            }
            reader.Close();
            return lstUsrProfile;
        }

        /// <summary>
        /// Description:Block The User By Admin
        /// </summary>
        /// <param name="usrId"></param>
        //public bool SetUsrBlock(Guid usrId)
        //{
        //    bool block = false;
        //    SqlDatabase db = new SqlDatabase(ConnectionString);
        //    DbCommand cmd = db.GetStoredProcCommand("SetUsrBlockByUid");
        //    try
        //    {
        //        db.AddInParameter(cmd, "@userId", DbType.Guid, usrId);
        //        db.ExecuteNonQuery(cmd);
        //        block = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.Message);
        //    }
        //    return block;
        //}

        public List<UserProfile> GetAllFreeUsrDetails(Guid LoggedinUserID)
        {
            List<UserProfile> lstUsrProfile = new List<UserProfile>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetAllFreeUsrDetails");
            db.AddInParameter(cmd, "@LoggedinUserID", DbType.Guid, LoggedinUserID);

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                lstUsrProfile.Add(new UserProfile()
                {
                    UserId = reader.GetValue<Guid>("UserID"),
                    email = reader.GetValue<string>("Email"),
                    UserName = reader.GetValue<string>("UserName"),
                    CompanyName = reader.GetValue<string>("CompanyName"),
                    ContactName = reader.GetValue<string>("ContactName"),
                    OwnerName = reader.GetValue<string>("OwnerName"),
                    CreateDate = reader.GetValue<DateTime>("CreateDate"),
                    ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                    PaymentStatus = reader.GetValue<bool>("IsBlocked"),
                    ReasonToBlock = reader.GetValue<string>("ReasonToBlock"),
                    ReasonToUnblock = reader.GetValue<string>("ReasonToUnblock"),
                    PrimaryCountry = reader.GetValue<string>("PrimaryCountry"),
                    //IsExcluded = reader.GetValue<bool>("IsExcluded")
                });
            }
            reader.Close();
            return lstUsrProfile;
        }

        //**Reference-List**//
        //public List<UserProfile> GetAllgvReferencelistDetails(Guid LoggedinUserID)
        //{
        //    List<UserProfile> lstUsrProfile = new List<UserProfile>();
        //    SqlDatabase db = new SqlDatabase(ConnectionString);
        //    DbCommand cmd = db.GetStoredProcCommand("GetAllgvReferencelistDetails");
        //    db.AddInParameter(cmd, "@LoggedinUserID", DbType.Guid, LoggedinUserID);

        //    IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

        //    while (reader.Read())
        //    {
        //        lstUsrProfile.Add(new UserProfile()
        //        {
        //            UserId = reader.GetValue<Guid>("UserID"),
        //            CompanyName = reader.GetValue<string>("CompanyName"),
        //            PrimaryCountry = reader.GetValue<string>("PrimaryCountry"),
        //        });
        //    }
        //    reader.Close();
        //    return lstUsrProfile;
        //}

        //public bool SetUsrUnBlock(Guid usrId)
        //{
        //    bool block = false;
        //    SqlDatabase db = new SqlDatabase(ConnectionString);
        //    DbCommand cmd = db.GetStoredProcCommand("SetUsrUnBlockByUid");
        //    try
        //    {
        //        db.AddInParameter(cmd, "@userId", DbType.Guid, usrId);
        //        db.ExecuteNonQuery(cmd);
        //        block = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogError(ex.Message);
        //    }
        //    return block;
        //}

        public List<UserProfile> GetAllTrialUserDetails()
        {
            List<UserProfile> lstTrialUsrProfile = new List<UserProfile>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetAllTrialUsrDetails");

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);

            while (reader.Read())
            {
                lstTrialUsrProfile.Add(new UserProfile()
                {
                    UserId = reader.GetValue<Guid>("UserID"),
                    email = reader.GetValue<string>("Email"),
                    UserName = reader.GetValue<string>("UserName"),
                    CompanyName = reader.GetValue<string>("CompanyName"),
                    ContactName = reader.GetValue<string>("ContactName"),
                    OwnerName = reader.GetValue<string>("OwnerName"),
                    CreateDate = reader.GetValue<DateTime>("CreateDate"),
                    ModifiedDate = reader.GetValue<DateTime>("ModifiedDate"),
                    PaymentStatus = reader.GetValue<bool>("IsBlocked"),
                });
            }
            reader.Close();
            return lstTrialUsrProfile;
        }

        public List<UserProfile> GetMatchRecords(UserProfile usrProf)
        {
            List<UserProfile> listUsrProfile = new List<UserProfile>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("GetMatchDetailsForTrial");
            // db.AddInParameter(cmd, "@userId", DbType.Guid, usrProf.UserId);
            //db.AddInParameter(cmd, "@contactName", DbType.String, usrProf.ContactName);
            //db.AddInParameter(cmd, "@companyName", DbType.String, usrProf.CompanyName);
            db.AddInParameter(cmd, "@mobile", DbType.String, usrProf.Mobile);
            db.AddInParameter(cmd, "@email", DbType.String, usrProf.email);
            //db.AddInParameter(cmd, "@panNumber", DbType.String, usrProf.PanNumber);
            db.AddInParameter(cmd, "@PhoneNo", DbType.String, usrProf.LandLine);

            IDataReader reader = (IDataReader)db.ExecuteReader(cmd);
            //if (reader.RecordsAffected != -1)          
            while (reader.Read())
            {
                listUsrProfile.Add(new UserProfile()
                {
                    UserId = reader.GetValue<Guid>("UserID"),
                    email = reader.GetValue<string>("Email"),
                    UserName = reader.GetValue<string>("UserName"),
                    CompanyName = reader.GetValue<string>("CompanyName"),
                    ContactName = reader.GetValue<string>("ContactName"),
                    Mobile = reader.GetValue<string>("Mobile"),
                    CreateDate = reader.GetValue<DateTime>("CreateDate"),
                    TypeOfMembership = reader.GetValue<Int32>("TypeOfMembership"),
                    IsDecline = reader.GetValue<Int32>("IsDecline"),
                    OfflineMembership = reader.GetValue<Int32>("OfflineMembership"),
                });
            }
            reader.Close();
            return listUsrProfile;
        }


        /// <summary>
        /// Sets Trial User Expiry On Admin Approval.
        /// </summary>
        /// <param name="guid"></param>
        public bool UpdateTrialUserRecord(Guid guid)
        {
            bool block = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("[UpdateTrialUsrExpiry]");
            try
            {
                db.AddInParameter(cmd, "@UserId", DbType.Guid, guid);
                db.ExecuteNonQuery(cmd);
                block = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return block;
        }

        public void UpdateMemberShipForTrialUser(Guid currUserId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("UpdateMemberShipTypeForTrialUser");
            try
            {
                db.AddInParameter(cmd, "@UserId", DbType.Guid, currUserId);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }


        //To Exclude User
        public bool SetExcludeUsr(Guid loggedInuserid, Guid ExcludeUserId)
        {
            bool block = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("InsertExcludeUserDetailsByUserId");
            try
            {
                db.AddInParameter(cmd, "@userId", DbType.Guid, loggedInuserid);
                db.AddInParameter(cmd, "@ExcludeUserId", DbType.Guid, ExcludeUserId);
                db.ExecuteNonQuery(cmd);
                block = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return block;

        }

        //To Un-Exclude User
        public bool SetUnExcludeUsr(Guid LoggedinUserId, Guid UnexcludeUserId)
        {
            bool block = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("UnExcludeUserDetailsByUserId");
            try
            {
                db.AddInParameter(cmd, "@userId", DbType.Guid, LoggedinUserId);
                db.AddInParameter(cmd, "@ExcludeUserId", DbType.Guid, UnexcludeUserId);
                db.ExecuteNonQuery(cmd);
                block = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return block;

        }


        //To Block User
        public bool SetBlockUsr(UserProfile obj)
        {
            bool block = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("BlockUser");
            try
            {
                db.AddInParameter(cmd, "@userId", DbType.Guid, obj.UserId);
                db.AddInParameter(cmd, "@ReasonToBlock", DbType.String, obj.ReasonToBlock);
                db.ExecuteNonQuery(cmd);
                block = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return block;

        }



        // To UnBlock User

        public bool SetUnBlockUsr(UserProfile obj)
        {
            bool block = false;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("UnBlockUser");
            try
            {
                db.AddInParameter(cmd, "@userId", DbType.Guid, obj.UserId);
                db.AddInParameter(cmd, "@ReasonToUnblock", DbType.String, obj.ReasonToUnblock);
                db.ExecuteNonQuery(cmd);
                block = true;
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return block;
        }

        //Update Decline User
        public void SetDeclineUsr(UserProfile Profile)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand cmd = db.GetStoredProcCommand("DeclineUser");
            try
            {
                db.AddInParameter(cmd, "@UserId", DbType.Guid, Profile.UserID);
                db.AddInParameter(cmd, "@ReasonToDecline", DbType.String, Profile.ReasonToDecline);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        ////Approve Button Visible
        //public bool GetUserApprove(Guid Userid)
        //{
        //    int ValidUser;
        //    SqlDatabase db = new SqlDatabase(ConnectionString);

        //    DbCommand command = db.GetStoredProcCommand("GetApprovedUser");

        //    db.AddInParameter(command, "@userid", DbType.Guid, Userid);
        //    try
        //    {
        //        ValidUser = Convert.ToInt32(db.ExecuteScalar(command));
        //        if (ValidUser > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        IClogger.LogMessage(ex.Message);
        //        return false;
        //    }
        //}
    }
}
