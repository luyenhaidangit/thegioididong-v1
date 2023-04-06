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
using Thegioididong.Model.ViewModels.System.Emails;
using Thegioididong.Model.ViewModels.System.Users;
using Thegioididong.Service.Common;
using Thegioididong.Service.System;
using static Thegioididong.Common.Constants.SystemConstant;

namespace Thegioididong.Service
{
    public partial interface IUserService
    {
        UserClaim Authencate(LoginRequest request);

        UserClaim Authentication(LoginRequest request);

        bool Register(RegisterRequest request);

        OtpGetResult CreateOtp(int id);

        PagedResult<User> GetUsers(UserPagingManageGetRequest request);

        UserClaim SubmitOtp(SubmitOTPRequest request);
    }
    public partial class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IStorageService _storageService;
        private IEmailService _emailService;
        private const string USER_CONTENT_FOLDER_NAME = "upload";

        public UserService(IUserRepository userRepository, IStorageService storageService,IEmailService emailService)
        {
            this._userRepository = userRepository;
            this._storageService= storageService;
            this._emailService= emailService;
        }

        public bool VerificationAccount(int id)
        {
            Random r = new Random();
            string otp = r.Next(100001, 999999).ToString();
            string content = "Mã xác nhận của bạn là:" + otp;

            return true;
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
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);

            user.Token = token;

            return user;
        }

        public UserClaim Authentication(LoginRequest request)
        {
            UserClaim user = _userRepository.Authentication(request);

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
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.Username)
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

        public PagedResult<User> GetUsers(UserPagingManageGetRequest request)
        {
            return _userRepository.GetUsers(request);
        }

        public OtpGetResult CreateOtp(int id)
        {
            try
            {
                var result = _userRepository.CreateOtp(id);
                SendEmailRequest request = new SendEmailRequest();
                request.Title = "Mã xác nhận hệ thông Thegioididong";
                request.Content = "Mã xác nhận của bạn là:" + result.Code;
                request.Email = result.Email;

                bool sendMail = _emailService.Send(request);
                return _userRepository.CreateOtp(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserClaim SubmitOtp(SubmitOTPRequest request)
        {
            UserClaim user = _userRepository.SubmitOtp(request);

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
