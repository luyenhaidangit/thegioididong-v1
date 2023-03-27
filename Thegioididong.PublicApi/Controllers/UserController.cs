using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Common;
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
    }
}
