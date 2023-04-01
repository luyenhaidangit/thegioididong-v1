using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            StatusCode = 200;
            Data = resultObj;
        }

        public ApiSuccessResult()
        {
            StatusCode = 200;
        }

        public ApiSuccessResult(string message)
        {
            StatusCode = 200;
            Message = message;
        }

        public ApiSuccessResult(T resultObj,string message)
        {
            StatusCode = 200;
            Message= message;
            Data = resultObj;
        }

        public ApiSuccessResult(int statusCode,string message, T resultObj)
        {
            StatusCode = statusCode;
            Message = message;
            Data = resultObj;
        }
    }
}
