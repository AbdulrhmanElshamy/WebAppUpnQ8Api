using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class ServicesTbl
    {
        [Key]
        public int Service_ID { get; set; }
        public string Service_Title { get; set; }
        public string Service_Title_Ar { get; set; }
        public string Service_Description { get; set; }
        public string Service_Description_Ar { get; set; }
        public string Image { get; set; }
        public string Icon_Code { get; set; } = string.Empty;

        public virtual ICollection<RequestsQuoteTbl> RequestsQuoteTbls { get; set; }
        public virtual ICollection<SpecialFeaturesTbl> SpecialFeaturesTbls { get; set; }
        public virtual ICollection<SpecialRequestsTbl> SpecialRequestsTbls { get; set; }
        public virtual ICollection<SubServicesTbl> SubServicesTbls { get; set; }
    }
}
