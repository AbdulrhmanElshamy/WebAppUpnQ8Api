using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class SpecialRequestFeaturesTbl
    {
        [Key]
        public int Special_Request_Feature_ID { get; set; }
        [ForeignKey ("SpecialRequestsTbl")]
        public int Special_Request_ID { get; set; }
        [ForeignKey ("SpecialFeaturesTbl")]
        public int Special_Feature_ID { get; set; }

        public virtual SpecialFeaturesTbl SpecialFeaturesTbl { get; set; }
        public virtual SpecialRequestsTbl SpecialRequestsTbl { get; set; }
    }
}
