using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class PlanContentsTbl
    {
        [Key]
        public int Plan_Content_ID { get; set; }
        [ForeignKey ("ContentsTbl")]
        public int Content_ID { get; set; }
        [ForeignKey ("PlansTbl")]
        public int Plan_ID { get; set; }
        public string Content_Value { get; set; }
        public string Content_Value_Ar { get; set; }

        public virtual ContentsTbl ContentsTbl { get; set; }
        public virtual PlansTbl PlansTbl { get; set; }
    }
}
