using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.System.Users
{
    public class AccountRegisterRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IFormFile ImageFile { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }

        public string Role { get; set; }
    }

    public class UserRegisterRequest
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string Sex { get; set; }

        public string Andress { get; set; }

        public string NumberPhone { get; set; }

        public string Email { get; set; }

    }

    public class RegisterRequest
    {
        public UserRegisterRequest User { get; set; }

        public AccountRegisterRequest Account { get; set; }
    }
}
