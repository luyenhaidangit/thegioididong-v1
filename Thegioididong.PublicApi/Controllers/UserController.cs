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
        private readonly IHttpClientFactory _clientFactory;
        public UserController(IUserService userService, IHttpClientFactory clientFactory)
        {
            this._userService = userService;
            _clientFactory = clientFactory;
        }

        [Route("Register")]
        [HttpPost]
        public ApiResult<bool> Register([FromForm] RegisterRequest request)
        {
            try
            {
                request.Account.Role = "Customer";
                bool register = _userService.Register(request);
                return new ApiSuccessResult<bool>(true, "Đăng ký thành công");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message.ToString());
            }
        }

        [Route("create-otp")]
        [HttpGet]
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

        [Route("get-ip")]
        [HttpGet]
        public async Task<string> GetIp()
        {
            //// Get the remote IP address
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;

            if(remoteIpAddress == null)
            {
                if(remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    remoteIpAddress = Dns.GetHostEntry(remoteIpAddress).AddressList.First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
            }
            var resutl = remoteIpAddress.ToString();


            var client = _clientFactory.CreateClient();

            // Replace the URL with one of the services mentioned above
            var response = await client.GetAsync("https://api.ipify.org");

            if (response.IsSuccessStatusCode)
            {
                var ipAddress = await response.Content.ReadAsStringAsync();
                return ipAddress;
            }
            else
            {
                // Handle the error case
                return string.Empty;
            }
        }

    }
}
