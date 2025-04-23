using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class SpecialRequestsTbl
    {
        [Key]
        public int Special_Request_ID { get; set; }
        [ForeignKey ("ServicesTbl")]
        public int Service_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public string Customer_ID { get; set; }
        public string User_ID { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Requset_Code { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ApplicationUser CustomersTbl { get; set; }
        public virtual ServicesTbl ServicesTbl { get; set; }
        public virtual ICollection<SpecialRequestFeaturesTbl> SpecialRequestFeaturesTbls { get; set; }
    }
}
