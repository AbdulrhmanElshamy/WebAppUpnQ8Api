using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class DiscountsTbl
    {
        [Key]
        public int Discount_ID { get; set; }
        public Nullable<double> Discount_Percent { get; set; }
        public string Discount_Code { get; set; }
        public Nullable<bool> Discount_Statues { get; set; }
        public Nullable<System.DateTime> Discount_Start_Date { get; set; }
        public Nullable<System.DateTime> Discount_End_Date { get; set; }
        public virtual ICollection<PlanSubscripesTbl> PlanSubscripesTbls { get; set; }
        public virtual ICollection<SubscriptionsTbl> SubscriptionsTbls { get; set; }
    }
}
