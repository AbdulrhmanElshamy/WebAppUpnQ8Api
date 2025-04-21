using Microsoft.AspNetCore.Authentication;

namespace WebAppUpnQ8Api.ViewModels
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
