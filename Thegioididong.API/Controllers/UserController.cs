using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service;

namespace Thegioididong.API.Controllers
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
        public ApiResult<UserClaim> Create([FromQuery] LoginRequest request)
        {
            try
            {
                UserClaim result = _userService.Authencate(request);
                if(result == null)
                {
                    return new ApiErrorResult<UserClaim>(null, "Tên tài khoản hoặc mật khẩu không hợp lệ");
                }
                return new ApiSuccessResult<UserClaim>(result,"Đăng nhập thành công");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<UserClaim>(null,ex.Message.ToString());
            }
        }
    }
}
