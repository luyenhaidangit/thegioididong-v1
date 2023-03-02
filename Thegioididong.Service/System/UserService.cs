using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service.Common;
using static Thegioididong.Common.Constants.SystemConstant;

namespace Thegioididong.Service
{
    public partial interface IUserService
    {
        UserClaim Authencate(LoginRequest request);

        bool Register(RegisterRequest request);
    }
    public partial class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "upload";

        public UserService(IUserRepository userRepository, IStorageService storageService)
        {
            this._userRepository = userRepository;
            this._storageService= storageService;
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

        public bool Register(RegisterRequest request)
        {
            if(request.Account.ImageFile!= null)
            {
                request.Account.Image = this.SaveFile(request.Account.ImageFile);
            }

            return _userRepository.Register(request);
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
