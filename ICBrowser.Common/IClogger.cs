using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace ICBrowser.Common
{
    public class IClogger
    {
        private static readonly ILog log = LogManager.GetLogger(
        
        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //  private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(FTrimWS));

        /// Logs message in the log files.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void LogMessage(string message)
        {
            //for logging message to file    
            StringBuilder sb = new StringBuilder();
            sb.Append("From LogMEssage");
            sb.Append(message);
            log.Debug(sb.ToString());
        }


        /// <summary>
        /// Logs Errors in the log file
        /// </summary>
        /// <param name="error">Exception that occurs</param>
        /// <param name="additionalInfo">Additional information that might be helpful in understanding the cause of the exception</param>
        public static void LogError(Exception error, string additionalInfo)
        {
            additionalInfo = "LogError(Exception error, String additionalInfo): " + additionalInfo;
            log.Error(additionalInfo, error);
            if (error.InnerException != null)
            {
                log.Error(additionalInfo, error.InnerException);
            }
        }
        /// <summary>
        /// Logs Error in the log file
        /// </summary>
        /// <param name="errorMessage">Error message to be logged</param>
        public static void LogError(string errorMessage)
        {
            errorMessage = "LogError(String ErrorMessage): " + errorMessage;
            log.Error(errorMessage);
        }
    }
}
