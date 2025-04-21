using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using WebAppUpnQ8Api.Configuration;
using UPNprojectApi.Models;
using MailKit.Net.Smtp;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.ViewModels;
using WebAppUpnQ8Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppUpnQ8Api.Controllers;
using Newtonsoft.Json.Linq;

namespace WebAppUpnQ8Api.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly WebAppUpnQ8ApiDBContext _dBContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;
        private MailSettings Mail_Settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(WebAppUpnQ8ApiDBContext dBContext, UserManager<ApplicationUser> userManager, PasswordHasher<ApplicationUser> passwordHasher, IConfiguration configuration, IOptions<MailSettings> options, SignInManager<ApplicationUser> signInManager, ITokenRepository tokenRepository, IHttpContextAccessor httpContextAccessor)
        {
            Mail_Settings = options.Value;
            _dBContext = dBContext;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<string>> RegisterCustom(RegisterViewModel model, bool lan)
        {
            var validate = _dBContext.Users.Where(s => s.Email == model.Email || s.UserName == model.UserName).FirstOrDefault();
            if (validate is not null)

                return Result<string>.Faild("Email or username already used");

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = _passwordHasher.HashPassword(null, model.Password)
            };

            user.ActivationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {


                CustomersTbl customer = new CustomersTbl();
                customer.User_ID = user.Id;
                await _dBContext.CustomersTbls.AddAsync(customer);
                await _dBContext.SaveChangesAsync();

                await _userManager.AddToRoleAsync(user, "User");

                await _dBContext.SaveChangesAsync();
                bool res = SendMail(lan, user);

                if (res)
                {
                    return Result<string>.Success("Registeration Successed , plz Confirm Email");

                }
                else
                {
                    return Result<string>.Failed("Send Email Confirmation is Failed");

                }

            }
            else
            {
                return Result<string>.Failed("Registeration failed");
            }


        }

        public async Task<Result<string>> ConfirmEmail(string code)
        {
            try
            {
                var user = await _dBContext.Users
               .FirstOrDefaultAsync(u => u.ActivationCode == code && u.EmailConfirmed == false);
                if (user != null)
                {
                    user.EmailConfirmed = true;
                    _dBContext.SaveChanges();
                    return Result<string>.Success("تم تأكيد الحساب بنجاح");
                }
                return Result<string>.Failed("عذرا الكود خاطئ");

            }
            catch
            {
                return Result<string>.Failed("عذرا لم يتم تأكيد الحساب");
            }
        }

        public async Task<Result<string>> ResetPassword(string email, bool lan)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return Result<string>.Failed("User not found! .");

            user.ActivationCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            _dBContext.Users.Update(user);

            await _dBContext.SaveChangesAsync();

            bool res = SendMail(lan, user);

            if (res)
                return Result<string>.Success("plz Check Email");


            return Result<string>.Failed("Send Email Confirmation is Failed");


        }


        public async Task<Result<string>> ResetPassword(string email,string code, string Password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Result<string>.Failed("عذرًا، المستخدم غير موجود");

            var resetResult = await _userManager.ResetPasswordAsync(user, code, Password);
            if (!resetResult.Succeeded)
                return Result<string>.Failed("حدث خطأ أثناء إعادة تعيين كلمة المرور");

            await _dBContext.SaveChangesAsync();
            return Result<string>.Success("تم إعادة تعيين كلمة المرور بنجاح");


        }

        public async Task<Result<string>> ResendEmail(string email, bool lan)
        {
            var user = await _dBContext.Users
             .FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
                return Result<string>.Failed("Email not found");

            if(user.EmailConfirmed)
                return Result<string>.Failed("Email Already Confirmed");


            var token = await _userManager.GenerateConcurrencyStampAsync(user);

            string frontendUrl = _configuration["FrontendUrl"];
            string callbackUrl = "";
            if (lan)
            {
                callbackUrl = $"{frontendUrl}/ar?code={token}";
            }
            else
            {
                callbackUrl = $"{frontendUrl}/en?code={token}";
            }
            MailData Mail_Data = new MailData();
            Mail_Data.EmailToId = user.Email;
            Mail_Data.EmailToName = user.Email;
            Mail_Data.EmailSubject = "Confirm Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/cconfirm.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{ConfirmationLink}", callbackUrl);
            body = body.Replace("{UserName}", user.UserName);
            Mail_Data.EmailBody = body;
            bool res = SendMail(Mail_Data);


            if (res)
            {
                return Result<string>.Success("Registeration Successed , plz Confirm Email");

            }
            else
            {
                return Result<string>.Failed("Send Email Confirmation is Failed");

            }

        }

        public async Task<Result<ResponsLoginViewModel>> LoginCustom(RegisterViewModel model)
        {
            var user = _dBContext.Users.Where(a => a.Email == model.Email).FirstOrDefault();
            if (user != null && user.EmailConfirmed)
            {
                var result1 = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result1.Succeeded)
                {
                    var accessToken = _tokenRepository.GenerateAccessToken(user);
                    var refreshToken = _tokenRepository.GenerateRefreshToken();
                    var refresh = new RefreshTokenTbl();
                    refresh.UserId = "null";
                    refresh.Token = refreshToken;
                    refresh.IsUsed = false;
                    refresh.ExpirationDate = DateTime.Now.AddDays(3);
                    await _dBContext.RefreshTokenTbls.AddAsync(refresh);
                    await _dBContext.SaveChangesAsync();
                    var tt = new ResponsLoginViewModel();
                    tt.Token = accessToken;
                    tt.Email = user.Email;
                    tt.RefreshToken = refreshToken;
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Result<ResponsLoginViewModel>.Success(tt);
                }
                else
                {
                    return Result<ResponsLoginViewModel>.Failed("Sign in Failed");
                }
            }
            else
            {
                return Result<ResponsLoginViewModel>.Failed("Email or Pass Uncorrect");
            }

        }

        public async Task<Result<ResponsLoginViewModel>> RefreshToken([FromBody] RefreshTokenModel model)
        {
            if (string.IsNullOrEmpty(model.RefreshToken))
            {
                return Result<ResponsLoginViewModel>.Failed("Refresh token is required");
            }
            var refreshToken = await _dBContext.RefreshTokenTbls
           .FirstOrDefaultAsync(rt => rt.Token == model.RefreshToken && rt.ExpirationDate > DateTime.UtcNow && !rt.IsUsed);
            if (refreshToken == null)
            {
                return Result<ResponsLoginViewModel>.Failed("");
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId)) return null;

                var user = await _dBContext.Users.FindAsync(userId);
                if (user == null) return null;

                var newAccessToken = _tokenRepository.GenerateAccessToken(user);
                var newRefreshToken = _tokenRepository.GenerateRefreshToken();

                var refresh = new RefreshTokenTbl
                {
                    UserId = user.Id,
                    Token = newRefreshToken,
                    IsUsed = false,
                    ExpirationDate = DateTime.Now.AddDays(3)
                };
                await _dBContext.RefreshTokenTbls.AddAsync(refresh);

                refreshToken.IsUsed = true;
                _dBContext.RefreshTokenTbls.Remove(refreshToken);

                await _dBContext.SaveChangesAsync();

                var response = new ResponsLoginViewModel
                {
                    RefreshToken = newRefreshToken,
                    Token = newAccessToken,
                    Email = user.Email
                };
                return Result<ResponsLoginViewModel>.Success(response);
            }
        }

        public async Task CreateRole(string name)
        {
            IdentityRole role = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name
            };
            await _dBContext.Roles.AddAsync(role);
            await _dBContext.SaveChangesAsync(); ;
        }

        private bool SendMail(bool lan, ApplicationUser user)
        {
            string frontendUrl = _configuration["FrontendUrl"];
            string callbackUrl = "";
            if (lan)
            {
                callbackUrl = $"{frontendUrl}/ar?code={user.ActivationCode}";
            }
            else
            {
                callbackUrl = $"{frontendUrl}/en?code={user.ActivationCode}";
            }
            MailData Mail_Data = new MailData();
            Mail_Data.EmailToId = user.Email;
            Mail_Data.EmailToName = user.Email;
            Mail_Data.EmailSubject = "Confirm Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/cconfirm.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{ConfirmationLink}", callbackUrl);
            body = body.Replace("{UserName}", user.UserName);
            Mail_Data.EmailBody = body;
            bool res = SendMail(Mail_Data);
            return res;
        }

        private bool SendMail(MailData Mail_Data)
        {
            try
            {
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(Mail_Settings.Name, Mail_Settings.EmailId);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(Mail_Data.EmailToName, Mail_Data.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = Mail_Data.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = Mail_Data.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                SmtpClient MailClient = new SmtpClient();
                MailClient.Connect(Mail_Settings.Host, Mail_Settings.Port, Mail_Settings.UseSSL);
                MailClient.Authenticate(Mail_Settings.EmailId, Mail_Settings.Password);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
