using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUpnQ8Api.ViewModels.CustomerViewModels
{
    public class CustomServiceModel
    {
        public int Service_Request_ID { get; set; }
        public string Customer_ID { get; set; }
        public Nullable<bool> Service_Request_Statues { get; set; }
        public Nullable<System.DateTime> Service_Request_Date { get; set; }
        public Nullable<System.DateTime> Service_Response_Date { get; set; }
        public int Sub_Service_ID { get; set; }
        public string Sub_Service_Title { get; set; }
        public Nullable<int> Request_Status { get; set; }
        public Nullable<System.DateTime> Service_Active_Date { get; set; }
        public Nullable<double> Price { get; set; }
        public string? Requset_Code { get; set; }
        public Nullable<System.DateTime> Finished_Date { get; set; }
        public Nullable<double> Renewal_price { get; set; }
        public Nullable<bool> Renewal_request { get; set; }
    }
}
