﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.System.Users
{
    public class CustomerRegisterRequest
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
