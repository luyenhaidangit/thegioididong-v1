using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.System.Users
{
    public class VerificationAccountRequest
    {
        public int AccountId { get; set; }

        public string Code { get; set; }
    }
}
