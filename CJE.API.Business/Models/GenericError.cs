using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.API.Business.Models
{
    public class GenericError
    {
        public GenericError(string code, string message, string techError = "")
        {
            Code = code;
            Message = message;
            TechnicalError = techError;
        }
        public string Code { get; set; }
        public string Message { get; set; }
        public string TechnicalError { get; set; }
    }
}
