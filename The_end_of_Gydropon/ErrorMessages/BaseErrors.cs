using System.IO;

namespace The_end_of_Gydropon.ErrorMessages
{
    public class BaseErrors
    { 
        private static string _errorLogPath = @"D:\log.txt";

        public static void WriteLogMessage(string logMessage)
        {
            using (StreamWriter tw = new StreamWriter(_errorLogPath))
            {
                //logMessage = logMessage + " - on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                tw.Write(logMessage);
                tw.Close();
            }
        }

        #region ErrorMessages

        private string CallError403(string additionalInfo)
        {
            return "Call Error 403 - Forbidden. " 
                   + "\nAdditional info: " + additionalInfo;
        }
        
        private string CallError404(string additionalInfo)
        {
            return "Call Error 404 - not found"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        private string CallError500(string additionalInfo)
        {
            return "Call Error 500 - internal server error"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        private string CallError503(string additionalInfo)
        {
            return "Call Error 503 - service unavailable"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        private string CallError504(string additionalInfo)
        {
            return "Call Error 504 - gateway timeout"
                   + "\nAdditional info: " + additionalInfo;
        }

        #endregion
    }
}