using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Role { get; set; }

        public bool Status { get; set; }
    }
}
