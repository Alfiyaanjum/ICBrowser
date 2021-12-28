using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;

namespace ICBrowser.DAL
{
    public class StaticDataRepository : Repository
    {
        public EscrowDetails GetAboutUsStaticDetails()
        {
            EscrowDetails esc = new EscrowDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetAboutUsStaticDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    esc = FillAboutUsDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return esc;
        }

        private EscrowDetails FillAboutUsDetails(IDataReader reader)
        {

            EscrowDetails escrow = new EscrowDetails();
            try
            {
                escrow.StaticEnIN = reader.GetValue<string>("AboutUsEnIN");
                escrow.StaticZhCN = reader.GetValue<string>("AboutUsZhCN");
                escrow.ImagePath = reader.GetValue<string>("ImagePathAu");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return escrow;
        }


        public EscrowDetails GetServiceStaticDetails()
        {

            EscrowDetails esc = new EscrowDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);

            DbCommand command = db.GetStoredProcCommand("GetServiceStaticDetails");


            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    esc = FillServiceDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return esc;
        }

        private EscrowDetails FillServiceDetails(IDataReader reader)
        {

            EscrowDetails escrow = new EscrowDetails();
            try
            {
                escrow.StaticEnIN = reader.GetValue<string>("ServicesEnIN");
                escrow.StaticZhCN = reader.GetValue<string>("ServicesZhCN");
                escrow.ImagePath = reader.GetValue<string>("ImagePathSo");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return escrow;
        }

        public WhyUs GetWhyUsStaticDetails()
        {

            WhyUs esc = new WhyUs();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetWhyUsDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    esc = FillWhyusDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return esc;
        }

        public PrivatePolicy GetPrivatePolicyDetails()
        {

            PrivatePolicy policy = new PrivatePolicy();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetPrivatePolicyDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    policy = FillPrivatePolicyDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return policy;
        }
        public EscrowDetails GetEscrowStaticDetails()
        {

            EscrowDetails esc = new EscrowDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetICBrowserStaticDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    esc = FillEscrowDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return esc;
        }

        private EscrowDetails FillEscrowDetails(IDataReader reader)
        {

            EscrowDetails escrow = new EscrowDetails();
            try
            {
                escrow.StaticEnIN = reader.GetValue<string>("EscrowEnIN");
                escrow.StaticZhCN = reader.GetValue<string>("EscrowZhCN");
                escrow.ImagePath = reader.GetValue<string>("ImagePathEs");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return escrow;
        }
        private WhyUs FillWhyusDetails(IDataReader reader)
        {

            WhyUs escrow = new WhyUs();
            try
            {
                escrow.QuestionEng = reader.GetValue<string>("WhyUsENIN");
                escrow.QuestionCny = reader.GetValue<string>("WhyUsZhCN");
               // escrow.QuestionId = reader.GetValue<string>("ImagePathEs");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return escrow;
        }
        private PrivatePolicy FillPrivatePolicyDetails(IDataReader reader)
        {

            PrivatePolicy policy = new PrivatePolicy();
            try
            {
                policy.PrivatePolicyEn = reader.GetValue<string>("PrivatePolicyEnIN");
                policy.PrivatePolicyCn = reader.GetValue<string>("PrivatePolicyZhCN");
                // escrow.QuestionId = reader.GetValue<string>("ImagePathEs");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return policy;
        }


        public ContactUs GetContactUsStaticDetails()
        {
            ContactUs esc = new ContactUs();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetContactUsStaticDetails");
            try
            {
                IDataReader reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    esc = FillContactUsDetails(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return esc;
        }

        private ContactUs FillContactUsDetails(IDataReader reader)
        {

            ContactUs cu = new ContactUs();
            try
            {
                cu.StaticEnIN = reader.GetValue<string>("ContactUsEnIN");
                cu.StaticZhCN = reader.GetValue<string>("ContactUsZhCN");
                cu.ImagePath = reader.GetValue<string>("ImagePathCu");

                cu.SalesOfficeEmail = reader.GetValue<string>("SalesOfficeEmail");
                cu.SalesOfficePhNo = reader.GetValue<string>("SalesOfficePhNo");
                cu.AdvertisementEmail = reader.GetValue<string>("AdvertisementEmail");
                cu.AdvertisementPhNo = reader.GetValue<string>("AdvertisementPhNo");
                cu.CustServiceEmail = reader.GetValue<string>("CustServiceEmail");
                cu.CustServicePhNo = reader.GetValue<string>("CustServicePhNo");

            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

            return cu;
        }

        public void UpdateAboutUs(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateAboutUs");
            try
            {
                db.AddInParameter(command, "@AboutUsEnIN", DbType.String, ed.StaticEnIN);
                db.AddInParameter(command, "@AboutUsZhCN", DbType.String, ed.StaticZhCN);
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

        public void UpdateEscrow(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateEscro");

            try
            {
                db.AddInParameter(command, "@EscrowEnIN", DbType.String, ed.StaticEnIN);
                db.AddInParameter(command, "@EscrowZhCN", DbType.String, ed.StaticZhCN);
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

        public void UpdateServicesOffered(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateServicesOffered");

            try
            {
                db.AddInParameter(command, "@ServicesEnIN", DbType.String, ed.StaticEnIN);
                db.AddInParameter(command, "@ServicesZhCN", DbType.String, ed.StaticZhCN);
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

        public void UpdateContactUs(ContactUs cu)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateContactUs");
            try
            {
                db.AddInParameter(command, "@ContactUsEnIN", DbType.String, cu.StaticEnIN);
                db.AddInParameter(command, "@ContactUsZhCN", DbType.String, cu.StaticZhCN);
                db.AddInParameter(command, "@CustServiceEmail", DbType.String, cu.CustServiceEmail);
                db.AddInParameter(command, "@CustServicePhNo", DbType.String, cu.CustServicePhNo);
                db.AddInParameter(command, "@AdvertisementEmail", DbType.String, cu.AdvertisementEmail);
                db.AddInParameter(command, "@AdvertisementPhNo", DbType.String, cu.AdvertisementPhNo);
                db.AddInParameter(command, "@SalesOfficeEmail", DbType.String, cu.SalesOfficeEmail);
                db.AddInParameter(command, "@SalesOfficePhNo", DbType.String, cu.SalesOfficePhNo);

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



        public void UpdateImagepathAu(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateImagePathAu");
            try
            {
                db.AddInParameter(command, "@ImgPath", DbType.String, ed.ImagePath);
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

        public void UpdateImagepathEs(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateImagePathEs");
            try
            {
                db.AddInParameter(command, "@ImgPath", DbType.String, ed.ImagePath);
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

        public void UpdateImagepathSo(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateImagePathSo");
            try
            {
                db.AddInParameter(command, "@ImgPath", DbType.String, ed.ImagePath);
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

        public void UpdateImagepathCu(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("UpdateImagePathCu");
            try
            {
                db.AddInParameter(command, "@ImgPath", DbType.String, ed.ImagePath);
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
        /// FAQ.aspx Methods.
        /// </summary>
        /// <returns></returns>
        public List<FAQ> GetFaqData()
        {
            List<FAQ> fq = new List<FAQ>();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DbCommand command = db.GetStoredProcCommand("GetFaqData");

            IDataReader reader = db.ExecuteReader(command);
            while (reader.Read())
            {
                fq.Add(new FAQ()
                {
                    QuestionId = reader.GetValue<int>("QuestionId"),
                    QuestionEng = reader.GetValue<string>("QuestionEng"),
                    AnswerEng = reader.GetValue<string>("AnswerEng"),
                    QuestionCny = reader.GetValue<string>("QuestionCny"),
                    AnswerCny = reader.GetValue<string>("AnswerCny"),
                });
            }
            reader.Close();
            return fq;
        }

        public FAQ GetFaqbyQueId(int QueId)
        {
            FAQ faq = new FAQ();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("GetFaqbyQid");
                db.AddInParameter(command, "@Queid", DbType.Int32, QueId);
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    faq.QuestionId = reader.GetValue<int>("QuestionId");
                    faq.QuestionEng = reader.GetValue<string>("QuestionEng");
                    faq.AnswerEng = reader.GetValue<string>("AnswerEng");
                    faq.QuestionCny = reader.GetValue<string>("QuestionCny");
                    faq.AnswerCny = reader.GetValue<string>("AnswerCny");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
           

            return faq;
        }

        public void UpdateFaqEngbyQuestionId(FAQ faq)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("UpdateEngFaqbyQuestionId");
                db.AddInParameter(command, "@QueId", DbType.Int32, faq.QuestionId);
                db.AddInParameter(command, "@Question", DbType.String, faq.QuestionEng);
                db.AddInParameter(command, "@Answer", DbType.String, faq.AnswerEng);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        public void UpdateFaqCnybyQuestionId(FAQ faq)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("UpdateCnyFaqbyQuestionId");
                db.AddInParameter(command, "@QueId", DbType.Int32, faq.QuestionId);
                db.AddInParameter(command, "@Question", DbType.String, faq.QuestionCny);
                db.AddInParameter(command, "@Answer", DbType.String, faq.AnswerCny);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

        public void AddNewFaq(FAQ faq)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("AddNewFaq");

                db.AddInParameter(command, "@QueEng", DbType.String, faq.QuestionEng);
                db.AddInParameter(command, "@AnsEng", DbType.String, faq.AnswerEng);
                db.AddInParameter(command, "@QueCny", DbType.String, faq.QuestionCny);
                db.AddInParameter(command, "@AnsCny", DbType.String, faq.AnswerCny);

                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

       

        public void InsertUserLocationDetails(UserLocationDetails obj)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("InsertUserLocationDetails");
                db.AddInParameter(command, "@UserId", DbType.String,obj.UserId );
                db.AddInParameter(command, "@IPAddress", DbType.String, obj.IPAddress);
                db.AddInParameter(command, "@City", DbType.String, obj.City);
                db.AddInParameter(command, "@Country", DbType.String, obj.Country);

                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }

      


        public void DeleteFaqByQuestionId(int queId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("DeleteFaqbyQueId");
                db.AddInParameter(command, "@QuestionId", DbType.Int32, queId);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
        }


        /// <summary>
        /// Legal Agreement page Methods.
        /// </summary>
        /// <param name="ed"></param>
        public void UpdateLegalAgreementData(EscrowDetails ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("[UpdateLegalAgreement]");
                db.AddInParameter(command, "@LegalAgreeEnIN", DbType.String, ed.StaticEnIN);
                db.AddInParameter(command, "@LegalAgreeZhCN", DbType.String, ed.StaticZhCN);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

        }
        public void UpdateWhyusData(WhyUs ed)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("[UpdateWhyUs]");
                db.AddInParameter(command, "@WhyUsENIN", DbType.String, ed.QuestionEng);
                db.AddInParameter(command, "@WhyUsZhCN", DbType.String, ed.QuestionCny);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

        }
        public void UpdatePrivatepolicyData(PrivatePolicy policy)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("[UpdatePrivatePolicy]");
                db.AddInParameter(command, "@PrivatePolicyEnIN", DbType.String, policy.PrivatePolicyEn);
                db.AddInParameter(command, "@PrivatePolicyZhCN", DbType.String, policy.PrivatePolicyCn);
                IDataReader reader = db.ExecuteReader(command);
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }

        }
        
        
        public EscrowDetails GetLegalAgreementStaticDetails()
        {
            EscrowDetails ed = new EscrowDetails();
            SqlDatabase db = new SqlDatabase(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                DbCommand command = db.GetStoredProcCommand("GetLegalAgreementData");
                IDataReader reader = db.ExecuteReader(command);
                while (reader.Read())
                {
                    ed.StaticEnIN = reader.GetValue<string>("LegalAgreementEnIN");
                    ed.StaticZhCN = reader.GetValue<string>("LegalAgreementZhCN");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IClogger.LogError(ex.Message);
            }
            return ed;
        }
    }
}
