using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class ServiceRequestsTbl
    {
        public int Id { get; set; }
        [ForeignKey ("CustomersTbl")]
        public string Customer_ID { get; set; }
        public bool Service_Request_Statues { get; set; }
        public DateTime? Service_Request_Date { get; set; }
        public DateTime? Service_Response_Date { get; set; }
        [ForeignKey ("SubServicesTbl")]
        public int Sub_Service_ID { get; set; }
        public ServiceRequestStatus Request_Status { get; set; }
        public DateTime? Service_Active_Date { get; set; }
        public double? Price { get; set; }
        public string Requset_Code { get; set; }
        public DateTime? Finished_Date { get; set; }
        public double? Renewal_price { get; set; }
        public bool? Renewal_request { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ApplicationUser CustomersTbl { get; set; }
        public virtual SubServicesTbl SubServicesTbl { get; set; }
    }
}
