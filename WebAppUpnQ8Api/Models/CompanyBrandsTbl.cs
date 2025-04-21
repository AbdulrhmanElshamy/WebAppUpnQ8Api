using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class CompanyBrandsTbl
    {
        [Key]
        public int Company_Brand_ID { get; set; }
        public string Company_Brand_Name_Ar { get; set; }
        public string Company_Brand_Name_Eng { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<ProductsTbl> ProductsTbls { get; set; }
    }
}
