using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class SubFeaturesTbl
    {
        [Key]
        public int Sub_Feature_ID { get; set; }
        public string Sub_Feature_Text { get; set; }
        public string Sub_Feature_Text_Ar { get; set; }
        [ForeignKey ("SubServicesTbl")]
        public int Sub_Service_ID { get; set; }

        public virtual SubServicesTbl SubServicesTbl { get; set; }
    }
}
