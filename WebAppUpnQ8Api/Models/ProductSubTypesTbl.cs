using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ProductSubTypesTbl
    {
        [Key]
        public int Product_Sub_Type_ID { get; set; }
        public string Sub_Type_Name_Ar { get; set; }
        public string Sub_Type_Name_Eng { get; set; }
        [ForeignKey ("ProductTypesTbl")]
        public int Product_Type_ID { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ProductsTbl> ProductsTbls { get; set; }
        public virtual ICollection<ProductSubTypeSpecificationsTbl> ProductSubTypeSpecificationsTbls { get; set; }
        public virtual ProductTypesTbl ProductTypesTbl { get; set; }
    }
}
