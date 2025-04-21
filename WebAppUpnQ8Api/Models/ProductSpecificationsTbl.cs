using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ProductSpecificationsTbl
    {
        [Key]
        public int Product_Specificate_ID { get; set; }
        [ForeignKey ("ProductSubTypeSpecificationsTbl")]
        public int Product_Sub_Type_Specific_ID { get; set; }
        [ForeignKey ("ProductsTbl")]
        public int Product_ID { get; set; }
        public string Product_Specificate_Value_Ar { get; set; }
        public string Product_Specificate_Value_Eng { get; set; }

        public virtual ProductsTbl ProductsTbl { get; set; }
        public virtual ProductSubTypeSpecificationsTbl ProductSubTypeSpecificationsTbl { get; set; }
    }
}
