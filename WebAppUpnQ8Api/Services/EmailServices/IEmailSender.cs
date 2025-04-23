using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.EmailServices
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(MailData mailData);
    }
}
