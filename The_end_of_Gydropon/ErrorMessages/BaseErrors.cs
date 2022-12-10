using System;

namespace The_end_of_Gydropon.ErrorMessages
{
    public class BaseErrors
    {
        public string CallError404(string additionalInfo)
        {
            return "Call Error 404 - not found"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        public string CallError500(string additionalInfo)
        {
            return "Call Error 500 - internal server error"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        public string CallError503(string additionalInfo)
        {
            return "Call Error 503 - service unavailable"
                   + "\nAdditional info: " + additionalInfo;
        }
        
        public string CallError504(string additionalInfo)
        {
            return "Call Error 504 - gateway timeout"
                   + "\nAdditional info: " + additionalInfo;
        }
    }
}