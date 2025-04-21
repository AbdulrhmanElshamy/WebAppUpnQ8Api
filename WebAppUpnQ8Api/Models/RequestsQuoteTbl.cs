using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class RequestsQuoteTbl
    {
        [Key]
        public int Request_Quote_ID { get; set; }
        public string Custom_Name { get; set; }
        public string Custom_Email { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public Nullable<bool> Request_Status { get; set; }
        public string Message { get; set; }
        [ForeignKey ("ServicesTbl")]
        public int Service_ID { get; set; }
        public string Id { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ServicesTbl ServicesTbl { get; set; }
    }
}
