using Microsoft.AspNetCore.Identity;
using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string IP_Address { get; set; }

        //public virtual ICollection<CustomersTbl> CustomersTbls { get; set; }
        public string? ActivationCode { get; set; }

    }
}
