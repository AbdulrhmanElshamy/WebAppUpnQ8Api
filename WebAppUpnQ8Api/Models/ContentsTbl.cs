using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class ContentsTbl
    {
        [Key]
        public int Content_ID { get; set; }
        public string Content_Name { get; set; }
        public string Content_Name_Ar { get; set; }

        public virtual ICollection<PlanContentsTbl> PlanContentsTbls { get; set; }
        public virtual ICollection<PlanSubscripeContentsTbl> PlanSubscripeContentsTbls { get; set; }
    }
}
