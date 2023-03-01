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
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }

        public ApiSuccessResult(string message)
        {
            IsSuccessed = true;
            Message = message;
        }

        public ApiSuccessResult(T resultObj,string message)
        {
            IsSuccessed = true;
            Message= message;
            ResultObj = resultObj;
        }
    }
}
