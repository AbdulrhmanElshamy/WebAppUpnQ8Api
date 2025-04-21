using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class PlansTbl
    {
        [Key]
        public int Plan_ID { get; set; }
        public string Plan_Title { get; set; }
        public string Plan_Title_Ar { get; set; }
        public string Plan_Description { get; set; }
        public string Plan_Description_Ar { get; set; }
        public Nullable<double> Price_6m { get; set; }
        public Nullable<double> Price_1y { get; set; }
        public Nullable<double> Price_2y { get; set; }
        public Nullable<double> Price_1m { get; set; }

        public virtual ICollection<PlanContentsTbl> PlanContentsTbls { get; set; }
        public virtual ICollection<PlanSubscripesTbl> PlanSubscripesTbls { get; set; }
    }
}
