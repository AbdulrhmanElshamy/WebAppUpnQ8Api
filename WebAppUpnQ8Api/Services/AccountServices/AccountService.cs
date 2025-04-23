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
using WebAppUpnQ8Api.Services.EmailServices;

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
        private readonly IEmailSender _emailSender;

        public AccountService(WebAppUpnQ8ApiDBContext dBContext, UserManager<ApplicationUser> userManager, PasswordHasher<ApplicationUser> passwordHasher, IConfiguration configuration, IOptions<MailSettings> options, SignInManager<ApplicationUser> signInManager, ITokenRepository tokenRepository, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender)
        {
            Mail_Settings = options.Value;
            _dBContext = dBContext;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }

        public async Task<Result<string>> RegisterCustom(RegisterViewModel model, bool lan)
        {
            var validate = _dBContext.Users.Where(s => s.Email == model.Email || s.UserName == model.UserName).FirstOrDefault();
            if (validate is not null)

                return Result<string>.Faild("Email or username already used");

            if(model.CountryId is not null && model.CountryId != 0)
            {
                var country = await _dBContext.CountriesTbls.FindAsync(model.CountryId);
                if(country is null)
                    return Result<string>.Faild("Countory not found!.");


            }


            if (model.CityId is not null && model.CityId != 0)
            {
                var city = await _dBContext.CitiesTbls.FindAsync(model.CityId);
                if (city is null)
                    return Result<string>.Faild("city not found!.");


            }


            if (model.CodeNumberId is not null && model.CodeNumberId != 0)
            {
                var CodeNumber = await _dBContext.CodeNumbersTbls.FindAsync(model.CodeNumberId);
                if (CodeNumber is null)
                    return Result<string>.Faild("Code number not found!.");


            }




            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = _passwordHasher.HashPassword(null, model.Password),
                FirstName = model.FirstName,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                CityId = model.CityId != 0 && model.CityId != null ? model.CityId : null,
                CountryId = model.CountryId != 0 && model.CountryId != null ? model.CountryId : null,
                CodeNumberId = model.CodeNumberId != 0 && model.CodeNumberId != null ?  model.CodeNumberId : null,
                FirstAddress = model.FirstAdderess,
                SecondAddress = model.SecondAddress,
                LastName = model.LateName,
                PhoneNumber = model.FirstPhoneNumber,
                SecondPhoneNumber = model.SecondPhoneNumber,
                
            };

            //user.ActivationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, "User");

                await _dBContext.SaveChangesAsync();

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string callbackUrl = GetLinkWithUserId(lan, user, token);

                string body = string.Empty;
                using (StreamReader reader = new StreamReader("ViewModels/cconfirm.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{ConfirmationLink}", callbackUrl);
                body = body.Replace("{UserName}", user.UserName);

                var mail = new MailData
                {
                    EmailToId = user.Email,
                    EmailToName = user.FirstName ?? "",
                    EmailSubject = "Confirm Your Email",
                    EmailBody = body
                };

                bool res = await _emailSender.SendEmailAsync(mail);

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



        public async Task<Result<string>> ConfirmEmail(string userId,string code)
        {
            try
            {
                var user = await _dBContext.Users
               .FirstOrDefaultAsync(u => u.Id == userId && u.EmailConfirmed == false);

                if(user is null)
                    return Result<string>.Failed("عذرا لم يتم تأكيد الحساب");

                var res =await _userManager.ConfirmEmailAsync(user,code);

                if(res.Succeeded)
                    return Result<string>.Success("تم تأكيد الحساب بنجاح");
         
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

            _dBContext.Users.Update(user);

            await _dBContext.SaveChangesAsync();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            string callbackUrl = GetLinkWithUserId(lan, user, token);

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/resretPassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{ConfirmationLink}", callbackUrl);
            body = body.Replace("{UserName}", user.UserName);

            var mail = new MailData
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName ?? "",
                EmailSubject = "Confirm Your Email",
                EmailBody = body
            };

            bool res = await _emailSender.SendEmailAsync(mail);

            if (res)
                return Result<string>.Success("plz Check Email");


            return Result<string>.Failed("Send Email Confirmation is Failed");


        }


        public async Task<Result<string>> ResetPassword(string Id,string code, string Password)
        {
            var user = await _userManager.FindByIdAsync(Id);
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


            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            string callbackUrl = GetLinkWithUserId(lan, user, token);

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ViewModels/cconfirm.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{ConfirmationLink}", callbackUrl);
            body = body.Replace("{UserName}", user.UserName);

            var mail = new MailData
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName ?? "",
                EmailSubject = "Confirm Your Email",
                EmailBody = body
            };

            bool res = await _emailSender.SendEmailAsync(mail);


            if (res)
            {
                return Result<string>.Success("Registeration Successed , plz Confirm Email");

            }
            else
            {
                return Result<string>.Failed("Send Email Confirmation is Failed");

            }

        }

        public async Task<Result<ResponsLoginViewModel>> LoginCustom(LoginDTO model)
        {
            var user = _dBContext.Users.Where(a => a.Email == model.Email).FirstOrDefault();
            if (user != null && user.EmailConfirmed)
            {
                var result1 = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result1.Succeeded)
                {
                    ResponsLoginViewModel tt = await GetToken(user);
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

        public async Task<ResponsLoginViewModel> GetToken(ApplicationUser? user)
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
            return tt;
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

        private string GetLinkWithUserId(bool lan, ApplicationUser user,string code)
        {
            string frontendUrl = _configuration["FrontendUrl"];
            string callbackUrl = "";
            if (lan)
            {
                callbackUrl = $"{frontendUrl}/ar?userId={user.Id}&code={code}";
            }
            else
            {
                callbackUrl = $"{frontendUrl}/en?userId={user.Id}&code={code}";
            }

            return callbackUrl;
        }

        private string GetLink(bool lan, ApplicationUser user,string code)
        {
            string frontendUrl = _configuration["FrontendUrl"];
            string callbackUrl = "";
            if (lan)
            {
                callbackUrl = $"{frontendUrl}/ar?code={code}";
            }
            else
            {
                callbackUrl = $"{frontendUrl}/en?code={code}";
            }

            return callbackUrl;
        }
    }
}
