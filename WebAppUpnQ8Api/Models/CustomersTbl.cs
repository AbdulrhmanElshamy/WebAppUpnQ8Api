using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class CustomersTbl
    {
        [Key]
        public int Customer_ID { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public Nullable<System.DateTime> Birth_Day_Date { get; set; }
        public Nullable<long> Phone_Number_1 { get; set; }
        public Nullable<long> Phone_Number_2 { get; set; }
        public string? Address_1 { get; set; }
        public string? Address_2 { get; set; }
        public Nullable<int> Country_ID { get; set; }
        [ForeignKey ("CitiesTbl")]
        public int? City_ID { get; set; }
        public string User_ID { get; set; }
        public string? Image { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> Register_Date { get; set; }
       
        [ForeignKey ("CodeNumbersTbl")]
        public int? Code_Number_ID_1 { get; set; }
        //[ForeignKey("CodeNumbersTbl1")]
        //public int Code_Number_ID_2 { get; set; }
        
        
        //public virtual ApplicationUser AspNetUser { get; set; }
        public virtual CitiesTbl CitiesTbl { get; set; }
        public virtual CodeNumbersTbl CodeNumbersTbl { get; set; }
       // public virtual CodeNumbersTbl CodeNumbersTbl1 { get; set; }


        public virtual ICollection<MaintinanceRequestsTbl> MaintinanceRequestsTbls { get; set; }
        public virtual ICollection<PlanSubscripesTbl> PlanSubscripesTbls { get; set; }
        public virtual ICollection<ServiceRequestsTbl> ServiceRequestsTbls { get; set; }
        public virtual ICollection<SpecialRequestsTbl> SpecialRequestsTbls { get; set; }
        public virtual ICollection<SubscriptionsTbl> SubscriptionsTbls { get; set; }
        public virtual ICollection<TestmonialsTbl> TestmonialsTbls { get; set; }
    }
}
