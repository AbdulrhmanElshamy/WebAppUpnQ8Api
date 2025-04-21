using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class PlanSubscripeContentsTbl
    {
        [Key]
        public int Subscripe_Content_ID { get; set; }
        [ForeignKey ("PlanSubscripesTbl")]
        public int Plan_Subscripe_ID { get; set; }
        [ForeignKey ("ContentsTbl")]
        public int Content_ID { get; set; }
        public string Current_Value { get; set; }

        public virtual ContentsTbl ContentsTbl { get; set; }
        public virtual PlanSubscripesTbl PlanSubscripesTbl { get; set; }
    }
}
