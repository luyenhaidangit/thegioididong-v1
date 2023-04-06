using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Emails;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service;

namespace Thegioididong.ManageApi.Controllers
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

        [Route("Login")]
        [HttpPost]
        public ApiResult<UserClaim> Authentication([FromQuery] LoginRequest request)
        {
            try
            {
                UserClaim result = _userService.Authentication(request);
                if (result == null)
                {
                    return new ApiResult<UserClaim>(401,"Tên tài khoản hoặc mật khẩu không hợp lệ!", result);
                }
                return new ApiResult<UserClaim>(200, "Đăng nhập thành công",result);
            }
            catch (Exception ex)
            {
                return new ApiResult<UserClaim>(400, "Lỗi: "+ex.Message, null);
            }
        }

        [Route("VerifyAdminToken")]
        [Authorize(Roles = "administrator")]
        [HttpGet]
        public string VerifyAdminToken([FromQuery] string token)
        {
            try
            {
                return token;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("GetUsers")]
        [HttpGet]
        public PagedResult<User> GetUsers([FromQuery] UserPagingManageGetRequest request)
        {
            return _userService.GetUsers(request);
        }

        //[Route("CreateOtp")]
        //[HttpGet]
        //public OtpGetResult CreateOtp(int id)
        //{

        //    return _userService.CreateOtp(id);
        //}

        [Route("CreateOtp")]
        [HttpGet]
        public ApiResult<string> CreateOtp(int id)
        {
            try
            {
                OtpGetResult result = _userService.CreateOtp(id);
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

        //[Route("SubmitOtp")]
        //[HttpPost]
        //public UserClaim SubmitOtp([FromBody] SubmitOTPRequest request)
        //{
        //    return _userService.SubmitOtp(request);
        //}

        [Route("SubmitOtp")]
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

        //[Route("CreateOtp")]
        //[HttpGet]
        //public OtpGetResult(int int)
        //{
        //    return _userService.GetUsers(request);
        //}
    }
}
