

namespace AccessData.Repos.IRepo
{
    public interface IEmailSend
    {
       void SendEmail(string toEmail, string subject, string body);
    }
}
