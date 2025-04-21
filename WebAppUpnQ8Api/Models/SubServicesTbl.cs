using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class SubServicesTbl
    {
        [Key]
        public int Sub_Service_ID { get; set; }
        public string Sub_Service_Title { get; set; }
        public string Sub_Service_Title_Ar { get; set; }
        public Nullable<double> Sub_Service_Price { get; set; }
        public string Image { get; set; }
        [ForeignKey ("ServicesTbl")]
        public int Service_ID { get; set; }

        public virtual ICollection<ServiceRequestsTbl> ServiceRequestsTbls { get; set; }
        public virtual ServicesTbl ServicesTbl { get; set; }
        public virtual ICollection<SubFeaturesTbl> SubFeaturesTbls { get; set; }
    }
}
