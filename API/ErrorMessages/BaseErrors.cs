using System;
using System.Globalization;
using System.IO;

namespace The_end_of_Gydropon.ErrorMessages
{
    public class BaseErrors
    { 
        private static string _errorLogPath = @"D:\log.txt";
        
        /// <summary>
        /// Записывает ошибку в файл
        /// </summary>
        /// <param name="logMessage">Текст ошибки</param>
        public static void WriteLogMessage(string logMessage)
        {
            using (StreamWriter tw = new StreamWriter(_errorLogPath))
            {
                logMessage = logMessage + " - on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                tw.WriteLine(logMessage);
                tw.Close();
            }
        }
        
        /// <summary>
        /// Записывает Ошибку в Файл с Кодом Ошибки
        /// </summary>
        /// <param name="logMessage">текст ошибки с Exception.Message</param>
        /// <param name="ErrorCode">код ошибки</param>
        public static void WriteLogMessage(string logMessage, int ErrorCode)
        {
            using (StreamWriter tw = new StreamWriter(_errorLogPath))
            {
                logMessage = logMessage + " - on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                tw.WriteLine(logMessage);
                tw.Close();
            }
        }

        #region ErrorMessages

        /// <summary>
        /// Метод возвращающий текст ошибки
        /// </summary>
        /// <param name="code">код ошибки</param>
        /// <returns>текст ошибки</returns>
        private static string ChooseErrorCode(int code)
        {
            switch (code)
            {
                case 403:
                    return "Call Error 403 - Forbidden. " + '\n';
                case 404:
                    return "Call Error 404 - Not Found" + '\n';
                case 500:
                    return "Call Error 500 - Internal Server Error" + '\n';
                case 503:
                    return "Call Error 503 - Service Unavailable" + '\n';
                case 504:
                    return "Call Error 504 - gateway timeout" + '\n';
                default:
                    return "Unknown Error";
            }
        }
        

        #endregion
    }
}