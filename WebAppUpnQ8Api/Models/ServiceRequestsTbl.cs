using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class ServiceRequestsTbl
    {
        [Key]
        public int Service_Request_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public string Customer_ID { get; set; }
        public Nullable<bool> Service_Request_Statues { get; set; }
        public Nullable<System.DateTime> Service_Request_Date { get; set; }
        public Nullable<System.DateTime> Service_Response_Date { get; set; }
        [ForeignKey ("SubServicesTbl")]
        public int Sub_Service_ID { get; set; }
        public string Id { get; set; }
        public Nullable<int> Request_Status { get; set; }
        public Nullable<System.DateTime> Service_Active_Date { get; set; }
        public Nullable<double> Price { get; set; }
        public string Requset_Code { get; set; }
        public Nullable<System.DateTime> Finished_Date { get; set; }
        public Nullable<double> Renewal_price { get; set; }
        public Nullable<bool> Renewal_request { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ApplicationUser CustomersTbl { get; set; }
        public virtual SubServicesTbl SubServicesTbl { get; set; }
    }
}
