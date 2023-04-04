using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Common;
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
    }
}
