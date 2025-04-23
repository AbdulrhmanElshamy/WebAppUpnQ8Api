using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUpnQ8Api.ViewModels.CustomerViewModels
{
    public class CustomPlanModel
    {
        public int Plan_Subscripe_ID { get; set; }
        public string Customer_ID { get; set; }
        public Nullable<double> Subscription_Price { get; set; }
        public int Plan_ID { get; set; }
        public string? Plan_Title { get; set; }
        public Nullable<int> Discount_ID { get; set; }
        public Nullable<double> Discount_Percent { get; set; }
        public string? Discount_Code { get; set; }
        public Nullable<System.DateTime> Subscription_Start_Date { get; set; }
        public Nullable<System.DateTime> Subscription_End_Date { get; set; }
        public Nullable<int> DurationInMonth { get; set; }
        public string Subscripe_Code { get; set; }
    }
}
