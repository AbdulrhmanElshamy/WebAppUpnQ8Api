using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ProductsTbl
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name_Ar { get; set; }
        public string Product_Name_Eng { get; set; }
        public string Product_Description_Ar { get; set; }
        public string Product_Description_Eng { get; set; }
        public Nullable<int> Number_Piecies { get; set; }
        public Nullable<double> Sale_Price { get; set; }
        public Nullable<double> Buy_Price { get; set; }
        public string Image { get; set; }
        [ForeignKey ("ProductSubTypesTbl")]
        public int Product_Sub_Type_ID { get; set; }
        public Nullable<double> Discount_Percent { get; set; }
        [ForeignKey ("CompanyBrandsTbl")]
        public int Company_Brand_ID { get; set; }

        public virtual CompanyBrandsTbl CompanyBrandsTbl { get; set; }
        public virtual ICollection<ProductSpecificationsTbl> ProductSpecificationsTbls { get; set; }
        public virtual ProductSubTypesTbl ProductSubTypesTbl { get; set; }
        public virtual ICollection<ProductSalesTbl> ProductSalesTbls { get; set; }
        public virtual ICollection<EvaluationsTbl> EvaluationsTbls { get; set; }
    }
}
