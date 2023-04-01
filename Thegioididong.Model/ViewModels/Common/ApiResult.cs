using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Common
{
    public class ApiResult<T>
    {
        public ApiResult()
        {

        }

        public ApiResult(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
