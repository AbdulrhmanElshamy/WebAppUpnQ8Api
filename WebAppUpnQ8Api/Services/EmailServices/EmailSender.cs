using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using WebAppUpnQ8Api.Configuration;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;

        public EmailSender(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task<bool> SendEmailAsync(MailData mailData)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_mailSettings.Name, _mailSettings.EmailId));
                email.To.Add(new MailboxAddress(mailData.EmailToName, mailData.EmailToId));
                email.Subject = mailData.EmailSubject;

                var builder = new BodyBuilder
                {
                    HtmlBody = mailData.EmailBody
                };

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, _mailSettings.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.EmailId, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
