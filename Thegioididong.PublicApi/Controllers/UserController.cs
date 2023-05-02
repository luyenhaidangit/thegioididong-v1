using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Net;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Emails;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        //[Route("Register")]
        //[HttpPost]
        //public ApiResult<bool> Register([FromForm] RegisterRequest request)
        //{
        //    try
        //    {
        //        request.Account.Role = "Customer";
        //        bool register = _userService.Register(request);
        //        return new ApiSuccessResult<bool>(true, "Đăng ký thành công");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiErrorResult<bool>(ex.Message.ToString());
        //    }
        //}

        [Route("create-otp")]
        [HttpPost]
        public ApiResult<string> CreateOtp(string email)
        {
            try
            {
                OtpGetResult result = _userService.CreateOtp(email);
                if (result == null)
                {
                    return new ApiResult<string>(400, "Có lỗi xảy ra gửi mã OTP thất bại!", "Thất bại!");
                }
                return new ApiResult<string>(200, "Mã OTP đã được gửi!", "Thành công!");
            }
            catch (Exception ex)
            {
                return new ApiResult<string>(400, "Lỗi: " + ex.Message, null);
            }
        }

        [Route("submit-otp")]
        [HttpPost]
        public ApiResult<UserClaim> SubmitOtp([FromBody] SubmitOTPRequest request)
        {
            try
            {
                UserClaim result = _userService.SubmitOtp(request);
                if (result == null)
                {
                    return new ApiResult<UserClaim>(401, "Mã OTP không chính xác hoặc hết hạn!", result);
                }
                return new ApiResult<UserClaim>(200, "Xác nhận thành công!", result);
            }
            catch (Exception ex)
            {
                return new ApiResult<UserClaim>(400, "Lỗi: " + ex.Message, null);
            }
        }

        [Route("get-ip")]
        [HttpGet]
        public string GetIp()
        {
            return _userService.GetIpAddress();
        }

    }
}
