using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string IP_Address { get; set; }

        //public virtual ICollection<CustomersTbl> CustomersTbls { get; set; }
        //public string? ActivationCode { get; set; }



        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public string? FirstAddress { get; set; }
        public string? SecondAddress { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey("CitiesTbl")]
        public int? CityId { get; set; }
        public string? Image { get; set; }
        public bool Gender { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("CodeNumbersTbl")]
        public int? CodeNumberId{ get; set; }
        public virtual CitiesTbl CitiesTbl { get; set; }
        public virtual CodeNumbersTbl CodeNumbersTbl { get; set; }
        public virtual ICollection<MaintinanceRequestsTbl> MaintinanceRequestsTbls { get; set; }
        public virtual ICollection<PlanSubscripesTbl> PlanSubscripesTbls { get; set; }
        public virtual ICollection<ServiceRequestsTbl> ServiceRequestsTbls { get; set; }
        public virtual ICollection<SpecialRequestsTbl> SpecialRequestsTbls { get; set; }
        public virtual ICollection<SubscriptionsTbl> SubscriptionsTbls { get; set; }
        public virtual ICollection<TestmonialsTbl> TestmonialsTbls { get; set; }

    }
}
