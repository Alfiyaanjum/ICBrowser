using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICBrowser.Common;
using ICBrowser.Business;
using ICBrowser.DAL;
using System.Data;


namespace ICBrowser.Business
{
    public class UserRatings
    {
        DAL.UserRatingRepository objRatings = new DAL.UserRatingRepository();
        Common.Ratings ObjRating = new Common.Ratings();

        // Insert Value
        public void InsertUserRating(Guid FromLogInUserId, Guid ToRatedUserId, int questionId, int rating, string comment, bool IsAdmin) //insert and update Seller rating  by Buyers if buyerid is already present 
        {
            try
            {
                objRatings.InsertRatings(FromLogInUserId, ToRatedUserId, questionId, rating, comment, IsAdmin);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
        }

        // Calculates Avg for rated user
        public List<Common.Ratings> getAverageratingsForUser(Guid RatedUserId, bool typeOfUser)
        {
            List<Common.Ratings> lstrate = new List<Common.Ratings>();
            // int RatedTotal = 0;
            try
            {
                lstrate = objRatings.getAverageratingsForUser(RatedUserId, typeOfUser);
                // return rats;
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return lstrate;
        }



        /// <summary>
        /// Display averate ratings
        /// </summary>
        /// <param name="buyerid"></param>
        /// <returns></returns>
        public DataTable getQuestionRating(Guid ToUserId, Guid FromUserId, bool type)//getAverage rating done by Seller on buyer
        {
            // Ratings rates = new Ratings();
            DataTable dtablerateQuestion = new DataTable();
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            try
            {
                dtablerateQuestion = objUserRatingRepository.getQuestionRating(ToUserId, FromUserId, type);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return dtablerateQuestion;
        }


        /// <summary>
        /// method to get rating questons in grid 
        /// </summary>
        /// <returns></returns>
        public DataTable getRatingQuestion()
        {

            DataTable dtablequestion = new DataTable();
            try
            {
                dtablequestion = objRatings.getRatingQuestion();
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return dtablequestion;
        }

        /// <summary>
        /// Insert rating questions
        /// </summary>
        public int InsertRatingQuestions(Guid currUserId, string ratingQuestion, bool rateType)
        {
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            int insertstatus = 0;
            try
            {
                insertstatus = objUserRatingRepository.insertRatingQuestionDAL(currUserId, ratingQuestion, rateType);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertstatus;
        }

        /// <summary>
        /// updates rating question 
        /// </summary>
        /// <param name="ratingquestion"></param>
        /// <param name="type"></param>
        /// <param name="questionid"></param>
        /// <returns></returns>

        public int UpdateRatingQuestions(string ratingquestion, int questionid)
        {
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            int insertUpdateStatus = 0;

            try
            {
                insertUpdateStatus = objUserRatingRepository.UpdateRateQuestionDal(ratingquestion, questionid);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return insertUpdateStatus;
        }

        /// <summary>
        /// deleted rating question
        /// </summary>
        /// <param name="questionid"></param>
        public int deleteRatingQuestion(int questionid,bool type)
        {
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            int deletestatus = 0;
            try
            {
               deletestatus= objUserRatingRepository.deleteRatingQuestionDal(questionid,type);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return deletestatus;
        }



        /// <summary>
        /// gets questions related to selling
        /// </summary>
        public DataTable getRatingQuestion(bool typeOfMember)
        {
            DataTable dtablequestion = new DataTable();
            try
            {
                dtablequestion = objRatings.getRatingQuestionDAL(typeOfMember);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return dtablequestion;
        }



        public List<Ratings> getCommentDetails(Guid ToUserId)//getAverage rating done by Seller on buyer
        {
            List<Ratings> rates = new List<Ratings>();
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            try
            {
                rates = objUserRatingRepository.getCommentDetails(ToUserId);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return rates;

        }

        public List<Ratings> getCommentforUser(Guid ToUserId, Guid FromUserId)//getAverage rating done by Seller on buyer
        {
            List<Ratings> rates = new List<Ratings>();
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            try
            {
                rates = objUserRatingRepository.getCommentforUser(ToUserId, FromUserId);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }

            return rates;

        }

        public bool DeleteComment(Guid formUserId, Guid toUserId)//getAverage rating done by Seller on buyer
        {

            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            try
            {
                bool rates = objUserRatingRepository.delete(formUserId, toUserId);
            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
                return false;
            }

            return true;

        }

        public List<Common.UserProfile> getAllPaidMembers()
        {
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            List<Common.UserProfile> listpaidUser = new List<Common.UserProfile>();

            try
            {
                listpaidUser = objUserRatingRepository.getAllPaidMembersDAL();

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listpaidUser;
        }

        public List<Common.UserProfile> getsearchedMembers(string searchtext, int typeMembership)
        {
            UserRatingRepository objUserRatingRepository = new UserRatingRepository();
            List<Common.UserProfile> listpaidUser = new List<Common.UserProfile>();

            try
            {

                listpaidUser = objUserRatingRepository.getAllSearchMember(searchtext, typeMembership);

            }
            catch (Exception ex)
            {
                IClogger.LogMessage(ex.Message);
            }
            return listpaidUser;
        }

        public bool deleteUserRating(bool deleteType, string ToUserId)
        {
            UserRatingRepository objUserRatingRepo = new UserRatingRepository();
            try
            {
                objUserRatingRepo.deleteUserRatingDAL(deleteType, ToUserId);
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
