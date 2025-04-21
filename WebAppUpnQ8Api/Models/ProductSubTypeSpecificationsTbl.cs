using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ProductSubTypeSpecificationsTbl
    {
        [Key]
        public int Product_Sub_Type_Specific_ID { get; set; }
        public string Sub_Type_Specific_Name_Ar { get; set; }
        public string Sub_Type_Specific_Name_Eng { get; set; }
        [ForeignKey ("ProductSubTypesTbl")]
        public int Product_Sub_Type_ID { get; set; }

        public virtual ICollection<ProductSpecificationsTbl> ProductSpecificationsTbls { get; set; }
        public virtual ProductSubTypesTbl ProductSubTypesTbl { get; set; }
    }
}
