using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Emails;
using Thegioididong.Model.ViewModels.System.Users;
using static System.Net.WebRequestMethods;

namespace Thegioididong.Service.System
{
    public partial interface IEmailService
    {
        bool Send(SendEmailRequest request);
    }

    public class EmailService : IEmailService
    {
        public bool Send(SendEmailRequest request)
        {
            using (MailMessage mail = new MailMessage("luyenhaidangit@outlook.com", request.Email))
            {
                mail.Subject = request.Title;
                mail.Body = request.Content;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("luyenhaidangit@outlook.com", "Haidang106");
                smtp.Send(mail);
            }

            return true;
        }

    }
}
