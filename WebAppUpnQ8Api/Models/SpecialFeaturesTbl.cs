using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class SpecialFeaturesTbl
    {
        [Key]
        public int Special_Feature_ID { get; set; }
        public string Feature_Name { get; set; }
        public string Feature_Name_Ar { get; set; }
        public string Feature_Description { get; set; }
        public string Feature_Description_Ar { get; set; }
        public Nullable<double> Feature_Price { get; set; }
        [ForeignKey ("ServicesTbl")]
        public int Service_ID { get; set; }

        public virtual ServicesTbl ServicesTbl { get; set; }
        public virtual ICollection<SpecialRequestFeaturesTbl> SpecialRequestFeaturesTbls { get; set; }
    }
}
