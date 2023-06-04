using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Net;
using System.Security.Claims;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Sales.Orders;
using Thegioididong.Model.ViewModels.System.Emails;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
{
    [EnableCors]
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
        public ApiResult<CustomerClaim> SubmitOtp([FromBody] SubmitOTPRequest request)
        {
            try
            {
                CustomerClaim result = _userService.SubmitOtp(request);
                if (result == null)
                {
                    return new ApiResult<CustomerClaim>(401, "Mã OTP không chính xác hoặc hết hạn!", result);
                }
                return new ApiResult<CustomerClaim>(200, "Xác nhận thành công!", result);
            }
            catch (Exception ex)
            {
                return new ApiResult<CustomerClaim>(400, "Lỗi: " + ex.Message, null);
            }
        }

        [Route("get-ip")]
        [HttpGet]
        public string GetIp()
        {
            return _userService.GetIpAddress();
        }

        [Authorize]
        [Route("info")]
        [HttpGet]
        public string GetInfo()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "customerId");
            if (userIdClaim == null)
            {
                // user is not authenticated
                throw new Exception("Không nhận được username hợp lệ!");
            }

            var userId = userIdClaim.Value;

            return userId;
        }

        //[HttpGet("google")]
        //public IActionResult GoogleLogin()
        //{
        //    var authenticationProperties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("GoogleCallback")
        //    };

        //    return Challenge(authenticationProperties, "Google");
        //}

        //[HttpGet("google-callback")]
        //public async Task<IActionResult> GoogleCallback()
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync();
        //    if (!authenticateResult.Succeeded)
        //    {
        //        // Xử lý lỗi đăng nhập
        //        return Unauthorized();
        //    }

        //    // Lấy thông tin người dùng từ authenticateResult
        //    var userId = authenticateResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var email = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
        //    var displayName = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);

        //    // Xử lý người dùng đã đăng nhập thành công

        //    return Ok(displayName);
        //}

        //[HttpGet]
        //public IActionResult ExternalLoginCallback()
        //{
        //    var authProperties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("ExternalLoginCallback")
        //    };

        //    var authenticateResult = HttpContext.AuthenticateAsync().GetAwaiter().GetResult();

        //    if (authenticateResult?.Succeeded == true)
        //    {
        //        // Đăng nhập thành công, thực hiện các hành động tùy ý ở đây
        //        // Ví dụ: redirect đến trang chủ
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        // Đăng nhập thất bại, thực hiện xử lý thích hợp
        //        // Ví dụ: redirect đến trang đăng nhập
        //        return RedirectToAction("Login", "Account");
        //    }
        //}

        //[HttpGet]
        //public IActionResult ExternalLogin()
        //{
        //    var authenticationProperties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("ExternalLoginCallback")
        //    };

        //    return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
        //}

    }
}
