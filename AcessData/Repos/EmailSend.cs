using AccessData.Repos.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Repos
{
    public class EmailSend : IEmailSend
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("taleon18249456@gmail.com", "ylxa viqj cowb bydf");
                smtp.EnableSsl = true;

                var mail = new MailMessage("taleon18249456@gmail.com", toEmail,subject,body);
                smtp.Send(mail);
            }
        }
    }
}
