using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class PaymentTypesTbl
    {
        [Key]
        public int Payment_Type_ID { get; set; }
        public string Payment_Type_Name { get; set; }

        public virtual ICollection<SubscriptionsTbl> SubscriptionsTbls { get; set; }
    }
}
