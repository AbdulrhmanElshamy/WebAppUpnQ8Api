using Microsoft.AspNetCore.Mvc;
using WebAppUpnQ8Api.Controllers;
using WebAppUpnQ8Api.ViewModels;

namespace WebAppUpnQ8Api.Services.AccountServices
{
    public interface IAccountService
    {
        Task<Result<string>> RegisterCustom(RegisterViewModel model, bool lan);
        Task<Result<string>> ConfirmEmail(string code);

        Task<Result<ResponsLoginViewModel>> LoginCustom(RegisterViewModel model);
        Task<Result<ResponsLoginViewModel>> RefreshToken([FromBody] RefreshTokenModel model);
        Task<Result<string>> ResetPassword(string email, bool lan);
        Task<Result<string>> ResetPassword(string email,string code, string password);
        Task<Result<string>> ResendEmail(string email, bool lan);
        Task CreateRole(string name);
    }
}
