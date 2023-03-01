using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Users;
using static Thegioididong.Common.Constants.SystemConstant;

namespace Thegioididong.Service
{
    public partial interface IUserService
    {
        UserClaim Authencate(LoginRequest request);
    }
    public partial class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserClaim Authencate(LoginRequest request)
        {
            UserClaim user = _userRepository.Login(request);

            if (user == null)
            {
                user = null;
                return user;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretConfiguration.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);

            user.Token = token;

            return user;
        }
    }
}
