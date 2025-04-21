using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class PlanSubscripesTbl
    {
        [Key]
        public int Plan_Subscripe_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public int Customer_ID { get; set; }
        public Nullable<double> Subscription_Price { get; set; }
        [ForeignKey ("PlansTbl")]
        public int Plan_ID { get; set; }
        [ForeignKey ("DiscountsTbl")]
        public int Discount_ID { get; set; }
        public Nullable<System.DateTime> Subscription_Start_Date { get; set; }
        public Nullable<System.DateTime> Subscription_End_Date { get; set; }
        public Nullable<int> DurationInMonth { get; set; }
        public string Id { get; set; }
        public string Subscripe_Code { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual CustomersTbl CustomersTbl { get; set; }
        public virtual DiscountsTbl DiscountsTbl { get; set; }
        public virtual PlansTbl PlansTbl { get; set; }
        public virtual ICollection<PlanSubscripeContentsTbl> PlanSubscripeContentsTbls { get; set; }
    }
}
