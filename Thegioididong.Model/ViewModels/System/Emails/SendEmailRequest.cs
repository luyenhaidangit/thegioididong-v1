using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.System.Emails
{
    public class SendEmailRequest
    {
        public string Title { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}
