using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            StatusCode = 0;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            StatusCode = 0;
            ValidationErrors = validationErrors;
        }

        public ApiErrorResult(T resultObj, string message)
        {
            StatusCode = 0;
            Message = message;
            Data = resultObj;
        }
    }
}
