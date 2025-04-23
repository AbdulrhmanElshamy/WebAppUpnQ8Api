using AspNet.Security.OAuth.Instagram;
using Google.Apis.Auth;
using Grpc.Core;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using UPNprojectApi.Models;
using WebAppUpnQ8Api.Configuration;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.Services.AccountServices;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WebAppUpnQ8ApiDBContext _dBContext;
     
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;
        private readonly IAccountService _service;

        public AuthController(UserManager<ApplicationUser> userManager, PasswordHasher<ApplicationUser> passwordHasher,
            WebAppUpnQ8ApiDBContext dBContext, SignInManager<ApplicationUser> signInManager
            , IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, ITokenRepository tokenRepository, IAccountService service)
        {
            _userManager = userManager;
            _dBContext = dBContext;

            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _service = service;
        }
        [HttpPost]
        public async Task<Result<string>> RegisterCustom(RegisterViewModel model , bool lan)
        {
            
            var res = await _service.RegisterCustom(model,lan);

            return res;
        }

        [HttpPost]
        
        public async Task<Result<string>> ConfirmEmail(string userId,string code)
        {
           var res = await _service.ConfirmEmail(userId, code);

            return res;
        }






        [HttpPost]
        public async Task<Result<ResponsLoginViewModel>> LoginCustom(LoginDTO model)
        {
           var res = await _service.LoginCustom(model);

            return res;
        }
        
        
        
       
        [HttpPost]
        [Authorize]
        public async Task<Result<ResponsLoginViewModel>> RefreshToken([FromBody] RefreshTokenModel model)
        {
           var res = await _service.RefreshToken(model);
            return res;
        }


        [HttpPost("SendCodeToResetPassword")]
        public async Task<Result<string>> SendCodeToResetPassword(string email,bool lan)
        {
            var res = await _service.ResetPassword(email,lan);
            return res;
        }


        [HttpPost("ResetPassword")]
        public async Task<Result<string>> ResetPassword(string userId, string code,string password)
        {
            var res = await _service.ResetPassword(userId, code, password);
            return res;
        }

        [HttpPost("ResendEmail")]
        public async Task<Result<string>> ResendEmail(string email, bool lang)
        {
            var res = await _service.ResendEmail(email, lang);
            return res;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRole(string name)
        {
            await _service.CreateRole(name);
            return Ok();
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleCallback))
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync();

            if (!result.Succeeded)
            {
                var failureMessage = result.Failure?.Message ?? "Unknown error";
                return BadRequest(new { Message = "Google authentication failed", Error = failureMessage });
            }

            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { Message = "Failed to retrieve email from Google." });
            }
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = name
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    return BadRequest(new { Message = "User creation failed", Errors = createResult.Errors });
                }
            }

            var res = await _service.GetToken(user);

            return Ok(res);
        }


        //[HttpGet]
        //public async Task<IActionResult> GetGoogleUserInfo()
        //{
        //    var info = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

        //    // استرجاع بيانات المستخدم
        //    var googleUser = await _httpContextAccessor.HttpContext
        //        .AuthenticateAsync("Google")
        //        .ContinueWith(task =>
        //        {
        //            var externalPrincipal = task.Result.Principal;
        //            var claims = externalPrincipal?.Claims;

        //            var userName = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        //            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        //            return new { userName, email };
        //        });

        //    return Ok(googleUser);
        //}



        //private string GetBrowserDetails()
        //{
        //    var browserDetails = string.Empty;
        //    HttpRequest request = _httpContextAccessor.HttpContext.Request;

        //    if (request.Headers.ContainsKey("User-Agent"))
        //    {
        //        var userAgent = request.Headers["User-Agent"].ToString();
        //        Console.WriteLine($"User-Agent: {userAgent}");

        //        var browserPatterns = new Dictionary<string, string>
        //    {
        //        { "Edge", @"Edge\/(\d+\.\d+)" },
        //        { "Edge (Chromium)", @"Edg\/(\d+\.\d+)" },
        //        { "Chrome", @"Chrome\/(\d+\.\d+)" },
        //        { "Firefox", @"Firefox\/(\d+\.\d+)" },
        //        { "Safari", @"Version\/(\d+\.\d+).*Safari" },
        //        { "Opera", @"OPR\/(\d+\.\d+)" },
        //        { "Internet Explorer", @"Trident\/\d+.*rv:(\d+\.\d+)" }
        //    };

        //        string browser = "Unknown";
        //        string version = "Unknown";

        //        foreach (var pattern in browserPatterns)
        //        {
        //            var match = Regex.Match(userAgent, pattern.Value);
        //            if (match.Success)
        //            {
        //                browser = pattern.Key;
        //                version = match.Groups[1].Value;
        //                break;
        //            }
        //        }

        //        browserDetails = $"Browser: {browser} Version: {version}{Environment.NewLine}";
        //    }
        //    else
        //    {
        //        Console.WriteLine("User-Agent header not found");
        //    }

        //    return browserDetails;
        //}

    }
    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
    }
}
