using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class SubscriptionsTbl
    {
        [Key]
        public int Subscription_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public string Customer_ID { get; set; }
        public Nullable<double> Subscription_Price { get; set; }
        public Nullable<int> Princing_Duration_ID { get; set; }
        [ForeignKey ("DiscountsTbl")]
        public int Discount_ID { get; set; }
        [ForeignKey ("PaymentTypesTbl")]
        public int Payment_Type_ID { get; set; }
        public Nullable<System.DateTime> Subscription_Start_Date { get; set; }
        public Nullable<System.DateTime> Subscription_End_Date { get; set; }

        public virtual ApplicationUser CustomersTbl { get; set; }
        public virtual DiscountsTbl DiscountsTbl { get; set; }
        public virtual PaymentTypesTbl PaymentTypesTbl { get; set; }
    }
}
