using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class ProductTypesTbl
    {
        [Key]
        public int Product_Type_ID { get; set; }
        public string Product_Type_Name_Ar { get; set; }
        public string Product_Type_Name_Eng { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ProductSubTypesTbl> ProductSubTypesTbls { get; set; }
    }
}
